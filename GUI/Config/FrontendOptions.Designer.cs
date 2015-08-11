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
	internal partial class FrontendOptions
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
			this.OptionsLocationsContainer = new System.Windows.Forms.GroupBox();
			this.OptionsPcsx2Help = new System.Windows.Forms.Label();
			this.OptionsEpsxeHelp = new System.Windows.Forms.Label();
			this.OptionsProfilesHelp = new System.Windows.Forms.Label();
			this.OptionsProfilesLabel = new System.Windows.Forms.Label();
			this.OptionsProfilesTextbox = new System.Windows.Forms.TextBox();
			this.OptionsProfilesStatus = new System.Windows.Forms.PictureBox();
			this.OptionsProfilesBrowse = new System.Windows.Forms.Button();
			this.OptionsEpsxeLabel = new System.Windows.Forms.Label();
			this.OptionsEpsxeTextbox = new System.Windows.Forms.TextBox();
			this.OptionsEpsxeStatus = new System.Windows.Forms.PictureBox();
			this.OptionsEpsxeBrowse = new System.Windows.Forms.Button();
			this.OptionsPcsx2Label = new System.Windows.Forms.Label();
			this.OptionsPcsx2Textbox = new System.Windows.Forms.TextBox();
			this.OptionsPcsx2Status = new System.Windows.Forms.PictureBox();
			this.OptionsPcsx2Browse = new System.Windows.Forms.Button();
			this.OptionsMiscContainer = new System.Windows.Forms.GroupBox();
			this.OptionsToolbarHelp = new System.Windows.Forms.Label();
			this.OptionsVerifyHelp = new System.Windows.Forms.Label();
			this.OptionsLastProfileHelp = new System.Windows.Forms.Label();
			this.OptionsExtHelp = new System.Windows.Forms.Label();
			this.OptionsFileExt = new System.Windows.Forms.CheckBox();
			this.OptionsLastProfile = new System.Windows.Forms.CheckBox();
			this.Seperator2 = new System.Windows.Forms.Label();
			this.OptionsFileVerify = new System.Windows.Forms.CheckBox();
			this.OptionsToolbarLabel = new System.Windows.Forms.Label();
			this.ToolbarStyleList = new System.Windows.Forms.ComboBox();
			this.OptionsSaveButton = new System.Windows.Forms.Button();
			this.OptionsCancelButton = new System.Windows.Forms.Button();
			this.OptionsDefaultsButton = new System.Windows.Forms.Button();
			this.OptionsEpsxeMiscContainer = new System.Windows.Forms.GroupBox();
			this.OptionsPpfHelp = new System.Windows.Forms.Label();
			this.OptionsLoggingHelp = new System.Windows.Forms.Label();
			this.OptionsEpsxeLogging = new System.Windows.Forms.CheckBox();
			this.Seperator1 = new System.Windows.Forms.Label();
			this.OptionsEpsxePpf = new System.Windows.Forms.CheckBox();
			this.OptionsLocationsContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.OptionsProfilesStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.OptionsEpsxeStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.OptionsPcsx2Status)).BeginInit();
			this.OptionsMiscContainer.SuspendLayout();
			this.OptionsEpsxeMiscContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// OptionsLocationsContainer
			// 
			this.OptionsLocationsContainer.BackColor = System.Drawing.Color.Transparent;
			this.OptionsLocationsContainer.Controls.Add(this.OptionsPcsx2Help);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsEpsxeHelp);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsProfilesHelp);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsProfilesLabel);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsProfilesTextbox);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsProfilesStatus);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsProfilesBrowse);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsEpsxeLabel);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsEpsxeTextbox);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsEpsxeStatus);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsEpsxeBrowse);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsPcsx2Label);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsPcsx2Textbox);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsPcsx2Status);
			this.OptionsLocationsContainer.Controls.Add(this.OptionsPcsx2Browse);
			this.OptionsLocationsContainer.Location = new System.Drawing.Point(12, 13);
			this.OptionsLocationsContainer.Name = "OptionsLocationsContainer";
			this.OptionsLocationsContainer.Size = new System.Drawing.Size(420, 106);
			this.OptionsLocationsContainer.TabIndex = 0;
			this.OptionsLocationsContainer.TabStop = false;
			this.OptionsLocationsContainer.Text = "Locations";
			// 
			// OptionsPcsx2Help
			// 
			this.OptionsPcsx2Help.AutoSize = true;
			this.OptionsPcsx2Help.Cursor = System.Windows.Forms.Cursors.Help;
			this.OptionsPcsx2Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OptionsPcsx2Help.ForeColor = System.Drawing.Color.SteelBlue;
			this.OptionsPcsx2Help.Location = new System.Drawing.Point(303, 72);
			this.OptionsPcsx2Help.Name = "OptionsPcsx2Help";
			this.OptionsPcsx2Help.Size = new System.Drawing.Size(13, 13);
			this.OptionsPcsx2Help.TabIndex = 16;
			this.OptionsPcsx2Help.Text = "?";
			this.OptionsPcsx2Help.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.OptionsPcsx2Help.Click += new System.EventHandler(this.FrontendOptionsHelpLinkClicked);
			// 
			// OptionsEpsxeHelp
			// 
			this.OptionsEpsxeHelp.AutoSize = true;
			this.OptionsEpsxeHelp.Cursor = System.Windows.Forms.Cursors.Help;
			this.OptionsEpsxeHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OptionsEpsxeHelp.ForeColor = System.Drawing.Color.SteelBlue;
			this.OptionsEpsxeHelp.Location = new System.Drawing.Point(303, 44);
			this.OptionsEpsxeHelp.Name = "OptionsEpsxeHelp";
			this.OptionsEpsxeHelp.Size = new System.Drawing.Size(13, 13);
			this.OptionsEpsxeHelp.TabIndex = 15;
			this.OptionsEpsxeHelp.Text = "?";
			this.OptionsEpsxeHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.OptionsEpsxeHelp.Click += new System.EventHandler(this.FrontendOptionsHelpLinkClicked);
			// 
			// OptionsProfilesHelp
			// 
			this.OptionsProfilesHelp.AutoSize = true;
			this.OptionsProfilesHelp.Cursor = System.Windows.Forms.Cursors.Help;
			this.OptionsProfilesHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OptionsProfilesHelp.ForeColor = System.Drawing.Color.SteelBlue;
			this.OptionsProfilesHelp.Location = new System.Drawing.Point(303, 16);
			this.OptionsProfilesHelp.Name = "OptionsProfilesHelp";
			this.OptionsProfilesHelp.Size = new System.Drawing.Size(13, 13);
			this.OptionsProfilesHelp.TabIndex = 14;
			this.OptionsProfilesHelp.Text = "?";
			this.OptionsProfilesHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.OptionsProfilesHelp.Click += new System.EventHandler(this.FrontendOptionsHelpLinkClicked);
			// 
			// OptionsProfilesLabel
			// 
			this.OptionsProfilesLabel.AutoSize = true;
			this.OptionsProfilesLabel.Location = new System.Drawing.Point(7, 20);
			this.OptionsProfilesLabel.Name = "OptionsProfilesLabel";
			this.OptionsProfilesLabel.Size = new System.Drawing.Size(48, 13);
			this.OptionsProfilesLabel.TabIndex = 4;
			this.OptionsProfilesLabel.Text = "Profiles:";
			// 
			// OptionsProfilesTextbox
			// 
			this.OptionsProfilesTextbox.Location = new System.Drawing.Point(61, 18);
			this.OptionsProfilesTextbox.Name = "OptionsProfilesTextbox";
			this.OptionsProfilesTextbox.Size = new System.Drawing.Size(240, 20);
			this.OptionsProfilesTextbox.TabIndex = 3;
			this.OptionsProfilesTextbox.TextChanged += new System.EventHandler(this.OptionsProfilesTextboxTextChanged);
			// 
			// OptionsProfilesStatus
			// 
			this.OptionsProfilesStatus.Image = global::PSf.Properties.Resources.statuserror;
			this.OptionsProfilesStatus.Location = new System.Drawing.Point(317, 19);
			this.OptionsProfilesStatus.Name = "OptionsProfilesStatus";
			this.OptionsProfilesStatus.Size = new System.Drawing.Size(16, 16);
			this.OptionsProfilesStatus.TabIndex = 5;
			this.OptionsProfilesStatus.TabStop = false;
			// 
			// OptionsProfilesBrowse
			// 
			this.OptionsProfilesBrowse.Location = new System.Drawing.Point(339, 16);
			this.OptionsProfilesBrowse.Name = "OptionsProfilesBrowse";
			this.OptionsProfilesBrowse.Size = new System.Drawing.Size(75, 23);
			this.OptionsProfilesBrowse.TabIndex = 0;
			this.OptionsProfilesBrowse.Text = "Browse";
			this.OptionsProfilesBrowse.UseVisualStyleBackColor = true;
			this.OptionsProfilesBrowse.Click += new System.EventHandler(this.OptionsProfilesBrowseClick);
			// 
			// OptionsEpsxeLabel
			// 
			this.OptionsEpsxeLabel.AutoSize = true;
			this.OptionsEpsxeLabel.Location = new System.Drawing.Point(7, 48);
			this.OptionsEpsxeLabel.Name = "OptionsEpsxeLabel";
			this.OptionsEpsxeLabel.Size = new System.Drawing.Size(43, 13);
			this.OptionsEpsxeLabel.TabIndex = 7;
			this.OptionsEpsxeLabel.Text = "ePSXe:";
			// 
			// OptionsEpsxeTextbox
			// 
			this.OptionsEpsxeTextbox.Location = new System.Drawing.Point(61, 46);
			this.OptionsEpsxeTextbox.Name = "OptionsEpsxeTextbox";
			this.OptionsEpsxeTextbox.Size = new System.Drawing.Size(240, 20);
			this.OptionsEpsxeTextbox.TabIndex = 6;
			this.OptionsEpsxeTextbox.TextChanged += new System.EventHandler(this.OptionsEpsxeTextboxTextChanged);
			// 
			// OptionsEpsxeStatus
			// 
			this.OptionsEpsxeStatus.Image = global::PSf.Properties.Resources.statuserror;
			this.OptionsEpsxeStatus.Location = new System.Drawing.Point(317, 48);
			this.OptionsEpsxeStatus.Name = "OptionsEpsxeStatus";
			this.OptionsEpsxeStatus.Size = new System.Drawing.Size(16, 16);
			this.OptionsEpsxeStatus.TabIndex = 8;
			this.OptionsEpsxeStatus.TabStop = false;
			// 
			// OptionsEpsxeBrowse
			// 
			this.OptionsEpsxeBrowse.Location = new System.Drawing.Point(339, 45);
			this.OptionsEpsxeBrowse.Name = "OptionsEpsxeBrowse";
			this.OptionsEpsxeBrowse.Size = new System.Drawing.Size(75, 23);
			this.OptionsEpsxeBrowse.TabIndex = 1;
			this.OptionsEpsxeBrowse.Text = "Browse";
			this.OptionsEpsxeBrowse.UseVisualStyleBackColor = true;
			this.OptionsEpsxeBrowse.Click += new System.EventHandler(this.OptionsEpsxeBrowseClick);
			// 
			// OptionsPcsx2Label
			// 
			this.OptionsPcsx2Label.AutoSize = true;
			this.OptionsPcsx2Label.Enabled = false;
			this.OptionsPcsx2Label.Location = new System.Drawing.Point(7, 76);
			this.OptionsPcsx2Label.Name = "OptionsPcsx2Label";
			this.OptionsPcsx2Label.Size = new System.Drawing.Size(45, 13);
			this.OptionsPcsx2Label.TabIndex = 10;
			this.OptionsPcsx2Label.Text = "PCSX2:";
			// 
			// OptionsPcsx2Textbox
			// 
			this.OptionsPcsx2Textbox.Enabled = false;
			this.OptionsPcsx2Textbox.Location = new System.Drawing.Point(61, 74);
			this.OptionsPcsx2Textbox.Name = "OptionsPcsx2Textbox";
			this.OptionsPcsx2Textbox.Size = new System.Drawing.Size(240, 20);
			this.OptionsPcsx2Textbox.TabIndex = 9;
			this.OptionsPcsx2Textbox.TextChanged += new System.EventHandler(this.OptionsPcsx2TextboxTextChanged);
			// 
			// OptionsPcsx2Status
			// 
			this.OptionsPcsx2Status.Enabled = false;
			this.OptionsPcsx2Status.Image = global::PSf.Properties.Resources.statuserror;
			this.OptionsPcsx2Status.Location = new System.Drawing.Point(317, 76);
			this.OptionsPcsx2Status.Name = "OptionsPcsx2Status";
			this.OptionsPcsx2Status.Size = new System.Drawing.Size(16, 16);
			this.OptionsPcsx2Status.TabIndex = 11;
			this.OptionsPcsx2Status.TabStop = false;
			// 
			// OptionsPcsx2Browse
			// 
			this.OptionsPcsx2Browse.Enabled = false;
			this.OptionsPcsx2Browse.Location = new System.Drawing.Point(339, 74);
			this.OptionsPcsx2Browse.Name = "OptionsPcsx2Browse";
			this.OptionsPcsx2Browse.Size = new System.Drawing.Size(75, 23);
			this.OptionsPcsx2Browse.TabIndex = 2;
			this.OptionsPcsx2Browse.Text = "Browse";
			this.OptionsPcsx2Browse.UseVisualStyleBackColor = true;
			this.OptionsPcsx2Browse.Click += new System.EventHandler(this.OptionsPcsx2BrowseClick);
			// 
			// OptionsMiscContainer
			// 
			this.OptionsMiscContainer.BackColor = System.Drawing.Color.Transparent;
			this.OptionsMiscContainer.Controls.Add(this.OptionsToolbarHelp);
			this.OptionsMiscContainer.Controls.Add(this.OptionsVerifyHelp);
			this.OptionsMiscContainer.Controls.Add(this.OptionsLastProfileHelp);
			this.OptionsMiscContainer.Controls.Add(this.OptionsExtHelp);
			this.OptionsMiscContainer.Controls.Add(this.OptionsFileExt);
			this.OptionsMiscContainer.Controls.Add(this.OptionsLastProfile);
			this.OptionsMiscContainer.Controls.Add(this.Seperator2);
			this.OptionsMiscContainer.Controls.Add(this.OptionsFileVerify);
			this.OptionsMiscContainer.Controls.Add(this.OptionsToolbarLabel);
			this.OptionsMiscContainer.Controls.Add(this.ToolbarStyleList);
			this.OptionsMiscContainer.Location = new System.Drawing.Point(12, 173);
			this.OptionsMiscContainer.Name = "OptionsMiscContainer";
			this.OptionsMiscContainer.Size = new System.Drawing.Size(420, 67);
			this.OptionsMiscContainer.TabIndex = 1;
			this.OptionsMiscContainer.TabStop = false;
			this.OptionsMiscContainer.Text = "Misc.";
			// 
			// OptionsToolbarHelp
			// 
			this.OptionsToolbarHelp.AutoSize = true;
			this.OptionsToolbarHelp.Cursor = System.Windows.Forms.Cursors.Help;
			this.OptionsToolbarHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OptionsToolbarHelp.ForeColor = System.Drawing.Color.SteelBlue;
			this.OptionsToolbarHelp.Location = new System.Drawing.Point(406, 37);
			this.OptionsToolbarHelp.Name = "OptionsToolbarHelp";
			this.OptionsToolbarHelp.Size = new System.Drawing.Size(13, 13);
			this.OptionsToolbarHelp.TabIndex = 18;
			this.OptionsToolbarHelp.Text = "?";
			this.OptionsToolbarHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.OptionsToolbarHelp.Click += new System.EventHandler(this.FrontendOptionsHelpLinkClicked);
			// 
			// OptionsVerifyHelp
			// 
			this.OptionsVerifyHelp.AutoSize = true;
			this.OptionsVerifyHelp.Cursor = System.Windows.Forms.Cursors.Help;
			this.OptionsVerifyHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OptionsVerifyHelp.ForeColor = System.Drawing.Color.SteelBlue;
			this.OptionsVerifyHelp.Location = new System.Drawing.Point(401, 15);
			this.OptionsVerifyHelp.Name = "OptionsVerifyHelp";
			this.OptionsVerifyHelp.Size = new System.Drawing.Size(13, 13);
			this.OptionsVerifyHelp.TabIndex = 17;
			this.OptionsVerifyHelp.Text = "?";
			this.OptionsVerifyHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.OptionsVerifyHelp.Click += new System.EventHandler(this.FrontendOptionsHelpLinkClicked);
			// 
			// OptionsLastProfileHelp
			// 
			this.OptionsLastProfileHelp.AutoSize = true;
			this.OptionsLastProfileHelp.Cursor = System.Windows.Forms.Cursors.Help;
			this.OptionsLastProfileHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OptionsLastProfileHelp.ForeColor = System.Drawing.Color.SteelBlue;
			this.OptionsLastProfileHelp.Location = new System.Drawing.Point(179, 38);
			this.OptionsLastProfileHelp.Name = "OptionsLastProfileHelp";
			this.OptionsLastProfileHelp.Size = new System.Drawing.Size(13, 13);
			this.OptionsLastProfileHelp.TabIndex = 16;
			this.OptionsLastProfileHelp.Text = "?";
			this.OptionsLastProfileHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.OptionsLastProfileHelp.Click += new System.EventHandler(this.FrontendOptionsHelpLinkClicked);
			// 
			// OptionsExtHelp
			// 
			this.OptionsExtHelp.AutoSize = true;
			this.OptionsExtHelp.Cursor = System.Windows.Forms.Cursors.Help;
			this.OptionsExtHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OptionsExtHelp.ForeColor = System.Drawing.Color.SteelBlue;
			this.OptionsExtHelp.Location = new System.Drawing.Point(195, 15);
			this.OptionsExtHelp.Name = "OptionsExtHelp";
			this.OptionsExtHelp.Size = new System.Drawing.Size(13, 13);
			this.OptionsExtHelp.TabIndex = 15;
			this.OptionsExtHelp.Text = "?";
			this.OptionsExtHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.OptionsExtHelp.Click += new System.EventHandler(this.FrontendOptionsHelpLinkClicked);
			// 
			// OptionsFileExt
			// 
			this.OptionsFileExt.AutoSize = true;
			this.OptionsFileExt.Enabled = false;
			this.OptionsFileExt.Location = new System.Drawing.Point(6, 19);
			this.OptionsFileExt.Name = "OptionsFileExt";
			this.OptionsFileExt.Size = new System.Drawing.Size(197, 17);
			this.OptionsFileExt.TabIndex = 0;
			this.OptionsFileExt.Text = "Register .psf1/.psf2 file extensions";
			this.OptionsFileExt.UseVisualStyleBackColor = true;
			// 
			// OptionsLastProfile
			// 
			this.OptionsLastProfile.AutoSize = true;
			this.OptionsLastProfile.Checked = true;
			this.OptionsLastProfile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.OptionsLastProfile.Location = new System.Drawing.Point(6, 42);
			this.OptionsLastProfile.Name = "OptionsLastProfile";
			this.OptionsLastProfile.Size = new System.Drawing.Size(180, 17);
			this.OptionsLastProfile.TabIndex = 4;
			this.OptionsLastProfile.Text = "Remember last selected profile";
			this.OptionsLastProfile.UseVisualStyleBackColor = true;
			// 
			// Seperator2
			// 
			this.Seperator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Seperator2.Location = new System.Drawing.Point(209, 16);
			this.Seperator2.Name = "Seperator2";
			this.Seperator2.Size = new System.Drawing.Size(2, 44);
			this.Seperator2.TabIndex = 5;
			// 
			// OptionsFileVerify
			// 
			this.OptionsFileVerify.AutoSize = true;
			this.OptionsFileVerify.Checked = true;
			this.OptionsFileVerify.CheckState = System.Windows.Forms.CheckState.Checked;
			this.OptionsFileVerify.Location = new System.Drawing.Point(217, 19);
			this.OptionsFileVerify.Name = "OptionsFileVerify";
			this.OptionsFileVerify.Size = new System.Drawing.Size(191, 17);
			this.OptionsFileVerify.TabIndex = 3;
			this.OptionsFileVerify.Text = "Verify emulator .exe files on save";
			this.OptionsFileVerify.UseVisualStyleBackColor = true;
			this.OptionsFileVerify.CheckedChanged += new System.EventHandler(this.OptionsFileVerifyCheckedChanged);
			// 
			// OptionsToolbarLabel
			// 
			this.OptionsToolbarLabel.AutoSize = true;
			this.OptionsToolbarLabel.Location = new System.Drawing.Point(217, 43);
			this.OptionsToolbarLabel.Name = "OptionsToolbarLabel";
			this.OptionsToolbarLabel.Size = new System.Drawing.Size(76, 13);
			this.OptionsToolbarLabel.TabIndex = 7;
			this.OptionsToolbarLabel.Text = "Toolbar Style:";
			// 
			// ToolbarStyleList
			// 
			this.ToolbarStyleList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ToolbarStyleList.FormattingEnabled = true;
			this.ToolbarStyleList.Location = new System.Drawing.Point(296, 40);
			this.ToolbarStyleList.MaxDropDownItems = 3;
			this.ToolbarStyleList.Name = "ToolbarStyleList";
			this.ToolbarStyleList.Size = new System.Drawing.Size(110, 21);
			this.ToolbarStyleList.TabIndex = 6;
			// 
			// OptionsSaveButton
			// 
			this.OptionsSaveButton.Location = new System.Drawing.Point(276, 246);
			this.OptionsSaveButton.Name = "OptionsSaveButton";
			this.OptionsSaveButton.Size = new System.Drawing.Size(75, 23);
			this.OptionsSaveButton.TabIndex = 4;
			this.OptionsSaveButton.Text = "Save";
			this.OptionsSaveButton.UseVisualStyleBackColor = true;
			this.OptionsSaveButton.Click += new System.EventHandler(this.OptionsSaveButtonClick);
			// 
			// OptionsCancelButton
			// 
			this.OptionsCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.OptionsCancelButton.Location = new System.Drawing.Point(357, 246);
			this.OptionsCancelButton.Name = "OptionsCancelButton";
			this.OptionsCancelButton.Size = new System.Drawing.Size(75, 23);
			this.OptionsCancelButton.TabIndex = 3;
			this.OptionsCancelButton.Text = "Cancel";
			this.OptionsCancelButton.UseVisualStyleBackColor = true;
			// 
			// OptionsDefaultsButton
			// 
			this.OptionsDefaultsButton.Location = new System.Drawing.Point(12, 246);
			this.OptionsDefaultsButton.Name = "OptionsDefaultsButton";
			this.OptionsDefaultsButton.Size = new System.Drawing.Size(99, 23);
			this.OptionsDefaultsButton.TabIndex = 5;
			this.OptionsDefaultsButton.Text = "Restore Defaults";
			this.OptionsDefaultsButton.UseVisualStyleBackColor = true;
			this.OptionsDefaultsButton.Click += new System.EventHandler(this.OptionsDefaultsButtonClick);
			// 
			// OptionsEpsxeMiscContainer
			// 
			this.OptionsEpsxeMiscContainer.BackColor = System.Drawing.Color.Transparent;
			this.OptionsEpsxeMiscContainer.Controls.Add(this.OptionsPpfHelp);
			this.OptionsEpsxeMiscContainer.Controls.Add(this.OptionsLoggingHelp);
			this.OptionsEpsxeMiscContainer.Controls.Add(this.OptionsEpsxeLogging);
			this.OptionsEpsxeMiscContainer.Controls.Add(this.Seperator1);
			this.OptionsEpsxeMiscContainer.Controls.Add(this.OptionsEpsxePpf);
			this.OptionsEpsxeMiscContainer.Location = new System.Drawing.Point(12, 125);
			this.OptionsEpsxeMiscContainer.Name = "OptionsEpsxeMiscContainer";
			this.OptionsEpsxeMiscContainer.Size = new System.Drawing.Size(420, 42);
			this.OptionsEpsxeMiscContainer.TabIndex = 6;
			this.OptionsEpsxeMiscContainer.TabStop = false;
			this.OptionsEpsxeMiscContainer.Text = "ePSXe Misc.";
			// 
			// OptionsPpfHelp
			// 
			this.OptionsPpfHelp.AutoSize = true;
			this.OptionsPpfHelp.Cursor = System.Windows.Forms.Cursors.Help;
			this.OptionsPpfHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OptionsPpfHelp.ForeColor = System.Drawing.Color.SteelBlue;
			this.OptionsPpfHelp.Location = new System.Drawing.Point(392, 15);
			this.OptionsPpfHelp.Name = "OptionsPpfHelp";
			this.OptionsPpfHelp.Size = new System.Drawing.Size(13, 13);
			this.OptionsPpfHelp.TabIndex = 16;
			this.OptionsPpfHelp.Text = "?";
			this.OptionsPpfHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.OptionsPpfHelp.Click += new System.EventHandler(this.FrontendOptionsHelpLinkClicked);
			// 
			// OptionsLoggingHelp
			// 
			this.OptionsLoggingHelp.AutoSize = true;
			this.OptionsLoggingHelp.Cursor = System.Windows.Forms.Cursors.Help;
			this.OptionsLoggingHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OptionsLoggingHelp.ForeColor = System.Drawing.Color.SteelBlue;
			this.OptionsLoggingHelp.Location = new System.Drawing.Point(98, 15);
			this.OptionsLoggingHelp.Name = "OptionsLoggingHelp";
			this.OptionsLoggingHelp.Size = new System.Drawing.Size(13, 13);
			this.OptionsLoggingHelp.TabIndex = 15;
			this.OptionsLoggingHelp.Text = "?";
			this.OptionsLoggingHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.OptionsLoggingHelp.Click += new System.EventHandler(this.FrontendOptionsHelpLinkClicked);
			// 
			// OptionsEpsxeLogging
			// 
			this.OptionsEpsxeLogging.AutoSize = true;
			this.OptionsEpsxeLogging.Location = new System.Drawing.Point(6, 19);
			this.OptionsEpsxeLogging.Name = "OptionsEpsxeLogging";
			this.OptionsEpsxeLogging.Size = new System.Drawing.Size(99, 17);
			this.OptionsEpsxeLogging.TabIndex = 0;
			this.OptionsEpsxeLogging.Text = "Enable logging";
			this.OptionsEpsxeLogging.UseVisualStyleBackColor = true;
			// 
			// Seperator1
			// 
			this.Seperator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Seperator1.Location = new System.Drawing.Point(209, 16);
			this.Seperator1.Name = "Seperator1";
			this.Seperator1.Size = new System.Drawing.Size(2, 19);
			this.Seperator1.TabIndex = 8;
			// 
			// OptionsEpsxePpf
			// 
			this.OptionsEpsxePpf.AutoSize = true;
			this.OptionsEpsxePpf.Checked = true;
			this.OptionsEpsxePpf.CheckState = System.Windows.Forms.CheckState.Checked;
			this.OptionsEpsxePpf.Location = new System.Drawing.Point(217, 19);
			this.OptionsEpsxePpf.Name = "OptionsEpsxePpf";
			this.OptionsEpsxePpf.Size = new System.Drawing.Size(183, 17);
			this.OptionsEpsxePpf.TabIndex = 9;
			this.OptionsEpsxePpf.Text = "Automatically load PPF patches";
			this.OptionsEpsxePpf.UseVisualStyleBackColor = true;
			// 
			// FrontendOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.OptionsCancelButton;
			this.ClientSize = new System.Drawing.Size(444, 281);
			this.Controls.Add(this.OptionsLocationsContainer);
			this.Controls.Add(this.OptionsEpsxeMiscContainer);
			this.Controls.Add(this.OptionsMiscContainer);
			this.Controls.Add(this.OptionsDefaultsButton);
			this.Controls.Add(this.OptionsSaveButton);
			this.Controls.Add(this.OptionsCancelButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrontendOptions";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Frontend Options";
			this.Load += new System.EventHandler(this.FrontendOptionsLoad);
			this.OptionsLocationsContainer.ResumeLayout(false);
			this.OptionsLocationsContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.OptionsProfilesStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.OptionsEpsxeStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.OptionsPcsx2Status)).EndInit();
			this.OptionsMiscContainer.ResumeLayout(false);
			this.OptionsMiscContainer.PerformLayout();
			this.OptionsEpsxeMiscContainer.ResumeLayout(false);
			this.OptionsEpsxeMiscContainer.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox OptionsLocationsContainer;
		private System.Windows.Forms.Label OptionsPcsx2Label;
		private System.Windows.Forms.TextBox OptionsPcsx2Textbox;
		private System.Windows.Forms.Label OptionsEpsxeLabel;
		private System.Windows.Forms.TextBox OptionsEpsxeTextbox;
		private System.Windows.Forms.Label OptionsProfilesLabel;
		private System.Windows.Forms.TextBox OptionsProfilesTextbox;
		private System.Windows.Forms.Button OptionsPcsx2Browse;
		private System.Windows.Forms.Button OptionsEpsxeBrowse;
		private System.Windows.Forms.Button OptionsProfilesBrowse;
		private System.Windows.Forms.GroupBox OptionsMiscContainer;
		private System.Windows.Forms.Button OptionsSaveButton;
		private System.Windows.Forms.Button OptionsCancelButton;
		private System.Windows.Forms.Label Seperator2;
		private System.Windows.Forms.Button OptionsDefaultsButton;
		internal System.Windows.Forms.PictureBox OptionsProfilesStatus;
		internal System.Windows.Forms.PictureBox OptionsPcsx2Status;
		internal System.Windows.Forms.PictureBox OptionsEpsxeStatus;
		private System.Windows.Forms.Label OptionsToolbarLabel;
		private System.Windows.Forms.GroupBox OptionsEpsxeMiscContainer;
		private System.Windows.Forms.Label Seperator1;
		private System.Windows.Forms.CheckBox OptionsFileExt;
		private System.Windows.Forms.CheckBox OptionsFileVerify;
		private System.Windows.Forms.CheckBox OptionsLastProfile;
		private System.Windows.Forms.ComboBox ToolbarStyleList;
		private System.Windows.Forms.CheckBox OptionsEpsxePpf;
		private System.Windows.Forms.CheckBox OptionsEpsxeLogging;
		private System.Windows.Forms.Label OptionsProfilesHelp;
		private System.Windows.Forms.Label OptionsPcsx2Help;
		private System.Windows.Forms.Label OptionsEpsxeHelp;
		private System.Windows.Forms.Label OptionsToolbarHelp;
		private System.Windows.Forms.Label OptionsVerifyHelp;
		private System.Windows.Forms.Label OptionsLastProfileHelp;
		private System.Windows.Forms.Label OptionsExtHelp;
		private System.Windows.Forms.Label OptionsPpfHelp;
		private System.Windows.Forms.Label OptionsLoggingHelp;
	}
}