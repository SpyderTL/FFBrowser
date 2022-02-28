namespace FFBrowser
{
	public static class World
	{
		public static Segment[][] Rows;
		public static Tile[] Tiles = new Tile[128];
		public static Portal[] Portals = new Portal[32];
		public static DomainFormation[,] Domains = new DomainFormation[64, 8];
		public static byte[][] Characters = new byte[256][];
		public static byte[][] SpriteCharacters = new byte[256][];
		public static byte[][][] BackgroundCharacters = new byte[16][][];
		public static byte[][] Palettes = new byte[12][];
		public static byte[][] SpritePalettes = new byte[64][];

		public struct Segment
		{
			public int Tile;
			public int Count;
		}

		public struct Tile
		{
			public bool Dock;
			public bool Forest;
			public TileType Type;
			public bool Teleport;
			public bool Battle;
			public int Value;
			public byte Background;
			internal byte[] Characters;
			internal byte[] Palettes;
		}

		public enum TileType
		{
			Normal,
			Chime,
			Caravan,
			Floater
		}

		public struct Portal
		{
			public int Map;
			public int X;
			public int Y;
		}

		public struct DomainFormation
		{
			public int Formation;
			public bool Alternate;
		}
	}
}