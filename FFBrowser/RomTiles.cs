using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	internal static class RomTiles
	{
		internal static void LoadMap(int map)
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.MapTileBank, GameRom.MapTileAddress);

				reader.BaseStream.Seek(map * 256, SeekOrigin.Current);

				for(var property = 0; property < Map.Tiles.Length; property++)
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
				};
			}
		}
	}
}
