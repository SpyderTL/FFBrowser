using System;
using System.IO;
using System.Text;

namespace FFBrowser
{
	public static class RomMagic
	{
		public static void Load()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.MagicBank, GameRom.MagicAddress);

				for (var magic = 0; magic < GameRom.MagicCount; magic++)
				{
					Game.Magic[magic].Hit = reader.ReadByte();

					var value = reader.ReadByte();

					Game.Magic[magic].Elements = (Game.Elements)reader.ReadByte();
					Game.Magic[magic].Target = (Game.MagicTarget)reader.ReadByte();
					Game.Magic[magic].Effect = (Game.MagicEffect)reader.ReadByte();
					Game.Magic[magic].Graphic = reader.ReadByte();
					Game.Magic[magic].Palette = reader.ReadByte();
					Game.Magic[magic].Reserved = reader.ReadByte();

					switch (Game.Magic[magic].Effect)
					{
						case Game.MagicEffect.Resist:
						case Game.MagicEffect.Weak:
							Game.Magic[magic].EffectElements = (Game.Elements)value;
							break;

						case Game.MagicEffect.Status:
						case Game.MagicEffect.Status2:
						case Game.MagicEffect.Cure:
						case Game.MagicEffect.CureAll:
							Game.Magic[magic].EffectStatus = (Game.Status)value;
							break;

						default:
							Game.Magic[magic].Value = value;
							break;
					}
				}
			}
		}
	}
}