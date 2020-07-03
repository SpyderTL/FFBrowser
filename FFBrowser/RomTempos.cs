using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FFBrowser
{
	public static class RomTempos
	{
		public static void Load()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.TempoBank, GameRom.TempoAddress);

				for (var tempo = 0; tempo < GameRom.TempoCount; tempo++)
				{
					Song.Tempo[tempo] = new int[GameRom.DurationCount];

					for (var duration = 0; duration < GameRom.DurationCount; duration++)
					{
						Song.Tempo[tempo][duration] = reader.ReadByte();
					}
				}
			}
		}
	}
}