using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	public static class RomDomains
	{
		public static void LoadWorld()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.WorldDomainBank, GameRom.WorldDomainAddress);

				for (var domain = 0; domain < GameRom.WorldDomainCount; domain++)
				{
					for (var formation = 0; formation < GameRom.DomainFormationCount; formation++)
					{
						var data = reader.ReadByte();

						World.Domains[domain, formation].Formation = data & 0x7f;
						World.Domains[domain, formation].Alternate = (data & 0x80) == 0x80;
					}
				}
			}
		}

		public static void LoadMap(int map)
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.MapDomainBank, GameRom.MapDomainAddress + (map * 8));

				for (var formation = 0; formation < GameRom.DomainFormationCount; formation++)
				{
					var data = reader.ReadByte();

					Map.Formations[formation].Formation = data & 0x7f;
					Map.Formations[formation].Alternate = (data & 0x80) == 0x80;
				}
			}
		}
	}
}
