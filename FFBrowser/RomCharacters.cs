using System;
using System.Drawing;
using System.IO;

namespace FFBrowser
{
	public static class RomCharacters
	{
		public static void Load()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.FontCharacterBank, GameRom.FontCharacterAddress);

				// 1 bits per pixel
				// 1 byte per row
				// 8 rows per plane
				// 2 planes per character

				Game.FontCharacters = new byte[GameRom.FontCharacterCount][];

				for (var character = 0; character < GameRom.FontCharacterCount; character++)
				{
					var values = new byte[64];

					var plane0 = reader.ReadBytes(8);
					var plane1 = reader.ReadBytes(8);

					for (var row = 0; row < 8; row++)
					{
						values[(row * 8) + 0] = (byte)(((plane0[row] >> 7) & 0x01) | (((plane1[row] >> 7) & 0x01) << 1));
						values[(row * 8) + 1] = (byte)(((plane0[row] >> 6) & 0x01) | (((plane1[row] >> 6) & 0x01) << 1));
						values[(row * 8) + 2] = (byte)(((plane0[row] >> 5) & 0x01) | (((plane1[row] >> 5) & 0x01) << 1));
						values[(row * 8) + 3] = (byte)(((plane0[row] >> 4) & 0x01) | (((plane1[row] >> 4) & 0x01) << 1));
						values[(row * 8) + 4] = (byte)(((plane0[row] >> 3) & 0x01) | (((plane1[row] >> 3) & 0x01) << 1));
						values[(row * 8) + 5] = (byte)(((plane0[row] >> 2) & 0x01) | (((plane1[row] >> 2) & 0x01) << 1));
						values[(row * 8) + 6] = (byte)(((plane0[row] >> 1) & 0x01) | (((plane1[row] >> 1) & 0x01) << 1));
						values[(row * 8) + 7] = (byte)(((plane0[row] >> 0) & 0x01) | (((plane1[row] >> 0) & 0x01) << 1));
					}

					Game.FontCharacters[character] = values;
				};

				reader.Seek(GameRom.WorldCharacterBank, GameRom.WorldCharacterAddress);

				for (var character = 0; character < GameRom.WorldCharacterCount; character++)
				{
					var values = new byte[64];

					var plane0 = reader.ReadBytes(8);
					var plane1 = reader.ReadBytes(8);

					for (var row = 0; row < 8; row++)
					{
						values[(row * 8) + 0] = (byte)(((plane0[row] >> 7) & 0x01) | (((plane1[row] >> 7) & 0x01) << 1));
						values[(row * 8) + 1] = (byte)(((plane0[row] >> 6) & 0x01) | (((plane1[row] >> 6) & 0x01) << 1));
						values[(row * 8) + 2] = (byte)(((plane0[row] >> 5) & 0x01) | (((plane1[row] >> 5) & 0x01) << 1));
						values[(row * 8) + 3] = (byte)(((plane0[row] >> 4) & 0x01) | (((plane1[row] >> 4) & 0x01) << 1));
						values[(row * 8) + 4] = (byte)(((plane0[row] >> 3) & 0x01) | (((plane1[row] >> 3) & 0x01) << 1));
						values[(row * 8) + 5] = (byte)(((plane0[row] >> 2) & 0x01) | (((plane1[row] >> 2) & 0x01) << 1));
						values[(row * 8) + 6] = (byte)(((plane0[row] >> 1) & 0x01) | (((plane1[row] >> 1) & 0x01) << 1));
						values[(row * 8) + 7] = (byte)(((plane0[row] >> 0) & 0x01) | (((plane1[row] >> 0) & 0x01) << 1));
					}

					World.Characters[character] = values;
				};

				reader.Seek(GameRom.ClassCharacterBank, GameRom.ClassCharacterAddress);

