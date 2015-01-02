using System;
using System.Linq;
using System.Windows.Forms;
using TrackGearLibrary.VSS;
using VssPowerTools.Properties;

namespace VssPowerTools
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static Int32 Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if(args.Length > 0)
			{
				return ExecuteCommand(args);
			}

			Application.Run(new ToolsSelector());

			return 0;
		}

		static Int32 ExecuteCommand(string[] args)
		{
			try{
				var cmdline = args
					.Skip(1)
					.Select(l => {
						var sep = l.IndexOf('=');
						if(sep == -1)
							return new { Key = (string)null, Value = l };

						return new { Key = l.Substring(0, sep).Trim().ToLowerInvariant(), Value = l.Substring(sep + 1).Trim() };
					})
					.ToLookup(p => p.Key, p => p.Value)
				;

				// remove switches from arguments
				args = args.Where(a => !a.StartsWith("--")).ToArray();

				var cmd = args[0].ToLowerInvariant();
				switch(cmd)
				{
					case "create-patch":
						new CreatePatch().Create(args[1], args[2], Int32.Parse(args[3]), Int32.Parse(args[4]), args[5], false);
						break;
					case "create-patch-ex":
						new CreatePatch().CreateMulti(cmdline["--output"].Last(), cmdline["--file"]);
						break;
					case "blame":
						var dlg = new VssBame(cmdline["--ss-dir"].DefaultIfEmpty(Settings.Default.SourceSafe).Last(), args.Length > 1 ? args[1] : null);
						Application.Run(dlg);
						break;
					case "commits-browser":
						Application.Run(new LastSSCommits());
						break;
				}

				return 0;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return -1;
			}
		}
	}
}
