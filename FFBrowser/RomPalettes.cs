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
			}
		}
	}
}
