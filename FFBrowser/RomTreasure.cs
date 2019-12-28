using System;
using System.IO;

namespace FFBrowser
{
	public static class RomTreasure
	{
		public static void Load()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.TreasureBank, GameRom.TreasureAddress);

				for (var treasure = 0; treasure < GameRom.TreasureCount; treasure++)
				{
					Map.Treasure[treasure] = reader.ReadByte();
				};
			}
		}
	}
}