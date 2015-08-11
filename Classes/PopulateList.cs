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

using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using PSf.GUI;

namespace PSf.Classes
{
	internal static class PopulateList
	{
		#region Declerations

		private static readonly ArrayList ProfileFileList = new ArrayList();
		private static readonly BindingSource ProfileDataBind = new BindingSource();
		private static MainWindow _mainWindow;
		internal static readonly BackgroundWorker PopProfile = new BackgroundWorker();
		internal static readonly BackgroundWorker PopFound = new BackgroundWorker();

		private static readonly ArrayList BiosFileList = new ArrayList();
		private static readonly BindingSource BiosSource = new BindingSource();

		internal static readonly ArrayList GpuFileList = new ArrayList();
		internal static readonly ArrayList GpuFilePaths = new ArrayList();
		private static readonly BindingSource GpuSource = new BindingSource();

		private static readonly ArrayList SpuFileList = new ArrayList();
		internal static readonly ArrayList SpuFilePaths = new ArrayList();
		private static readonly BindingSource SpuSource = new BindingSource();

		private static readonly ArrayList CdFileList = new ArrayList();
		internal static readonly ArrayList CdFilePaths = new ArrayList();
		private static readonly BindingSource CdSource = new BindingSource();

		private static readonly ArrayList MemFileList = new ArrayList();
		private static readonly BindingSource Mem1Source = new BindingSource();
		private static readonly BindingSource Mem2Source = new BindingSource();

		private static readonly ArrayList NetFileList = new ArrayList();
		internal static readonly ArrayList NetFilePaths = new ArrayList();
		private static readonly BindingSource NetSource = new BindingSource();

		private static EpsxeTabControl _epsxeTabControl;

		#endregion

		#region Profiles

		internal static void PopulateProfileListThread(MainWindow mainWindow)
		{
			_mainWindow = mainWindow;
			PopProfile.DoWork += PopProfileDoWork;
			PopProfile.RunWorkerCompleted += PopProfileRunWorkerCompleted;
			PopProfile.WorkerSupportsCancellation = true;
			PopProfile.RunWorkerAsync();
		}

		private static void PopProfileDoWork(object sender, DoWorkEventArgs e)
		{
			ProfileDataBind.DataSource = ProfileFileList;
			_mainWindow.ProfileListMenu.ComboBox.DataSource = ProfileDataBind;

			if (XmlAccess.ReadSettings("Profiles") != string.Empty && Directory.Exists(XmlAccess.ReadSettings("Profiles")))
			{
				var dir = new DirectoryInfo(XmlAccess.ReadSettings("Profiles"));
				FileInfo[] files = dir.GetFiles("*.psf*");
				ProfileFileList.Clear();
				if (files.Length == 0)
				{
					ProfileFileList.Add("--No Profiles Found--");
				}
				else
				{
					foreach (FileInfo file in files)
					{
						ProfileFileList.Add(file.Name);
					}
				}
			}
			else
			{
				ProfileFileList.Add("--No Profiles Found--");
			}
		}

		private static void PopProfileRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			ProfileDataBind.ResetBindings(false);
			if (!_mainWindow.ProfileListMenu.Items.Contains("--"))
			{
				_mainWindow.ProfileListMenu.Enabled = true;
				_mainWindow.SelectTab();
			}
			else
			{
				_mainWindow.ProfileListMenu.Enabled = false;
			}
		}

		#endregion

		#region Plugins

		internal static void PopulatePluginListsThread(EpsxeTabControl epsxeTabControl)
		{
			if (!_mainWindow.ProfileListMenu.Items.Contains("--"))
			{
				_epsxeTabControl = epsxeTabControl;
				PopFound.DoWork += PopFoundDoWork;
				PopFound.RunWorkerCompleted += PopFoundWorkerCompleted;
				PopFound.WorkerSupportsCancellation = true;
				PopFound.RunWorkerAsync();
			}
		}

		private static void PopFoundDoWork(object sender, DoWorkEventArgs e)
		{
			FindControl(_epsxeTabControl.Controls);
		}

		private static void PopFoundWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			BiosSource.ResetBindings(false);
			GpuSource.ResetBindings(false);

			if (GpuFileList[0].ToString().Contains("--"))
			{
				_epsxeTabControl.GpuConfigButton.Enabled = false;
				_epsxeTabControl.GpuAboutButton.Enabled = false;
				_epsxeTabControl.Gpu2ConfigButton.Enabled = false;
				_epsxeTabControl.Gpu2AboutButton.Enabled = false;

				_epsxeTabControl.Gpu2FoundText.Text = File.Exists(Path.Combine(XmlAccess.EpsxePluginDir, "gpu.dat"))
				                                      	? "Present: Yes (Only works with a plugin selected above)"
				                                      	: "Present: No";
			}
			else
			{
				_epsxeTabControl.GpuConfigButton.Enabled = true;
				_epsxeTabControl.GpuAboutButton.Enabled = true;
				if (File.Exists(Path.Combine(XmlAccess.EpsxePluginDir, "gpu.dat")))
				{
					_epsxeTabControl.Gpu2FoundText.Text = "Present: Yes";
					_epsxeTabControl.Gpu2ConfigButton.Enabled = true;
					_epsxeTabControl.Gpu2AboutButton.Enabled = true;
				}
				else
				{
					_epsxeTabControl.Gpu2FoundText.Text = "Missing";
					_epsxeTabControl.Gpu2ConfigButton.Enabled = false;
					_epsxeTabControl.Gpu2AboutButton.Enabled = false;
				}
			}

