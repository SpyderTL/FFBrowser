namespace FFBrowser
{
	public static class World
	{
		public static Segment[][] Rows;
		public static Tile[] Tiles = new Tile[128];

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
	}
}