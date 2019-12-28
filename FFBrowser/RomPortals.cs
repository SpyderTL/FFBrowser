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
		internal static void LoadWorldPortals()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.WorldPortalBank, GameRom.WorldPortalMapAddress);

				for (var portal = 0; portal < GameRom.WorldPortalCount; portal++)
				{
					World.Portals[portal].Map = reader.ReadByte();
				};

				reader.Seek(GameRom.WorldPortalBank, GameRom.WorldPortalXAddress);

				for (var portal = 0; portal < GameRom.WorldPortalCount; portal++)
				{
					World.Portals[portal].X = reader.ReadByte();
				};

				reader.Seek(GameRom.WorldPortalBank, GameRom.WorldPortalYAddress);

				for (var portal = 0; portal < GameRom.WorldPortalCount; portal++)
				{
					World.Portals[portal].Y = reader.ReadByte();
				};
			}
		}

		internal static void LoadMapPortals()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.MapPortalBank, GameRom.MapPortalMapAddress);

				for (var portal = 0; portal < GameRom.MapPortalCount; portal++)
				{
					Map.Portals[portal].Map = reader.ReadByte();
				};

				reader.Seek(GameRom.MapPortalBank, GameRom.MapPortalXAddress);

				for (var portal = 0; portal < GameRom.MapPortalCount; portal++)
				{
					Map.Portals[portal].X = reader.ReadByte();
				};

				reader.Seek(GameRom.MapPortalBank, GameRom.MapPortalYAddress);

				for (var portal = 0; portal < GameRom.MapPortalCount; portal++)
				{
					Map.Portals[portal].Y = reader.ReadByte();
				};

				reader.Seek(GameRom.MapPortalBank, GameRom.MapExitXAddress);

				for (var exit = 0; exit < GameRom.MapExitCount; exit++)
				{
					Map.Exits[exit].X = reader.ReadByte();
				};

				reader.Seek(GameRom.MapPortalBank, GameRom.MapExitYAddress);

				for (var exit = 0; exit < GameRom.MapExitCount; exit++)
				{
					Map.Exits[exit].Y = reader.ReadByte();
				};
			}
		}
	}
}
