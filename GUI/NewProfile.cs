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
using System.Windows.Forms;
using PSf.Classes;
using PSf.Properties;

namespace PSf.GUI
{
	internal partial class NewProfile : Form
	{
		private readonly int[] _epsxeCurrentDiscArray = {1, 2, 3, 4};
		private readonly int[] _epsxeTotalDiscArray = {2, 3, 4};
		private readonly int[] _pcsx2CurrentDiscArray = {1, 2};
		private readonly int[] _pcsx2TotalDiscArray = {2};
		private readonly string[] _regionList = {"PAL", "NTSC-U", "NTSC-J"};
		private int _discCurrent = 1;
		private int _discTotal = 2;
		private string _fileExtension = "psf1";
		private string _regionSelect = "PAL";

		internal NewProfile()
		{
			InitializeComponent();
		}

		private void NewProfileLoad(object sender, EventArgs e)
		{
			BackgroundImage = Resources.newprofilebg;
			BackgroundImageLayout = ImageLayout.Center;

			CurrentDiscList.DataSource = _epsxeCurrentDiscArray;
			TotalDiscList.DataSource = _epsxeTotalDiscArray;
			RegionList.DataSource = _regionList;
			ProfilePreviewLabel.Text = string.Empty;
		}

		private void EpsxeRadioSelectCheckedChanged(object sender, EventArgs e)
		{
			switch (EpsxeRadioSelect.Checked)
			{
				case true:
					CurrentDiscList.DataSource = _epsxeCurrentDiscArray;
					TotalDiscList.DataSource = _epsxeTotalDiscArray;
					_fileExtension = "psf1";
					UpdatePreview();
					break;
				case false:
					CurrentDiscList.DataSource = _pcsx2CurrentDiscArray;
					TotalDiscList.DataSource = _pcsx2TotalDiscArray;
					_fileExtension = "psf2";
					UpdatePreview();
					break;
			}
		}

		private void ProfileTitleTextboxTextChanged(object sender, EventArgs e)
		{
			UpdatePreview();
		}

		private void DiscCheckboxCheckedChanged(object sender, EventArgs e)
		{
			switch (DiscCheckbox.Checked)
			{
				case true:
					CurrentDiscList.Enabled = true;
					DiscSeperatorLabel.Enabled = true;
					TotalDiscList.Enabled = true;
					UpdatePreview();
					break;
				case false:
					CurrentDiscList.Enabled = false;
					DiscSeperatorLabel.Enabled = false;
					TotalDiscList.Enabled = false;
					UpdatePreview();
					break;
			}
		}

		private void CurrentDiscListSelectedIndexChanged(object sender, EventArgs e)
		{
			_discCurrent = Convert.ToInt16(CurrentDiscList.Text);
			UpdatePreview();
		}

		private void TotalDiscListSelectedIndexChanged(object sender, EventArgs e)
		{
			_discTotal = Convert.ToInt16(TotalDiscList.Text);
			UpdatePreview();
		}

		private void RegionCheckboxCheckedChanged(object sender, EventArgs e)
		{
			switch (RegionCheckbox.Checked)
			{
				case true:
					RegionList.Enabled = true;
					UpdatePreview();
					break;
				case false:
					RegionList.Enabled = false;
					UpdatePreview();
					break;
			}
		}

		private void RegionListSelectedIndexChanged(object sender, EventArgs e)
		{
			_regionSelect = RegionList.Text;
			UpdatePreview();
		}

		private void UpdatePreview()
		{
			if (ProfileTitleTextbox.Text.Length > 0)
			{
				if (DiscCheckbox.Checked && RegionCheckbox.Checked)
				{
					ProfilePreviewLabel.Text = String.Format("{0} [{1}-{2}] [{3}].{4}", ProfileTitleTextbox.Text, _discCurrent,
					                                         _discTotal, _regionSelect, _fileExtension);
				}
				else if (DiscCheckbox.Checked && RegionCheckbox.Checked == false)
				{
					ProfilePreviewLabel.Text = String.Format("{0} [{1}-{2}].{3}", ProfileTitleTextbox.Text, _discCurrent, _discTotal,
					                                         _fileExtension);
				}
				else if (DiscCheckbox.Checked == false && RegionCheckbox.Checked)
				{
					ProfilePreviewLabel.Text = String.Format("{0} [{1}].{2}", ProfileTitleTextbox.Text, _regionSelect, _fileExtension);
				}
				else if (DiscCheckbox.Checked == false && RegionCheckbox.Checked == false)
				{
					ProfilePreviewLabel.Text = String.Format("{0}.{1}", ProfileTitleTextbox.Text, _fileExtension);
				}
			}
			else
			{
				ProfilePreviewLabel.Text = "";
			}
		}

		private void ProfileCreateButtonClick(object sender, EventArgs e)
		{
			try
			{
				if (DiscCheckbox.Checked && _discCurrent > _discTotal)
				{
					string errorMessage =
						String.Format("There's a problem with your disc values, you have more than what exists; {0} out of {1} discs.",
						              _discCurrent, _discTotal);
					MessageBox.Show(errorMessage, "Incorrect Disc Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				else if (String.IsNullOrEmpty(ProfilePreviewLabel.Text))
				{
					MessageBox.Show("Looks like you left the title blank or typed it in an invisible font.", "Empty Title",
					                MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				else
				{
					XmlAccess.CreateProfile(ProfilePreviewLabel.Text);
					if (File.Exists(Path.Combine(XmlAccess.ReadSettings("Profiles"), ProfilePreviewLabel.Text)))
					{
						XmlAccess.ReadProfileToMemory(ProfilePreviewLabel.Text);
						XmlAccess.WriteInfo("Title", ProfileTitleTextbox.Text);
						XmlAccess.WriteInfo("Region", RegionCheckbox.Checked ? _regionSelect : string.Empty);
						XmlAccess.WriteInfo("Disc", DiscCheckbox.Checked ? string.Format("{0}/{1}", _discCurrent, _discTotal) : "N/A");
						XmlAccess.WriteProfileSave(ProfilePreviewLabel.Text);
					}
					Close();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("The title you entered contained one or more of the following illegal characters:\n" +
				                "\\ / : * ? \" < > |\n\n" +
				                "Please correct this before continuing.");
			}
		}
	}
}