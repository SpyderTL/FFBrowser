namespace FFBrowser
{
	public static class Map
	{
		public static Segment[] Segments;
		public static Object[] Objects = new Object[16];
		public static Property[] Properties = new Property[256];

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

		public struct Property
		{
			public int TileType;
			public bool Move;
			public bool Battle;
			public int TeleportType;
			public bool Teleport;
			public int Value;					// Teleport ID, Chest ID, Battle Type
		}
	}
}