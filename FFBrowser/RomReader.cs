using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	public class RomReader : BinaryReader
	{
		public RomReader(Stream stream)
			: base(stream)
		{
		}

		public long Seek(int bank, int address)
		{
			long position;
			
			if (bank == 0x1F)
				position = 0x30000 | address;
			else
				position = (bank * 0x4000) + address - 0x8000;

			return BaseStream.Seek(position, SeekOrigin.Begin);
		}
	}
}
