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

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PSf.Classes;
using PSf.Properties;

namespace PSf.GUI
{
	internal partial class FrontendOptions : Form
	{
		internal static bool ProfileOptionChanged;
		internal static bool EpsxeOptionChanged;
		private readonly Image _errorstatus = Resources.statuserror;
		private readonly Image _goodstatus = Resources.statusgood;
		//internal static bool Pcsx2OptionChanged;
		private readonly MainWindow _mainWindow;
		private readonly string[] _styles = {"Icons + Text", "Icons Only", "Text Only"};
		private readonly Image _warningstatus = Resources.statuswarning;

		internal FrontendOptions(MainWindow mainWindow)
		{
			_mainWindow = mainWindow;
			InitializeComponent();
		}

		private void FrontendOptionsLoad(object sender, EventArgs e)
		{
			ToolbarStyleList.Items.AddRange(_styles);

			BackgroundImage = Resources.settingsbg;
			BackgroundImageLayout = ImageLayout.Center;

			OptionsProfilesTextbox.Text = XmlAccess.ReadSettings("Profiles");
			OptionsEpsxeTextbox.Text = XmlAccess.ReadSettings("ePSXe");
			OptionsPcsx2Textbox.Text = XmlAccess.ReadSettings("PCSX2");
			OptionsEpsxeLogging.Checked = Convert.ToBoolean(XmlAccess.ReadSettings("Logging"));
			OptionsEpsxePpf.Checked = Convert.ToBoolean(XmlAccess.ReadSettings("AutoPPF"));
			OptionsLastProfile.Checked = Convert.ToBoolean(XmlAccess.ReadSettings("LastProfileAttribute"));
			OptionsFileVerify.Checked = Convert.ToBoolean(XmlAccess.ReadSettings("FileVerify"));
			ToolbarStyleList.SelectedItem = XmlAccess.ReadSettings("ToolbarStyle");
		}

		private void OptionsProfilesTextboxTextChanged(object sender, EventArgs e)
		{
			OptionsProfilesStatus.Image = Directory.Exists(OptionsProfilesTextbox.Text) ? _goodstatus : _errorstatus;
		}

		private void OptionsProfilesBrowseClick(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				fbd.ShowNewFolderButton = true;
				fbd.Description = @"Please choose a directory to place your profiles:";
				fbd.RootFolder = Environment.SpecialFolder.MyComputer;

				if (fbd.ShowDialog() == DialogResult.OK)
				{
					OptionsProfilesTextbox.Text = fbd.SelectedPath;
				}
			}
		}

		private void OptionsEpsxeTextboxTextChanged(object sender, EventArgs e)
		{
			if (File.Exists(OptionsEpsxeTextbox.Text) &&
			    OptionsFileVerify.Checked &&
			    FileChecksum.VerifyChecksum(FileChecksum.CalculateChecksum(OptionsEpsxeTextbox.Text)))
			{
				OptionsEpsxeStatus.Image = _goodstatus;
			}
			else if (File.Exists(OptionsEpsxeTextbox.Text) &&
			         OptionsFileVerify.Checked &&
			         FileChecksum.VerifyChecksum(FileChecksum.CalculateChecksum(OptionsEpsxeTextbox.Text)) == false)
			{
				OptionsEpsxeStatus.Image = _warningstatus;
			}
			else if (File.Exists(OptionsEpsxeTextbox.Text) &&
			         OptionsFileVerify.Checked == false)
			{
				OptionsEpsxeStatus.Image = _goodstatus;
			}
			else
			{
				OptionsEpsxeStatus.Image = _errorstatus;
			}
		}

