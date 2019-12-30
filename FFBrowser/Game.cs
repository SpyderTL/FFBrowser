using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	internal static class Game
	{
		public static string[] Maps = new string[]
		{
			"Coneria",
			"Provoka",
			"Elfland",
			"Melmond",
			"Cresent Lake",
			"Gaia",
			"Onrac",
			"Leifen",
			"Corneria Castle 1F",
			"Elfland Castle",
			"Northwest Castle",
			"Castle of Ordeals 1F",
			"Temple of Fiends",
			"Earth Cave B1",
			"Gurgu Volcano B1",
			"Ice Cave B1",
			"Cardia",
			"Bahamut's Room B1",
			"Waterfall",
			"Dwarf Cave",
			"Matoya's Cave",
			"Sarda's Cave",
			"Marsh Cave B1",
			"Mirage Tower 1F",
			"Coneria Castle 2F",
			"Castle of Ordeals 2F",
			"Castle of Ordeals 3F",
			"Marsh Cave B2",
			"Marsh Cave B3",
			"Earth Cave B2",
			"Earth Cave B3",
			"Earth Cave B4",
			"Earth Cave B5",
			"Gurgu Volcano B2",
			"Gurgu Volcano B3",
			"Gurgu Volcano B4",
			"Gurgu Volcano B5",
			"Ice Cave B2",
			"Ice Cave B3",
			"Bahamut's Room B2",
			"Mirage Tower 2F",
			"Mirage Tower 3F",
			"Sea Shrine B5",
			"Sea Shrine B4",
			"Sea Shrine B3",
			"Sea Shrine B2",
			"Sea Shrine B1",
			"Sky Palace 1F",
			"Sky Palace 2F",
			"Sky Palace 3F",
			"Sky Palace 4F",
			"Sky Palace 5F",
			"Temple of Fiends 1F",
			"Temple of Fiends 2F",
			"Temple of Fiends 3F",
			"Temple of Fiends Earth",
			"Temple of Fiends Fire",
			"Temple of Fiends Water",
			"Temple of Fiends Air",
			"Temple of Fiends Chaos",
			"Titan's Tunnel",
		};

		public enum Objects
		{
			Garland = 2,
			Princess = 3,
			Bikke = 4,
			ElfPrince = 6,
			Astos = 7,
			Nerrick = 8,
			Smith = 9,
			Matoya = 10,
			Unne = 11,
			Vampire = 12,
			Sarda = 13,
			Bahamut = 14,
			Subengineer = 16,
			Princess2 = 18,
			Fairy = 19,
			Titan = 20,
			RodPlate = 22,
			LutePlate = 23,
			Skywarrior = 58,
			Skywarrior2 = 59,
			Skywarrior3 = 60,
			Skywarrior4 = 61,
			Skywarrior5 = 62,
			Hidden = 63,
			Hidden2 = 64,
			Hidden3 = 65,
			Bat = 87,
			BlackOrb = 202
		}

		public static int[][] ObjectDialogs = new int[208][];
		public static string[] Items = new string[256];
		public static string[] Dialogs = new string[256];
		public static WeaponData[] Weapons = new WeaponData[40];
		public static ArmorData[] Armor = new ArmorData[40];
		public static MagicData[] Magic = new MagicData[0x5C];
		public static EnemyData[] Enemies = new EnemyData[0x80];
		public static LogicData[] Logic = new LogicData[0x80];

		public struct WeaponData
		{
			public int Hit;
			public int Damage;
			public int Critical;
			public int Magic;
			public Elements Elements;
			public EnemyCategories Effective;
			public int Graphic;
			public int Palette;
		}

		public struct ArmorData
		{
			public int Evade;
			public int Absorb;
			public Elements Elements;
			public int Magic;
		}

		public struct MagicData
		{
			public int Hit;
			public EnemyCategories Effective;
			public Elements Elements;
			public MagicTarget Target;
			public int Effect;
			public int Graphic;
			public int Palette;
			public int Reserved;
		}

		[Flags]
		public enum EnemyCategories
		{
			None = 0,
			Normal = 1,
			Dragon = 2,
			Giant = 4,
			Undead = 8,
			Were = 16,
			Water = 32,
			Mage = 64,
			Regen = 128
		}

		[Flags]
		public enum Elements
		{
			None = 0,
			Earth = 1,
			Wind = 2,
			Water = 4,
			Holy = 8,
			Fire = 16,
			Ice = 32,
			Lightning = 64,
			Dark = 128
		}

		[Flags]
		public enum MagicTarget
		{
			None = 0,
			Enemies = 1,
			Enemy = 2,
			Self = 4,
			Allies = 8,
			Ally = 16
		}

		public struct EnemyData
		{
			public int Experience;
			public int Gold;
			public int Health;
			public int Morale;
			public int Logic;
			public int Evade;
			public int Absorb;
			public int Hits;
			public int Hit;
			public int Damage;
			public int Critical;
			public int Reserved;
			public int Attack;
			public EnemyCategories Categories;
			public int MagicDefense;
			public Elements Weak;
			public Elements Resist;
			public string Name;
		}

		public struct LogicData
		{
			public int Magic;
			public int Special;
			public int[] MagicOptions;
			public int[] SpecialOptions;
		}
	}
}
