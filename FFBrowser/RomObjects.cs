﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	internal static class RomObjects
	{
		internal static void LoadObjects(int map)
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.ObjectBank, GameRom.ObjectAddress);

				reader.BaseStream.Seek(map * 0x30, SeekOrigin.Current);

				for(var obj = 0; obj < Map.Objects.Length; obj++)
				{
					var type = reader.ReadByte();
					var value = reader.ReadByte();
					var y = reader.ReadByte();

					var flags = value & 0xc0;
					var x = value & 0x3f;

					var mapObject = new Map.Object
					{
						Type = type,
						X = x,
						Y = y,
						Flags = flags
					};

					Map.Objects[obj] = mapObject;
				};
			}
		}
	}
}