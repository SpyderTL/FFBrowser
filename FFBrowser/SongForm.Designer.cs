namespace FFBrowser
{
	partial class SongForm
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
			this.StopButton = new System.Windows.Forms.Button();
			this.PlayButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.Panel3 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// StopButton
			// 
			this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.StopButton.Location = new System.Drawing.Point(570, 158);
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(75, 23);
			this.StopButton.TabIndex = 0;
			this.StopButton.Text = "Stop";
			this.StopButton.UseVisualStyleBackColor = true;
			// 
			// PlayButton
			// 
			this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.PlayButton.Location = new System.Drawing.Point(489, 158);
			this.PlayButton.Name = "PlayButton";
			this.PlayButton.Size = new System.Drawing.Size(75, 23);
			this.PlayButton.TabIndex = 1;
			this.PlayButton.Text = "Play";
			this.PlayButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Square Wave 1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Square Wave 2";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Triangle Wave";
			// 
			// Panel1
			// 
			this.Panel1.BackColor = System.Drawing.Color.Lime;
			this.Panel1.Location = new System.Drawing.Point(12, 25);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(0, 23);
			this.Panel1.TabIndex = 8;
			// 
			// Panel2
			// 
			this.Panel2.BackColor = System.Drawing.Color.Lime;
			this.Panel2.Location = new System.Drawing.Point(12, 67);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(0, 23);
			this.Panel2.TabIndex = 9;
			// 
			// Panel3
			// 
			this.Panel3.BackColor = System.Drawing.Color.Lime;
			this.Panel3.Location = new System.Drawing.Point(12, 109);
			this.Panel3.Name = "Panel3";
			this.Panel3.Size = new System.Drawing.Size(0, 23);
			this.Panel3.TabIndex = 10;
			// 
			// SongForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(657, 193);
			this.Controls.Add(this.Panel3);
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.Panel1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.PlayButton);
			this.Controls.Add(this.StopButton);
			this.Name = "SongForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Song";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Button StopButton;
		public System.Windows.Forms.Button PlayButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.Panel Panel1;
		public System.Windows.Forms.Panel Panel2;
		public System.Windows.Forms.Panel Panel3;
	}
}