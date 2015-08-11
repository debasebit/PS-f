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
using System.IO;
using System.Windows.Forms;
using PSf.Classes;
using PSf.Properties;

namespace PSf.GUI
{
	internal partial class EpsxeTabControl : UserControl
	{
		private readonly ImageList _il = new ImageList();

		internal EpsxeTabControl()
		{
			InitializeComponent();

			#region Set up tab designs

			_il.ColorDepth = ColorDepth.Depth32Bit;
			_il.Images.Add("bios", Resources.bios);
			_il.Images.Add("cd", Resources.cd);
			_il.Images.Add("gpu", Resources.gpu);
			_il.Images.Add("mem", Resources.mem);
			_il.Images.Add("net", Resources.net);
			_il.Images.Add("pad", Resources.pad);
			_il.Images.Add("profile", Resources.profile);
			_il.Images.Add("sound", Resources.sound);

			EpsxeTabsCollection.ImageList = _il;

			EpsxeProfileTab.ImageKey = "profile";

			EpsxeBiosTab.ImageKey = "bios";


			EpsxeGpuTab.ImageKey = "gpu";
			EpsxeSpuTab.ImageKey = "sound";
			EpsxeCdIsoTab.ImageKey = "cd";
			EpsxePadTab.ImageKey = "pad";
			EpsxeMemTab.ImageKey = "mem";
			EpsxeNetTab.ImageKey = "net";

			#endregion

			UpdateValues.InitEpsxeControl(this);

			#region Help Info

			BiosHelpText.Text = HelpStore.GetHelpTips("BIOSHelp");

			switch (XmlAccess.ReadProfile("Graphics"))
			{
				case "Pete's OpenGL2 Driver v2.9":
					GpuHelpText.Text = HelpStore.GetHelpTips("OpenGL2Help");
					break;

				case "P.E.Op.S. OpenGL Driver v1.78":
					GpuHelpText.Text = HelpStore.GetHelpTips("OpenGLHelp");
					break;

				case "P.E.Op.S. Soft Driver v1.18":
					GpuHelpText.Text = HelpStore.GetHelpTips("SoftHelp");
					break;

				default:
					GpuHelpText.Text = HelpStore.GetHelpTips("GPUDefault");
					break;
			}

			switch (XmlAccess.ReadProfile("Sound"))
			{
				case "(Internal) ePSXe SPU Core v1.7":
					SpuHelpText.Text = HelpStore.GetHelpTips("InternalSPU");
					break;

				case "Eternal SPU Plugin v1.5":
					SpuHelpText.Text = HelpStore.GetHelpTips("Eternal");
					break;

				case "P.E.Op.S DSound Audio Driver v1.9":
					SpuHelpText.Text = HelpStore.GetHelpTips("PeopsSPU");
					break;

				case "P.E.Op.S. Sound Audio Driver v1.10":
					SpuHelpText.Text = HelpStore.GetHelpTips("PeopsSPUNew");
					break;

				default:
					SpuHelpText.Text = HelpStore.GetHelpTips("SPUDefault");
					break;
			}

			switch (XmlAccess.ReadProfile("Disc"))
			{
				case "(Internal) ePSXe CDR Core v1.7":
					CdIsoHelpText.Text = HelpStore.GetHelpTips("InternalCD");
					break;

				case "P.E.Op.S. CDR Driver v1.4":
					CdIsoHelpText.Text = HelpStore.GetHelpTips("PeopsCD");
					break;

				case "SaPu's CD-ROM Plugin v1.3":
					CdIsoHelpText.Text = HelpStore.GetHelpTips("Sapu");
					break;

				default:
					CdIsoHelpText.Text = HelpStore.GetHelpTips("CDISODefault");
					break;
			}

			PadHelpText.Text = HelpStore.GetHelpTips("PSPad");

			MemHelpText.Text = HelpStore.GetHelpTips("PSMem");

			NetHelpText.Text = HelpStore.GetHelpTips("NetDefault");

			#endregion

			if (!File.Exists(XmlAccess.ReadSettings("ePSXe"))) return;

			UpdateValues.EpsxeDirectories();
		}

		#region GPU

		private void GpuConfigButtonClick(object sender, EventArgs e)
		{
			NativeMethods.PluginFunction(PopulateList.GpuFilePaths[GpuList.SelectedIndex].ToString(), "GPUconfigure");
		}

		private void GpuAboutButtonClick(object sender, EventArgs e)
		{
			NativeMethods.PluginFunction(PopulateList.GpuFilePaths[GpuList.SelectedIndex].ToString(), "GPUabout");
		}

