using System;
using System.IO;
using System.Text;

namespace FFBrowser
{
	public static class RomWeapons
	{
		public static void Load()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.WeaponBank, GameRom.WeaponAddress);

				for (var weapon = 0; weapon < GameRom.WeaponCount; weapon++)
				{
					Game.Weapons[weapon].Hit = reader.ReadByte();
					Game.Weapons[weapon].Damage = reader.ReadByte();
					Game.Weapons[weapon].Critical = reader.ReadByte();
					Game.Weapons[weapon].Magic = reader.ReadByte();
					Game.Weapons[weapon].Elements = (Game.Elements)reader.ReadByte();
					Game.Weapons[weapon].Effective = (Game.EnemyCategories)reader.ReadByte();
					Game.Weapons[weapon].Graphic = reader.ReadByte();
					Game.Weapons[weapon].Palette = reader.ReadByte();
				}
			}
		}
	}
}