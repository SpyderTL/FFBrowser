﻿using System;
using System.Threading;

namespace FFBrowser
{
	internal class SongMidi
	{
		internal static Thread Thread;
		internal static bool Stopped;

		internal static Song.Event[][] Events = new Song.Event[3][];
		internal static int[] Next = new int[3];
		internal static int[] Last = new int[3];
		internal static int[] Octave = new int[3];
		internal static double[] Timers = new double[3];
		internal static int[] Tempo = new int[3];
		internal static int[] Loop = new int[3];
		internal static bool[] Playing = new bool[3];

		internal static event Action<int> ChannelActive;
		internal static event Action<int> ChannelInactive;

		internal static void Play()
		{
			Events[0] = Song.Channels[0];
			Events[1] = Song.Channels[1];
			Events[2] = Song.Channels[2];

			Next[0] = 0;
			Next[1] = 0;
			Next[2] = 0;

			Last[0] = 0;
			Last[1] = 0;
			Last[2] = 0;

			Timers[0] = 0;
			Timers[1] = 0;
			Timers[2] = 0;

			Loop[0] = -1;
			Loop[1] = -1;
			Loop[2] = -1;

			Playing[0] = true;
			Playing[1] = true;
			Playing[2] = true;

			Thread = new Thread(Start);
			Thread.Start();
		}

		private static void Start()
		{
			Midi.Enable();

			Midi.ControlChange(0, 123, 0);
			Midi.ControlChange(1, 123, 0);
			Midi.ControlChange(2, 123, 0);

			Midi.ProgramChange(0, 80);
			Midi.ProgramChange(1, 80);
			Midi.ProgramChange(2, 35);

			Midi.ControlChange(0, 0x0A, 0);
			Midi.ControlChange(1, 0x0A, 127);

			Stopped = false;

			var last = DateTime.Now;

			while (!Stopped)
			{
				var now = DateTime.Now;
				var elapsed = now - last;
				last = now;

				var playing = false;

				for (var channel = 0; channel < 3; channel++)
				{
					if (Playing[channel])
					{
						playing = true;

						Timers[channel] -= elapsed.TotalMilliseconds * 0.056;
					}

					while (Playing[channel] && Timers[channel] <= 0)
					{
						var e = Events[channel][Next[channel]];

						switch (e.Type)
						{
							case Song.EventType.End:
								Midi.NoteOff(channel, Last[channel], 127);
								ChannelInactive?.Invoke(channel);
								Playing[channel] = false;
								break;

							case Song.EventType.Note:
								Midi.NoteOff(channel, Last[channel], 127);
								var note = e.Value + (Octave[channel] * 12) + (channel == 2 ? 36 : 48);
								Midi.NoteOn(channel, note, 127);
								ChannelActive?.Invoke(channel);
								Timers[channel] += Song.Tempo[Tempo[channel]][e.Value2];
								Last[channel] = note;
								Next[channel]++;
								break;

							case Song.EventType.Rest:
								Midi.NoteOff(channel, Last[channel], 127);
								ChannelInactive?.Invoke(channel);
								Timers[channel] += Song.Tempo[Tempo[channel]][e.Value];
								Next[channel]++;
								break;

							case Song.EventType.Tempo:
								Tempo[channel] = e.Value;
								Next[channel]++;
								break;

							case Song.EventType.Octave:
								Octave[channel] = e.Value;
								Next[channel]++;
								break;

							case Song.EventType.Loop:
								if (Loop[channel] == 0)
								{
									Loop[channel] = -1;
									Next[channel]++;
								}
								else
								{
									if (Loop[channel] == -1)
										Loop[channel] = e.Value2;

									Loop[channel]--;

									Next[channel] = 0;

									while (Events[channel][Next[channel]].Address != e.Value)
										Next[channel]++;
								}
								break;

							case Song.EventType.LoopInfinite:
								Next[channel] = 0;

								while (Events[channel][Next[channel]].Address != e.Value)
									Next[channel]++;
								break;

							default:
								Next[channel]++;
								break;
						}
					}
				}

				if (!playing)
					Stopped = true;
				else
					Thread.Sleep(10);
			}

			Midi.ControlChange(0, 123, 0);
			Midi.ControlChange(1, 123, 0);
			Midi.ControlChange(2, 123, 0);

			Midi.Disable();
		}

		internal static void Stop()
		{
			Stopped = true;
		}
	}
}