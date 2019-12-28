using System;
using System.IO;
using System.Text;

namespace FFBrowser
{
	public static class RomItems
	{
		public static void Load()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.ItemBank, GameRom.ItemAddress);

				var addresses = new int[GameRom.ItemCount];

				for (var item = 0; item < GameRom.ItemCount; item++)
				{
					addresses[item] = reader.ReadUInt16();
				};

				for (var item = 0; item < GameRom.ItemCount; item++)
				{
					reader.Seek(GameRom.ItemBank, addresses[item]);

					Game.Items[item] = reader.ReadItem();
				}
			}
		}

		private static string ReadItem(this RomReader reader)
		{
			var builder = new StringBuilder(256);

			while (true)
			{
				var character = reader.ReadByte();

				if (character == 0)
					break;

				if (character == 0x01)
					builder.Append("\\n");
				else if (character == 0x02)
					builder.Append("[Item Name]");
				else if (character == 0x03)
					builder.Append("[Character Name]");
				else if (character == 0x05)
					builder.Append("\\r\\n");
				else
					builder.Append(Characters[character]);
			}

			return builder.ToString();
		}

		private static string[] Characters = new string[]
		{
			// 0x00
			"[0x00]",
			"[0x01]",
			"[0x02]",
			"[0x03]",
			"[0x04]",
			"[0x05]",
			"[0x06]",
			"[0x07]",
			"[0x08]",
			"[0x09]",
			"[0x0a]",
			"[0x0b]",
			"[0x0c]",
			"[0x0d]",
			"[0x0e]",
			"[0x0f]",

			// 0x10
			"[0x10]",
			"[0x11]",
			"[0x12]",
			"[0x13]",
			"[0x14]",
			"[0x15]",
			"[0x16]",
			"[0x17]",
			"[0x18]",
			"[0x19]",
			"e ",
			" t",
			"th",
			"he",
			"s ",
			"in",

			// 0x20
			" a",
			"t ",
			"an",
			"re",
			" s",
			"er",
			"ou",
			"d ",
			"to",
			"n ",
			"ng",
			"ea",
			"es",
			" i",
			"o ",
			"ar",

			// 0x30
			"is",
			" b",
			"ve",
			" w",
			"me",
			"or",
			" o",
			"st",
			" c",
			"at",
			"en",
			"nd",
			"on",
			"hi",
			"se",
			"as",

			// 0x40
			"ed",
			"ha",
			" m",
			" f",
			"r ",
			"le",
			"ow",
			"g ",
			"ce",
			"om",
			"GI",
			"y ",
			"of",
			"ro",
			"ll",
			" p",

			// 0x50
			" y",
			"ca",
			"MA",
			"te",
			"f ",
			"ur",
			"yo",
			"ti",
			"l ",
			" h",
			"ne",
			"it",
			"ri",
			"wa",
			"ac",
			"al",

			// 0x60
			"we",
			"il",
			"be",
			"rs",
			"u ",
			" l",
			"ge",
			" d",
			"li",
			"....",
			"ne",
			"it",
			"ri",
			"wa",
			"ac",
			"al",

			// 0x70
			"[0x70]",
			"[0x71]",
			"[0x72]",
			"[0x73]",
			"[0x74]",
			"[0x75]",
			"[0x76]",
			"[0x77]",
			"[0x78]",
			"[0x79]",
			"/",
			"[0x7b]",
			"[0x7c]",
			"[0x7d]",
			"[0x7e]",
			"[0x7f]",

			// 0x80
			"0",
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			"A",
			"B",
			"C",
			"D",
			"E",
			"F",

			// 0x90
			"G",
			"H",
			"I",
			"J",
			"K",
			"L",
			"M",
			"N",
			"O",
			"P",
			"Q",
			"R",
			"S",
			"T",
			"U",
			"V",

			// 0xa0
			"W",
			"X",
			"Y",
			"Z",
			"a",
			"b",
			"c",
			"d",
			"e",
			"f",
			"g",
			"h",
			"i",
			"j",
			"k",
			"l",

			// 0xb0
			"m",
			"n",
			"o",
			"p",
			"q",
			"r",
			"s",
			"t",
			"u",
			"v",
			"w",
			"x",
			"y",
			"z",
			"'",
			",",

			// 0xc0
			".",
			"[0xc1]",
			"-",
			"..",
			"!",
			"?",
			"[0xc6]",
			"[0xc7]",
			"ee",
			"[0xc9]",
			"[0xca]",
			"[0xcb]",
			"[0xcc]",
			"[0xcd]",
			"[0xce]",
			"[0xcf]",

			// 0xd0
			"[0xd0]",
			"[0xd1]",
			"[0xd2]",
			"[0xd3]",
			"[Sword]",
			"[Hammer]",
			"[Dagger]",
			"[Axe]",
			"[Staff]",
			"[Nunchuck]",
			"[Armor]",
			"[Shield]",
			"[Helmet]",
			"[Gauntlet]",
			"[Bracelet]",
			"[Robe]",
			// 0xe0
			"%",
			"[Potion]",
			"[0xe2]",
			"[0xe3]",
			"[0xe4]",
			"[0xe5]",
			"[0xe6]",
			"[0xe7]",
			"[0xe8]",
			"[0xe9]",
			"[0xea]",
			"[0xeb]",
			"[0xec]",
			"[0xed]",
			"[0xee]",
			"[0xef]",

			// 0xf0
			"[0xf0]",
			"[0xf1]",
			"[0xf2]",
			"[0xf3]",
			"[0xf4]",
			"[0xf5]",
			"[0xf6]",
			"[0xf7]",
			"[0xf8]",
			"[0xf9]",
			"[0xfa]",
			"[0xfb]",
			"[0xfc]",
			"[0xfd]",
			"[0xfe]",
			" ",
		};
	}
}