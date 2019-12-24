﻿using System;
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

		internal static int AttributeBank = 0;
		internal static int AttributeAddress = 0x8400;

		internal static int WorldTileBank = 0;
		internal static int WorldTileAddress = 0x8000;
		// 2 bytes per tiles
		// 128 tiles
		
		internal static int MapTileBank = 0;
		internal static int MapTileAddress = 0x8800;
		// 2 bytes per tiles
		// 128 tiles
	}
}