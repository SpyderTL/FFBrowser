using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	internal static class NesFile
	{
		internal static byte[] Data;

		internal static Header ReadHeader()
		{
			using (var stream = new MemoryStream(Data))
			using (var reader = new BinaryReader(stream))
			{
				return new Header
				{
					Signature = reader.ReadChars(4),
					ProgramBanks = reader.ReadByte(),
					CharacterBanks = reader.ReadByte(),
					Flags = reader.ReadByte(),
					Flags2 = reader.ReadByte(),
					Flags3 = reader.ReadByte(),
					Flags4 = reader.ReadByte(),
					Flags5 = reader.ReadByte(),
					Reserved = reader.ReadBytes(5)
				};
			}
		}

		internal static byte[] ReadData()
		{
			var data = new byte[Data.Length - 0x10];

			Array.Copy(Data, 0x10, data, 0x00, data.Length);

			return data;
		}

		public struct Header
		{
			public char[] Signature;
			public int ProgramBanks;
			public int CharacterBanks;
			public int Flags;
			public int Flags2;
			public int Flags3;
			public int Flags4;
			public int Flags5;
			public byte[] Reserved;
		}
	}
}
