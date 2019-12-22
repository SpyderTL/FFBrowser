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
			var position = (bank * 0x4000) + address - 0x8000;

			return BaseStream.Seek(position, SeekOrigin.Begin);
		}
	}
}
