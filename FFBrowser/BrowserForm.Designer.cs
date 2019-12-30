namespace FFBrowser
{
	partial class BrowserForm
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.TreeView = new System.Windows.Forms.TreeView();
			this.TabControl = new System.Windows.Forms.TabControl();
			this.PropertiesTabPage = new System.Windows.Forms.TabPage();
			this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.TabControl.SuspendLayout();
			this.PropertiesTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.TreeView);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.TabControl);
			this.splitContainer1.Size = new System.Drawing.Size(1008, 729);
			this.splitContainer1.SplitterDistance = 336;
			this.splitContainer1.TabIndex = 0;
			// 
			// TreeView
			// 
			this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TreeView.Location = new System.Drawing.Point(0, 0);
			this.TreeView.Name = "TreeView";
			this.TreeView.Size = new System.Drawing.Size(336, 729);
			this.TreeView.TabIndex = 0;
			// 
			// TabControl
			// 
			this.TabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.TabControl.Controls.Add(this.PropertiesTabPage);
			this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl.Location = new System.Drawing.Point(0, 0);
			this.TabControl.Name = "TabControl";
			this.TabControl.SelectedIndex = 0;
			this.TabControl.Size = new System.Drawing.Size(668, 729);
			this.TabControl.TabIndex = 0;
			// 
			// PropertiesTabPage
			// 
			this.PropertiesTabPage.Controls.Add(this.PropertyGrid);
			this.PropertiesTabPage.Location = new System.Drawing.Point(4, 4);
			this.PropertiesTabPage.Name = "PropertiesTabPage";
			this.PropertiesTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.PropertiesTabPage.Size = new System.Drawing.Size(660, 703);
			this.PropertiesTabPage.TabIndex = 0;
			this.PropertiesTabPage.Text = "Properties";
			this.PropertiesTabPage.UseVisualStyleBackColor = true;
			// 
			// PropertyGrid
			// 
			this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PropertyGrid.Location = new System.Drawing.Point(3, 3);
			this.PropertyGrid.Name = "PropertyGrid";
			this.PropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
			this.PropertyGrid.Size = new System.Drawing.Size(654, 697);
			this.PropertyGrid.TabIndex = 0;
			this.PropertyGrid.ToolbarVisible = false;
			// 
			// BrowserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 729);
			this.Controls.Add(this.splitContainer1);
			this.DoubleBuffered = true;
			this.Name = "BrowserForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Browser";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.TabControl.ResumeLayout(false);
			this.PropertiesTabPage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		public System.Windows.Forms.PropertyGrid PropertyGrid;
		public System.Windows.Forms.TabControl TabControl;
		public System.Windows.Forms.TabPage PropertiesTabPage;
		public System.Windows.Forms.TreeView TreeView;
	}
}

