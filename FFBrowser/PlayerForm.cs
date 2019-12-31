using System;

namespace FFBrowser
{
	internal static class PlayerForm
	{
		public static SongForm Form;

		internal static bool[] Channels = new bool[3];
		internal static System.Timers.Timer Timer = new System.Timers.Timer(10);

		public static void Show()
		{
			if (Form == null)
			{
				Form = new SongForm();

				Form.PlayButton.Click += PlayButton_Click;
				Form.StopButton.Click += StopButton_Click;
				Form.FormClosed += Form_FormClosed;

				SongMidi.ChannelActive += SongMidi_ChannelActive;
				SongMidi.ChannelInactive += SongMidi_ChannelInactive;

				Timer.Elapsed += Timer_Elapsed;
				Timer.Start();

				Form.Show();
			}
		}

		private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				Form.Invoke((Action)Update);
			}
			catch (Exception)
			{
			}
		}

		private static void Update()
		{
			if (Channels[0])
				Form.Panel1.Width = Form.ClientSize.Width - 20;
			else
				Form.Panel1.Width = Math.Max(Form.Panel1.Width - 20, 0);

			if (Channels[1])
				Form.Panel2.Width = Form.ClientSize.Width - 20;
			else
				Form.Panel2.Width = Math.Max(Form.Panel2.Width - 20, 0);

			if (Channels[2])
				Form.Panel3.Width = Form.ClientSize.Width - 20;
			else
				Form.Panel3.Width = Math.Max(Form.Panel3.Width - 20, 0);
		}

		private static void SongMidi_ChannelActive(int channel)
		{
			Channels[channel] = true;
		}

		private static void SongMidi_ChannelInactive(int channel)
		{
			Channels[channel] = false;
		}

		private static void Form_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			Timer.Stop();

			SongMidi.Stop();

			Form = null;
		}

		private static void PlayButton_Click(object sender, System.EventArgs e)
		{
			SongMidi.Play();
		}

		private static void StopButton_Click(object sender, System.EventArgs e)
		{
			SongMidi.Stop();

			Channels[0] = false;
			Channels[1] = false;
			Channels[2] = false;
		}
	}
}