		private void GpuListSelectedIndexChanged(object sender, EventArgs e)
		{
			switch (GpuList.SelectedItem.ToString())
			{
				case "Pete's OpenGL2 Driver v2.9":
					GpuHelpText.Text = HelpStore.GetHelpTips("OpenGL2Help");
					break;

				case "P.E.Op.S. OpenGL Driver v1.78":
					GpuHelpText.Text = HelpStore.GetHelpTips("OpenGLHelp");
					break;

				case "P.E.Op.S. Soft Driver v1.18":
					GpuHelpText.Text = HelpStore.GetHelpTips("SoftHelp");
					break;

				default:
					GpuHelpText.Text = "No information is available at this moment.";
					break;
			}
		}

		private void GpuReadMoreClick(object sender, EventArgs e)
		{
			switch (GpuList.SelectedItem.ToString())
			{
					//case "Pete's OpenGL2 Driver v2.9":
					//    var ghw = new GpuHelpWindow();
					//    ghw.label1.Text = HelpStore.GetHelpTips("OpenGL2HelpMore");
					//    ghw.Show();
					//    break;

					//case "P.E.Op.S. OpenGL Driver v1.78":
					//    MessageBox.Show("Coming Soon...");
					//    break;

					//case "P.E.Op.S. Soft Driver v1.18":
					//    MessageBox.Show("Coming Soon...");
					//    break;

				default:
					MessageBox.Show("More information is coming soon...");
					break;
			}
		}

		#endregion

		#region Intenal GPU

		private void Gpu2ConfigButtonClick(object sender, EventArgs e)
		{
			NativeMethods.PluginFunction(XmlAccess.EpsxePluginDir + @"\gpu.dat", "GPUconfigure");
		}

		private void Gpu2AboutButtonClick(object sender, EventArgs e)
		{
			NativeMethods.PluginFunction(XmlAccess.EpsxePluginDir + @"\gpu.dat", "GPUabout");
		}

		#endregion

		#region SPU

		internal void CheckCurrentSpuSelection()
		{
			if (SpuList.SelectedItem.ToString().Contains("(Internal)"))
			{
				SpuConfigButton.Enabled = false;
				SpuAboutButton.Enabled = false;
			}
			else
			{
				SpuConfigButton.Enabled = true;
				SpuAboutButton.Enabled = true;
			}
		}

		private void SpuListSelectedIndexChanged(object sender, EventArgs e)
		{
			CheckCurrentSpuSelection();
			switch (SpuList.SelectedItem.ToString())
			{
				case "(Internal) ePSXe SPU Core v1.7":
					SpuHelpText.Text = HelpStore.GetHelpTips("InternalSPU");
					break;

				case "Eternal SPU Plugin v1.5":
					SpuHelpText.Text = HelpStore.GetHelpTips("Eternal");
					break;

				case "P.E.Op.S. DSound Audio Driver v1.9":
					SpuHelpText.Text = HelpStore.GetHelpTips("PeopsSPU");
					break;

				case "P.E.Op.S. Sound Audio Driver v1.10":
					SpuHelpText.Text = HelpStore.GetHelpTips("PeopsSPUNew");
					break;

				default:
					SpuHelpText.Text = HelpStore.GetHelpTips("SPUDefault");
					break;
			}
		}

		private void SpuConfigButtonClick(object sender, EventArgs e)
		{
			int i = SpuList.SelectedIndex;
			NativeMethods.PluginFunction(PopulateList.SpuFilePaths[i - 1].ToString(), "SPUconfigure");
		}

		private void SpuAboutButtonClick(object sender, EventArgs e)
		{
			int i = SpuList.SelectedIndex;
			NativeMethods.PluginFunction(PopulateList.SpuFilePaths[i - 1].ToString(), "SPUabout");
		}

		#endregion

		#region CD/ISO

		private void CdRadioButtonCheckedChanged(object sender, EventArgs e)
		{
			switch (CdRadioButton.Checked)
			{
				case true:
					CdLocationText.Enabled = true;
					CdList.Enabled = true;
					CdConfigButton.Enabled = true;
					CdAboutButton.Enabled = true;
					IsoPath.Enabled = false;
					IsoBrowse.Enabled = false;
					break;

				case false:
					CdLocationText.Enabled = false;
					CdList.Enabled = false;
					CdConfigButton.Enabled = false;
					CdAboutButton.Enabled = false;
					IsoPath.Enabled = true;
					IsoBrowse.Enabled = true;
					break;
			}

			CdIsoHelpText.Text = HelpStore.GetHelpTips("CDISODefault");
		}

		internal void CheckCurrentCdSelection()
		{
			CdAboutButton.Enabled = !CdList.SelectedItem.ToString().Contains("(Internal)");
		}

