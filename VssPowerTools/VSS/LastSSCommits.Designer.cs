namespace TrackGearLibrary.VSS
{
	partial class LastSSCommits
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
			this.components = new System.ComponentModel.Container();
			this.listViewCommits = new System.Windows.Forms.ListView();
			this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colComment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generateFDPToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.composeReviewEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.blameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unifiedDiffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.savePatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createPatchesupToHeadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.queuePatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.queuePatchToLatestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.cSVToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comboBoxTimeFilter = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxAuthorFilter = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxActionFilter = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxFilePath = new System.Windows.Forms.TextBox();
			this.buttonApply = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.textBoxSS = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxComment = new System.Windows.Forms.TextBox();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// listViewCommits
			// 
			this.listViewCommits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewCommits.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colAuthor,
            this.colAction,
            this.colFile,
            this.colComment});
			this.listViewCommits.ContextMenuStrip = this.contextMenuStrip;
			this.listViewCommits.FullRowSelect = true;
			this.listViewCommits.GridLines = true;
			this.listViewCommits.Location = new System.Drawing.Point(12, 65);
			this.listViewCommits.Name = "listViewCommits";
			this.listViewCommits.Size = new System.Drawing.Size(1098, 449);
			this.listViewCommits.TabIndex = 11;
			this.listViewCommits.UseCompatibleStateImageBehavior = false;
			this.listViewCommits.View = System.Windows.Forms.View.Details;
			this.listViewCommits.DoubleClick += new System.EventHandler(this.ShowUnifiedDiffToolStripMenuItemClick);
			// 
			// colDate
			// 
			this.colDate.Text = "Time";
			this.colDate.Width = 115;
			// 
			// colAuthor
			// 
			this.colAuthor.Text = "Author";
			this.colAuthor.Width = 100;
			// 
			// colAction
			// 
			this.colAction.Text = "Action";
			// 
			// colFile
			// 
			this.colFile.Text = "File";
			this.colFile.Width = 474;
			// 
			// colComment
			// 
			this.colComment.Text = "Comment";
			this.colComment.Width = 168;
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyPathsToolStripMenuItem,
            this.generateFDPToFileToolStripMenuItem,
            this.composeReviewEmailToolStripMenuItem,
            this.toolStripSeparator1,
            this.blameToolStripMenuItem,
            this.unifiedDiffToolStripMenuItem,
            this.savePatchToolStripMenuItem,
            this.createPatchesupToHeadToolStripMenuItem,
            this.toolStripSeparator2,
            this.queuePatchToolStripMenuItem,
            this.queuePatchToLatestToolStripMenuItem,
            this.toolStripSeparator3,
            this.cSVToClipboardToolStripMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(219, 242);
			// 
			// copyPathsToolStripMenuItem
			// 
			this.copyPathsToolStripMenuItem.Name = "copyPathsToolStripMenuItem";
			this.copyPathsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyPathsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.copyPathsToolStripMenuItem.Text = "Copy paths";
			this.copyPathsToolStripMenuItem.Click += new System.EventHandler(this.copyPathsToolStripMenuItem_Click);
			// 
			// generateFDPToFileToolStripMenuItem
			// 
			this.generateFDPToFileToolStripMenuItem.Name = "generateFDPToFileToolStripMenuItem";
			this.generateFDPToFileToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.generateFDPToFileToolStripMenuItem.Text = "Generate FDP to file";
			this.generateFDPToFileToolStripMenuItem.Click += new System.EventHandler(this.generateFDPToFileToolStripMenuItem_Click);
			// 
			// composeReviewEmailToolStripMenuItem
			// 
			this.composeReviewEmailToolStripMenuItem.Name = "composeReviewEmailToolStripMenuItem";
			this.composeReviewEmailToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.composeReviewEmailToolStripMenuItem.Text = "Compose review e-mail";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
			// 
			// blameToolStripMenuItem
			// 
			this.blameToolStripMenuItem.Name = "blameToolStripMenuItem";
			this.blameToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.blameToolStripMenuItem.Text = "Blame/Log ...";
			this.blameToolStripMenuItem.Click += new System.EventHandler(this.blameToolStripMenuItem_Click);
			// 
			// unifiedDiffToolStripMenuItem
			// 
			this.unifiedDiffToolStripMenuItem.Name = "unifiedDiffToolStripMenuItem";
			this.unifiedDiffToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.unifiedDiffToolStripMenuItem.Text = "Show Unified Diff";
			this.unifiedDiffToolStripMenuItem.Click += new System.EventHandler(this.ShowUnifiedDiffToolStripMenuItemClick);
			// 
			// savePatchToolStripMenuItem
			// 
			this.savePatchToolStripMenuItem.Name = "savePatchToolStripMenuItem";
			this.savePatchToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.savePatchToolStripMenuItem.Text = "Create Patches...";
			this.savePatchToolStripMenuItem.Click += new System.EventHandler(this.CreatePatchToolStripMenuItem_Click);
			// 
			// createPatchesupToHeadToolStripMenuItem
			// 
			this.createPatchesupToHeadToolStripMenuItem.Name = "createPatchesupToHeadToolStripMenuItem";
			this.createPatchesupToHeadToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.createPatchesupToHeadToolStripMenuItem.Text = "Create Patch (up to head)...";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
			// 
			// queuePatchToolStripMenuItem
			// 
			this.queuePatchToolStripMenuItem.Name = "queuePatchToolStripMenuItem";
			this.queuePatchToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.queuePatchToolStripMenuItem.Text = "Queue Patch(es)";
			this.queuePatchToolStripMenuItem.Click += new System.EventHandler(this.QueuePatchToolStripMenuItemClick);
			// 
			// queuePatchToLatestToolStripMenuItem
			// 
			this.queuePatchToLatestToolStripMenuItem.Name = "queuePatchToLatestToolStripMenuItem";
			this.queuePatchToLatestToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.queuePatchToLatestToolStripMenuItem.Text = "Queue Patch(es) to latest";
			this.queuePatchToLatestToolStripMenuItem.Click += new System.EventHandler(this.QueuePatchToLatestToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(215, 6);
			// 
			// cSVToClipboardToolStripMenuItem
			// 
			this.cSVToClipboardToolStripMenuItem.Name = "cSVToClipboardToolStripMenuItem";
			this.cSVToClipboardToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.cSVToClipboardToolStripMenuItem.Text = "CSV to clipboard";
			this.cSVToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CSV2ClipboardToolStripMenuItemClick);
			// 
			// comboBoxTimeFilter
			// 
			this.comboBoxTimeFilter.FormattingEnabled = true;
			this.comboBoxTimeFilter.Location = new System.Drawing.Point(12, 38);
			this.comboBoxTimeFilter.Name = "comboBoxTimeFilter";
			this.comboBoxTimeFilter.Size = new System.Drawing.Size(156, 21);
			this.comboBoxTimeFilter.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(174, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Author:";
			// 
			// textBoxAuthorFilter
			// 
			this.textBoxAuthorFilter.Location = new System.Drawing.Point(221, 38);
			this.textBoxAuthorFilter.Name = "textBoxAuthorFilter";
			this.textBoxAuthorFilter.Size = new System.Drawing.Size(100, 20);
			this.textBoxAuthorFilter.TabIndex = 5;
			this.textBoxAuthorFilter.Text = "!autobuild";
			this.toolTip.SetToolTip(this.textBoxAuthorFilter, "Case insensitive.\r\nUse next switches in start of pattern:\r\n ! inverse filter.\r\n ~" +
        " regex\r\n ^ (for strings) start with");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(327, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Action:";
			// 
			// textBoxActionFilter
			// 
			this.textBoxActionFilter.Location = new System.Drawing.Point(373, 38);
			this.textBoxActionFilter.Name = "textBoxActionFilter";
			this.textBoxActionFilter.Size = new System.Drawing.Size(84, 20);
			this.textBoxActionFilter.TabIndex = 7;
			this.toolTip.SetToolTip(this.textBoxActionFilter, "Case insensitive.\r\nUse next switches in start of pattern:\r\n ! inverse filter.\r\n ~" +
        " regex\r\n ^ (for strings) start with");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(625, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "File path(rx):";
			// 
			// textBoxFilePath
			// 
			this.textBoxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFilePath.Location = new System.Drawing.Point(695, 38);
			this.textBoxFilePath.Name = "textBoxFilePath";
			this.textBoxFilePath.Size = new System.Drawing.Size(360, 20);
			this.textBoxFilePath.TabIndex = 9;
			this.toolTip.SetToolTip(this.textBoxFilePath, "Case insensitive.\r\nUse next switches in start of pattern:\r\n ! inverse filter.\r\n ~" +
        " regex\r\n ^ (for strings) start with\r\n | or with previous test");
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Location = new System.Drawing.Point(1061, 36);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(49, 23);
			this.buttonApply.TabIndex = 10;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(108, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "SourceSafe DB path:";
			// 
			// buttonLoad
			// 
			this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLoad.Location = new System.Drawing.Point(1061, 10);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(49, 23);
			this.buttonLoad.TabIndex = 2;
			this.buttonLoad.Text = "Load";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// textBoxSS
			// 
			this.textBoxSS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSS.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::VssPowerTools.Properties.Settings.Default, "SourceSafe", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxSS.Location = new System.Drawing.Point(126, 12);
			this.textBoxSS.Name = "textBoxSS";
			this.textBoxSS.Size = new System.Drawing.Size(929, 20);
			this.textBoxSS.TabIndex = 1;
			this.textBoxSS.Text = global::VssPowerTools.Properties.Settings.Default.SourceSafe;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(463, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Comment:";
			// 
			// textBoxComment
			// 
			this.textBoxComment.Location = new System.Drawing.Point(523, 38);
			this.textBoxComment.Name = "textBoxComment";
			this.textBoxComment.Size = new System.Drawing.Size(96, 20);
			this.textBoxComment.TabIndex = 7;
			// 
			// LastSSCommits
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1122, 526);
			this.Controls.Add(this.textBoxSS);
			this.Controls.Add(this.buttonLoad);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.textBoxFilePath);
			this.Controls.Add(this.textBoxComment);
			this.Controls.Add(this.textBoxActionFilter);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxAuthorFilter);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxTimeFilter);
			this.Controls.Add(this.listViewCommits);
			this.KeyPreview = true;
			this.Name = "LastSSCommits";
			this.Text = "Last SourceSafe Commits";
			this.Load += new System.EventHandler(this.LastSSCommits_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listViewCommits;
		private System.Windows.Forms.ColumnHeader colDate;
		private System.Windows.Forms.ColumnHeader colAuthor;
		private System.Windows.Forms.ColumnHeader colComment;
		private System.Windows.Forms.ColumnHeader colFile;
		private System.Windows.Forms.ComboBox comboBoxTimeFilter;
		private System.Windows.Forms.ColumnHeader colAction;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxAuthorFilter;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxActionFilter;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxFilePath;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem copyPathsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem generateFDPToFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem composeReviewEmailToolStripMenuItem;
		private System.Windows.Forms.TextBox textBoxSS;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonLoad;
		private System.Windows.Forms.ToolStripMenuItem blameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem unifiedDiffToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem savePatchToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem createPatchesupToHeadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem queuePatchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem queuePatchToLatestToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem cSVToClipboardToolStripMenuItem;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxComment;
	}
}