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
				Form.Panel1.Width = Form.ClientSize.Width - 24;
			else
				Form.Panel1.Width = Math.Max(Form.Panel1.Width - 10, 0);

			if (Channels[1])
				Form.Panel2.Width = Form.ClientSize.Width - 24;
			else
				Form.Panel2.Width = Math.Max(Form.Panel2.Width - 10, 0);

			if (Channels[2])
				Form.Panel3.Width = Form.ClientSize.Width - 24;
			else
				Form.Panel3.Width = Math.Max(Form.Panel3.Width - 10, 0);

			Form.Panel4.BackColor = Channels[0] ? System.Drawing.Color.Lime : System.Drawing.Color.Green;
			Form.Panel5.BackColor = Channels[1] ? System.Drawing.Color.Lime : System.Drawing.Color.Green;
			Form.Panel6.BackColor = Channels[2] ? System.Drawing.Color.Lime : System.Drawing.Color.Green;

			Form.Label4.Text = Channels[0] ? SongMidi.Last[0].ToString() : string.Empty;
			Form.Label5.Text = Channels[1] ? SongMidi.Last[1].ToString() : string.Empty;
			Form.Label6.Text = Channels[2] ? SongMidi.Last[2].ToString() : string.Empty;

			Form.Label4.Left = (int)(SongMidi.Last[0] * 4) + Form.Panel4.Right;
			Form.Label5.Left = (int)(SongMidi.Last[1] * 4) + Form.Panel5.Right;
			Form.Label6.Left = (int)(SongMidi.Last[2] * 4) + Form.Panel6.Right;

			Form.Panel1.Refresh();
			Form.Panel2.Refresh();
			Form.Panel3.Refresh();
			Form.Panel4.Refresh();
			Form.Panel5.Refresh();
			Form.Panel6.Refresh();
			Form.Label4.Refresh();
			Form.Label5.Refresh();
			Form.Label6.Refresh();
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
			Form.PlayButton.Click -= PlayButton_Click;
			Form.StopButton.Click -= StopButton_Click;
			Form.FormClosed -= Form_FormClosed;

			SongMidi.ChannelActive -= SongMidi_ChannelActive;
			SongMidi.ChannelInactive -= SongMidi_ChannelInactive;

			Timer.Elapsed -= Timer_Elapsed;

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