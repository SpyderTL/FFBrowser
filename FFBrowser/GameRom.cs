using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	internal static class GameRom
	{
		internal static int WorldBank = 1;
		internal static int WorldRowAddress = 0x8000;
		internal static int WorldAddress = 0x8200;

		internal static int MapBank = 4;
		internal static int MapAddress = 0x8000;

		internal static int MapObjectBank = 0;
		internal static int MapObjectAddress = 0xB400;

		internal static int AttributeBank = 0;
		internal static int AttributeAddress = 0x8400;

		internal static int WorldTileBank = 0;
		internal static int WorldTileAddress = 0x8000;
		internal static int WorldTileCount = 128;
		// 2 bytes per tiles
		// 128 tiles

		internal static int WorldTileCharacterBank = 0;
		internal static int WorldTileTopLeftCharacterAddress = 0x8100;
		internal static int WorldTileTopRightCharacterAddress = 0x8180;
		internal static int WorldTileBottomLeftCharacterAddress = 0x8200;
		internal static int WorldTileBottomRightCharacterAddress = 0x8280;
		internal static int WorldTilePaletteAddress = 0x8300;
		// 2 bits per character
		// Bottom Right			2 bits
		// Bottom Left				2 bits
		// Top Right					2 bits
		// Top Left					2 bits

		internal static int WorldPaletteBank = 0;
		internal static int WorldPaletteAddress = 0x8380;
		internal static int WorldPaletteCount = 12;
		// 4 bytes per entry
		// Color 0
		// Color 1
		// Color 2
		// Color 3

		internal static int MapTileBank = 0;
		internal static int MapTileAddress = 0x8800;
		// 2 bytes per tiles
		// 128 tiles

		internal static int TilesetCharacterAddress = 0x9000;
		// 512 bytes per tileset
		internal static int TilesetPaletteAddress = 0x8400;
		// 128 bytes per tileset

		internal static int MapPaletteBank = 0;
		internal static int MapPaletteAddress = 0xA000;
		internal static int MapPaletteCount = 12;

		internal static int WorldSpritePaletteAddress = 0x83A0;

		internal static int TilesetCount = 8;
		internal static int TilesetTileCount = 128;

		internal static int WorldPortalBank = 0;
		internal static int WorldPortalXAddress = 0xAC00;
		internal static int WorldPortalYAddress = 0xAC20;
		internal static int WorldPortalMapAddress = 0xAC40;
		internal static int WorldPortalCount = 0x20;

		internal static int MapPortalBank = 0;
		internal static int MapPortalXAddress = 0xAD00;
		internal static int MapPortalYAddress = 0xAD40;
		internal static int MapPortalMapAddress = 0xAD80;
		internal static int MapPortalCount = 0x40;

		internal static int MapTilesetBank = 0;
		internal static int MapTilesetAddress = 0xACC0;
		internal static int MapTilesetCount = 0x40;

		internal static int WorldTileBackgroundBank = 0;
		internal static int WorldTileBackgroundAddress = 0xB300;

		internal static int BackgroundPaletteBank = 0;
		internal static int BackgroundPaletteAddress = 0xB200;
		internal static int BackgroundPaletteCount = 64;

		internal static int MapExitXAddress = 0xAC60;
		internal static int MapExitYAddress = 0xAC70;
		internal static int MapExitCount = 0x10;

		internal static int TreasureBank = 0;
		internal static int TreasureAddress = 0xB100;
		internal static int TreasureCount = 0x100;

		internal static int DialogBank = 0x0A;
		internal static int DialogAddress = 0x8000;
		internal static int DialogCount = 0x100;

		internal static int ItemBank = 0x0A;
		internal static int ItemAddress = 0xB700;
		internal static int ItemCount = 0x100;

		internal static int PriceBank = 0x0D;
		internal static int PriceAddress = 0xBC00;

		internal static int ObjectBank = 0x0E;
		internal static int ObjectFunctionAddress = 0x90D3;
		internal static int ObjectParameterAddress = 0x95D5;
		internal static int ObjectParameterCount = 4;

		internal static int ObjectCount = 0xD0;

		internal static int WeaponBank = 0x0C;
		internal static int WeaponAddress = 0x8000;
		internal static int WeaponCount = 40;

		internal static int ArmorBank = 0x0C;
		internal static int ArmorAddress = 0x8140;
		internal static int ArmorCount = 40;

		internal static int MagicBank = 0x0C;
		internal static int MagicAddress = 0x81E0;
		internal static int SpellCount = 0x40;
		internal static int PotionCount = 0x02;
		internal static int AbilityCount = 0x1A;

		internal static int PermissionBank = 0x0E;

		internal static int MagicPermissionAddress = 0xAD00;
		internal static int PromotedMagicPermissionAddress = 0xAD30;
		internal static int WeaponPermissionAddress = 0xBF50;
		internal static int ArmorPermissionAddress = 0xBFA0;
		internal static int ClassPermissionAddress = 0xBCB9;
		internal static int ArmorTypeAddress = 0xBCD1;

		internal static int EnemyBank = 0x0C;
		internal static int EnemyAddress = 0x8520;
		internal static int EnemyCount = 0x80;

		internal static int LogicBank = 0x0C;
		internal static int LogicAddress = 0x9020;
		internal static int LogicCount = 0x80;

		internal static int NameBank = 0x0B;
		internal static int NameAddress = 0x94E0;

		internal static int SongBank = 0x0D;
		internal static int SongAddress = 0x8000;
		internal static int SongCount = 24;

		internal static int TempoBank = 0x0D;
		internal static int TempoAddress = 0xB359;
		internal static int TempoCount = 6;
		internal static int DurationCount = 16;

		internal static int WorldDomainBank = 0x0B;
		internal static int WorldDomainAddress = 0x8000;
		internal static int WorldDomainCount = 64;

		internal static int MapDomainBank = 0x0B;
		internal static int MapDomainAddress = 0x8200;

		internal static int DomainFormationCount = 8;

		internal static int FormationBank = 0x0B;
		internal static int FormationAddress = 0x8400;
		internal static int FormationCount = 128;

		internal static int ClassBank = 0x00;
		internal static int ClassAddress = 0xb040;
		internal static int ClassCount = 6;

		internal static int FontCharacterBank = 0x09;
		internal static int FontCharacterAddress = 0x8800;
		internal static int FontCharacterCount = 128;

		internal static int ShopCharacterBank = 0x09;
		internal static int ShopCharacterAddress = 0x8000;
		internal static int ShopCharacterCount = 128;

		internal static int ShopTextBank = 0x0E;
		internal static int ShopTextAddress = 0x8000;

		internal static int ShopDataBank = 0x0E;
		internal static int ShopDataAddress = 0x8300;

		internal static int MenuTextBank = 0x0E;
		internal static int MenuTextAddress = 0x8500;

		internal static int WorldCharacterBank = 0x02;
		internal static int WorldCharacterAddress = 0x8000;
		internal static int WorldSpriteCharacterAddress = 0x9000;
		internal static int WorldCharacterCount = 256;

		internal static int MapCharacterBank = 0x03;
		internal static int MapCharacterAddress = 0x8000;
		internal static int MapCharacterCount = 128;

		internal static int ClassCharacterBank = 0x09;
		internal static int ClassCharacterAddress = 0x9000;
		internal static int ClassCharacterCount = 32;

		internal static int ClassPaletteBank = 0x1f;
		internal static int ClassPaletteAddress = 0xECA4;
		internal static int PromotedClassPaletteAddress = 0xECAA;

		internal static int PointerCharacterBank = 0x09;
		internal static int PointerCharacterAddress = 0xA800;
		internal static int PointerCharacterCount = 128;

		internal static int BackgroundCharacterBank = 0x07;
		internal static int BackgroundCharacterBank2 = 0x08;
		internal static int BackgroundCharacterAddress = 0x8000;
		internal static int BackgroundCharacterCount = 128;

		internal static int SpritePaletteBank = 0x1F;
		internal static int SpritePaletteAddress = 0xEBA5;
		internal static int SpritePaletteCount = 4;

		internal static int LevelCount = 49;
		internal static int LevelAddress = 0x9094;
		internal static int LevelBank = 0x0B;
	}
}
