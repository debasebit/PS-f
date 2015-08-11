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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PSf.Classes;
using PSf.GUI.Help;
using PSf.Properties;

namespace PSf.GUI
{
	internal partial class MainWindow : Form
	{
		private readonly EpsxeTabControl _mainEpsxeTab;
		//private readonly Pcsx2TabControl _mainPcsx2Tab;

		internal MainWindow()
		{
			InitializeComponent();

			//if (ProfileListMenu.ComboBox != null)
			//	ProfileListMenu.ComboBox.MouseWheel += ProfileListMenuMouseWheel; //Prevents multiple BackgroundWorker instances as a result of quick scrolling

			if (File.Exists(RegistryAccess.TempRegFile)) //Cleans up any previously undeleted temp files
			{
				File.Delete(RegistryAccess.TempRegFile);
			}

			#region Creates a settings file

			if (!Directory.Exists(XmlAccess.SettingsDir))
			{
				Directory.CreateDirectory(XmlAccess.SettingsDir);
			}

			if (!File.Exists(XmlAccess.SettingsFile))
			{
				XmlAccess.CreateSettings();
			}

			RegistryAccess.FirstRunKey();

			#endregion

			#region Sets up frontend/settings

			TabControlContainer.BackgroundImage = Resources.logobg;
			TabControlContainer.BackgroundImageLayout = ImageLayout.Center;

			XmlAccess.LoadSettingsToMemory();
			ChangeStyle(XmlAccess.ReadSettings("ToolbarStyle"));

			PopulateList.PopulateProfileListThread(this);

			while (PopulateList.PopProfile.IsBusy)
			{
				Application.DoEvents();
			}

			if (Convert.ToBoolean(XmlAccess.ReadSettings("LastProfileAttribute")) &&
			    XmlAccess.ReadSettings("LastProfile").Length > 0)
			{
				ProfileListMenu.SelectedItem = XmlAccess.ReadSettings("LastProfile");
			}

			#endregion

			_mainEpsxeTab = new EpsxeTabControl();
			//_mainPcsx2Tab = new Pcsx2TabControl();
			CheckProfileStatus();
		}

		#region Buttons

		private void NewProfileButtonClick(object sender, EventArgs e)
		{
			string profileDir = XmlAccess.ReadSettings("Profiles");

			switch (string.IsNullOrEmpty(profileDir) || !Directory.Exists(profileDir))
			{
				case true:
					MessageBox.Show("The profile directory has not been set. Please do so in the frontend options.",
					                "Profile Directory Not Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
					break;
				case false:
					using (var np = new NewProfile())
					{
						np.ShowDialog(this);
					}
					PopulateList.PopulateProfileListThread(this);
					while (PopulateList.PopProfile.IsBusy)
					{
						Application.DoEvents();
					}
					break;
			}
		}

		private void SaveProfileButtonClick(object sender, EventArgs e)
		{
			if (ProfileListMenu.Enabled)
			{
				#region Info

				XmlAccess.WriteInfo("Title", _mainEpsxeTab.ProfileInfoTitleText.Text);
				XmlAccess.WriteInfo("Developer", _mainEpsxeTab.ProfileInfoDevText.Text);
				XmlAccess.WriteInfo("Publisher", _mainEpsxeTab.ProfileInfoPubText.Text);
				XmlAccess.WriteInfo("Genre", _mainEpsxeTab.ProfileInfoGenreText.Text);
				XmlAccess.WriteInfo("Region", _mainEpsxeTab.ProfileInfoRegionText.Text);
				XmlAccess.WriteInfo("Disc", _mainEpsxeTab.ProfileInfoDiscText.Text);

				#endregion

				#region Plugins

				XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "BIOS",
				                       _mainEpsxeTab.BiosList.SelectedItem.ToString());

				XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "Graphics",
				                       _mainEpsxeTab.GpuList.SelectedItem.ToString());
				RegistryAccess.WritePluginSettingsToProfile(ProfileListMenu.SelectedItem.ToString(),
				                                            _mainEpsxeTab.GpuList.SelectedItem.ToString());

				XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "IntGraphics", string.Empty);
				RegistryAccess.WritePluginSettingsToProfile(ProfileListMenu.SelectedItem.ToString(), "IntGraphics");

				XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "Sound",
				                       _mainEpsxeTab.SpuList.SelectedItem.ToString());
				if (ProfileListMenu.SelectedItem.ToString() == "(Internal) ePSXe SPU Core v1.7")
				{
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "SoundSettings", string.Empty);
				}
				else
				{
					RegistryAccess.WritePluginSettingsToProfile(ProfileListMenu.SelectedItem.ToString(),
					                                            _mainEpsxeTab.SpuList.SelectedItem.ToString());
				}

				if (_mainEpsxeTab.CdRadioButton.Checked)
				{
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "DiscSelect",
					                       _mainEpsxeTab.CdRadioButton.Checked.ToString());
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "Disc",
					                       _mainEpsxeTab.CdList.SelectedItem.ToString());
					RegistryAccess.WritePluginSettingsToProfile(ProfileListMenu.SelectedItem.ToString(),
					                                            _mainEpsxeTab.CdList.SelectedItem.ToString());
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "ISOSelect",
					                       _mainEpsxeTab.IsoRadioButton.Checked.ToString());
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "ISO",
					                       string.Empty);
				}
				else
				{
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "DiscSelect",
					                       _mainEpsxeTab.CdRadioButton.Checked.ToString());
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "Disc",
					                       string.Empty);
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "DiscSettings",
					                       string.Empty);
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "ISOSelect",
					                       _mainEpsxeTab.IsoRadioButton.Checked.ToString());
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "ISO",
					                       _mainEpsxeTab.IsoPath.Text);
				}

				RegistryAccess.WritePluginSettingsToProfile(ProfileListMenu.SelectedItem.ToString(), "Pad");

				if (_mainEpsxeTab.Mem1ToggleCheckbox.Checked)
				{
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "MemoryCard1Select",
					                       _mainEpsxeTab.Mem1ToggleCheckbox.Checked.ToString());
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "MemoryCard1",
					                       _mainEpsxeTab.Mem1List.SelectedItem.ToString());
				}
				else
				{
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "MemoryCard1Select",
					                       _mainEpsxeTab.Mem1ToggleCheckbox.Checked.ToString());
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "MemoryCard1", string.Empty);
				}

				if (_mainEpsxeTab.Mem2ToggleCheckbox.Checked)
				{
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "MemoryCard2Select",
					                       _mainEpsxeTab.Mem2ToggleCheckbox.Checked.ToString());
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "MemoryCard2",
					                       _mainEpsxeTab.Mem2List.SelectedItem.ToString());
				}
				else
				{
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "MemoryCard2Select",
					                       _mainEpsxeTab.Mem2ToggleCheckbox.Checked.ToString());
					XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "MemoryCard2", string.Empty);
				}

				XmlAccess.WriteProfile(ProfileListMenu.SelectedItem.ToString(), "NetPlay",
				                       _mainEpsxeTab.NetList.SelectedItem.ToString());

				#endregion

				XmlAccess.WriteProfileSave(ProfileListMenu.SelectedItem.ToString());

				UpdateValues.ProfileInfo();

				RegistryAccess.WritePluginSettingsToRegistry(_mainEpsxeTab);

				CheckProfileStatus();
			}

			else
			{
				MessageBox.Show("A profile hasn't been created yet, so saving is meaningless.");
			}
		}

		private void DeleteProfileButtonClick(object sender, EventArgs e)
		{
			if (ProfileListMenu.Enabled)
			{
				if (MessageBox.Show("Please note that this action cannot be undone." +
				                    "\n\nAre you sure you want to delete this file?",
				                    "Delete Selected Profile", MessageBoxButtons.YesNo,
				                    MessageBoxIcon.Warning) != DialogResult.Yes) return;

				File.Delete(Path.Combine(XmlAccess.ReadSettings("Profiles"),
				                         ProfileListMenu.SelectedItem.ToString()));

				PopulateList.PopulateProfileListThread(this);
				while (PopulateList.PopProfile.IsBusy)
				{
					Application.DoEvents();
				}
			}
			else
			{
				MessageBox.Show("A profile hasn't been created yet, deleting nothing is like dividing by zero.");
			}
		}

		private void FrontendOptionsButtonClick(object sender, EventArgs e)
		{
			using (var fo = new FrontendOptions(this))
			{
				fo.ShowDialog(this);
			}
			if (FrontendOptions.ProfileOptionChanged)
			{
				PopulateList.PopulateProfileListThread(this);
				while (PopulateList.PopProfile.IsBusy)
				{
					Application.DoEvents();
				}
			}

			if (!FrontendOptions.EpsxeOptionChanged) return;
			UpdateValues.EpsxeDirectories();
			while (PopulateList.PopFound.IsBusy)
			{
				Application.DoEvents();
			}
		}

		private void AboutButtonClick(object sender, EventArgs e)
		{
			using (var aw = new AboutWindow())
			{
				aw.ShowDialog(this);
			}
		}

		private void RunProfileButtonClick(object sender, EventArgs e)
		{
			string arg;
			if (Convert.ToBoolean(XmlAccess.ReadProfile("ISOSelect")))
			{
				arg = "-nogui -loadiso " + "\"" + XmlAccess.ReadProfile("ISO") + "\"";
			}
			else
			{
				arg = "-nogui";
			}

			using (var proc = new Process())
			{
				proc.StartInfo.FileName = XmlAccess.ReadSettings("ePSXe");
				proc.StartInfo.Arguments = arg;
				proc.Start();
			}
		}

		private void RunBiosButtonClick(object sender, EventArgs e)
		{
			using (var proc = new Process())
			{
				proc.StartInfo.FileName = XmlAccess.ReadSettings("ePSXe");
				proc.StartInfo.Arguments = "-nogui -nocd -slowboot";
				proc.Start();
			}
		}

		#endregion

		#region Events

		private void ProfileListMenuSelectedIndexChanged(object sender, EventArgs e)
		{
			SelectTab();

			CheckProfileStatus();
		}

		private void MainWindowFormClosing(object sender, FormClosingEventArgs e)
		{
			if (Convert.ToBoolean(XmlAccess.ReadSettings("LastProfileAttribute")))
			{
				if (ProfileListMenu.SelectedItem.ToString().Contains("psf"))
				{
					XmlAccess.WriteSettings
						("LastProfile", ProfileListMenu.SelectedItem.ToString());
					XmlAccess.WriteSettingsSave();
				}
			}
			Application.Exit();
		}

		#endregion

		internal void SelectTab()
		{
			if (ProfileListMenu.Items.Count <= 0) return;
			if (ProfileListMenu.SelectedItem.ToString().Contains(".psf1") && File.Exists(XmlAccess.ReadSettings("ePSXe")))
			{
				XmlAccess.ReadProfileToMemory(Path.Combine(XmlAccess.ReadSettings("Profiles"),
				                                           ProfileListMenu.SelectedItem.ToString()));
				TabControlContainer.BackgroundImage = null;
				if (!TabControlContainer.Controls.Contains(_mainEpsxeTab))
				{
					TabControlContainer.Controls.Clear();
					TabControlContainer.Controls.Add(_mainEpsxeTab);
				}

				try
				{
					if (_mainEpsxeTab != null)
					{
						UpdateValues.ProfileInfo();
						UpdateValues.EpsxePlugins();
						RegistryAccess.WritePluginSettingsToRegistry(_mainEpsxeTab);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
				//else if (ProfileListMenu.SelectedItem.ToString().Contains(".psf2") && File.Exists(XmlIo.ReadSettings("PCSX2")))
				//{
				//    ProfileListMenu.Enabled = false;
				//    TabControlContainer.BackgroundImage = null;
				//    TabControlContainer.Controls.Clear();
				//    TabControlContainer.Controls.Add(_mainPcsx2Tab);
				//    //_mainPcsx2Tab.UpdateTabOnProfileSwitch();
				//}
			else
			{
				ProfileListMenu.Enabled = false;
				TabControlContainer.Controls.Clear();
				TabControlContainer.BackgroundImage = Resources.logobg;
			}
		}

		internal void ChangeStyle(string style)
		{
			switch (style)
			{
				case "Icons + Text":
					NewProfileButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
					SaveProfileButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
					DeleteProfileButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
					FrontendOptionsButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
					AboutButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
					RunProfileButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
					ProfileListMenu.Size = new Size(254, 25);
					break;

				case "Icons Only":
					NewProfileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
					SaveProfileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
					DeleteProfileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
					FrontendOptionsButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
					AboutButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
					RunProfileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
					ProfileListMenu.Size = new Size(568, 25);
					break;

				case "Text Only":
					NewProfileButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
					SaveProfileButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
					DeleteProfileButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
					FrontendOptionsButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
					AboutButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
					RunProfileButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
					ProfileListMenu.Size = new Size(351, 25);
					break;
			}
		}

		private void CheckProfileStatus()
		{
			if (XmlAccess.ReadProfile("BIOS").Length > 0 && XmlAccess.ReadProfile("Graphics").Length > 0 &&
			    XmlAccess.ReadProfile("Sound").Length > 0 &&
			    (XmlAccess.ReadProfile("Disc").Length > 0 || XmlAccess.ReadProfile("ISO").Length > 0))
			{
				ProfileStatusIcon.Image = Resources.statusgood;
			}
			else
			{
				ProfileStatusIcon.Image = Resources.statuserror;
			}
		}
	}
}