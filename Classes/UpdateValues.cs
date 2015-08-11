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
using System.IO;
using PSf.GUI;

namespace PSf.Classes
{
	internal static class UpdateValues
	{
		private static EpsxeTabControl _epsxeTabControl;
		//private static Pcsx2TabControl _pcsx2TabControl;

		internal static void InitEpsxeControl(EpsxeTabControl epsxeTabControl)
		{
			_epsxeTabControl = epsxeTabControl;
		}

		//internal static void InitPcsx2Control(Pcsx2TabControl pcsx2TabControl)
		//{
		//	_pcsx2TabControl = pcsx2TabControl;
		//}

		internal static void ProfileInfo()
		{
			string tempMem1 = XmlAccess.ReadProfile("MemoryCard1") != string.Empty
			                  	? XmlAccess.ReadProfile("MemoryCard1")
			                  	: "None";
			string tempMem2 = XmlAccess.ReadProfile("MemoryCard2") != string.Empty
			                  	? XmlAccess.ReadProfile("MemoryCard2")
			                  	: "None";

			_epsxeTabControl.ProfileInfoTitleText.Text = XmlAccess.ReadInfo("Title");
			_epsxeTabControl.ProfileInfoDevText.Text = XmlAccess.ReadInfo("Developer");
			_epsxeTabControl.ProfileInfoPubText.Text = XmlAccess.ReadInfo("Publisher");
			_epsxeTabControl.ProfileInfoGenreText.Text = XmlAccess.ReadInfo("Genre");
			_epsxeTabControl.ProfileInfoRegionText.Text = XmlAccess.ReadInfo("Region");
			_epsxeTabControl.ProfileInfoDiscText.Text = XmlAccess.ReadInfo("Disc");

			_epsxeTabControl.ProfilePluginBiosText.Text = XmlAccess.ReadProfile("BIOS") == string.Empty
			                                              	? "Not set"
			                                              	: XmlAccess.ReadProfile("BIOS");
			_epsxeTabControl.ProfilePluginGpuText.Text = XmlAccess.ReadProfile("Graphics") == string.Empty
			                                             	? "Not set"
			                                             	: XmlAccess.ReadProfile("Graphics");
			_epsxeTabControl.ProfilePluginSpuText.Text = XmlAccess.ReadProfile("Sound") == string.Empty
			                                             	? "Not set"
			                                             	: XmlAccess.ReadProfile("Sound");
			if (Convert.ToBoolean(XmlAccess.ReadProfile("DiscSelect")))
			{
				_epsxeTabControl.ProfilePluginCdIsoText.Text = XmlAccess.ReadProfile("Disc") == string.Empty
				                                               	? "Not set"
				                                               	: XmlAccess.ReadProfile("Disc");
			}
			else
			{
				_epsxeTabControl.ProfilePluginCdIsoText.Text = XmlAccess.ReadProfile("ISO") == string.Empty
				                                               	? "Not set"
				                                               	: XmlAccess.ReadProfile("ISO");
			}
			_epsxeTabControl.ProfilePluginMemText.Text = string.Format("1: {0} / 2: {1}", tempMem1, tempMem2);
			_epsxeTabControl.ProfilePluginNetText.Text = XmlAccess.ReadProfile("NetPlay") == string.Empty
			                                             	? "Not set"
			                                             	: XmlAccess.ReadProfile("NetPlay");
		}

		internal static void EpsxeDirectories()
		{
			XmlAccess.GetEmuDirectories();

			_epsxeTabControl.BiosLocationText.Text = "Looking in: " + XmlAccess.EpsxeBiosDir;

			_epsxeTabControl.GpuLocationText.Text = "Looking in: " + XmlAccess.EpsxePluginDir;

			_epsxeTabControl.SpuLocationText.Text = "Looking in: " + XmlAccess.EpsxePluginDir;

			_epsxeTabControl.CdLocationText.Text = "Looking in: " + XmlAccess.EpsxePluginDir;

			_epsxeTabControl.MemLocationText.Text = "Looking in: " + XmlAccess.EpsxeMemDir;

			_epsxeTabControl.NetLocationText.Text = "Looking in: " + XmlAccess.EpsxePluginDir;

			PopulateList.PopulatePluginListsThread(_epsxeTabControl);
		}

