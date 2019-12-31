using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FFBrowser
{
	public static class Midi
	{
		[DllImport("winmm.dll")]
		private static extern int midiOutOpen(ref int handle, int deviceID, MidiCallBack proc, int instance, int flags);

		[DllImport("winmm.dll")]
		private static extern int midiOutShortMsg(int handle, int message);

		[DllImport("winmm.dll")]
		private static extern int midiOutClose(int handle);

		private delegate void MidiCallBack(int handle, int msg, int instance, int param1, int param2);

		private static int Handle;

		public static void Enable()
		{
			var result = midiOutOpen(ref Handle, -1, null, 0, 0);
		}

		public static void NoteOn(int channel, int note, int velocity)
		{
			var result = midiOutShortMsg(Handle, 0x90 | channel | (note << 8) | (velocity << 16));
		}

		public static void NoteOff(int channel, int note, int velocity)
		{
			var result = midiOutShortMsg(Handle, 0x80 | channel | (note << 8) | (velocity << 16));
		}

		public static void ProgramChange(int channel, int patch)
		{
			var result = midiOutShortMsg(Handle, 0xC0 | channel | (patch << 8));
		}

		public static void Disable()
		{
			var result = midiOutClose(Handle);
		}
	}
}
