using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	public class NesReader : BinaryReader
	{
		public NesReader(Stream stream)
			: base(stream)
		{
		}

		public long SeekHeader()
		{
			return BaseStream.Seek(0, SeekOrigin.Begin);
		}

		public long Seek(int bank, int address)
		{
			var position = (bank * 0x4000) + address - 0x8000 + 0x10;

			return BaseStream.Seek(position, SeekOrigin.Begin);
		}
	}
}
