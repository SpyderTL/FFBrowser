using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FFBrowser
{
	public static class RomSongs
	{
		// Crystal Theme 0x41
		// Bridge Theme 0x42
		// Epilogue 0x43
		// World Theme 0x44
		// Ship Theme 0x45
		// Airship Theme 0x46
		// Shop Theme 0x4F
		// Battle Theme 0x50
		// Menu Theme 0x51
		// Game Over 0x52
		// Victory Theme 0x53
		// Special Item / Puzzle Solved 0x54
		// Crystal Theme 0x55
		// Save Game 0x56
		// Cure Theme 0x57
		// Treasure Chest 0x58
		// Stop Song 0x80

		public static void Load(int song)
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.SongBank, GameRom.SongAddress + (song * 8));

				var address = reader.ReadUInt16();
				var address2 = reader.ReadUInt16();
				var address3 = reader.ReadUInt16();

				ReadChannel(0, reader, address);
				ReadChannel(1, reader, address2);
				ReadChannel(2, reader, address3);
			}
		}

		public static void ReadChannel(int channel, RomReader reader, int address)
		{
			reader.Seek(GameRom.SongBank, address);

			var events = new List<Song.Event>(2048);

			while (true)
			{
				var e = ReadEvent(reader, ref address);

				events.Add(e);

				if (e.Type == Song.EventType.End ||
					e.Type == Song.EventType.LoopInfinite)
					break;
			}

			Song.Channels[channel] = events.ToArray();
		}

		private static Song.Event ReadEvent(RomReader reader, ref int address)
		{
			var e = new Song.Event
			{
				Address = address
			};

			var value = reader.ReadByte();

			if (value < 0xC0)
			{
				// Note
				e.Type = Song.EventType.Note;
				e.Value = value >> 4;
				e.Value2 = value & 0x0f;
			}
			else if (value < 0xD0)
			{
				// Rest
				e.Type = Song.EventType.Rest;
				e.Value = value & 0x0f;
			}
			else if (value == 0xD0)
			{
				// Infinite Loop
				e.Type = Song.EventType.LoopInfinite;
				e.Value = reader.ReadUInt16();
				address += 2;
			}
			else if (value < 0xD8)
			{
				// Loop
				e.Type = Song.EventType.Loop;
				e.Value = reader.ReadUInt16();
				e.Value2 = value & 0x0f;
				address += 2;
			}
			else if (value < 0xDC)
			{
				// Octave
				e.Type = Song.EventType.Octave;
				e.Value = (value & 0x0f) - 8;
			}
			else if (value < 0xE0)
			{
				// Reserved
				e.Type = Song.EventType.Reserved;
			}
			else if (value < 0xF0)
			{
				// Envelope
				e.Type = Song.EventType.Envelope;
				e.Value = value & 0x0f;
			}
			else if (value < 0xF8)
			{
				// Reserved
				e.Type = Song.EventType.Reserved;
			}
			else if (value == 0xF8)
			{
				// Envelope Speed
				e.Type = Song.EventType.EnvelopeSpeed;

				var value2 = reader.ReadByte();

				e.Value = value2 & 0x0f;
				address++;
			}
			else if (value < 0xFF)
			{
				// Tempo
				e.Type = Song.EventType.Tempo;

				e.Value = (value & 0x0f) - 0x09;
			}
			else if (value == 0xFF)
			{
				// End
				e.Type = Song.EventType.End;
			}

			address++;

			return e;
		}
	}
}