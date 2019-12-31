using System;
using System.IO;
using System.Text;

namespace FFBrowser
{
	public static class RomArmor
	{
		public static void Load()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.ArmorBank, GameRom.ArmorAddress);

				for (var armor = 0; armor < GameRom.ArmorCount; armor++)
				{
					Game.Armor[armor].Evade = reader.ReadByte();
					Game.Armor[armor].Absorb = reader.ReadByte();
					Game.Armor[armor].Resist = (Game.Elements)reader.ReadByte();
					Game.Armor[armor].Magic = reader.ReadByte();
				}
			}
		}
	}
}