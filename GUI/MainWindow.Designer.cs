/***************************************************************************/
/*	This file is part of PS:f.											   */
/*																		   */
/*  PS:f is free software: you can redistribute it and/or modify		   */
/*  it under the terms of the GNU General Public License as published by   */
/*  the Free Software Foundation, either version 3 of the License, or	   */
/*  (at your option) any later version.									   */
/*																		   */
/*  PS:f is distributed in the hope that it will be useful,				   */
/*  but WITHOUT ANY WARRANTY; without even the implied warranty of		   */
/*  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the		   */
/*  GNU General Public License for more details.						   */
/*																		   */
/*  You should have received a copy of the GNU General Public License	   */
/*  along with PS:f.  If not, see <http://www.gnu.org/licenses/>.		   */
/***************************************************************************/

namespace PSf.GUI
{
	partial class MainWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.ProfileStatusStrip = new System.Windows.Forms.StatusStrip();
			this.ProfileStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ProfileStatusIcon = new System.Windows.Forms.ToolStripStatusLabel();
			this.TabControlContainer = new System.Windows.Forms.Panel();
			this.MainWindowStrip = new System.Windows.Forms.ToolStrip();
			this.NewProfileButton = new System.Windows.Forms.ToolStripButton();
			this.SaveProfileButton = new System.Windows.Forms.ToolStripButton();
			this.DeleteProfileButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.FrontendOptionsButton = new System.Windows.Forms.ToolStripButton();
			this.AboutButton = new System.Windows.Forms.ToolStripButton();
			this.RunProfileButton = new System.Windows.Forms.ToolStripSplitButton();
			this.RunBiosButton = new System.Windows.Forms.ToolStripMenuItem();
			this.ProfileListMenu = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ProfileStatusStrip.SuspendLayout();
			this.MainWindowStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// ProfileStatusStrip
			// 
			this.ProfileStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProfileStatusLabel,
            this.ProfileStatusIcon});
			this.ProfileStatusStrip.Location = new System.Drawing.Point(0, 408);
			this.ProfileStatusStrip.Name = "ProfileStatusStrip";
			this.ProfileStatusStrip.Size = new System.Drawing.Size(731, 22);
			this.ProfileStatusStrip.SizingGrip = false;
			this.ProfileStatusStrip.TabIndex = 7;
			// 
			// ProfileStatusLabel
			// 
			this.ProfileStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ProfileStatusLabel.Name = "ProfileStatusLabel";
			this.ProfileStatusLabel.Size = new System.Drawing.Size(79, 17);
			this.ProfileStatusLabel.Text = "Profile Status:";
			this.ProfileStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ProfileStatusIcon
			// 
			this.ProfileStatusIcon.Image = global::PSf.Properties.Resources.statuserror;
			this.ProfileStatusIcon.Name = "ProfileStatusIcon";
			this.ProfileStatusIcon.Size = new System.Drawing.Size(16, 17);
			// 
			// TabControlContainer
			// 
			this.TabControlContainer.BackColor = System.Drawing.Color.Transparent;
			this.TabControlContainer.Location = new System.Drawing.Point(12, 28);
			this.TabControlContainer.Name = "TabControlContainer";
			this.TabControlContainer.Size = new System.Drawing.Size(707, 377);
			this.TabControlContainer.TabIndex = 8;
			// 
			// MainWindowStrip
			// 
			this.MainWindowStrip.AutoSize = false;
			this.MainWindowStrip.CanOverflow = false;
			this.MainWindowStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.MainWindowStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.MainWindowStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewProfileButton,
            this.SaveProfileButton,
            this.DeleteProfileButton,
            this.toolStripSeparator1,
            this.FrontendOptionsButton,
            this.AboutButton,
            this.RunProfileButton,
            this.ProfileListMenu,
            this.toolStripSeparator2});
			this.MainWindowStrip.Location = new System.Drawing.Point(0, 0);
			this.MainWindowStrip.Name = "MainWindowStrip";
			this.MainWindowStrip.Size = new System.Drawing.Size(732, 25);
			this.MainWindowStrip.TabIndex = 9;
			// 
			// NewProfileButton
			// 
			this.NewProfileButton.Image = global::PSf.Properties.Resources.newprofile;
			this.NewProfileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.NewProfileButton.Name = "NewProfileButton";
			this.NewProfileButton.Size = new System.Drawing.Size(88, 22);
			this.NewProfileButton.Text = "New Profile";
			this.NewProfileButton.Click += new System.EventHandler(this.NewProfileButtonClick);
			// 
			// SaveProfileButton
			// 
			this.SaveProfileButton.Image = global::PSf.Properties.Resources.saveprofile;
			this.SaveProfileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SaveProfileButton.Name = "SaveProfileButton";
			this.SaveProfileButton.Size = new System.Drawing.Size(88, 22);
			this.SaveProfileButton.Text = "Save Profile";
			this.SaveProfileButton.Click += new System.EventHandler(this.SaveProfileButtonClick);
			// 
			// DeleteProfileButton
			// 
			this.DeleteProfileButton.Image = global::PSf.Properties.Resources.delete;
			this.DeleteProfileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DeleteProfileButton.Name = "DeleteProfileButton";
			this.DeleteProfileButton.Size = new System.Drawing.Size(97, 22);
			this.DeleteProfileButton.Text = "Delete Profile";
			this.DeleteProfileButton.Click += new System.EventHandler(this.DeleteProfileButtonClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// FrontendOptionsButton
			// 
			this.FrontendOptionsButton.Image = global::PSf.Properties.Resources.settings;
			this.FrontendOptionsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FrontendOptionsButton.Name = "FrontendOptionsButton";
			this.FrontendOptionsButton.Size = new System.Drawing.Size(69, 22);
			this.FrontendOptionsButton.Text = "Options";
			this.FrontendOptionsButton.Click += new System.EventHandler(this.FrontendOptionsButtonClick);
			// 
			// AboutButton
			// 
			this.AboutButton.Image = global::PSf.Properties.Resources.about;
			this.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AboutButton.Name = "AboutButton";
			this.AboutButton.Size = new System.Drawing.Size(60, 22);
			this.AboutButton.Text = "About";
			this.AboutButton.Click += new System.EventHandler(this.AboutButtonClick);
			// 
			// RunProfileButton
			// 
			this.RunProfileButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.RunProfileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunBiosButton});
			this.RunProfileButton.Image = global::PSf.Properties.Resources.play;
			this.RunProfileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RunProfileButton.Name = "RunProfileButton";
			this.RunProfileButton.Size = new System.Drawing.Size(60, 22);
			this.RunProfileButton.Text = "Run";
			this.RunProfileButton.ButtonClick += new System.EventHandler(this.RunProfileButtonClick);
			// 
			// RunBiosButton
			// 
			this.RunBiosButton.Name = "RunBiosButton";
			this.RunBiosButton.Size = new System.Drawing.Size(123, 22);
			this.RunBiosButton.Text = "Run BIOS";
			this.RunBiosButton.Click += new System.EventHandler(this.RunBiosButtonClick);
			// 
			// ProfileListMenu
			// 
			this.ProfileListMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.ProfileListMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ProfileListMenu.Enabled = false;
			this.ProfileListMenu.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.ProfileListMenu.Name = "ProfileListMenu";
			this.ProfileListMenu.Size = new System.Drawing.Size(254, 25);
			this.ProfileListMenu.SelectedIndexChanged += new System.EventHandler(this.ProfileListMenuSelectedIndexChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(731, 430);
			this.Controls.Add(this.MainWindowStrip);
			this.Controls.Add(this.TabControlContainer);
			this.Controls.Add(this.ProfileStatusStrip);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainWindow";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PS:f";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindowFormClosing);
			this.ProfileStatusStrip.ResumeLayout(false);
			this.ProfileStatusStrip.PerformLayout();
			this.MainWindowStrip.ResumeLayout(false);
			this.MainWindowStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip ProfileStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel ProfileStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel ProfileStatusIcon;
		private System.Windows.Forms.Panel TabControlContainer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		internal System.Windows.Forms.ToolStripComboBox ProfileListMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		internal System.Windows.Forms.ToolStripButton SaveProfileButton;
		internal System.Windows.Forms.ToolStripButton NewProfileButton;
		internal System.Windows.Forms.ToolStripButton DeleteProfileButton;
		internal System.Windows.Forms.ToolStripButton FrontendOptionsButton;
		internal System.Windows.Forms.ToolStripButton AboutButton;
		internal System.Windows.Forms.ToolStrip MainWindowStrip;
		internal System.Windows.Forms.ToolStripSplitButton RunProfileButton;
		private System.Windows.Forms.ToolStripMenuItem RunBiosButton;
	}
}