﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	internal static class RomTiles
	{
		internal static void LoadWorld()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.WorldTileBank, GameRom.WorldTileAddress);

				for (var tile = 0; tile < World.Tiles.Length; tile++)
				{
					var value = reader.ReadByte();
					var value2 = reader.ReadByte();

					World.Tiles[tile] = new World.Tile
					{
						Forest = (value & 0x10) == 0x10,
						Dock = (value & 0x20) == 0x20,
						Type = (World.TileType)(value >> 6),
						Teleport = (value2 & 0x80) == 0x80,
						Battle = (value2 & 0x40) == 0x40,
						Value = value2 & 0x3f
					};
				}

				reader.Seek(GameRom.WorldTileBank, GameRom.WorldTileTopLeftCharacterAddress);

				for (var tile = 0; tile < World.Tiles.Length; tile++)
				{
					World.Tiles[tile].Characters = new byte[4];

					World.Tiles[tile].Characters[0] = reader.ReadByte();
				}

				for (var tile = 0; tile < World.Tiles.Length; tile++)
				{
					World.Tiles[tile].Characters[1] = reader.ReadByte();
				}

				for (var tile = 0; tile < World.Tiles.Length; tile++)
				{
					World.Tiles[tile].Characters[2] = reader.ReadByte();
				}

				for (var tile = 0; tile < World.Tiles.Length; tile++)
				{
					World.Tiles[tile].Characters[3] = reader.ReadByte();
				}

				for (var tile = 0; tile < World.Tiles.Length; tile++)
				{
					var value = reader.ReadByte();

					World.Tiles[tile].Palettes = new byte[4];

					World.Tiles[tile].Palettes[0] = (byte)((value >> 0) & 0x03);
					World.Tiles[tile].Palettes[1] = (byte)((value >> 2) & 0x03);
					World.Tiles[tile].Palettes[2] = (byte)((value >> 4) & 0x03);
					World.Tiles[tile].Palettes[3] = (byte)((value >> 6) & 0x03);
				}

				reader.Seek(GameRom.WorldTileBackgroundBank, GameRom.WorldTileBackgroundAddress);

				for (var tile = 0; tile < World.Tiles.Length; tile++)
				{
					World.Tiles[tile].Background = reader.ReadByte();
				}
			}
		}

		internal static void LoadTileset(int tileset)
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.MapTileBank, GameRom.MapTileAddress);

				reader.BaseStream.Seek(tileset * 256, SeekOrigin.Current);

				for (var property = 0; property < Map.Tiles.Length; property++)
				{
					var value = reader.ReadByte();
					var value2 = reader.ReadByte();

					Map.Tiles[property] = new Map.Tile
					{
						Blocked = (value & 0x01) == 0x01,
						TileType = (Map.TileType)((value >> 1) & 0x0f),
						TeleportType = (Map.TeleportType)(value >> 6),
						Battle = (value & 0x20) == 0x20,
						Value = value2
					};
				}

				reader.Seek(GameRom.MapTilesetBank, GameRom.TilesetCharacterAddress);

				reader.BaseStream.Seek(tileset * 512, SeekOrigin.Current);

				for (var tile = 0; tile < Map.Tiles.Length; tile++)
				{
					Map.Tiles[tile].Characters = new byte[4];

					Map.Tiles[tile].Characters[0] = reader.ReadByte();
				}

				for (var tile = 0; tile < Map.Tiles.Length; tile++)
				{
					Map.Tiles[tile].Characters[1] = reader.ReadByte();
				}

				for (var tile = 0; tile < Map.Tiles.Length; tile++)
				{
					Map.Tiles[tile].Characters[2] = reader.ReadByte();
				}

				for (var tile = 0; tile < Map.Tiles.Length; tile++)
				{
					Map.Tiles[tile].Characters[3] = reader.ReadByte();
				}

				reader.Seek(GameRom.MapTilesetBank, GameRom.TilesetPaletteAddress);

				reader.BaseStream.Seek(tileset * 128, SeekOrigin.Current);

				for (var tile = 0; tile < Map.Tiles.Length; tile++)
				{
					var value = reader.ReadByte();

					Map.Tiles[tile].Palettes = new byte[4];

					Map.Tiles[tile].Palettes[0] = (byte)((value >> 0) & 0x03);
					Map.Tiles[tile].Palettes[1] = (byte)((value >> 2) & 0x03);
					Map.Tiles[tile].Palettes[2] = (byte)((value >> 4) & 0x03);
					Map.Tiles[tile].Palettes[3] = (byte)((value >> 6) & 0x03);
				}
			}
		}
	}
}
