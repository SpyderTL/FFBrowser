namespace FFBrowser
{
	public static class Map
	{
		public static Segment[] Segments;
		public static Object[] Objects = new Object[16];

		public struct Segment
		{
			public int Tile;
			public int Repeat;
		}

		public struct Object
		{
			public int Type;
			public int X;
			public int Y;
			public int Flags;
		}
	}
}