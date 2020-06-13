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

				for (var magic = 0; magic < GameRom.SpellCount; magic++)
				{
					Game.Spells[magic].Hit = reader.ReadByte();

					var value = reader.ReadByte();

					Game.Spells[magic].Elements = (Game.Elements)reader.ReadByte();
					Game.Spells[magic].Target = (Game.MagicTarget)reader.ReadByte();
					Game.Spells[magic].Effect = (Game.MagicEffect)reader.ReadByte();
					Game.Spells[magic].Graphic = reader.ReadByte();
					Game.Spells[magic].Palette = reader.ReadByte();
					Game.Spells[magic].Reserved = reader.ReadByte();

					switch (Game.Spells[magic].Effect)
					{
						case Game.MagicEffect.Resist:
						case Game.MagicEffect.Weak:
							Game.Spells[magic].EffectElements = (Game.Elements)value;
							break;

						case Game.MagicEffect.Status:
						case Game.MagicEffect.Status2:
						case Game.MagicEffect.Cure:
						case Game.MagicEffect.CureAll:
							Game.Spells[magic].EffectStatus = (Game.Status)value;
							break;

						default:
							Game.Spells[magic].Value = value;
							break;
					}
				}

				for (var potion = 0; potion < GameRom.PotionCount; potion++)
				{
					Game.Potions[potion].Hit = reader.ReadByte();

					var value = reader.ReadByte();

					Game.Potions[potion].Elements = (Game.Elements)reader.ReadByte();
					Game.Potions[potion].Target = (Game.MagicTarget)reader.ReadByte();
					Game.Potions[potion].Effect = (Game.MagicEffect)reader.ReadByte();
					Game.Potions[potion].Graphic = reader.ReadByte();
					Game.Potions[potion].Palette = reader.ReadByte();
					Game.Potions[potion].Reserved = reader.ReadByte();

					switch (Game.Potions[potion].Effect)
					{
						case Game.MagicEffect.Resist:
						case Game.MagicEffect.Weak:
							Game.Potions[potion].EffectElements = (Game.Elements)value;
							break;

						case Game.MagicEffect.Status:
						case Game.MagicEffect.Status2:
						case Game.MagicEffect.Cure:
						case Game.MagicEffect.CureAll:
							Game.Potions[potion].EffectStatus = (Game.Status)value;
							break;

						default:
							Game.Potions[potion].Value = value;
							break;
					}
				}

				for (var ability = 0; ability < GameRom.AbilityCount; ability++)
				{
					Game.Abilities[ability].Hit = reader.ReadByte();

					var value = reader.ReadByte();

					Game.Abilities[ability].Elements = (Game.Elements)reader.ReadByte();
					Game.Abilities[ability].Target = (Game.MagicTarget)reader.ReadByte();
					Game.Abilities[ability].Effect = (Game.MagicEffect)reader.ReadByte();
					Game.Abilities[ability].Graphic = reader.ReadByte();
					Game.Abilities[ability].Palette = reader.ReadByte();
					Game.Abilities[ability].Reserved = reader.ReadByte();

					switch (Game.Abilities[ability].Effect)
					{
						case Game.MagicEffect.Resist:
						case Game.MagicEffect.Weak:
							Game.Abilities[ability].EffectElements = (Game.Elements)value;
							break;

						case Game.MagicEffect.Status:
						case Game.MagicEffect.Status2:
						case Game.MagicEffect.Cure:
						case Game.MagicEffect.CureAll:
							Game.Abilities[ability].EffectStatus = (Game.Status)value;
							break;

						default:
							Game.Abilities[ability].Value = value;
							break;
					}
				}
			}
		}
	}
}