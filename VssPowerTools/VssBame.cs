using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using VssPowerTools.Properties;

namespace VssPowerTools
{
	public partial class VssBame : Form
	{
		readonly string _tproc = @"C:\Program Files\TortoiseSVN\bin\TortoiseProc.exe";

		string _svnVersionedFile;

		public VssBame(string ssIniPath, string fileSpec)
		{
			InitializeComponent();

			textBoxSSDir.Text = ssIniPath ?? Settings.Default.SourceSafe;

			if(!string.IsNullOrEmpty(fileSpec))
			{
				textBoxFileSpec.Text = fileSpec;
			}

			using(var svnKey = Registry.ClassesRoot.OpenSubKey(@"svn\shell\open\command", false))
			{
				var v = svnKey.GetValue(null) as string;
				if(v != null)
				{
					var c = v.IndexOf("/command:");
					if(c != -1)
						v = v.Substring(0, c - 1).Trim(' ', '"');
					
					_tproc = v;
				}
			}
		}

		private void ButtonBuildClick(object sender, EventArgs e)
		{
			try{
				buttonBlame.Enabled = false;
				buttonLog.Enabled = false;
				buttonBuild.Enabled = false;
				textBoxSSDir.Enabled = false;
				textBoxFileSpec.Enabled = false;
				comboBox_MimeType.Enabled = false;

				var task = new BlameMaker().Blame(textBoxFileSpec.Text, comboBox_MimeType.Text, textBoxSSDir.Text, "autobuild", "build", pos => 
					progressBar.Invoke((Action)delegate {
						progressBar.Value = (int)(pos * progressBar.Maximum);
						progressBar.Text = progressBar.Value.ToString("0:0.00");
					})
				);

				task.ContinueWith(t => {

					if(t.IsFaulted)
					{
						MessageBox.Show(this, t.Exception.ToString(), "Error");
					}

					if(t.Status == TaskStatus.RanToCompletion)
					{
						_svnVersionedFile = t.Result;
						buttonBlame.Enabled = true;
						buttonLog.Enabled = true;
					}
					buttonBuild.Enabled = true;
					textBoxSSDir.Enabled = true;
					textBoxFileSpec.Enabled = true;
					comboBox_MimeType.Enabled = true;

				}, TaskScheduler.FromCurrentSynchronizationContext());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				buttonBuild.Enabled = true;
				textBoxSSDir.Enabled = true;
				textBoxFileSpec.Enabled = true;
				comboBox_MimeType.Enabled = true;
			}
		}

		void ButtonBlameClick(object sender, EventArgs e)
		{
			try{
				var p = new Process();
				p.StartInfo = new ProcessStartInfo {
					FileName = "tsvncmd:command:blame?path:" + _svnVersionedFile,
					UseShellExecute = true
				};

				p.Start();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), ex.Message);
			}
		}
		
		void ButtonLogClick(object sender, EventArgs e)
		{
			try{
				var p = new Process();
				p.StartInfo = new ProcessStartInfo {
					Arguments = "/command:log /path:\"" + _svnVersionedFile + "\"",
					FileName = _tproc
				};
				p.Start();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), ex.Message);
			}
		}

		void TextBoxFileSpecTextChanged(object sender, EventArgs e)
		{
			SettingsChanged();
		}

		private void SettingsChanged()
		{
			buttonBlame.Enabled = false;
			buttonLog.Enabled = false;
			buttonBuild.Enabled = true;
			progressBar.Value = 0;
		}

		private void VssBameDragDrop(object sender, DragEventArgs e)
		{
			var files = e.Data.GetData(DataFormats.FileDrop) as string[];

			if(files == null || files.Length == 0)
				return;

			textBoxFileSpec.Text = files[0].Replace('\\', '/');

			try{
				var db = new Microsoft.VisualStudio.SourceSafe.Interop.VSSDatabase();
				db.Open(textBoxSSDir.Text);

				var item = db.VSSItem["$/"];

				var root = item.LocalSpec.ToLowerInvariant().Replace('\\', '/');

				if(textBoxFileSpec.Text.ToLowerInvariant().StartsWith(root))
					textBoxFileSpec.Text = textBoxFileSpec.Text.Substring(root.Length);

				if(textBoxFileSpec.Text.StartsWith("/"))
					textBoxFileSpec.Text = textBoxFileSpec.Text.Substring(1);
				
				textBoxFileSpec.Text = "$/" + textBoxFileSpec.Text;
			}
			catch(Exception)
			{
			}

			TextBoxFileSpecTextChanged(null, null);
		}

		private void VssBameDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		public void Build(string fileSpec)
		{
			textBoxFileSpec.Text = fileSpec;

			ButtonBuildClick(null, null);
		}

		void textBoxSSDir_TextChanged(object sender, EventArgs e)
		{
			Settings.Default.SourceSafe = textBoxSSDir.Text;
			Settings.Default.Save();

			SettingsChanged();
		}

		void comboBox_MimeType_TextChanged(object sender, EventArgs e)
		{
			SettingsChanged();
		}
	}
}
