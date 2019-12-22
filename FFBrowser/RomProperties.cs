using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	internal static class RomProperties
	{
		internal static void LoadProperties(int map)
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.PropertyBank, GameRom.PropertyAddress);

				reader.BaseStream.Seek(map * 256, SeekOrigin.Current);

				for(var obj = 0; obj < Map.Properties.Length; obj++)
				{

				};
			}
		}
	}
}
