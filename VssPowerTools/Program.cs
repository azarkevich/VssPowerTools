using System;
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
		static Int32 Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if(Settings.Default.FirstRun)
			{
				Settings.Default.Upgrade();
				Settings.Default.FirstRun = false;
				Settings.Default.Save();
			}

			Application.Run(new LastSSCommits());

			return 0;
		}
	}
}
