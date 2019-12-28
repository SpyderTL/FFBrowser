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

		internal static int TilesetCount = 8;

		internal static int WorldPortalBank = 0;
		internal static int WorldPortalXAddress = 0xAC00;
		internal static int WorldPortalYAddress = 0xAC20;
		internal static int WorldPortalMapAddress = 0xAC40;
		internal static int WorldPortalCount = 0x20;

		internal static int MapPortalBank = 0;
		internal static int MapPortalXAddress = 0xAD00;
		internal static int MapPortalYAddress = 0xAD40;
		internal static int MapPortalMapAddress = 0xAD80;
		internal static int MapPortalCount = 0x40;

		internal static int MapTilesetBank = 0;
		internal static int MapTilesetAddress = 0xACC0;
		internal static int MapTilesetCount = 0x40;

		internal static int MapExitXAddress = 0xAC60;
		internal static int MapExitYAddress = 0xAC70;
		internal static int MapExitCount = 0x10;

		internal static int TreasureBank = 0;
		internal static int TreasureAddress = 0xB100;
		internal static int TreasureCount = 0x100;

		internal static int DialogBank = 0x0A;
		internal static int DialogAddress = 0x8000;
		internal static int DialogCount = 0x100;

		internal static int ItemBank = 0x0A;
		internal static int ItemAddress = 0xB700;
		internal static int ItemCount = 0x100;

		internal static int PriceBank = 0x0D;
		internal static int PriceAddress = 0xBC00;
	}
}
