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
using System.Security.Cryptography;

namespace PSf.Classes
{
	internal static class FileChecksum
	{
		private const string EpsxeChecksum =
			"0AA0DEEB5647B53D0B2AF36D076BC7AB23F1C8AC36F8D05C17304DFBD51420B9BA876784C85C25561E58F94351CCB8443DCDC9E7F96C27521EEA4E054421585F";

		private const string Pcsx2Checksum =
			"1C799574FAFCA3A032D4973691BB40464F1F115376D0DE64D055DF9E1C576D2FF5DD04329E372A723648287274AE5AC5CD9ABA3FF48845A5E3452D30715A64D1";

		private static readonly string[] Hashes = {EpsxeChecksum, Pcsx2Checksum};

		internal static string CalculateChecksum(string fileInput)
		{
			using (var file = new FileStream(fileInput, FileMode.Open, FileAccess.Read))
			{
				using (var alg = new SHA512Managed())
				{
					return BitConverter.ToString(alg.ComputeHash(file)).Replace("-", string.Empty);
				}
			}
		}

		internal static bool VerifyChecksum(string inputHash)
		{
			return Hashes.Any(hash => inputHash == hash);
		}
	}
}