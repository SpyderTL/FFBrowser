using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	internal static class RomMap
	{
		internal static int[] MapBanks = new int[64];
		internal static int[] MapAddresses = new int[64];

		internal static void LoadWorld()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.WorldBank, GameRom.WorldAddress);

				var rows = Enumerable.Range(0, 256).Select(x =>
				{
					var segments = new List<World.Segment>();

					while (true)
					{
						var value = reader.ReadByte();

						if (value == 0xff)
							break;

						var repeat = 0;

						if ((value & 0x80) == 0x80)
						{
							value &= 0x7f;

							repeat = reader.ReadByte();

							if (repeat == 0)
								repeat = 255;
						}

						segments.Add(new World.Segment { Tile = value, Repeat = repeat });
					}

					return segments.ToArray();
				}).ToArray();

				World.Rows = rows;
			}
		}

		internal static void LoadMaps()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.MapBank, GameRom.MapAddress);

				for (int map = 0; map < MapAddresses.Length; map++)
				{
					var value = reader.ReadUInt16();

					var address = (value & 0x3fff) + GameRom.MapAddress;
					var bank = (value >> 14) + GameRom.MapBank;

					MapAddresses[map] = address;
					MapBanks[map] = bank;
				}
			}
		}

		internal static void LoadMap(int map)
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(MapBanks[map], MapAddresses[map]);

				var segments = new List<Map.Segment>();

				while (true)
				{
					var value = reader.ReadByte();

					if (value == 0xff)
						break;

					var repeat = 0;

					if ((value & 0x80) == 0x80)
					{
						value &= 0x7f;

						repeat = reader.ReadByte();

						if (repeat == 0)
							repeat = 255;
					}

					segments.Add(new Map.Segment { Tile = value, Repeat = repeat });
				}

				Map.Segments = segments.ToArray();
			}
		}
	}
}
