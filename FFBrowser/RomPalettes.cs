using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	internal static class RomPalettes
	{
		internal static void LoadBattlePalettes()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.SpritePaletteBank, GameRom.SpritePaletteAddress);

				for (var palette = 0; palette < GameRom.SpritePaletteCount; palette++)
				{
					Game.BattlePalettes[palette] = new byte[4];

					Game.BattlePalettes[palette][0] = reader.ReadByte();
					Game.BattlePalettes[palette][1] = reader.ReadByte();
					Game.BattlePalettes[palette][2] = reader.ReadByte();
					Game.BattlePalettes[palette][3] = reader.ReadByte();
				};

				reader.Seek(GameRom.ClassPaletteBank, GameRom.ClassPaletteAddress);

				for (var @class = 0; @class < GameRom.ClassCount; @class++)
				{
					Game.Classes[@class].Palette = reader.ReadByte();
				}

				for (var @class = 0; @class < GameRom.ClassCount; @class++)
				{
					Game.Classes[@class].PromotedPalette = reader.ReadByte();
				}

				reader.Seek(GameRom.WorldPaletteBank, GameRom.WorldPaletteAddress);

				for (var entry = 0; entry < GameRom.WorldPaletteCount; entry++)
				{
					World.Palette[entry] = reader.ReadByte();
				}

				reader.Seek(GameRom.BackgroundPaletteBank, GameRom.BackgroundPaletteAddress);

				for (var background = 0; background < GameRom.BackgroundPaletteCount; background++)
				{
					Game.BackgroundPalettes[background] = new byte[4];

					Game.BackgroundPalettes[background][0] = reader.ReadByte();
					Game.BackgroundPalettes[background][1] = reader.ReadByte();
					Game.BackgroundPalettes[background][2] = reader.ReadByte();
					Game.BackgroundPalettes[background][3] = reader.ReadByte();
				}
			}
		}

		internal static void LoadMapPalette(int map)
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.MapPaletteBank, GameRom.MapPaletteAddress + (map * GameRom.MapPaletteCount * 4));

				for (var entry = 0; entry < GameRom.MapPaletteCount; entry++)
				{
					Map.Palette[entry] = new byte[4];

					Map.Palette[entry][0] = reader.ReadByte();
					Map.Palette[entry][1] = reader.ReadByte();
					Map.Palette[entry][2] = reader.ReadByte();
					Map.Palette[entry][3] = reader.ReadByte();
				}
			}
		}
	}
}
