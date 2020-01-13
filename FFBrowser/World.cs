namespace FFBrowser
{
	public static class World
	{
		public static Segment[][] Rows;
		public static Tile[] Tiles = new Tile[128];
		public static Portal[] Portals = new Portal[32];
		public static DomainFormation[,] Domains = new DomainFormation[64, 8];

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