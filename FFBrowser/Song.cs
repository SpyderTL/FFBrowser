namespace FFBrowser
{
	internal static class Song
	{
		internal static Event[][] Channels = new Event[3][];
		internal static int[][] Tempo = new int[6][];

		internal struct Event
		{
			public int Address;
			public EventType Type;
			public int Value;
			public int Value2;
		}

		internal enum EventType
		{
			Note,
			Rest,
			LoopInfinite,
			Loop,
			Octave,
			Reserved,
			Envelope,
			EnvelopeSpeed,
			Tempo,
			End
		}
	}
}