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
using System.Linq;
using System.Xml.Linq;

namespace PSf.Classes
{
	internal static class XmlAccess
	{
		internal static readonly string SettingsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
		                                              "\\3rdDin8\\PS-f";

		internal static readonly string SettingsFile = Path.Combine(SettingsDir, "Settings.xml");
		private static XElement _xmlSettings;
		private static XElement _xmlProfile;

		internal static string EpsxeBiosDir;
		internal static string EpsxePluginDir;
		internal static string EpsxeMemDir;

		#region Managing frontend settings

		internal static void CreateSettings()
		{
			var doc = new XDocument(
				new XElement("Options",
				             new XElement("Locations",
				                          new XElement("Profiles", string.Empty),
				                          new XElement("ePSXe", string.Empty),
				                          new XElement("PCSX2", string.Empty)),
				             new XElement("ePSXeMisc.",
				                          new XElement("Logging", string.Empty,
				                                       new XAttribute("Enabled", false)),
				                          new XElement("AutoPPF", string.Empty,
				                                       new XAttribute("Enabled", true))),
				             new XElement("Misc.",
				                          new XElement("LastProfile", 0,
				                                       new XAttribute("Enabled", true)),
				                          new XElement("FileVerify", true),
				                          new XElement("ToolbarStyle", "Icons + Text"))));

			doc.Save(SettingsFile);
		}

		internal static void LoadSettingsToMemory()
		{
			_xmlSettings = XElement.Load(SettingsFile);
		}

		internal static void GetEmuDirectories()
		{
			#region ePSXe - Other Directories

			string eDir = ReadSettings("ePSXe");
			string dir2 = Path.GetDirectoryName(eDir);
			EpsxeBiosDir = Path.Combine(dir2, "bios");
			EpsxePluginDir = Path.Combine(dir2, "plugins");
			EpsxeMemDir = Path.Combine(dir2, "memcards");

			#endregion

			//#region PCSX2 - Other Directories
			//var pDir = ReadSettings("PCSX2");

			//if (!string.IsNullOrEmpty(pDir))
			//{
			//    var dir2 = Path.GetDirectoryName(dir);
			//    Pcsx2BiosDir = Path.Combine(dir2, "bios");
			//    Pcsx2PluginDir = Path.Combine(dir2, "plugins");
			//    Pcsx2MemDir = Path.Combine(dir2, "memcards");
			//}
			//else
			//{
			//    Pcsx2BiosDir = string.Empty;
			//    Pcsx2MemDir = string.Empty;
			//    Pcsx2PluginDir = string.Empty;
			//} 
			//#endregion
		}

		internal static string ReadSettings(string settingName)
		{
			switch (settingName)
			{
				case "Logging":
					return _xmlSettings.Descendants("Logging").Single().Attribute("Enabled").Value;
				case "AutoPPF":
					return _xmlSettings.Descendants("AutoPPF").Single().Attribute("Enabled").Value;
				case "LastProfileAttribute":
					return _xmlSettings.Descendants("LastProfile").Single().Attribute("Enabled").Value;
				default:
					return _xmlSettings.Descendants(settingName).Single().Value;
			}
		}

		internal static void WriteSettings(string settingName, string newValue)
		{
			XElement ele;
			switch (settingName)
			{
				case "Profiles":
				case "ePSXe":
				case "PCSX2":
					ele = _xmlSettings.Descendants("Locations").Single();
					ele.SetElementValue(settingName, newValue);
					break;

				case "Logging":
				case "AutoPPF":
					ele = _xmlSettings.Descendants("ePSXeMisc.").Single();
					ele.Element(settingName).SetAttributeValue("Enabled", newValue);
					break;

				case "LastProfileAttribute":
					ele = _xmlSettings.Descendants("Misc.").Single();
					ele.Element("LastProfile").SetAttributeValue("Enabled", newValue);
					break;

				case "LastProfile":
				case "FileVerify":
				case "ToolbarStyle":
					ele = _xmlSettings.Descendants("Misc.").Single();
					ele.SetElementValue(settingName, newValue);
					break;
			}
		}

		internal static void WriteSettingsSave()
		{
			_xmlSettings.Save(SettingsFile);
			_xmlSettings = null;
			LoadSettingsToMemory();
		}

		#endregion

		#region Managing profile settings

		internal static void CreateProfile(string profileName)
		{
			XDocument doc;
			switch (profileName.Contains(".psf1"))
			{
				case true:
					doc = new XDocument(
						new XDeclaration("1.0", "utf-8", "yes"),
						new XElement("Profile",
						             new XElement("Info",
						                          new XElement("Title", String.Empty),
						                          new XElement("Developer", String.Empty),
						                          new XElement("Publisher", String.Empty),
						                          new XElement("Genre", String.Empty),
						                          new XElement("Disc", String.Empty),
						                          new XElement("Region", String.Empty)),
						             new XElement("Plugins",
						                          new XElement("BIOS", String.Empty),
						                          new XElement("Graphics", String.Empty,
						                                       new XAttribute("Plugin", String.Empty)),
						                          new XElement("IntGraphics", String.Empty),
						                          new XElement("Sound", String.Empty,
						                                       new XAttribute("Plugin", String.Empty)),
						                          new XElement("Disc", String.Empty,
						                                       new XAttribute("Enabled", true),
						                                       new XAttribute("Plugin", String.Empty)),
						                          new XElement("ISO", String.Empty,
						                                       new XAttribute("Enabled", false)),
						                          new XElement("Pad", String.Empty),
						                          new XElement("MemoryCard1", String.Empty,
						                                       new XAttribute("Enabled", false)),
						                          new XElement("MemoryCard2", String.Empty,
						                                       new XAttribute("Enabled", false)),
						                          new XElement("NetPlay", String.Empty,
						                                       new XAttribute("Plugin", String.Empty)))));

					doc.Save(Path.Combine(ReadSettings("Profiles"), profileName));
					break;

					//case false:
					//    doc = new XDocument(
					//        new XDeclaration("1.0", "utf-8", "yes"),
					//        new XElement("Profile",
					//            new XElement("Info", String.Empty),
					//            new XElement("Plugins",
					//                new XElement("BIOS", String.Empty),
					//                new XElement("Graphics", String.Empty),
					//                new XElement("Sound", String.Empty),
					//                new XElement("Disc", String.Empty),
					//                new XElement("ISO", String.Empty),
					//                new XElement("Pad1", String.Empty),
					//                new XElement("Pad2", String.Empty),
					//                new XElement("MemoryCard1", String.Empty),
					//                new XElement("MemoryCard2", String.Empty),
					//                new XElement("USB", String.Empty),
					//                new XElement("FireWire", String.Empty),
					//                new XElement("Dev9", String.Empty))));

					//    doc.Save(Path.Combine(ReadSettings("Profiles"), profileName));
					//    break;
			}
		}