		private void OptionsEpsxeBrowseClick(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
			{
				ofd.AutoUpgradeEnabled = true;
				ofd.CheckFileExists = true;
				ofd.CheckPathExists = true;
				ofd.Filter = @"ePSXe (ePSXe*.exe)|ePSXe*.exe";
				ofd.InitialDirectory = @"C:\";

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					OptionsEpsxeTextbox.Text = ofd.FileName;
				}
			}
		}

		private void OptionsPcsx2TextboxTextChanged(object sender, EventArgs e)
		{
			if (File.Exists(OptionsPcsx2Textbox.Text) &&
			    OptionsFileVerify.Checked &&
			    FileChecksum.VerifyChecksum(FileChecksum.CalculateChecksum(OptionsPcsx2Textbox.Text)))
			{
				OptionsPcsx2Status.Image = _goodstatus;
			}
			else if (File.Exists(OptionsPcsx2Textbox.Text) &&
			         OptionsFileVerify.Checked &&
			         FileChecksum.VerifyChecksum(FileChecksum.CalculateChecksum(OptionsPcsx2Textbox.Text)) == false)
			{
				OptionsPcsx2Status.Image = _warningstatus;
			}
			else if (File.Exists(OptionsPcsx2Textbox.Text) &&
			         OptionsFileVerify.Checked == false)
			{
				OptionsPcsx2Status.Image = _goodstatus;
			}
			else
			{
				OptionsPcsx2Status.Image = _errorstatus;
			}
		}

		private void OptionsPcsx2BrowseClick(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
			{
				ofd.AutoUpgradeEnabled = true;
				ofd.CheckFileExists = true;
				ofd.CheckPathExists = true;
				ofd.Filter = @"PCSX2 (PCSX2*.exe)|PCSX2*.exe";
				ofd.InitialDirectory = @"C:\";

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					OptionsPcsx2Textbox.Text = ofd.FileName;
				}
			}
		}

		private void OptionsFileVerifyCheckedChanged(object sender, EventArgs e)
		{
			OptionsEpsxeTextboxTextChanged(null, null);
			OptionsPcsx2TextboxTextChanged(null, null);
		}

		private void OptionsDefaultsButtonClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to restore these options back to their " +
			                    "default state? Registered file extensions and profiles will not " +
			                    "be affected.\n\n" +
			                    "WARNING: This will overwrite any previously saved options in " +
			                    "the settings file. Continue?",
			                    "Restore Option Defaults", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
			    == DialogResult.Yes)
			{
				OptionsProfilesTextbox.Text = "";
				OptionsEpsxeTextbox.Text = "";
				OptionsPcsx2Textbox.Text = "";
				OptionsEpsxeLogging.Checked = false;
				OptionsEpsxePpf.Checked = true;
				OptionsLastProfile.Checked = true;
				OptionsFileVerify.Checked = true;
				ToolbarStyleList.SelectedIndex = 0;

				try
				{
					XmlAccess.WriteSettings("Profiles", OptionsProfilesTextbox.Text);
					XmlAccess.WriteSettings("ePSXe", OptionsEpsxeTextbox.Text);
					XmlAccess.WriteSettings("PCSX2", OptionsPcsx2Textbox.Text);
					XmlAccess.WriteSettings("Logging", OptionsEpsxeLogging.Checked.ToString());
					XmlAccess.WriteSettings("AutoPPF", OptionsEpsxePpf.Checked.ToString());
					XmlAccess.WriteSettings("LastProfileAttribute", OptionsLastProfile.Checked.ToString());
					XmlAccess.WriteSettings("FileVerify", OptionsFileVerify.Checked.ToString());
					XmlAccess.WriteSettings("ToolbarStyle", ToolbarStyleList.SelectedIndex.ToString());
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
		}

		private void OptionsSaveButtonClick(object sender, EventArgs e)
		{
			//Check for changes
			if (OptionsProfilesStatus.Image == _goodstatus && (OptionsEpsxeStatus.Image == _goodstatus ||
			                                                   OptionsPcsx2Status.Image == _goodstatus))
			{
				if (XmlAccess.ReadSettings("Profiles") == OptionsProfilesTextbox.Text)
				{
					ProfileOptionChanged = false;
				}
				else
				{
					ProfileOptionChanged = true;
					XmlAccess.WriteSettings("Profiles", OptionsProfilesTextbox.Text);
				}

				if (XmlAccess.ReadSettings("ePSXe") == OptionsEpsxeTextbox.Text)
				{
					EpsxeOptionChanged = false;
				}
				else
				{
					EpsxeOptionChanged = true;
					XmlAccess.WriteSettings("ePSXe", OptionsEpsxeTextbox.Text);
				}

				//if (XmlIo.ReadSettings("PCSX2") == OptionsPcsx2Textbox.Text)
				//{
				//    Pcsx2OptionChanged = false;
				//}
				//else
				//{
				//    Pcsx2OptionChanged = true;
				//    XmlIo.WriteSettings("PCSX2", OptionsPcsx2Textbox.Text);
				//}

				XmlAccess.WriteSettings("Logging", OptionsEpsxeLogging.Checked.ToString());
				XmlAccess.WriteSettings("AutoPPF", OptionsEpsxePpf.Checked.ToString());
				XmlAccess.WriteSettings("LastProfileAttribute", Convert.ToString(OptionsLastProfile.Checked));
				XmlAccess.WriteSettings("VerifyFile", Convert.ToString(OptionsFileVerify.Checked));
				XmlAccess.WriteSettings("ToolbarStyle", Convert.ToString(ToolbarStyleList.SelectedItem));

				XmlAccess.WriteSettingsSave();

				_mainWindow.ChangeStyle(ToolbarStyleList.SelectedItem.ToString());

				Close();
			}
			else
			{
				MessageBox.Show("The profile directory and at least one emulator must be set in order to continue.",
				                "Required Settings",
				                MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void FrontendOptionsHelpLinkClicked(object sender, EventArgs e)
		{
			MessageBox.Show(HelpStore.GetHelpTips(((Control) sender).Name), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}