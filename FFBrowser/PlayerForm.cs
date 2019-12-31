namespace FFBrowser
{
	internal static class PlayerForm
	{
		public static SongForm Form;

		public static void Show()
		{
			if (Form == null)
			{
				Form = new SongForm();

				Form.PlayButton.Click += PlayButton_Click;
				Form.StopButton.Click += StopButton_Click;
				Form.FormClosed += Form_FormClosed;

				Form.Show();
			}
		}

		private static void Form_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
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
		}
	}
}