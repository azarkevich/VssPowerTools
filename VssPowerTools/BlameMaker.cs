using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpSvn;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.SourceSafe.Interop;

namespace VssPowerTools
{
	class BlameMaker
	{
		public Task<string> Blame(string fileSpec, string mimeType, string ssIni, string ssUser, string ssPasswd, Action<double> progress)
		{
			return Task.Factory.StartNew(() => BlameCore(fileSpec, mimeType, ssIni, ssUser, ssPasswd, progress));
		}

		string BlameCore(string fileSpec, string mimeType, string ssIni, string ssUser, string ssPasswd, Action<double> progress)
		{
			var db = new VSSDatabase();
			db.Open(ssIni, ssUser, ssPasswd);

			var vssItem = db.VSSItem[fileSpec];

			var trueExe = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "true.exe");
			var repo = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "blame-repo");
			var repoUrl = "file:///" + repo;
			var wc = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "blame-repo.wc");

			var fpath = Path.Combine(wc, Path.GetFileName(vssItem.Spec.TrimStart('$', '/', '\\')));

			// create temp repository
			using(var svn = new SvnRepositoryClient())
			{
				if(Directory.Exists(repo))
					svn.DeleteRepository(repo);

				svn.CreateRepository(repo);
			}

			// create hooks
			File.Copy(trueExe, Path.Combine(repo, "hooks/post-revprop-change.exe"));
			File.Copy(trueExe, Path.Combine(repo, "hooks/pre-revprop-change.exe"));

			if(Directory.Exists(wc))
			{
				Directory.GetFiles(wc).ToList().ForEach(f => File.SetAttributes(f, FileAttributes.Normal));
				Directory.Delete(wc, true);
			}

			using (var svn = new SvnClient())
			{
				svn.CheckOut(new SvnUriTarget(repoUrl), wc);

				var firstTime = true;
				var versions = new List<int>();

				foreach (IVSSVersion ver in vssItem.Versions)
				{
					if(ver.Action.StartsWith("Labeled"))
						continue;

					versions.Add(ver.VersionNumber);
				}

				versions.Reverse();

				var ind = 0;

				foreach(var verNum in versions)
				{
					if(File.Exists(fpath))
					{
						File.SetAttributes(fpath, FileAttributes.Normal);
						File.Delete(fpath);
					}

					var ver = vssItem.Version[verNum].VSSVersion;

					ver.VSSItem.Get(fpath);

					File.SetAttributes(fpath, FileAttributes.Normal);

					if(firstTime)
					{
						svn.Add(fpath);

						mimeType = (mimeType ?? "").Trim();
						if(!string.IsNullOrEmpty(mimeType))
							svn.SetProperty(fpath, "svn:mime-type", mimeType);
					}

					firstTime = false;

					var commitArgs = new SvnCommitArgs { LogMessage = "author: " + ver.Username + "\n" + ver.Comment };

					SvnCommitResult cr;
					if(svn.Commit(wc, commitArgs, out cr))
					{
						try
						{
							svn.SetRevisionProperty(new Uri(repoUrl), new SvnRevision(cr.Revision), "svn:author", ver.Username);
							svn.SetRevisionProperty(new Uri(repoUrl), new SvnRevision(cr.Revision), "svn:log", ver.Comment);
							svn.SetRevisionProperty(new Uri(repoUrl), new SvnRevision(cr.Revision), "svn:date", ver.Date.ToUniversalTime().ToString("o"));
						}
						catch (Exception)
						{
						}
					}

					progress((double)(++ind) / versions.Count);
				}

				return fpath;
			}
		}
	}
}
