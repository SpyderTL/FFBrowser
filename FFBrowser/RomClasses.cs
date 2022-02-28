using System;
using System.IO;

namespace FFBrowser
{
	public static class RomClasses
	{
		public static void Load()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.ClassBank, GameRom.ClassAddress);

				for (var @class = 0; @class < GameRom.ClassCount; @class++)
				{
					Game.Classes[@class].ID = reader.ReadByte();
					Game.Classes[@class].Health = reader.ReadByte();
					Game.Classes[@class].Strength = reader.ReadByte();
					Game.Classes[@class].Agility = reader.ReadByte();
					Game.Classes[@class].Intelligence = reader.ReadByte();
					Game.Classes[@class].Vitality = reader.ReadByte();
					Game.Classes[@class].Luck = reader.ReadByte();
					Game.Classes[@class].Damage = reader.ReadByte();
					Game.Classes[@class].Hit = reader.ReadByte();
					Game.Classes[@class].Evade = reader.ReadByte();
					Game.Classes[@class].MagicDefense = reader.ReadByte();

					reader.ReadBytes(5);
				};

				reader.Seek(GameRom.LevelBank, GameRom.LevelAddress);

				for (var @class = 0; @class < GameRom.ClassCount; @class++)
				{
					Game.Levels[@class] = new Game.LevelData[49];

					for (var level = 0; level < GameRom.LevelCount; level++)
					{
						Game.Levels[@class][level].Flags = (Game.LevelUpFlags)reader.ReadByte();
						Game.Levels[@class][level].MagicLevels = reader.ReadByte();
					}
				};
			}
		}
	}
}