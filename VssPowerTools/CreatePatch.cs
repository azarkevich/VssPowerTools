using System;
using System.Collections.Generic;
using SharpSvn.Diff;
using System.IO;
using Microsoft.VisualStudio.SourceSafe.Interop;

namespace VssPowerTools
{
	public class CreatePatch
	{
		public void Create(string vssDB, string vssPath, int version1, int version2, string writeTo, bool append)
		{
			vssDB = vssDB.TrimEnd('\\', '/') + @"\";

			var path = vssPath.TrimStart('$', '/', '\\');
			var fileName = Path.GetFileName(path);

			var db = new VSSDatabase();
			db.Open(vssDB, "autobuild", "build");

			var item = db.VSSItem[vssPath];

			var fileNameA = fileName + ".v" + version1;
			var fileNameB = fileName + ".v" + version2;

			if(File.Exists(fileNameA))
			{
				File.SetAttributes(fileNameA, FileAttributes.Normal);
				File.Delete(fileNameA);
			}

			if(File.Exists(fileNameB))
			{
				File.SetAttributes(fileNameB, FileAttributes.Normal);
				File.Delete(fileNameB);
			}

			item.Version[version1].VSSVersion.VSSItem.Get(fileNameA);
			if(version2 != -1)
				item.Version[version2].VSSVersion.VSSItem.Get(fileNameB);
			else
				item.Get(fileNameB);

			SvnFileDiff diff;

			if(SvnFileDiff.TryCreate(fileNameA, fileNameB, new SvnFileDiffArgs(), out diff))
			{
				using(diff)
				{
					var args = new SvnDiffWriteDifferencesArgs {
						OriginalHeader = path,
						ModifiedHeader = path,
						//ThrowOnCancel = true,
						ThrowOnError = true,
						ThrowOnWarning = true
					};

					if(!append)
						File.WriteAllText(writeTo, "");

					File.AppendAllText(writeTo, "Index: " + path + "\n===================================================================\n");

					var s = File.Open(writeTo, FileMode.Append);
					diff.WriteDifferences(s, args);
					s.Flush();
					s.Close();

					if(File.Exists(fileNameA))
					{
						File.SetAttributes(fileNameA, FileAttributes.Normal);
						File.Delete(fileNameA);
					}

					if(File.Exists(fileNameB))
					{
						File.SetAttributes(fileNameB, FileAttributes.Normal);
						File.Delete(fileNameB);
					}
				}
			}
		}

		public void CreateMulti(string target, IEnumerable<string> sourceFiles)
		{
			var firstPatch = true;
			foreach (var sourceFile in sourceFiles)
			{
				var ar = sourceFile.Split(':');
				Create(ar[0], ar[1], Int32.Parse(ar[2]), Int32.Parse(ar[3]), target, !firstPatch);
				firstPatch = false;
			}
		}
	}
}
