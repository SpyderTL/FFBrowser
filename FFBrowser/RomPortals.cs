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
		internal static void Load()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.PortalBank, GameRom.PortalMapAddress);

				for (var portal = 0; portal < GameRom.PortalCount; portal++)
				{
					Game.Portals[portal].Map = reader.ReadByte();
				};

				reader.Seek(GameRom.PortalBank, GameRom.PortalXAddress);

				for (var portal = 0; portal < GameRom.PortalCount; portal++)
				{
					Game.Portals[portal].X = reader.ReadByte();
				};

				reader.Seek(GameRom.PortalBank, GameRom.PortalYAddress);

				for (var portal = 0; portal < GameRom.PortalCount; portal++)
				{
					Game.Portals[portal].Y = reader.ReadByte();
				};
			}
		}
	}
}
