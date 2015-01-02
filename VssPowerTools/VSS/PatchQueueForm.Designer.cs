namespace TrackGearLibrary.VSS
{
	partial class PatchQueueForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listViewPatches = new System.Windows.Forms.ListView();
			this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colVersionFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colVersionTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.buttonRemove = new System.Windows.Forms.Button();
			this.buttonCreatePatch = new System.Windows.Forms.Button();
			this.savePatchDialog = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// listViewPatches
			// 
			this.listViewPatches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewPatches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPath,
            this.colVersionFrom,
            this.colVersionTo});
			this.listViewPatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listViewPatches.FullRowSelect = true;
			this.listViewPatches.GridLines = true;
			this.listViewPatches.Location = new System.Drawing.Point(3, 3);
			this.listViewPatches.Name = "listViewPatches";
			this.listViewPatches.Size = new System.Drawing.Size(380, 220);
			this.listViewPatches.TabIndex = 0;
			this.listViewPatches.UseCompatibleStateImageBehavior = false;
			this.listViewPatches.View = System.Windows.Forms.View.Details;
			// 
			// colPath
			// 
			this.colPath.Text = "Path";
			this.colPath.Width = 237;
			// 
			// colVersionFrom
			// 
			this.colVersionFrom.Text = "From";
			// 
			// colVersionTo
			// 
			this.colVersionTo.Text = "To";
			// 
			// buttonRemove
			// 
			this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonRemove.Location = new System.Drawing.Point(3, 229);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(75, 23);
			this.buttonRemove.TabIndex = 1;
			this.buttonRemove.Text = "Remove";
			this.buttonRemove.UseVisualStyleBackColor = true;
			this.buttonRemove.Click += new System.EventHandler(this.ButtonRemoveClick);
			// 
			// buttonCreatePatch
			// 
			this.buttonCreatePatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCreatePatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonCreatePatch.Location = new System.Drawing.Point(308, 229);
			this.buttonCreatePatch.Name = "buttonCreatePatch";
			this.buttonCreatePatch.Size = new System.Drawing.Size(75, 23);
			this.buttonCreatePatch.TabIndex = 1;
			this.buttonCreatePatch.Text = "Create";
			this.buttonCreatePatch.UseVisualStyleBackColor = true;
			this.buttonCreatePatch.Click += new System.EventHandler(this.ButtonCreatePatchClick);
			// 
			// savePatchDialog
			// 
			this.savePatchDialog.DefaultExt = "patch";
			// 
			// PatchQueueForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(386, 254);
			this.Controls.Add(this.buttonCreatePatch);
			this.Controls.Add(this.buttonRemove);
			this.Controls.Add(this.listViewPatches);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "PatchQueueForm";
			this.Opacity = 0.8D;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Patch Queue";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listViewPatches;
		private System.Windows.Forms.ColumnHeader colPath;
		private System.Windows.Forms.ColumnHeader colVersionFrom;
		private System.Windows.Forms.ColumnHeader colVersionTo;
		private System.Windows.Forms.Button buttonRemove;
		private System.Windows.Forms.Button buttonCreatePatch;
		private System.Windows.Forms.SaveFileDialog savePatchDialog;
	}
}