		private void CdListSelectedIndexChanged(object sender, EventArgs e)
		{
			CheckCurrentCdSelection();
			switch (CdList.SelectedItem.ToString())
			{
				case "(Internal) ePSXe CDR Core v1.7":
					CdIsoHelpText.Text = HelpStore.GetHelpTips("InternalCD");
					break;

				case "P.E.Op.S. CDR Driver v1.4":
					CdIsoHelpText.Text = HelpStore.GetHelpTips("PeopsCD");
					break;

				case "SaPu's CD-ROM Plugin v1.3":
					CdIsoHelpText.Text = HelpStore.GetHelpTips("Sapu");
					break;

				default:
					CdIsoHelpText.Text = HelpStore.GetHelpTips("CDISODefault");
					break;
			}
		}

		private void CdIsoConfigButtonClick(object sender, EventArgs e)
		{
			try
			{
				int i = CdList.SelectedIndex;
				NativeMethods.PluginFunction(PopulateList.CdFilePaths[i - 1].ToString(), "CDRconfigure");
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Config window here");
			}
		}

		private void CdIsoAboutButtonClick(object sender, EventArgs e)
		{
			try
			{
				int i = CdList.SelectedIndex;
				NativeMethods.PluginFunction(PopulateList.CdFilePaths[i - 1].ToString(), "CDRabout");
			}
			catch (ArgumentOutOfRangeException)
			{
			}
		}

		private void IsoBrowseClick(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
			{
				ofd.InitialDirectory = Environment.SpecialFolder.MyComputer.ToString();
				ofd.AutoUpgradeEnabled = true;
				ofd.Title = "Browse for Images";
				ofd.Filter = "Supported Images|*.cue;*.bin;*.iso;*.ccd;*.img;*.mds";

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					IsoPath.Text = ofd.FileName;
				}
			}
		}

		#endregion

		#region Gamepads

		private void PadButtonClick(object sender, EventArgs e)
		{
			if ((MessageBox.Show("Gamepad configuration will be implemented in the near future,"+
			" for now, ePSXe will open and you can configure it there. To configure it, go to Config ->"+
			" Game Pad -> Port 1/2 -> Pad 1\n\nRemember to 'Save Profile' when finished to keep your "+
			"settings\n\n Continue to ePSXe?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
			{
				Process.Start(XmlAccess.ReadSettings("ePSXe"));
			}
		}

		#endregion

		#region Memory Cards

		private void Mem1ToggleCheckboxCheckedChanged(object sender, EventArgs e)
		{
			Mem1List.Enabled = Mem1ToggleCheckbox.Checked;
			Mem1Button.Enabled = Mem1ToggleCheckbox.Checked;
		}

		private void Mem2ToggleCheckboxCheckedChanged(object sender, EventArgs e)
		{
			Mem2List.Enabled = Mem2ToggleCheckbox.Checked;
			Mem2Button.Enabled = Mem2ToggleCheckbox.Checked;
		}

		#endregion

		#region NetPlay

		internal void CheckCurrentNetSelection()
		{
			if (NetList.SelectedItem.ToString().Contains("Disabled"))
			{
				NetConfigButton.Enabled = false;
				NetAboutButton.Enabled = false;
			}
			else
			{
				NetConfigButton.Enabled = true;
				NetAboutButton.Enabled = true;
			}
		}

		private void NetListSelectedIndexChanged(object sender, EventArgs e)
		{
			CheckCurrentNetSelection();
		}

		private void NetConfigButtonClick(object sender, EventArgs e)
		{
			int i = NetList.SelectedIndex;
			NativeMethods.PluginFunction(PopulateList.NetFilePaths[i - 1].ToString(), "NETconfigure");
		}

		private void NetAboutButtonClick(object sender, EventArgs e)
		{
			int i = NetList.SelectedIndex;
			NativeMethods.PluginFunction(PopulateList.NetFilePaths[i - 1].ToString(), "NETabout");
		}

		#endregion

		private void CdMoreHelpLinkClick(object sender, EventArgs e)
		{
			MessageBox.Show("More information soon...");
		}

		private void PadMoreHelpLinkClick(object sender, EventArgs e)
		{
			MessageBox.Show("More information soon...");
		}

		private void MemMoreHelpLinkClick(object sender, EventArgs e)
		{
			MessageBox.Show("More information soon...");
		}

		private void NetMoreHelpLinkClick(object sender, EventArgs e)
		{
			MessageBox.Show("More information soon...");
		}

		private void Mem1ButtonClick(object sender, EventArgs e)
		{
			MessageBox.Show("Implemented soon...");
		}

		private void Mem2ButtonClick(object sender, EventArgs e)
		{
			MessageBox.Show("Implemented soon...");
		}

		private void SpuMoreHelpLinkClick(object sender, EventArgs e)
		{
			MessageBox.Show("More information soon...");
		}
	}
}