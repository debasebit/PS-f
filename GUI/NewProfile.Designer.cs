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
	partial class NewProfile
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
			this.ProfileTypeContainer = new System.Windows.Forms.GroupBox();
			this.Pcsx2RadioSelect = new System.Windows.Forms.RadioButton();
			this.EpsxeRadioSelect = new System.Windows.Forms.RadioButton();
			this.ProfileDetailsContainer = new System.Windows.Forms.GroupBox();
			this.ProfileDetailsOptionalContainer = new System.Windows.Forms.GroupBox();
			this.DiscSeperatorLabel = new System.Windows.Forms.Label();
			this.RegionList = new System.Windows.Forms.ComboBox();
			this.TotalDiscList = new System.Windows.Forms.ComboBox();
			this.CurrentDiscList = new System.Windows.Forms.ComboBox();
			this.RegionCheckbox = new System.Windows.Forms.CheckBox();
			this.DiscCheckbox = new System.Windows.Forms.CheckBox();
			this.ProfileTitleTextbox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ProfilePreviewContainer = new System.Windows.Forms.GroupBox();
			this.ProfilePreviewLabel = new System.Windows.Forms.Label();
			this.ProfileCancelButton = new System.Windows.Forms.Button();
			this.ProfileCreateButton = new System.Windows.Forms.Button();
			this.ProfileTypeContainer.SuspendLayout();
			this.ProfileDetailsContainer.SuspendLayout();
			this.ProfileDetailsOptionalContainer.SuspendLayout();
			this.ProfilePreviewContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// ProfileTypeContainer
			// 
			this.ProfileTypeContainer.BackColor = System.Drawing.Color.Transparent;
			this.ProfileTypeContainer.Controls.Add(this.Pcsx2RadioSelect);
			this.ProfileTypeContainer.Controls.Add(this.EpsxeRadioSelect);
			this.ProfileTypeContainer.Location = new System.Drawing.Point(12, 12);
			this.ProfileTypeContainer.Name = "ProfileTypeContainer";
			this.ProfileTypeContainer.Size = new System.Drawing.Size(240, 42);
			this.ProfileTypeContainer.TabIndex = 0;
			this.ProfileTypeContainer.TabStop = false;
			this.ProfileTypeContainer.Text = "Profile Type";
			// 
			// Pcsx2RadioSelect
			// 
			this.Pcsx2RadioSelect.AutoSize = true;
			this.Pcsx2RadioSelect.BackColor = System.Drawing.Color.Transparent;
			this.Pcsx2RadioSelect.Enabled = false;
			this.Pcsx2RadioSelect.Location = new System.Drawing.Point(122, 19);
			this.Pcsx2RadioSelect.Name = "Pcsx2RadioSelect";
			this.Pcsx2RadioSelect.Size = new System.Drawing.Size(95, 17);
			this.Pcsx2RadioSelect.TabIndex = 1;
			this.Pcsx2RadioSelect.TabStop = true;
			this.Pcsx2RadioSelect.Text = "PCSX2 Profile";
			this.Pcsx2RadioSelect.UseVisualStyleBackColor = false;
			// 
			// EpsxeRadioSelect
			// 
			this.EpsxeRadioSelect.AutoSize = true;
			this.EpsxeRadioSelect.BackColor = System.Drawing.Color.Transparent;
			this.EpsxeRadioSelect.Checked = true;
			this.EpsxeRadioSelect.Location = new System.Drawing.Point(24, 19);
			this.EpsxeRadioSelect.Name = "EpsxeRadioSelect";
			this.EpsxeRadioSelect.Size = new System.Drawing.Size(93, 17);
			this.EpsxeRadioSelect.TabIndex = 0;
			this.EpsxeRadioSelect.TabStop = true;
			this.EpsxeRadioSelect.Text = "ePSXe Profile";
			this.EpsxeRadioSelect.UseVisualStyleBackColor = false;
			this.EpsxeRadioSelect.CheckedChanged += new System.EventHandler(this.EpsxeRadioSelectCheckedChanged);
			// 
			// ProfileDetailsContainer
			// 
			this.ProfileDetailsContainer.BackColor = System.Drawing.Color.Transparent;
			this.ProfileDetailsContainer.Controls.Add(this.ProfileDetailsOptionalContainer);
			this.ProfileDetailsContainer.Controls.Add(this.ProfileTitleTextbox);
			this.ProfileDetailsContainer.Controls.Add(this.label1);
			this.ProfileDetailsContainer.Location = new System.Drawing.Point(12, 60);
			this.ProfileDetailsContainer.Name = "ProfileDetailsContainer";
			this.ProfileDetailsContainer.Size = new System.Drawing.Size(240, 121);
			this.ProfileDetailsContainer.TabIndex = 1;
			this.ProfileDetailsContainer.TabStop = false;
			this.ProfileDetailsContainer.Text = "Profile Details";
			// 
			// ProfileDetailsOptionalContainer
			// 
			this.ProfileDetailsOptionalContainer.BackColor = System.Drawing.Color.Transparent;
			this.ProfileDetailsOptionalContainer.Controls.Add(this.DiscSeperatorLabel);
			this.ProfileDetailsOptionalContainer.Controls.Add(this.RegionList);
			this.ProfileDetailsOptionalContainer.Controls.Add(this.TotalDiscList);
			this.ProfileDetailsOptionalContainer.Controls.Add(this.CurrentDiscList);
			this.ProfileDetailsOptionalContainer.Controls.Add(this.RegionCheckbox);
			this.ProfileDetailsOptionalContainer.Controls.Add(this.DiscCheckbox);
			this.ProfileDetailsOptionalContainer.Location = new System.Drawing.Point(6, 42);
			this.ProfileDetailsOptionalContainer.Name = "ProfileDetailsOptionalContainer";
			this.ProfileDetailsOptionalContainer.Size = new System.Drawing.Size(228, 73);
			this.ProfileDetailsOptionalContainer.TabIndex = 2;
			this.ProfileDetailsOptionalContainer.TabStop = false;
			this.ProfileDetailsOptionalContainer.Text = "Optional";
			// 
			// DiscSeperatorLabel
			// 
			this.DiscSeperatorLabel.AutoSize = true;
			this.DiscSeperatorLabel.BackColor = System.Drawing.Color.Transparent;
			this.DiscSeperatorLabel.Enabled = false;
			this.DiscSeperatorLabel.Location = new System.Drawing.Point(116, 23);
			this.DiscSeperatorLabel.Name = "DiscSeperatorLabel";
			this.DiscSeperatorLabel.Size = new System.Drawing.Size(16, 13);
			this.DiscSeperatorLabel.TabIndex = 5;
			this.DiscSeperatorLabel.Text = "of";
			// 
			// RegionList
			// 
			this.RegionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.RegionList.Enabled = false;
			this.RegionList.FormattingEnabled = true;
			this.RegionList.Location = new System.Drawing.Point(75, 46);
			this.RegionList.Name = "RegionList";
			this.RegionList.Size = new System.Drawing.Size(98, 21);
			this.RegionList.TabIndex = 4;
			this.RegionList.SelectedIndexChanged += new System.EventHandler(this.RegionListSelectedIndexChanged);
			// 
			// TotalDiscList
			// 
			this.TotalDiscList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TotalDiscList.Enabled = false;
			this.TotalDiscList.FormattingEnabled = true;
			this.TotalDiscList.Location = new System.Drawing.Point(138, 19);
			this.TotalDiscList.Name = "TotalDiscList";
			this.TotalDiscList.Size = new System.Drawing.Size(35, 21);
			this.TotalDiscList.TabIndex = 3;
			this.TotalDiscList.SelectedIndexChanged += new System.EventHandler(this.TotalDiscListSelectedIndexChanged);
			// 
			// CurrentDiscList
			// 
			this.CurrentDiscList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CurrentDiscList.Enabled = false;
			this.CurrentDiscList.FormattingEnabled = true;
			this.CurrentDiscList.Location = new System.Drawing.Point(75, 19);
			this.CurrentDiscList.Name = "CurrentDiscList";
			this.CurrentDiscList.Size = new System.Drawing.Size(35, 21);
			this.CurrentDiscList.TabIndex = 2;
			this.CurrentDiscList.SelectedIndexChanged += new System.EventHandler(this.CurrentDiscListSelectedIndexChanged);
			// 
			// RegionCheckbox
			// 
			this.RegionCheckbox.AutoSize = true;
			this.RegionCheckbox.BackColor = System.Drawing.Color.Transparent;
			this.RegionCheckbox.Location = new System.Drawing.Point(6, 48);
			this.RegionCheckbox.Name = "RegionCheckbox";
			this.RegionCheckbox.Size = new System.Drawing.Size(64, 17);
			this.RegionCheckbox.TabIndex = 1;
			this.RegionCheckbox.Text = "Region:";
			this.RegionCheckbox.UseVisualStyleBackColor = false;
			this.RegionCheckbox.CheckedChanged += new System.EventHandler(this.RegionCheckboxCheckedChanged);
			// 
			// DiscCheckbox
			// 
			this.DiscCheckbox.AutoSize = true;
			this.DiscCheckbox.BackColor = System.Drawing.Color.Transparent;
			this.DiscCheckbox.Location = new System.Drawing.Point(6, 21);
			this.DiscCheckbox.Name = "DiscCheckbox";
			this.DiscCheckbox.Size = new System.Drawing.Size(52, 17);
			this.DiscCheckbox.TabIndex = 0;
			this.DiscCheckbox.Text = "Disc:";
			this.DiscCheckbox.UseVisualStyleBackColor = false;
			this.DiscCheckbox.CheckedChanged += new System.EventHandler(this.DiscCheckboxCheckedChanged);
			// 
			// ProfileTitleTextbox
			// 
			this.ProfileTitleTextbox.Location = new System.Drawing.Point(44, 19);
			this.ProfileTitleTextbox.Name = "ProfileTitleTextbox";
			this.ProfileTitleTextbox.Size = new System.Drawing.Size(188, 20);
			this.ProfileTitleTextbox.TabIndex = 0;
			this.ProfileTitleTextbox.TextChanged += new System.EventHandler(this.ProfileTitleTextboxTextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Title:";
			// 
			// ProfilePreviewContainer
			// 
			this.ProfilePreviewContainer.BackColor = System.Drawing.Color.Transparent;
			this.ProfilePreviewContainer.Controls.Add(this.ProfilePreviewLabel);
			this.ProfilePreviewContainer.Location = new System.Drawing.Point(12, 187);
			this.ProfilePreviewContainer.Name = "ProfilePreviewContainer";
			this.ProfilePreviewContainer.Size = new System.Drawing.Size(240, 37);
			this.ProfilePreviewContainer.TabIndex = 2;
			this.ProfilePreviewContainer.TabStop = false;
			this.ProfilePreviewContainer.Text = "Profile Preview";
			// 
			// ProfilePreviewLabel
			// 
			this.ProfilePreviewLabel.BackColor = System.Drawing.Color.Transparent;
			this.ProfilePreviewLabel.Location = new System.Drawing.Point(6, 16);
			this.ProfilePreviewLabel.Name = "ProfilePreviewLabel";
			this.ProfilePreviewLabel.Size = new System.Drawing.Size(228, 13);
			this.ProfilePreviewLabel.TabIndex = 0;
			this.ProfilePreviewLabel.Text = "Preview Title Here";
			this.ProfilePreviewLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ProfileCancelButton
			// 
			this.ProfileCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ProfileCancelButton.Location = new System.Drawing.Point(177, 230);
			this.ProfileCancelButton.Name = "ProfileCancelButton";
			this.ProfileCancelButton.Size = new System.Drawing.Size(75, 23);
			this.ProfileCancelButton.TabIndex = 3;
			this.ProfileCancelButton.Text = "Cancel";
			this.ProfileCancelButton.UseVisualStyleBackColor = true;
			// 
			// ProfileCreateButton
			// 
			this.ProfileCreateButton.Location = new System.Drawing.Point(96, 230);
			this.ProfileCreateButton.Name = "ProfileCreateButton";
			this.ProfileCreateButton.Size = new System.Drawing.Size(75, 23);
			this.ProfileCreateButton.TabIndex = 4;
			this.ProfileCreateButton.Text = "Create";
			this.ProfileCreateButton.UseVisualStyleBackColor = true;
			this.ProfileCreateButton.Click += new System.EventHandler(this.ProfileCreateButtonClick);
			// 
			// NewProfile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.ProfileCancelButton;
			this.ClientSize = new System.Drawing.Size(264, 265);
			this.Controls.Add(this.ProfileCreateButton);
			this.Controls.Add(this.ProfileCancelButton);
			this.Controls.Add(this.ProfilePreviewContainer);
			this.Controls.Add(this.ProfileDetailsContainer);
			this.Controls.Add(this.ProfileTypeContainer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewProfile";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Profile";
			this.Load += new System.EventHandler(this.NewProfileLoad);
			this.ProfileTypeContainer.ResumeLayout(false);
			this.ProfileTypeContainer.PerformLayout();
			this.ProfileDetailsContainer.ResumeLayout(false);
			this.ProfileDetailsContainer.PerformLayout();
			this.ProfileDetailsOptionalContainer.ResumeLayout(false);
			this.ProfileDetailsOptionalContainer.PerformLayout();
			this.ProfilePreviewContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox ProfileTypeContainer;
		private System.Windows.Forms.RadioButton Pcsx2RadioSelect;
		private System.Windows.Forms.RadioButton EpsxeRadioSelect;
		private System.Windows.Forms.GroupBox ProfileDetailsContainer;
		private System.Windows.Forms.GroupBox ProfileDetailsOptionalContainer;
		private System.Windows.Forms.Label DiscSeperatorLabel;
		private System.Windows.Forms.ComboBox RegionList;
		private System.Windows.Forms.ComboBox TotalDiscList;
		private System.Windows.Forms.ComboBox CurrentDiscList;
		private System.Windows.Forms.CheckBox RegionCheckbox;
		private System.Windows.Forms.CheckBox DiscCheckbox;
		private System.Windows.Forms.TextBox ProfileTitleTextbox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox ProfilePreviewContainer;
		private System.Windows.Forms.Label ProfilePreviewLabel;
		private System.Windows.Forms.Button ProfileCancelButton;
		private System.Windows.Forms.Button ProfileCreateButton;
	}
}