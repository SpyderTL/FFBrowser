namespace FFBrowser
{
	public static class Map
	{
		public static Segment[] Segments;
		public static Object[] Objects = new Object[16];
		public static Tile[] Tiles = new Tile[128];
		public static Portal[] Portals = new Portal[64];
		public static Exit[] Exits = new Exit[16];
		public static int[] Treasure = new int[256];
		public static MapFormation[] Formations = new MapFormation[8];

		public struct Segment
		{
			public int Tile;
			public int Count;
		}

		public struct Object
		{
			public int Type;
			public int X;
			public int Y;
			public int Flags;
		}

		public struct Tile
		{
			public TileType TileType;
			public bool Blocked;
			public bool Battle;
			public TeleportType TeleportType;
			public int Value;
		}

		public enum TileType
		{
			Normal,
			Door,
			Locked,
			CloseRoom,
			Treasure,
			Battle,
			Damage,
			Crown,
			Cube,
			FourOrbs,
			UseRod,
			UseLute,
			EarthOrb,
			FireOrb,
			WaterOrb,
			AirOrb
		}

		public enum TeleportType
		{
			None,
			Warp,
			Normal,
			Exit
		}

		public struct Portal
		{
			public int Map;
			public int X;
			public int Y;
		}

		public struct Exit
		{
			public int X;
			public int Y;
		}

		public struct MapFormation
		{
			public int Formation;
			public bool Alternate;
		}
	}
}