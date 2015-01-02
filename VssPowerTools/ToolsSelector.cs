using System;
using System.Windows.Forms;
using TrackGearLibrary.VSS;

namespace VssPowerTools
{
	public partial class ToolsSelector : Form
	{
		public ToolsSelector()
		{
			InitializeComponent();
		}

		void buttonBrowser_Click(object sender, EventArgs e)
		{
			new LastSSCommits().ShowDialog(this);
		}

		private void buttonBlame_Click(object sender, EventArgs e)
		{
			new VssBame(null, null).ShowDialog(this);
		}
	}
}