		internal static void EpsxePlugins()
		{
			if (XmlAccess.ReadProfile("BIOS") == string.Empty ||
			    !_epsxeTabControl.BiosList.Items.Contains(XmlAccess.ReadProfile("BIOS")))
			{
				_epsxeTabControl.BiosList.SelectedIndex = 0;
			}
			else
			{
				_epsxeTabControl.BiosList.SelectedItem = XmlAccess.ReadProfile("BIOS");
			}

			if (XmlAccess.ReadProfile("Graphics") == string.Empty ||
			    !_epsxeTabControl.GpuList.Items.Contains(XmlAccess.ReadProfile("Graphics")))
			{
				_epsxeTabControl.GpuList.SelectedIndex = 0;
			}
			else
			{
				_epsxeTabControl.GpuList.SelectedItem = XmlAccess.ReadProfile("Graphics");
			}

			if (XmlAccess.ReadProfile("Sound") == string.Empty ||
			    !_epsxeTabControl.SpuList.Items.Contains(XmlAccess.ReadProfile("Sound")))
			{
				_epsxeTabControl.SpuList.SelectedIndex = 0;
			}
			else
			{
				_epsxeTabControl.SpuList.SelectedItem = XmlAccess.ReadProfile("Sound");
			}

			if (Convert.ToBoolean(XmlAccess.ReadProfile("DiscSelect")))
			{
				_epsxeTabControl.CdRadioButton.Checked = true;

				if (XmlAccess.ReadProfile("Disc") == string.Empty ||
				    !_epsxeTabControl.CdList.Items.Contains(XmlAccess.ReadProfile("Disc")))
				{
					_epsxeTabControl.CdList.SelectedIndex = 0;
				}
				else
				{
					_epsxeTabControl.CdList.SelectedItem = XmlAccess.ReadProfile("Disc");
				}
				_epsxeTabControl.IsoPath.Text = string.Empty;
			}
			else
			{
				_epsxeTabControl.IsoRadioButton.Checked = true;

				if (XmlAccess.ReadProfile("ISO") == string.Empty || !File.Exists(XmlAccess.ReadProfile("ISO")))
				{
					_epsxeTabControl.IsoPath.Text = string.Empty;
				}
				else
				{
					_epsxeTabControl.IsoPath.Text = XmlAccess.ReadProfile("ISO");
				}
				_epsxeTabControl.CdList.SelectedIndex = 0;
			}

			if (Convert.ToBoolean(XmlAccess.ReadProfile("MemoryCard1Select")))
			{
				_epsxeTabControl.Mem1ToggleCheckbox.Checked = true;

				if (XmlAccess.ReadProfile("MemoryCard1") == string.Empty ||
				    !_epsxeTabControl.Mem1List.Items.Contains(XmlAccess.ReadProfile("MemoryCard1")))
				{
					_epsxeTabControl.Mem1List.SelectedIndex = 0;
				}
				else
				{
					_epsxeTabControl.Mem1List.SelectedItem = XmlAccess.ReadProfile("MemoryCard1");
				}
			}
			else
			{
				_epsxeTabControl.Mem1ToggleCheckbox.Checked = false;

				_epsxeTabControl.Mem1List.SelectedIndex = 0;
			}

			if (Convert.ToBoolean(XmlAccess.ReadProfile("MemoryCard2Select")))
			{
				_epsxeTabControl.Mem2ToggleCheckbox.Checked = true;

				if (XmlAccess.ReadProfile("MemoryCard2") == string.Empty ||
				    !_epsxeTabControl.Mem2List.Items.Contains(XmlAccess.ReadProfile("MemoryCard2")))
				{
					_epsxeTabControl.Mem2List.SelectedIndex = 0;
				}
				else
				{
					_epsxeTabControl.Mem2List.SelectedItem = XmlAccess.ReadProfile("MemoryCard2");
				}
			}
			else
			{
				_epsxeTabControl.Mem2ToggleCheckbox.Checked = false;

				_epsxeTabControl.Mem2List.SelectedIndex = 0;
			}

			if (XmlAccess.ReadProfile("NetPlay") == string.Empty ||
			    !_epsxeTabControl.NetList.Items.Contains(XmlAccess.ReadProfile("NetPlay")))
			{
				_epsxeTabControl.NetList.SelectedIndex = 0;
			}
			else
			{
				_epsxeTabControl.NetList.SelectedItem = XmlAccess.ReadProfile("NetPlay");
			}

			_epsxeTabControl.CheckCurrentSpuSelection();
			_epsxeTabControl.CheckCurrentCdSelection();
			_epsxeTabControl.CheckCurrentNetSelection();
		}
	}
}