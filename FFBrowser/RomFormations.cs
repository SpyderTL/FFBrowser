using System;
using System.IO;

namespace FFBrowser
{
	public class RomFormations
	{
		public static void Load()
		{
			using (var stream = new MemoryStream(Rom.Data))
			using (var reader = new RomReader(stream))
			{
				reader.Seek(GameRom.FormationBank, GameRom.FormationAddress);

				for (var formation = 0; formation < GameRom.FormationCount; formation++)
				{
					var data = reader.ReadBytes(16);

					Game.Formations[formation].BattleType = data[0] >> 4;
					Game.Formations[formation].Pattern = data[0] & 0x0f;
					Game.Formations[formation].EnemyGraphics1 = (data[1] >> 6) & 0x03;
					Game.Formations[formation].EnemyGraphics2 = (data[1] >> 4) & 0x03;
					Game.Formations[formation].EnemyGraphics3 = (data[1] >> 2) & 0x03;
					Game.Formations[formation].EnemyGraphics4 = (data[1] >> 0) & 0x03;
					Game.Formations[formation].Enemy1 = data[2];
					Game.Formations[formation].Enemy2 = data[3];
					Game.Formations[formation].Enemy3 = data[4];
					Game.Formations[formation].Enemy4 = data[5];
					Game.Formations[formation].EnemyMinimum1 = data[6] >> 4;
					Game.Formations[formation].EnemyMaximum1 = data[6] & 0x0f;
					Game.Formations[formation].EnemyMinimum2 = data[7] >> 4;
					Game.Formations[formation].EnemyMaximum2 = data[7] & 0x0f;
					Game.Formations[formation].EnemyMinimum3 = data[8] >> 4;
					Game.Formations[formation].EnemyMaximum3 = data[8] & 0x0f;
					Game.Formations[formation].EnemyMinimum4 = data[9] >> 4;
					Game.Formations[formation].EnemyMaximum4 = data[9] & 0x0f;
					Game.Formations[formation].Palette1 = data[10];
					Game.Formations[formation].Palette2 = data[11];
					Game.Formations[formation].Surprise = data[12];
					Game.Formations[formation].EnemyPalette = data[13] >> 4;
					Game.Formations[formation].NoRun = (data[13] & 0x01) == 0x01;
					Game.Formations[formation].AlternateEnemyMinimum1 = data[14] >> 4;
					Game.Formations[formation].AlternateEnemyMaximum1 = data[14] & 0x0f;
					Game.Formations[formation].AlternateEnemyMinimum2 = data[15] >> 4;
					Game.Formations[formation].AlternateEnemyMaximum2 = data[15] & 0x0f;
				}
			}
		}
	}
}