			SpuSource.ResetBindings(false);
			CdSource.ResetBindings(false);
			Mem1Source.ResetBindings(false);
			Mem2Source.ResetBindings(false);
			NetSource.ResetBindings(false);

			if (NetFileList.Count < 2)
			{
				_epsxeTabControl.NetConfigButton.Enabled = false;
				_epsxeTabControl.NetAboutButton.Enabled = false;
			}
			else
			{
				_epsxeTabControl.NetConfigButton.Enabled = true;
				_epsxeTabControl.NetAboutButton.Enabled = true;
			}

			_mainWindow.ProfileListMenu.Enabled = true;
			_mainWindow.SelectTab();
		}

		private static void FindControl(IEnumerable c)
		{
			foreach (Control ctrl in c)
			{
				if (ctrl.Controls.Count > 0)
				{
					FindControl(ctrl.Controls);
				}
				else
				{
					if (ctrl is ComboBox)
					{
						DirectoryInfo dir;
						FileInfo[] files;
						switch (ctrl.Name)
						{
							case "BiosList":
								BiosSource.DataSource = BiosFileList;
								_epsxeTabControl.BiosList.DataSource = BiosSource;
								dir = new DirectoryInfo(XmlAccess.EpsxeBiosDir);
								files = dir.GetFiles("*.bin");
								BiosFileList.Clear();
								if (files.Length == 0)
								{
									BiosFileList.Add("--No BIOS Found--");
								}
								else
								{
									foreach (FileInfo file in files)
									{
										BiosFileList.Add(file.Name);
									}
								}
								break;

							case "GpuList":
								GpuSource.DataSource = GpuFileList;
								_epsxeTabControl.GpuList.DataSource = GpuSource;
								dir = new DirectoryInfo(XmlAccess.EpsxePluginDir);
								files = dir.GetFiles("gpu*.dll");
								GpuFileList.Clear();
								GpuFilePaths.Clear();
								if (files.Length == 0)
								{
									GpuFileList.Add("--No Graphics Plugins Found--");
								}
								else
								{
									foreach (FileInfo file in files)
									{
										GpuFileList.Add(NativeMethods.GetPluginName(file.FullName) +
										                NativeMethods.GetPluginVersion(file.FullName));
										GpuFilePaths.Add(file.FullName);
									}
								}
								break;

							case "SpuList":
								SpuSource.DataSource = SpuFileList;
								_epsxeTabControl.SpuList.DataSource = SpuSource;
								dir = new DirectoryInfo(XmlAccess.EpsxePluginDir);
								files = dir.GetFiles("spu*.dll");
								SpuFileList.Clear();
								SpuFilePaths.Clear();
								if (files.Length == 0)
								{
									SpuFileList.Add("(Internal) ePSXe SPU Core v1.7");
								}
								else
								{
									SpuFileList.Add("(Internal) ePSXe SPU Core v1.7");
									foreach (FileInfo file in files)
									{
										SpuFileList.Add(NativeMethods.GetPluginName(file.FullName) +
										                NativeMethods.GetPluginVersion(file.FullName));
										SpuFilePaths.Add(file.FullName);
									}
								}
								break;

							case "CdList":
								CdSource.DataSource = CdFileList;
								_epsxeTabControl.CdList.DataSource = CdSource;
								dir = new DirectoryInfo(XmlAccess.EpsxePluginDir);
								files = dir.GetFiles("cdr*.dll");
								CdFileList.Clear();
								CdFilePaths.Clear();
								if (files.Length == 0)
								{
									CdFileList.Add("(Internal) ePSXe CDR Core v1.7");
								}
								else
								{
									CdFileList.Add("(Internal) ePSXe CDR Core v1.7");
									foreach (FileInfo file in files)
									{
										CdFileList.Add(NativeMethods.GetPluginName(file.FullName) +
										               NativeMethods.GetPluginVersion(file.FullName));
										CdFilePaths.Add(file.FullName);
									}
								}
								break;

							case "Mem1List":
							case "Mem2List":
								Mem1Source.DataSource = MemFileList;
								Mem2Source.DataSource = MemFileList;
								_epsxeTabControl.Mem1List.DataSource = Mem1Source;
								_epsxeTabControl.Mem2List.DataSource = Mem2Source;
								dir = new DirectoryInfo(XmlAccess.EpsxeMemDir);
								files = dir.GetFiles("*.mcr");
								MemFileList.Clear();
								if (files.Length == 0)
								{
									MemFileList.Add("--No Memory Cards Found--");
								}
								else
								{
									foreach (FileInfo file in files)
									{
										MemFileList.Add(file.Name);
									}
								}
								break;

							case "NetList":
								NetSource.DataSource = NetFileList;
								_epsxeTabControl.NetList.DataSource = NetSource;
								dir = new DirectoryInfo(XmlAccess.EpsxePluginDir);
								files = dir.GetFiles("net*.dll");
								NetFileList.Clear();
								NetFilePaths.Clear();
								if (files.Length == 0)
								{
									NetFileList.Add("NetPlay Disabled");
								}
								else
								{
									NetFileList.Add("NetPlay Disabled");
									foreach (FileInfo file in files)
									{
										NetFileList.Add(NativeMethods.GetPluginName(file.FullName) +
										                NativeMethods.GetPluginVersion(file.FullName));
										NetFilePaths.Add(file.FullName);
									}
								}
								break;
						}
					}
				}
			}
		}

		#endregion
	}
}