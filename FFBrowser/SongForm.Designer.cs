﻿namespace FFBrowser
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
			this.SuspendLayout();
			// 
			// StopButton
			// 
			this.StopButton.Location = new System.Drawing.Point(355, 58);
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(75, 23);
			this.StopButton.TabIndex = 0;
			this.StopButton.Text = "Stop";
			this.StopButton.UseVisualStyleBackColor = true;
			// 
			// PlayButton
			// 
			this.PlayButton.Location = new System.Drawing.Point(274, 58);
			this.PlayButton.Name = "PlayButton";
			this.PlayButton.Size = new System.Drawing.Size(75, 23);
			this.PlayButton.TabIndex = 1;
			this.PlayButton.Text = "Play";
			this.PlayButton.UseVisualStyleBackColor = true;
			// 
			// SongForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(442, 93);
			this.Controls.Add(this.PlayButton);
			this.Controls.Add(this.StopButton);
			this.Name = "SongForm";
			this.Text = "Song";
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Button StopButton;
		public System.Windows.Forms.Button PlayButton;
	}
}