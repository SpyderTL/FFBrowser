using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	internal static class RomPortals
	{
		internal static void LoadWorld()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.WorldPortalBank, GameRom.WorldPortalMapAddress);

				for (var portal = 0; portal < GameRom.WorldPortalCount; portal++)
				{
					Game.WorldPortals[portal].Map = reader.ReadByte();
				};

				reader.Seek(GameRom.WorldPortalBank, GameRom.WorldPortalXAddress);

				for (var portal = 0; portal < GameRom.WorldPortalCount; portal++)
				{
					Game.WorldPortals[portal].X = reader.ReadByte();
				};

				reader.Seek(GameRom.WorldPortalBank, GameRom.WorldPortalYAddress);

				for (var portal = 0; portal < GameRom.WorldPortalCount; portal++)
				{
					Game.WorldPortals[portal].Y = reader.ReadByte();
				};
			}
		}
	}
}
