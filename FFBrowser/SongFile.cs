using System;
using System.IO;

namespace FFBrowser
{
	internal class SongFile
	{
		internal static void Save(string path)
		{
			var directory = Path.GetDirectoryName(path);

			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			using (var stream = File.Create(path))
			using (var writer = new BinaryWriter(stream))
			{
				writer.Write((ushort)0);
				writer.Write((ushort)0);
				writer.Write((ushort)0);

				var channels = new long[3];

				var start = Song.Channels[0][0].Address - 6;

				for (var channel = 0; channel < 3; channel++)
				{
					channels[channel] = stream.Position;

					foreach (var e in Song.Channels[channel])
					{
						switch (e.Type)
						{
							case Song.EventType.Note:
								writer.Write((byte)((e.Value << 4) | e.Value2));
								break;

							case Song.EventType.Rest:
								writer.Write((byte)(0xc0 | e.Value));
								break;

							case Song.EventType.LoopInfinite:
								writer.Write((byte)0xd0);
								writer.Write((ushort)(e.Value - start));
								break;

							case Song.EventType.Loop:
								writer.Write((byte)(0xd0 | e.Value2));
								writer.Write((ushort)(e.Value - start));
								break;

							case Song.EventType.Octave:
								writer.Write((byte)(0xd8 | e.Value));
								break;

							case Song.EventType.Envelope:
								writer.Write((byte)(0xe0 | e.Value));
								break;

							case Song.EventType.EnvelopeSpeed:
								writer.Write((byte)0xf8);
								writer.Write((byte)e.Value);
								break;

							case Song.EventType.Tempo:
								writer.Write((byte)(0xf8 | e.Value));
								break;

							case Song.EventType.End:
								writer.Write((byte)0xff);
								break;
						}
					}
				}

				stream.Position = 0;

				for (var channel = 0; channel < 3; channel++)
				{
					writer.Write((ushort)channels[channel]);
				}

				writer.Flush();
			}
		}
	}
}