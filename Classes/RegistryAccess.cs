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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using PSf.GUI;

namespace PSf.Classes
{
	internal static class RegistryAccess
	{
		private const string EpsxeKey = "Software\\epsxe\\config";
		private const string FirstRunEpsxeKey = "67328";
		private const string OpenGl2Key = "\"HKEY_CURRENT_USER\\Software\\Vision Thing\\PSEmu Pro\\GPU\\PeteOpenGL2\"";
		private const string OpenGlKey = "\"HKEY_CURRENT_USER\\Software\\Vision Thing\\PSEmu Pro\\GPU\\PeteTNT\"";
		private const string SoftKey = "\"HKEY_CURRENT_USER\\Software\\Vision Thing\\PSEmu Pro\\GPU\\PeteSoft\"";
		private const string EternalKey = "\"HKEY_CURRENT_USER\\Software\\Vision Thing\\PSEmu Pro\\SPU\\spuEternal\"";
		private const string PeopsCdKey = "\"HKEY_CURRENT_USER\\Software\\Vision Thing\\PSEmu Pro\\SPU\\PeopsSound\"";
		private const string PeopsSpuKey = "\"HKEY_CURRENT_USER\\Software\\Vision Thing\\PSEmu Pro\\CDR\\PeopsCDRASPI\"";
		private const string SapuKey = "\"HKEY_CURRENT_USER\\Software\\Vision Thing\\PSEmu Pro\\CDR\\SaPu\"";
		private const string RegTag = @"Windows Registry Editor Version 5.00";
		internal static readonly string TempRegFile = Path.GetTempPath() + @"\plugintemp.reg";
		private static readonly string[] InternalSpuKey = new string[2];

		internal static void FirstRunKey()
		{
			if (Registry.CurrentUser.OpenSubKey("Software\\epsxe\\config") == null)
			{
				Registry.CurrentUser.CreateSubKey("Software\\epsxe\\config").SetValue("Version", FirstRunEpsxeKey);
			}
		}

