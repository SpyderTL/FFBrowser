using System;
using System.IO;
using System.Text;

namespace FFBrowser
{
	public static class RomMagic
	{
		public static void Load()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.MagicBank, GameRom.MagicAddress);

				for (var magic = 0; magic < GameRom.MagicCount; magic++)
				{
					Game.Magic[magic].Hit = reader.ReadByte();
					Game.Magic[magic].Effective = (Game.EnemyCategories)reader.ReadByte();
					Game.Magic[magic].Elements = (Game.Elements)reader.ReadByte();
					Game.Magic[magic].Target = (Game.MagicTarget)reader.ReadByte();
					Game.Magic[magic].Effect = reader.ReadByte();
					Game.Magic[magic].Graphic = reader.ReadByte();
					Game.Magic[magic].Palette = reader.ReadByte();
					Game.Magic[magic].Reserved = reader.ReadByte();
				}
			}
		}
	}
}