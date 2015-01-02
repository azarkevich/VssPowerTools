namespace VssPowerTools
{
	partial class ToolsSelector
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
			this.buttonBrowser = new System.Windows.Forms.Button();
			this.buttonBlame = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonBrowser
			// 
			this.buttonBrowser.Location = new System.Drawing.Point(12, 12);
			this.buttonBrowser.Name = "buttonBrowser";
			this.buttonBrowser.Size = new System.Drawing.Size(112, 23);
			this.buttonBrowser.TabIndex = 0;
			this.buttonBrowser.Text = "Commits Browser";
			this.buttonBrowser.UseVisualStyleBackColor = true;
			this.buttonBrowser.Click += new System.EventHandler(this.buttonBrowser_Click);
			// 
			// buttonBlame
			// 
			this.buttonBlame.Location = new System.Drawing.Point(12, 41);
			this.buttonBlame.Name = "buttonBlame";
			this.buttonBlame.Size = new System.Drawing.Size(112, 23);
			this.buttonBlame.TabIndex = 0;
			this.buttonBlame.Text = "Blame";
			this.buttonBlame.UseVisualStyleBackColor = true;
			this.buttonBlame.Click += new System.EventHandler(this.buttonBlame_Click);
			// 
			// ToolsSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(136, 78);
			this.Controls.Add(this.buttonBlame);
			this.Controls.Add(this.buttonBrowser);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ToolsSelector";
			this.Text = "ToolsSelector";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonBrowser;
		private System.Windows.Forms.Button buttonBlame;
	}
}