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
using PSf.Properties;

namespace PSf.GUI.Help
{
	public partial class AboutWindow : Form
	{
		private readonly string _currentFolder = Path.GetDirectoryName(Application.ExecutablePath);

		public AboutWindow()
		{
			InitializeComponent();
		}

		private void AboutWindowLoad(object sender, EventArgs e)
		{
			BackgroundImage = Resources.aboutbg;
			BackgroundImageLayout = ImageLayout.Center;

			using (var ico = new Icon(Resources.logo, 64, 64))
			{
				AboutLogo.Image = ico.ToBitmap();
			}

			AppNameLabel.Text = "PS:f";
			AppVersionLabel.Text = "v" + Application.ProductVersion;

			AboutDisclaimer.Text = "Created by\nDarrell (3rdDin8) Perks 2011" +
			                       "\n\nLicensed with";
		}

		private void AboutLicenseLinkClicked(object sender, EventArgs e)
		{
			Process.Start(_currentFolder + @"\License.txt");
		}
	}
}