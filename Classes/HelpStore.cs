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

namespace PSf.Classes
{
	internal static class HelpStore
	{
		internal static string GetHelpTips(string helpInfo)
		{
			switch (helpInfo)
			{
					#region Frontend Options

					#region Profiles

				case "OptionsProfilesHelp":
					return "Determines if the profiles folder is valid or not:\n\n" +
					       "Green: Folder path is valid and can be used to store your profiles.\n" +
					       "Red: Folder path is invalid or doesn't exist.\n\n" +
					       "Note: A valid profile folder and at least one valid emulator is " +
					       "required for PS:f to function, the Save function will be enabled " +
					       "when this condition is met.";

					#endregion

					#region ePSXe

				case "OptionsEpsxeHelp":
					return "Determines if the emulator, ePSXe, is selected:\n\n" +
					       "Green: ePSXe has been selected and verified successfully.\n" +
					       "Yellow: ePSXe has been selected but has failed verification; " +
					       "possibly corrupt or using a different file with the same name.\n" +
					       "Red: ePSXe has not been selected.\n\n" +
					       "Note: A valid profile folder and at least one valid emulator is " +
					       "required for PS:f to function, the Save function will be enabled " +
					       "when this condition is met.";

					#endregion

					#region PCSX2

				case "OptionsPcsx2Help":
					return "Determines if the emulator, PCSX2, is selected:\n\n" +
					       "Green: PCSX2 has been selected and verified successfully.\n" +
					       "Yellow: PCSX2 has been selected but has failed verification; " +
					       "possibly corrupt, using a non-public versions or using a " +
					       "different file with the same name.\n" +
					       "Red: PCSX2 has not been selected.\n\n" +
					       "Note: A valid profile folder and at least one valid emulator is " +
					       "required for PS:f to function, the Save function will be enabled " +
					       "when this condition is met.\n\n" +
					       "**The PCSX2 side of the program is not finished thus is disabled.**";

					#endregion

					#region Logging

				case "OptionsLoggingHelp":
					return "This option, when enabled, shows a console window detailing various " +
					       "information when running ePSXe such as plugin initialisation. This " +
					       "is primarily used for troubleshooting purposes.\n\n" +
					       "Disabled by default.";

					#endregion

					#region PPF

				case "OptionsPpfHelp":
					return "A PPF patch allows you to bypass the copy protection and/or add a " +
					       "\"trainer\" (a cheat menu) to a game when loading via a CD " +
					       "image (ISO, BIN, CCD, etc).\n\n" +
					       "When enabled, and if the PPF file is in the same directory and has " +
					       "the same name as the CD image, will automatically load the patch " +
					       "without altering the CD image itself.\n\n" +
					       "Enabled by default.";

					#endregion

					#region File Extensions

				case "OptionsExtHelp":
					return "Associates the .psf1 and .psf2 file extensions to PS:f for easy " +
					       "profile access:\n\n" +
					       "On: File extensions will be or already are registered.\n" +
					       "Off: File extensions will be or already are deregistered. (Default)\n\n" +
					       "Not implemented yet, so it is disabled for the time being.";

					#endregion

					#region Last Profile

				case "OptionsLastProfileHelp":
					return "Allows you to remember the last profile you selected in your " +
					       "last session:\n\n" +
					       "On: Remembers last profile.\n" +
					       "Off: Automatically selects first profile in list when available. " +
					       "(Default)";

					#endregion

					#region File Verify

				case "OptionsVerifyHelp":
					return "Verifies the emulator executables to check if they are valid " +
					       "and not corrupt:\n\n" +
					       "On: Use checksums to verify the emulator(s) on save. (Default)\n" +
					       "Off: Disables verification on save.\n\n" +
					       "Note: Disable verification if you're using an earlier (or possible " +
					       "future) version of ePSXe and a beta or SVN build of PCSX2, no " +
					       "guarantees of these unsupported builds working with PS:f.";

					#endregion

					#region Toolbar

				case "OptionsToolbarHelp":
					return "Simply allows you to alter the design of the toolbar in PS:f; " +
					       "entirely your preference.";

					#endregion

					#endregion

					#region ePSXe Tab Control

					#region BIOS

				case "BIOSHelp":
					return "A BIOS is one of the core components for an emulator to " +
					       "function correctly or even at all. Most known methods of " +
					       "acquiring a BIOS file is illegal, even if you own the console " +
					       "and the specific model. The legal way of acquiring a BIOS is to " +
					       "\"dump\" (extract) it yourself, there are many tutorials on " +
					       "the Internet on doing this, so use your favourite search engine.\n\n" +
					       "No support will be given to those who: state that they downloaded it " +
					       "off the Internet and/or ask where to find it.";

					#endregion

					#region GPU

				case "GPUDefault":
					return "A graphics plugin helps draw the pretty pictures that games make " +
					       "that you see on your monitor. The different choices available determine " +
					       "whether you want accuracy over performance and visa versa, also be able run " +
					       "it without the aid of the graphics card.\n\n" +
					       "Select a plugin from the list above to reveal information about it.";

					#region OpenGL2

				case "OpenGL2Help":
					return "Minimum Requirements: NVIDIA GeForce FX 5600 or ATI Radeon 9600\n\n" +
					       "Arguably, one of the best GPU plug-ins for ePSXe offering the highest " +
					       "graphical quality over the other choices. Supports various shaders to " +
					       "customise/enhance the look of the games.\n\n";

				case "OpenGL2HelpMore":
					return "Fullscreen Mode:\n" +
					       "Runs the emulator at the resolution set, in fullscreen; this does not affect " +
					       "the rendering quality of a game. Always set this to the native resolution of " +
					       "your display.\n\n" +
					       "Window Mode:\n" +
					       "Run the emulator at the resolution set, in a window; like Fullscreen Mode, this " +
					       "does not affect the rendering quality of a game. Window mode is useful for multi-" +
					       "tasking with other running programs.\n\n" +
					       "Widescreen Fix:\n" +
					       "When enabled, and Fullscreen Mode is selected, the game would be displayed in the " +
					       "resolution set in the Window Mode in fullscreen, useful for correcting the aspect " +
					       "ratio of games on a widescreen monitor. It is recommended to use a 4:3 aspect ratio " +
					       "resolution to prevent stretching.\n(Example: Fullscreen @ 1920x1080, Window @ " +
					       "1440x1080)\n\n" +
					       "Color depth:\n" +
					       "Controls how many colours you see on the screen. This option is sort of redundant " +
					       "as if you have an OpenGL 2.0 capable graphics card, it can display and run with 32bit " +
					       "colour just fine.\n\n" +
					       "Internal X/Y Resolution:\n" +
					       "The vast majority of PlayStation games are rendered at 320x240 resolution and this " +
					       "option scales the resolution depending on the setting you select (this is why the " +
					       "fullscreen resolution setting does not matter rendering-wise). Running games, even " +
					       "emulated games at very high resolutions require a lot of VRAM, here is a small " +
					       "table outlining approximate values on rendering resolution and VRAM requirements:\n\n" +
					       "X/Y Setting (Render Res.) [VRAM req.]\n" +
					       "------------------------------------------------\n" +
					       "0/0 (320x240) [Does not matter]\n" +
					       "1/1 (640x480) [Does not matter]\n" +
					       "2/2 (1280x960) [128MB]\n" +
					       "2/3 (1280x1920) [256MB]\n" +
					       "3/3* (2560x1920) [512MB]\n\n" +
					       "*To enable this option, you have to edit the value in the registry but it is " +
					       "non-supported and may cause issues. As far as I know, you cannot increase the " +
					       "value any higher either due to emulator or graphic card limitations.\n\n" +
					       "Stretching Mode:\n" +
					       "As the title says, it allows you to change how the game is stretched on screen " +
					       "but due to the way that some games are rendered, leaving it on the default option " +
					       "'0: Stretch to full window size (standard)' is best otherwise you would be left " +
					       "with some funky aspect ratios.\n\n" +
					       "Render Mode:\n" +
					       "Gives you options to how the game is rendered. Unless you have a very old card, option " +
					       "2 is the best choice as it is the fastest mode available.";

				case "OpenGL2HelpMore2":
					return "";

					#endregion

					#region OpenGL

				case "OpenGLHelp":
					return "Minimum Requirements: Any graphics card supporting OpenGL 1.0 or better\n\n" +
					       "Although it is not as accurate as the OpenGL2 plugin, it is an excellent alternative " +
					       "if your graphics card does not support OpenGL 2.0 or cannot run a game at good speed " +
					       "with OpenGL2. Recommended for ancient graphic cards and old low-budget laptops.";

					#endregion

					#region Soft

				case "SoftHelp":
					return "Minimum Requirements: Any graphics card, 800MHz CPU\n\n" +
					       "The most accurate graphics plugin but sacrifices hardware rendering and is entirely " +
					       "reliant on your CPU. Looks awful on 3D games, highly recommended for 2D games. For the " +
					       "best scaling options, a CPU of 1.5-2GHz is recommended.\n" +
					       "Note: The internal graphics and this plugin are the same and settings are shared.";

					#endregion

					#endregion

					#region SPU

				case "SPUDefault":
					return "A sound plugin helps deliver the funky tunes and nostalgic noises " +
					       "to your speakers or headphones. The different choices available determine " +
					       "the accurate reproduction of the sound, some games work better with " +
					       "certain plug-ins so experimentation is key. The developers were nice " +
					       "enough to make their own plugin which works quite well but the choice " +
					       "for alternatives is there.\n\n" +
					       "Select a plugin from the list above to reveal information about it.";

					#region Internal

				case "InternalSPU":
					return "A built-in sound plugin that does not require any configuration " +
					       "and works pretty well with the majority of games.";

					#endregion

					#region Eternal

				case "Eternal":
					return "A high quality sound plugin with varied options ranging from output " +
					       "types, buffer size, reverb types and so on.";

					#endregion

					#region Peops

				case "PeopsSPU":
					return "A dated plugin that offer great sound accuracy although other plug-ins " +
					       "will perform better.";

					#endregion

					#region PeopsNew

				case "PeopsSPUNew":
					return "A very recent and heavily developed modification of the original P.E.Op.S. " +
					       "DSound plugin improving compatibility, having a deeper array of options, more " +
					       "quality options and lots of advanced options for those who love to tweak.\n\n" +
					       "**Due to how the settings are saved, this plugin is not fully supported yet (No individual settings saved).**";

					#endregion

					#endregion

					#region CD/ISO

				case "CDISODefault":
					return "A CDR plugin allows the emulator to read the complex " +
					       "wizardry on your PlayStation discs for your gaming " +
					       "pleasure. Although ePSXe has a built-in plugin, the " +
					       "alternatives may offer better features and configurability." +
					       "Conversely, using the internal ISO (CD image) reader is the " +
					       "way to go, primarily for convenience and performance reasons.\n\n" +
					       "For \"ripping\" instructions (copying from disc to hard drive) " +
					       "look it up in your favourite search engine.";

				case "InternalCD":
					return "A simple CDR plugin built-in into the emulator, simply works.";

				case "PeopsCD":
					return "This open source plugin allows you to change the way discs " +
					       "are read, helps those who have old quirky CD/DVD drives. " +
					       "Supports loading PPF patches along side the disc and has " +
					       "the ability to extract the sub-channel information to your " +
					       "hard drive if you get performance problems with games that " +
					       "use them.";

				case "Sapu":
					return "";

					#endregion

					#region Pad

				case "PSPad":
					return "Simply allowing you to configure the PlayStation pads with your " +
					       "keyboard and/or connected gamepads.\n\n" +
					       "Users who wish to use their Xbox 360 or PlayStation 3 pad, click " +
					       "on 'Read More' below for instructions on how to get them working.";

					#endregion

					#region Memory Card

				case "PSMem":
					return "Memory cards allow you to save your progress in a game. " +
					       "Each memory card consists of 15 blocks, different games " +
					       "use different number of blocks for saving, for example, " +
					       "Tales of Phantasia uses 1 block while Gran Turismo 2 uses " +
					       "4 blocks.\n\n" +
					       "Future releases will include a memory card manager and creator.";

					#endregion

					#region NetPlay

				case "NetDefault":
					return "NetPlay allows you and a friend to play cooperatively or " +
					       "competitively over LAN (Local Area Network) or the Internet. " +
					       "It is disabled by default. NetPlay plugins will require that " +
					       "both you and your friend have the exact same plugins and settings " +
					       "for it to successfully work (to be confirmed), that includes video, " +
					       "sound and CD plugins.";

					#endregion

					#endregion

				default:
					return string.Empty;
			}
		}
	}
}