		internal static void ReadProfileToMemory(string profileFile)
		{
			_xmlProfile = XElement.Load(Path.Combine(ReadSettings("Profiles"), profileFile));
		}

		internal static void WriteProfile(string profileFile, string pluginType, string newValue)
		{
			XElement ele;
			switch (profileFile.Contains(".psf1"))
			{
				case true:
					ele = _xmlProfile.Descendants("Plugins").Single();
					switch (pluginType)
					{
						case "BIOS":
						case "IntGraphics":
						case "ISO":
						case "Pad":
						case "MemoryCard1":
						case "MemoryCard2":
							ele.SetElementValue(pluginType, newValue);
							break;

						case "Graphics":
						case "Sound":
						case "Disc":
						case "NetPlay":
							ele.Descendants(pluginType).Single().SetAttributeValue("Plugin", newValue);
							break;

						case "GraphicsSettings":
							ele.SetElementValue("Graphics", newValue);
							break;

						case "SoundSettings":
							ele.SetElementValue("Sound", newValue);
							break;

						case "DiscSettings":
							ele.SetElementValue("Disc", newValue);
							break;

						case "NetPlaySettings":
							ele.SetElementValue("NetPlay", newValue);
							break;

						case "DiscSelect":
							ele.Descendants("Disc").Single().SetAttributeValue("Enabled", newValue);
							break;

						case "ISOSelect":
							ele.Descendants("ISO").Single().SetAttributeValue("Enabled", newValue);
							break;

						case "MemoryCard1Select":
							ele.Descendants("MemoryCard1").Single().SetAttributeValue("Enabled", newValue);
							break;

						case "MemoryCard2Select":
							ele.Descendants("MemoryCard2").Single().SetAttributeValue("Enabled", newValue);
							break;
					}
					break;

					//case false:
					//    XmlProfile = XElement.Load(profileFile);
					//    ele = XmlProfile.Descendants("Plugins").Single();
					//    switch (pluginType)
					//    {
					//        case "BIOS":
					//        case "Graphics":
					//        case "Sound":
					//        case "Disc":
					//        case "ISO":
					//        case "Pad1":
					//        case "Pad2":
					//        case "MemoryCard1":
					//        case "MemoryCard2":
					//        case "USB":
					//        case "FireWire":
					//        case "Dev9":
					//            ele.SetElementValue(pluginType, newValue);
					//            break;
					//    }
					//    break;
			}
		}

		internal static void WriteProfileSave(string profileFile)
		{
			_xmlProfile.Save(Path.Combine(ReadSettings("Profiles"), profileFile));
			_xmlProfile = null;
			ReadProfileToMemory(profileFile);
		}

		internal static string ReadProfile(string pluginType)
		{
			try
			{
				XElement ele;
				ele = _xmlProfile.Descendants("Plugins").Single();
				switch (pluginType)
				{
					case "Graphics":
					case "Sound":
					case "Disc":
					case "NetPlay":
						return ele.Descendants(pluginType).Single().Attribute("Plugin").Value;

					case "GraphicsSettings":
						return ele.Descendants("Graphics").Single().Value;

					case "SoundSettings":
						return ele.Descendants("Sound").Single().Value;

					case "DiscSettings":
						return ele.Descendants("Disc").Single().Value;

					case "NetPlaySettings":
						return ele.Descendants("NetPlay").Single().Value;

					case "DiscSelect":
						return ele.Descendants("Disc").Single().Attribute("Enabled").Value;
					case "ISOSelect":
						return ele.Descendants("ISO").Single().Attribute("Enabled").Value;
					case "MemoryCard1Select":
						return ele.Descendants("MemoryCard1").Single().Attribute("Enabled").Value;
					case "MemoryCard2Select":
						return ele.Descendants("MemoryCard2").Single().Attribute("Enabled").Value;
					default:
						return ele.Descendants(pluginType).Single().Value;
				}
			}

			catch (NullReferenceException)
			{
				return string.Empty;
			}
		}

		#endregion

		#region Managing profile info

		internal static void WriteInfo(string infoType, string newValue)
		{
			XElement ele = _xmlProfile.Descendants("Info").Single();
			ele.SetElementValue(infoType, newValue);
		}

		internal static string ReadInfo(string infoType)
		{
			XElement ele = _xmlProfile.Descendants("Info").Single();
			return ele.Descendants(infoType).Single().Value;
		}

		#endregion

		//internal static string Pcsx2BiosDir;
		//internal static string Pcsx2PluginDir;
		//internal static string Pcsx2MemDir;
	}
}