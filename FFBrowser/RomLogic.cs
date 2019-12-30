using System;
using System.IO;
using System.Text;

namespace FFBrowser
{
	public static class RomLogic
	{
		public static void Load()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.LogicBank, GameRom.LogicAddress);

				for (var logic = 0; logic < GameRom.LogicCount; logic++)
				{
					Game.Logic[logic].Magic = reader.ReadByte();
					Game.Logic[logic].Special = reader.ReadByte();

					Game.Logic[logic].MagicOptions = new int[9];

					for (var magic = 0; magic < 9; magic++)
						Game.Logic[logic].MagicOptions[magic] = reader.ReadByte();

					Game.Logic[logic].SpecialOptions = new int[5];

					for (var special = 0; special < 5; special++)
						Game.Logic[logic].SpecialOptions[special] = reader.ReadByte();
				}
			}
		}
	}
}