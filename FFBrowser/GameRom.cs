using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	internal static class GameRom
	{
		internal static int WorldBank = 1;
		internal static int WorldRowAddress = 0x8000;
		internal static int WorldAddress = 0x8200;

		internal static int MapBank = 4;
		internal static int MapAddress = 0x8000;

		internal static int ObjectBank = 0;
		internal static int ObjectAddress = 0xB400;
	}
}