				for (var @class = 0; @class < GameRom.ClassCount; @class++)
				{
					Game.Classes[@class].Characters = new byte[GameRom.ClassCharacterCount][];

					for (var character = 0; character < GameRom.ClassCharacterCount; character++)
					{
						var values = new byte[64];

						var plane0 = reader.ReadBytes(8);
						var plane1 = reader.ReadBytes(8);

						for (var row = 0; row < 8; row++)
						{
							values[(row * 8) + 0] = (byte)(((plane0[row] >> 7) & 0x01) | (((plane1[row] >> 7) & 0x01) << 1));
							values[(row * 8) + 1] = (byte)(((plane0[row] >> 6) & 0x01) | (((plane1[row] >> 6) & 0x01) << 1));
							values[(row * 8) + 2] = (byte)(((plane0[row] >> 5) & 0x01) | (((plane1[row] >> 5) & 0x01) << 1));
							values[(row * 8) + 3] = (byte)(((plane0[row] >> 4) & 0x01) | (((plane1[row] >> 4) & 0x01) << 1));
							values[(row * 8) + 4] = (byte)(((plane0[row] >> 3) & 0x01) | (((plane1[row] >> 3) & 0x01) << 1));
							values[(row * 8) + 5] = (byte)(((plane0[row] >> 2) & 0x01) | (((plane1[row] >> 2) & 0x01) << 1));
							values[(row * 8) + 6] = (byte)(((plane0[row] >> 1) & 0x01) | (((plane1[row] >> 1) & 0x01) << 1));
							values[(row * 8) + 7] = (byte)(((plane0[row] >> 0) & 0x01) | (((plane1[row] >> 0) & 0x01) << 1));
						}

						Game.Classes[@class].Characters[character] = values;
					};
				}

				reader.Seek(GameRom.PointerCharacterBank, GameRom.PointerCharacterAddress);

				Game.BattleCharacters = new byte[GameRom.PointerCharacterCount][];

				for (var character = 0; character < GameRom.PointerCharacterCount; character++)
				{
					var values = new byte[64];

					var plane0 = reader.ReadBytes(8);
					var plane1 = reader.ReadBytes(8);

					for (var row = 0; row < 8; row++)
					{
						values[(row * 8) + 0] = (byte)(((plane0[row] >> 7) & 0x01) | (((plane1[row] >> 7) & 0x01) << 1));
						values[(row * 8) + 1] = (byte)(((plane0[row] >> 6) & 0x01) | (((plane1[row] >> 6) & 0x01) << 1));
						values[(row * 8) + 2] = (byte)(((plane0[row] >> 5) & 0x01) | (((plane1[row] >> 5) & 0x01) << 1));
						values[(row * 8) + 3] = (byte)(((plane0[row] >> 4) & 0x01) | (((plane1[row] >> 4) & 0x01) << 1));
						values[(row * 8) + 4] = (byte)(((plane0[row] >> 3) & 0x01) | (((plane1[row] >> 3) & 0x01) << 1));
						values[(row * 8) + 5] = (byte)(((plane0[row] >> 2) & 0x01) | (((plane1[row] >> 2) & 0x01) << 1));
						values[(row * 8) + 6] = (byte)(((plane0[row] >> 1) & 0x01) | (((plane1[row] >> 1) & 0x01) << 1));
						values[(row * 8) + 7] = (byte)(((plane0[row] >> 0) & 0x01) | (((plane1[row] >> 0) & 0x01) << 1));
					}

					Game.BattleCharacters[character] = values;
				};

				reader.Seek(GameRom.BackgroundCharacterBank, GameRom.BackgroundCharacterAddress);

				for (var background = 0; background < 8; background++)
				{
					World.BackgroundCharacters[background] = new byte[GameRom.BackgroundCharacterCount][];

					for (var character = 0; character < GameRom.BackgroundCharacterCount; character++)
					{
						var values = new byte[64];

						var plane0 = reader.ReadBytes(8);
						var plane1 = reader.ReadBytes(8);

						for (var row = 0; row < 8; row++)
						{
							values[(row * 8) + 0] = (byte)(((plane0[row] >> 7) & 0x01) | (((plane1[row] >> 7) & 0x01) << 1));
							values[(row * 8) + 1] = (byte)(((plane0[row] >> 6) & 0x01) | (((plane1[row] >> 6) & 0x01) << 1));
							values[(row * 8) + 2] = (byte)(((plane0[row] >> 5) & 0x01) | (((plane1[row] >> 5) & 0x01) << 1));
							values[(row * 8) + 3] = (byte)(((plane0[row] >> 4) & 0x01) | (((plane1[row] >> 4) & 0x01) << 1));
							values[(row * 8) + 4] = (byte)(((plane0[row] >> 3) & 0x01) | (((plane1[row] >> 3) & 0x01) << 1));
							values[(row * 8) + 5] = (byte)(((plane0[row] >> 2) & 0x01) | (((plane1[row] >> 2) & 0x01) << 1));
							values[(row * 8) + 6] = (byte)(((plane0[row] >> 1) & 0x01) | (((plane1[row] >> 1) & 0x01) << 1));
							values[(row * 8) + 7] = (byte)(((plane0[row] >> 0) & 0x01) | (((plane1[row] >> 0) & 0x01) << 1));
						}

						World.BackgroundCharacters[background][character] = values;
					};
				}