		internal static void WritePluginSettingsToProfile(string profileFile, string pluginName)
		{
			var lines = new List<string>();

			switch (pluginName)
			{
				#region GPU

				case "Pete's OpenGL2 Driver v2.9":
					if (Registry.CurrentUser.OpenSubKey("Software\\Vision Thing\\PSEmu Pro\\GPU\\PeteOpenGL2") != null)
					{
						XmlAccess.WriteProfile(profileFile, "GraphicsSettings", PluginRegistryOutput(OpenGl2Key));
					}
					break;
				case "P.E.Op.S. OpenGL Driver v1.78":
					if (Registry.CurrentUser.OpenSubKey("Software\\Vision Thing\\PSEmu Pro\\GPU\\PeteTNT") != null)
					{
						XmlAccess.WriteProfile(profileFile, "GraphicsSettings", PluginRegistryOutput(OpenGlKey));
					}
					break;
				case "P.E.Op.S. Soft Driver v1.18":
					if (Registry.CurrentUser.OpenSubKey("Software\\Vision Thing\\PSEmu Pro\\GPU\\PeteSoft") != null)
					{
						XmlAccess.WriteProfile(profileFile, "GraphicsSettings", PluginRegistryOutput(SoftKey));
					}
					break;
				case "IntGraphics":
					if (Registry.CurrentUser.OpenSubKey("Software\\Vision Thing\\PSEmu Pro\\GPU\\PeteSoft") != null)
					{
						XmlAccess.WriteProfile(profileFile, "IntGraphics", PluginRegistryOutput(SoftKey));
					}
					break;

				#endregion

				#region SPU

				case "Eternal SPU Plugin v1.5":
					if (Registry.CurrentUser.OpenSubKey("Software\\Vision Thing\\PSEmu Pro\\SPU\\spuEternal") != null)
					{
						PluginRegistryOutput(EternalKey);
						XmlAccess.WriteProfile(profileFile, "SoundSettings", string.Join("\n", lines.ToArray()));
					}
					break;
				case "P.E.Op.S. DSound Audio Driver v1.9":
					if (Registry.CurrentUser.OpenSubKey("Software\\Vision Thing\\PSEmu Pro\\SPU\\PeopsSound") != null)
					{
						PluginRegistryOutput(PeopsSpuKey);
						XmlAccess.WriteProfile(profileFile, "SoundSettings", string.Join("\n", lines.ToArray()));
					}
					break;
				case "P.E.Op.S. Sound Audio Driver v1.10":
					//To be implemented...
					break;

					#endregion

				#region CDR

				case "(Internal) ePSXe CDR Core v1.7":
					if (Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("CdromLetter") != null)
					{
						InternalSpuKey[0] = Registry.CurrentUser.OpenSubKey("Software\\epsxe\\config").GetValue("CdromLetter").ToString();
						InternalSpuKey[1] =
							Registry.CurrentUser.OpenSubKey("Software\\epsxe\\config").GetValue("SubchannelW2kCdromEnabled").ToString();
						XmlAccess.WriteProfile(profileFile, "DiscSettings", string.Join("\n", InternalSpuKey));
					}
					break;
				case "P.E.Op.S. CDR Driver v1.4":
					if (Registry.CurrentUser.OpenSubKey("Software\\Vision Thing\\PSEmu Pro\\SPU\\spuEternal") != null)
					{
						PluginRegistryOutput(PeopsCdKey);
						XmlAccess.WriteProfile(profileFile, "DiscSettings", string.Join("\n", lines.ToArray()));
					}
					break;
				case "SaPu's CD-ROM Plugin v1.3":
					if (Registry.CurrentUser.OpenSubKey("Software\\Vision Thing\\PSEmu Pro\\SPU\\spuEternal") != null)
					{
						PluginRegistryOutput(SapuKey);
						XmlAccess.WriteProfile(profileFile, "DiscSettings", string.Join("\n", lines.ToArray()));
					}
					break;

					#endregion

				#region Pad

				case "Pad":
					var openSubKey = Registry.CurrentUser.OpenSubKey(EpsxeKey);
					if (openSubKey != null && openSubKey.GetValue("GamepadType") != null)
					{
						/*var tempString = new List<string>
						                 	{
						                 		"\n[HKEY_CURRENT_USER\\Software\\epsxe\\config]",
						                 		string.Format("\"GamepadBMotorType\"=\"{0}\"",
						                 		              Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("GamepadBMotorType")),
						                 		string.Format("\"GamepadFullAxis\"=\"{0}\"",
						                 		              Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("GamepadFullAxis")),
						                 		string.Format("\"GamepadMotorType\"=\"{0}\"",
						                 		              Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("GamepadMotorType")),
						                 		string.Format("\"GamepadSMotorType\"=\"{0}\"",
						                 		              Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("GamepadSMotorType")),
						                 		string.Format("\"GamepadSubType\"=\"{0}\"",
						                 		              Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("GamepadSubType")),
						                 		string.Format("\"GamepadType\"=\"{0}\"",
						                 		              Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("GamepadType")),
						                 		string.Format("\"Multitap1\"=\"{0}\"",
						                 		              Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("Multitap1")),
						                 		string.Format("\"Multitap2\"=\"{0}\"",
						                 		              Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("Multitap2")),
						                 		string.Format("\"Pad1\"=\"{0}\"", Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("Pad1")),
						                 		string.Format("\"Pad2\"=\"{0}\"", Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("Pad2")),
						                 		string.Format("\"Pad3\"=\"{0}\"", Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("Pad3")),
						                 		string.Format("\"Pad4\"=\"{0}\"", Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("Pad4")),
						                 		string.Format("\"Pad5\"=\"{0}\"", Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("Pad5")),
						                 		string.Format("\"Pad6\"=\"{0}\"", Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("Pad6")),
						                 		string.Format("\"Pad7\"=\"{0}\"", Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("Pad7")),
						                 		string.Format("\"Pad8\"=\"{0}\"\n", Registry.CurrentUser.OpenSubKey(EpsxeKey).GetValue("Pad8"))
						                 	};*/
						lines.Add("\n[HKEY_CURRENT_USER\\Software\\epsxe\\config]");
						lines.Add(string.Format("\"GamepadBMotorType\"=\"{0}\"", openSubKey.GetValue("GamepadBMotorType")));
						lines.Add(string.Format("\"GamepadFullAxis\"=\"{0}\"", openSubKey.GetValue("GamepadFullAxis")));
						lines.Add(string.Format("\"GamepadMotorType\"=\"{0}\"", openSubKey.GetValue("GamepadMotorType")));
						lines.Add(string.Format("\"GamepadSMotorType\"=\"{0}\"", openSubKey.GetValue("GamepadSMotorType")));
						lines.Add(string.Format("\"GamepadSubType\"=\"{0}\"", openSubKey.GetValue("GamepadSubType")));
						lines.Add(string.Format("\"GamepadType\"=\"{0}\"", openSubKey.GetValue("GamepadType")));
						lines.Add(string.Format("\"Multitap1\"=\"{0}\"", openSubKey.GetValue("Multitap1")));
						lines.Add(string.Format("\"Multitap2\"=\"{0}\"", openSubKey.GetValue("Multitap2")));
						lines.Add(string.Format("\"Pad1\"=\"{0}\"", openSubKey.GetValue("Pad1")));
						lines.Add(string.Format("\"Pad1\"=\"{0}\"", openSubKey.GetValue("Pad2")));
						lines.Add(string.Format("\"Pad1\"=\"{0}\"", openSubKey.GetValue("Pad3")));
						lines.Add(string.Format("\"Pad1\"=\"{0}\"", openSubKey.GetValue("Pad4")));
						lines.Add(string.Format("\"Pad1\"=\"{0}\"", openSubKey.GetValue("Pad5")));
						lines.Add(string.Format("\"Pad1\"=\"{0}\"", openSubKey.GetValue("Pad6")));
						lines.Add(string.Format("\"Pad1\"=\"{0}\"", openSubKey.GetValue("Pad7")));
						lines.Add(string.Format("\"Pad1\"=\"{0}\"\n", openSubKey.GetValue("Pad8")));

						XmlAccess.WriteProfile(profileFile, "Pad", string.Join("\n", lines.ToArray()));
					}
					break;

					#endregion
			}

			File.Delete(TempRegFile);
		}

