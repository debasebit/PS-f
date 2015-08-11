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
using System.Runtime.InteropServices;

namespace PSf.Classes
{
	static class NativeMethods
	{
		[DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
		static extern int LoadLibrary(
			[MarshalAs(UnmanagedType.LPStr)] string lpLibFileName);

		[DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
		static extern IntPtr GetProcAddress(int hModule,
			[MarshalAs(UnmanagedType.LPStr)] string lpProcName);

		[DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
		static extern bool FreeLibrary(int hModule);

		delegate string DllName();

		delegate void DllFunction();

		internal static string GetPluginName(string dllFile)
		{
			var hModule = LoadLibrary(dllFile);
			var intPtr = GetProcAddress(hModule, "PSEgetLibName");
			var dllname = (DllName)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(DllName));
			var name = dllname();
			FreeLibrary(hModule);
			return name;
		}

		internal static string GetPluginVersion(string dllFile)
		{
			try
			{
				var ver1 = FileVersionInfo.GetVersionInfo(dllFile);
				var ver2 = ver1.FileVersion.Replace("0, ", "");
				var ver3 = ver2.Replace(", 0", "");
				return " v" + ver3.Replace(", ", ".");
			}
			catch (Exception)
			{
				return string.Empty;
			}
		}

		internal static void PluginFunction(string dllFile, string function)
		{
			try
			{
				var hModule = LoadLibrary(dllFile);
				var intPtr = GetProcAddress(hModule, function);
				var dllfunc = (DllFunction)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(DllFunction));
				dllfunc();
				FreeLibrary(hModule);
			}

			catch (ArgumentNullException)
			{
				System.Windows.Forms.MessageBox.Show("The plugin seems to have gone missing or is broken. \n\nTo fix this, redownload the plugin then restart the program.");
			}
		}
	}
}