				reader.Seek(GameRom.BackgroundCharacterBank2, GameRom.BackgroundCharacterAddress);

				for (var background = 8; background < 16; background++)
				{
					World.BackgroundCharacters[background] = new byte[GameRom.BackgroundCharacterCount][];

					for (var character = 0; character < GameRom.BackgroundCharacterCount; character++)
					{
						var values = new byte[64];

						var plane0 = reader.ReadBytes(8);
						var plane1 = reader.ReadBytes(8);

						for (var row = 0; row < 8; row++)
						{
							values[(row * 8) + 0] = (byte)(((plane0[row] >> 7) & 0x01) | (((plane1[row] >> 7) & 0x01) << 1));
							values[(row * 8) + 1] = (byte)(((plane0[row] >> 6) & 0x01) | (((plane1[row] >> 6) & 0x01) << 1));
							values[(row * 8) + 2] = (byte)(((plane0[row] >> 5) & 0x01) | (((plane1[row] >> 5) & 0x01) << 1));
							values[(row * 8) + 3] = (byte)(((plane0[row] >> 4) & 0x01) | (((plane1[row] >> 4) & 0x01) << 1));
							values[(row * 8) + 4] = (byte)(((plane0[row] >> 3) & 0x01) | (((plane1[row] >> 3) & 0x01) << 1));
							values[(row * 8) + 5] = (byte)(((plane0[row] >> 2) & 0x01) | (((plane1[row] >> 2) & 0x01) << 1));
							values[(row * 8) + 6] = (byte)(((plane0[row] >> 1) & 0x01) | (((plane1[row] >> 1) & 0x01) << 1));
							values[(row * 8) + 7] = (byte)(((plane0[row] >> 0) & 0x01) | (((plane1[row] >> 0) & 0x01) << 1));
						}

						World.BackgroundCharacters[background][character] = values;
					};
				}
			}
		}

		public static void LoadTileset(int tileset)
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.MapCharacterBank, GameRom.MapCharacterAddress + (tileset * 0x0800));

				// 1 bits per pixel
				// 1 byte per row
				// 8 rows per plane
				// 2 planes per character

				for (var character = 0; character < GameRom.MapCharacterCount; character++)
				{
					var values = new byte[64];

					var plane0 = reader.ReadBytes(8);
					var plane1 = reader.ReadBytes(8);

					for (var row = 0; row < 8; row++)
					{
						values[(row * 8) + 0] = (byte)(((plane0[row] >> 7) & 0x01) | (((plane1[row] >> 7) & 0x01) << 1));
						values[(row * 8) + 1] = (byte)(((plane0[row] >> 6) & 0x01) | (((plane1[row] >> 6) & 0x01) << 1));
						values[(row * 8) + 2] = (byte)(((plane0[row] >> 5) & 0x01) | (((plane1[row] >> 5) & 0x01) << 1));
						values[(row * 8) + 3] = (byte)(((plane0[row] >> 4) & 0x01) | (((plane1[row] >> 4) & 0x01) << 1));
						values[(row * 8) + 4] = (byte)(((plane0[row] >> 3) & 0x01) | (((plane1[row] >> 3) & 0x01) << 1));
						values[(row * 8) + 5] = (byte)(((plane0[row] >> 2) & 0x01) | (((plane1[row] >> 2) & 0x01) << 1));
						values[(row * 8) + 6] = (byte)(((plane0[row] >> 1) & 0x01) | (((plane1[row] >> 1) & 0x01) << 1));
						values[(row * 8) + 7] = (byte)(((plane0[row] >> 0) & 0x01) | (((plane1[row] >> 0) & 0x01) << 1));
					}

					Map.Characters[character] = values;
				};
			}
		}
	}
}