		private static string PluginRegistryOutput(string keyName)
		{
			using (var proc = new Process())
			{
				proc.StartInfo.FileName = "regedit";
				proc.StartInfo.Arguments = string.Format("/e {0} {1}", TempRegFile, keyName);
				proc.Start();

				while (!File.Exists(TempRegFile))
				{
					Thread.Sleep(50);
				}

				var lines = new List<string>();
				lines.AddRange(File.ReadAllLines(TempRegFile));
				lines.RemoveAt(0);
				File.Delete(TempRegFile);
				return string.Join("\n", lines.ToArray());
			}
		}

		internal static void WritePluginSettingsToRegistry(EpsxeTabControl mainEpsxeTab)
		{
			var registryKey = Registry.CurrentUser.CreateSubKey(EpsxeKey);
			if (registryKey != null)
			{
				var finalRegKeyImport = new List<string> {RegTag + "\n"};

				#region BIOS

				if (XmlAccess.ReadProfile("BIOS") != string.Empty)
				{
					registryKey.SetValue("BiosName", Path.Combine(XmlAccess.EpsxeBiosDir, XmlAccess.ReadProfile("BIOS")));
				}

				#endregion

				#region GPU

				if (XmlAccess.ReadProfile("GraphicsSettings") != string.Empty)
				{
					registryKey.SetValue("VideoPlugin",
						                    Path.GetFileName(PopulateList.GpuFilePaths[mainEpsxeTab.GpuList.SelectedIndex].ToString()));
					finalRegKeyImport.Add(XmlAccess.ReadProfile("GraphicsSettings"));
				}
				if (XmlAccess.ReadProfile("IntGraphics") != string.Empty)
				{
					finalRegKeyImport.Add(XmlAccess.ReadProfile("IntGraphics"));
				}

				#endregion

				#region SPU

				if (XmlAccess.ReadProfile("SoundSettings") != string.Empty)
				{
					switch (XmlAccess.ReadProfile("Sound"))
					{
						case "(Internal) ePSXe SPU Core v1.7":
							registryKey.SetValue("SoundPlugin", "SPUCORE");
							break;
						default:
							registryKey.SetValue("SoundPlugin", 
													Path.GetFileName(PopulateList.SpuFilePaths[mainEpsxeTab.SpuList.SelectedIndex - 1].ToString()));
							finalRegKeyImport.Add(XmlAccess.ReadProfile("SoundSettings"));
							break;
					}
				}

				#endregion

				#region Disc

				if (XmlAccess.ReadProfile("DiscSettings") != string.Empty)
				{
					switch (XmlAccess.ReadProfile("Disc"))
					{
						case "(Internal) ePSXe CDR Core v1.7":
							registryKey.SetValue("CdromPlugin", "W2KCDRCORE");
							char[] val = XmlAccess.ReadProfile("DiscSettings").ToCharArray();
							registryKey.SetValue("CdromLetter", val[0].ToString() + val[1].ToString());
							registryKey.SetValue("SubchannelW2kCdromEnabled", val[3]);
							break;
						default:
							registryKey.SetValue("CdromPlugin",
								                    Path.GetFileName(PopulateList.CdFilePaths[mainEpsxeTab.CdList.SelectedIndex - 1].ToString()));
							finalRegKeyImport.Add(XmlAccess.ReadProfile("DiscSettings"));
							break;
					}
				}

				#endregion

				#region Pad

				if (XmlAccess.ReadProfile("Pad") != string.Empty)
				{
					finalRegKeyImport.Add(XmlAccess.ReadProfile("Pad"));
				}

				#endregion

				#region MemoryCards

				registryKey.SetValue("Memcard1",
					                    XmlAccess.ReadProfile("MemoryCard1") != string.Empty ? Path.Combine(XmlAccess.EpsxeMemDir, 
										XmlAccess.ReadProfile("MemoryCard1")) : string.Empty);
				registryKey.SetValue("Memcard2",
					                    XmlAccess.ReadProfile("MemoryCard2") != string.Empty ? Path.Combine(XmlAccess.EpsxeMemDir, 
										XmlAccess.ReadProfile("MemoryCard2")) : string.Empty);

				#endregion

				#region NetPlay

				if (XmlAccess.ReadProfile("NetPlay") != string.Empty)
				{
					switch (XmlAccess.ReadProfile("NetPlay"))
					{
						case "NetPlay Disabled":
							registryKey.SetValue("NetPlugin", "DISABLED");
							break;
						case "netSock Driver":
							registryKey.SetValue("NetPlugin",
								                    Path.GetFileName(PopulateList.NetFilePaths[mainEpsxeTab.NetList.SelectedIndex - 1].ToString()));
							break;
					}
				}

				#endregion

				#region Misc.

				bool tempPpf = Convert.ToBoolean(XmlAccess.ReadSettings("AutoPPF"));
				bool tempLog = Convert.ToBoolean(XmlAccess.ReadSettings("Logging"));
				registryKey.SetValue("AutoPpfLoad", Convert.ToInt16(tempPpf));
				registryKey.SetValue("Logswindow", Convert.ToInt16(tempLog));

				#endregion

				if (finalRegKeyImport.Count <= 1) return;
				File.WriteAllText(TempRegFile, string.Join("\n", finalRegKeyImport.ToArray()));
				using (var proc = new Process())
				{
					proc.StartInfo.FileName = "regedit";
					proc.StartInfo.Arguments = string.Format("/s " + TempRegFile);
					proc.Start();
				}
				while (!File.Exists(TempRegFile))
				{
					Thread.Sleep(100);
				}

				File.Delete(TempRegFile);
			}
		}
	}
}