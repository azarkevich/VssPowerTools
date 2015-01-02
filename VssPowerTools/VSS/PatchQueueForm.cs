using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TrackGearLibrary.VSS
{
	public partial class PatchQueueForm : Form
	{
		readonly string _vssDB;

		public PatchQueueForm(string vssDB)
		{
			_vssDB = vssDB;

			InitializeComponent();
		}

		public void AddPatch(string fileSpec, int version1, int version2)
		{
			// try find for update:
			foreach(ListViewItem lvi in listViewPatches.Items)
			{
				var item = (PatchQueueItem)lvi.Tag;
				if(item.FileSpec == fileSpec)
				{
					item.Version1 = Math.Min(item.Version1, version1);
					if(version2 == -1)
					{
						item.Version2 = -1;
					}
					else if(item.Version2 != -1)
					{
						item.Version2 = Math.Max(item.Version2, version2);
					}

					lvi.SubItems[1].Text = item.Version1.ToString(CultureInfo.InvariantCulture);
					if(item.Version2 == -1)
						lvi.SubItems[2].Text = "latest";
					else
						lvi.SubItems[2].Text = item.Version2.ToString(CultureInfo.InvariantCulture);

					listViewPatches.Refresh();

					return;
				}
			}

			// create new item
			var pitem = new PatchQueueItem {
				FileSpec = fileSpec,
				Version1 = version1,
				Version2 = version2
			};

			var plvi = new ListViewItem(pitem.FileSpec);
			plvi.Tag = pitem;

			plvi.SubItems.Add(pitem.Version1.ToString(CultureInfo.InvariantCulture));
			plvi.SubItems.Add(pitem.Version2 == -1 ? "latest" : pitem.Version2.ToString(CultureInfo.InvariantCulture));

			listViewPatches.Items.Add(plvi);
		}

		private void ButtonRemoveClick(object sender, EventArgs e)
		{
			listViewPatches
				.SelectedItems
				.Cast<ListViewItem>()
				.ToList()
				.ForEach(listViewPatches.Items.Remove)
			;
		}

		void ButtonCreatePatchClick(object sender, EventArgs e)
		{
			try
			{
				if (savePatchDialog.ShowDialog() != DialogResult.OK)
					return;

				var sb = new StringBuilder();

				sb.AppendFormat("create-patch-ex");

				foreach (ListViewItem item in listViewPatches.Items)
				{
					var qitem = (PatchQueueItem)item.Tag;

					sb.AppendFormat(" --file=\"{0}:{1}:{2}:{3}\"", _vssDB, qitem.FileSpec, qitem.Version1, qitem.Version2);
				}

				sb.AppendFormat(" --output=\"{0}\"", savePatchDialog.FileName);

				var powerTools = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "VssPowerTools\\VssPowerTools.exe");
				if (!File.Exists(powerTools))
					throw new ApplicationException("NotFound:\n" + "VssPowerTools\\VssPowerTools.exe\nIn:\n" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

				Process
					.Start(powerTools, sb.ToString())
					.WaitForExit()
				;

				Process.Start(savePatchDialog.FileName);
			}
			catch(ApplicationException ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
