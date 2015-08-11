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

namespace PSf.GUI.Help
{
	partial class AboutWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.AboutLogo = new System.Windows.Forms.PictureBox();
			this.AppNameLabel = new System.Windows.Forms.Label();
			this.AppVersionLabel = new System.Windows.Forms.Label();
			this.AboutDisclaimer = new System.Windows.Forms.Label();
			this.AboutLicense = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.AboutLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// AboutLogo
			// 
			this.AboutLogo.BackColor = System.Drawing.Color.Transparent;
			this.AboutLogo.Location = new System.Drawing.Point(12, 12);
			this.AboutLogo.Name = "AboutLogo";
			this.AboutLogo.Size = new System.Drawing.Size(64, 64);
			this.AboutLogo.TabIndex = 0;
			this.AboutLogo.TabStop = false;
			// 
			// AppNameLabel
			// 
			this.AppNameLabel.AutoSize = true;
			this.AppNameLabel.BackColor = System.Drawing.Color.Transparent;
			this.AppNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AppNameLabel.Location = new System.Drawing.Point(83, 19);
			this.AppNameLabel.Name = "AppNameLabel";
			this.AppNameLabel.Size = new System.Drawing.Size(62, 31);
			this.AppNameLabel.TabIndex = 1;
			this.AppNameLabel.Text = "App";
			// 
			// AppVersionLabel
			// 
			this.AppVersionLabel.AutoSize = true;
			this.AppVersionLabel.BackColor = System.Drawing.Color.Transparent;
			this.AppVersionLabel.Location = new System.Drawing.Point(86, 50);
			this.AppVersionLabel.Name = "AppVersionLabel";
			this.AppVersionLabel.Size = new System.Drawing.Size(82, 13);
			this.AppVersionLabel.TabIndex = 2;
			this.AppVersionLabel.Text = "v0.0.0000.0000";
			// 
			// AboutDisclaimer
			// 
			this.AboutDisclaimer.BackColor = System.Drawing.Color.Transparent;
			this.AboutDisclaimer.Location = new System.Drawing.Point(12, 79);
			this.AboutDisclaimer.Name = "AboutDisclaimer";
			this.AboutDisclaimer.Size = new System.Drawing.Size(151, 55);
			this.AboutDisclaimer.TabIndex = 3;
			this.AboutDisclaimer.Text = "Line1\r\nLine2\r\n\r\nLine3";
			this.AboutDisclaimer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// AboutLicense
			// 
			this.AboutLicense.BackColor = System.Drawing.Color.Transparent;
			this.AboutLicense.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AboutLicense.ForeColor = System.Drawing.Color.SteelBlue;
			this.AboutLicense.Location = new System.Drawing.Point(51, 134);
			this.AboutLicense.Name = "AboutLicense";
			this.AboutLicense.Size = new System.Drawing.Size(72, 15);
			this.AboutLicense.TabIndex = 4;
			this.AboutLicense.Text = "GNU GPL v3";
			this.AboutLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.AboutLicense.Click += new System.EventHandler(this.AboutLicenseLinkClicked);
			// 
			// AboutWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(175, 158);
			this.Controls.Add(this.AboutLicense);
			this.Controls.Add(this.AboutDisclaimer);
			this.Controls.Add(this.AppVersionLabel);
			this.Controls.Add(this.AppNameLabel);
			this.Controls.Add(this.AboutLogo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.Load += new System.EventHandler(this.AboutWindowLoad);
			((System.ComponentModel.ISupportInitialize)(this.AboutLogo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox AboutLogo;
		private System.Windows.Forms.Label AppNameLabel;
		private System.Windows.Forms.Label AppVersionLabel;
		private System.Windows.Forms.Label AboutDisclaimer;
		private System.Windows.Forms.Label AboutLicense;
	}
}