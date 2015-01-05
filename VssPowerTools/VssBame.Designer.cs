namespace VssPowerTools
{
	partial class VssBame
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VssBame));
			this.textBoxFileSpec = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonBuild = new System.Windows.Forms.Button();
			this.buttonBlame = new System.Windows.Forms.Button();
			this.buttonLog = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.textBoxSSDir = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.checkBoxConvertUCS2 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// textBoxFileSpec
			// 
			this.textBoxFileSpec.Location = new System.Drawing.Point(76, 38);
			this.textBoxFileSpec.Name = "textBoxFileSpec";
			this.textBoxFileSpec.Size = new System.Drawing.Size(459, 20);
			this.textBoxFileSpec.TabIndex = 3;
			this.toolTip.SetToolTip(this.textBoxFileSpec, "File path in VSS format.\r\nFor example:\r\n$/project1/file1.txt");
			this.textBoxFileSpec.TextChanged += new System.EventHandler(this.TextBoxFileSpecTextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "File Spec:";
			// 
			// buttonBuild
			// 
			this.buttonBuild.Location = new System.Drawing.Point(76, 98);
			this.buttonBuild.Name = "buttonBuild";
			this.buttonBuild.Size = new System.Drawing.Size(71, 23);
			this.buttonBuild.TabIndex = 5;
			this.buttonBuild.Text = "Build";
			this.buttonBuild.UseVisualStyleBackColor = true;
			this.buttonBuild.Click += new System.EventHandler(this.ButtonBuildClick);
			// 
			// buttonBlame
			// 
			this.buttonBlame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBlame.Enabled = false;
			this.buttonBlame.Location = new System.Drawing.Point(379, 98);
			this.buttonBlame.Name = "buttonBlame";
			this.buttonBlame.Size = new System.Drawing.Size(75, 23);
			this.buttonBlame.TabIndex = 7;
			this.buttonBlame.Text = "Blame";
			this.buttonBlame.UseVisualStyleBackColor = true;
			this.buttonBlame.Click += new System.EventHandler(this.ButtonBlameClick);
			// 
			// buttonLog
			// 
			this.buttonLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLog.Enabled = false;
			this.buttonLog.Location = new System.Drawing.Point(460, 98);
			this.buttonLog.Name = "buttonLog";
			this.buttonLog.Size = new System.Drawing.Size(75, 23);
			this.buttonLog.TabIndex = 8;
			this.buttonLog.Text = "Log";
			this.buttonLog.UseVisualStyleBackColor = true;
			this.buttonLog.Click += new System.EventHandler(this.ButtonLogClick);
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(153, 98);
			this.progressBar.Maximum = 1000;
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(220, 23);
			this.progressBar.TabIndex = 6;
			// 
			// textBoxSSDir
			// 
			this.textBoxSSDir.Location = new System.Drawing.Point(76, 12);
			this.textBoxSSDir.Name = "textBoxSSDir";
			this.textBoxSSDir.Size = new System.Drawing.Size(459, 20);
			this.textBoxSSDir.TabIndex = 1;
			this.toolTip.SetToolTip(this.textBoxSSDir, "Directory where reside srcsafe.ini.\r\nFor example:\r\n\\\\IMB-SRCSAFE\\SS_GF80\\");
			this.textBoxSSDir.TextChanged += new System.EventHandler(this.textBoxSSDir_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "SS Dir:";
			// 
			// checkBoxConvertUCS2
			// 
			this.checkBoxConvertUCS2.AutoSize = true;
			this.checkBoxConvertUCS2.Location = new System.Drawing.Point(76, 64);
			this.checkBoxConvertUCS2.Name = "checkBoxConvertUCS2";
			this.checkBoxConvertUCS2.Size = new System.Drawing.Size(70, 17);
			this.checkBoxConvertUCS2.TabIndex = 4;
			this.checkBoxConvertUCS2.Text = "UCS2 file";
			this.checkBoxConvertUCS2.UseVisualStyleBackColor = true;
			this.checkBoxConvertUCS2.CheckedChanged += new System.EventHandler(this.checkBoxConvertUCS2_CheckedChanged);
			// 
			// VssBame
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(547, 135);
			this.Controls.Add(this.checkBoxConvertUCS2);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.buttonLog);
			this.Controls.Add(this.buttonBlame);
			this.Controls.Add(this.buttonBuild);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxSSDir);
			this.Controls.Add(this.textBoxFileSpec);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "VssBame";
			this.Text = "VssBame";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.VssBameDragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.VssBameDragEnter);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxFileSpec;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonBuild;
		private System.Windows.Forms.Button buttonBlame;
		private System.Windows.Forms.Button buttonLog;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.TextBox textBoxSSDir;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.CheckBox checkBoxConvertUCS2;
	}
}

