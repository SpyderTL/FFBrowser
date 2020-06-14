using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FFBrowser
{
	internal static class RomBrowser
	{
		internal static BrowserForm Form;

		internal static void ShowForm()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Form = new BrowserForm();

			var root = Node("ROM", null);

			var header = NesFile.ReadHeader();

			var properties = new
			{
				header.Signature,
				header.ProgramBanks,
				header.CharacterBanks,
				header.Flags,
				header.Flags2,
				header.Flags3,
				header.Flags4,
				header.Flags5,
				header.Reserved
			};

			root.Nodes.Add(Node("Header", properties));

			// Load World
			root.Nodes.Add(Folder("World", new WorldNode()));

			// Load Maps
			RomMap.LoadMaps();
			RomMap.LoadMapTilesets();

			var maps = Node("Maps", null);

			for (int map = 0; map < Game.Maps.Length; map++)
			{
				var node = Folder(Game.Maps[map], new MapNode { Map = map, Bank = RomMap.MapBanks[map], Address = RomMap.MapAddresses[map], Name = Game.Maps[map], Tileset = RomMap.MapTilesets[map] });

				maps.Nodes.Add(node);
			}

			root.Nodes.Add(maps);

			// Load Tilesets
			var tilesets = Node("Tilesets", null);

			for (int tileset = 0; tileset < GameRom.TilesetCount; tileset++)
			{
				var node = Folder(tileset.ToString(), new TilesetNode { Tileset = tileset });

				tilesets.Nodes.Add(node);
			}

			root.Nodes.Add(tilesets);

			// Load Portals
			RomPortals.LoadMapPortals();

			var portals = Node("Portals", null);

			for (int portal = 0; portal < Map.Portals.Length; portal++)
			{
				var node = Node(portal.ToString("X2") + " " + Game.Maps[Map.Portals[portal].Map] + " (" + Map.Portals[portal].X + ", " + Map.Portals[portal].Y + ")", new PortalNode { Portal = portal, Map = Map.Portals[portal].Map, X = Map.Portals[portal].X, Y = Map.Portals[portal].Y });

				portals.Nodes.Add(node);
			}

			root.Nodes.Add(portals);

			// Load Exits
			var exits = Node("Exits", null);

			for (int exit = 0; exit < Map.Exits.Length; exit++)
			{
				var node = Node(exit.ToString("X2") + ": (" + Map.Exits[exit].X + ", " + Map.Exits[exit].Y + ")", new PortalNode { Portal = exit, X = Map.Exits[exit].X, Y = Map.Exits[exit].Y });

				exits.Nodes.Add(node);
			}

			root.Nodes.Add(exits);

			// Load Treasures
			RomTreasure.Load();

			var treasures = Node("Treasure", null);

			for (int treasure = 0; treasure < GameRom.TreasureCount; treasure++)
			{
				treasures.Nodes.Add(Node(treasure.ToString("X2") + ": " + Map.Treasure[treasure].ToString("X2"), new { Item = Map.Treasure[treasure] }));
			}

			root.Nodes.Add(treasures);

			// Load Items
			RomItems.Load();

			var items = Node("Items", null);

			for (int item = 0; item < GameRom.ItemCount; item++)
			{
				items.Nodes.Add(Node(item.ToString("X2") + ": " + Game.Items[item], new { Item = item, Name = Game.Items[item] }));
			}

			root.Nodes.Add(items);

			// Load Weapons
			RomWeapons.Load();

			var weapons = Node("Weapons", null);

			for (int weapon = 0; weapon < GameRom.WeaponCount; weapon++)
			{
				weapons.Nodes.Add(Node(weapon.ToString("X2") + ": " + Game.Items[weapon + 0x1C], new { Weapon = weapon, Name = Game.Items[weapon + 0x1C], Game.Weapons[weapon].Hit, Game.Weapons[weapon].Damage, Game.Weapons[weapon].Critical, Game.Weapons[weapon].Magic, Game.Weapons[weapon].Elements, Game.Weapons[weapon].Effective, Game.Weapons[weapon].Graphic, Game.Weapons[weapon].Palette }));
			}

			root.Nodes.Add(weapons);

			// Load Armor
			RomArmor.Load();

			var armorNode = Node("Armor", null);

			for (int armor = 0; armor < GameRom.ArmorCount; armor++)
			{
				armorNode.Nodes.Add(Node(armor.ToString("X2") + ": " + Game.Items[armor + 0x44], new { Weapon = armor, Name = Game.Items[armor + 0x44], Game.Armor[armor].Evade, Game.Armor[armor].Absorb, Game.Armor[armor].Resist, Game.Armor[armor].Magic }));
			}

			root.Nodes.Add(armorNode);

			// Load Magic
			RomMagic.Load();

			var spells = Node("Spells", null);

			for (int spell = 0; spell < GameRom.SpellCount; spell++)
			{
				spells.Nodes.Add(Node(spell.ToString("X2") + ": " + Game.Items[spell + 0xB0], new { Spell = spell, Name = Game.Items[spell + 0xB0], Game.Spells[spell].Hit, Game.Spells[spell].Value, Game.Spells[spell].Elements, Game.Spells[spell].Target, Game.Spells[spell].Effect, Game.Spells[spell].EffectElements, Game.Spells[spell].EffectStatus, Game.Spells[spell].Graphic, Game.Spells[spell].Palette, Game.Spells[spell].Reserved }));
			}

			root.Nodes.Add(spells);

			var potions = Node("Potions", null);

			for (int potion = 0; potion < GameRom.PotionCount; potion++)
			{
				potions.Nodes.Add(Node(potion.ToString("X2") + ": " + Game.Items[potion + 0x19], new { Potion = potion, Name = Game.Items[potion + 0x19], Game.Potions[potion].Hit, Game.Potions[potion].Value, Game.Potions[potion].Elements, Game.Potions[potion].Target, Game.Potions[potion].Effect, Game.Potions[potion].EffectElements, Game.Potions[potion].EffectStatus, Game.Potions[potion].Graphic, Game.Potions[potion].Palette, Game.Potions[potion].Reserved }));
			}

			root.Nodes.Add(potions);

			var abilities = Node("Abilities", null);

			for (int ability = 0; ability < GameRom.AbilityCount; ability++)
			{
				abilities.Nodes.Add(Node(ability.ToString("X2"), new { Ability = ability, Game.Abilities[ability].Hit, Game.Abilities[ability].Value, Game.Abilities[ability].Elements, Game.Abilities[ability].Target, Game.Abilities[ability].Effect, Game.Abilities[ability].EffectElements, Game.Abilities[ability].EffectStatus, Game.Abilities[ability].Graphic, Game.Abilities[ability].Palette, Game.Abilities[ability].Reserved }));
			}

			root.Nodes.Add(abilities);

			// Load Enemies
			RomEnemies.Load();

			var enemies = Node("Enemies", null);

			for (int enemy = 0; enemy < GameRom.EnemyCount; enemy++)
			{
				enemies.Nodes.Add(Node(enemy.ToString("X2") + ": " + Game.Enemies[enemy].Name, new { Enemy = enemy, Game.Enemies[enemy].Name, Game.Enemies[enemy].Experience, Game.Enemies[enemy].Gold, Game.Enemies[enemy].Health, Game.Enemies[enemy].Morale, Game.Enemies[enemy].Logic, Game.Enemies[enemy].Evade, Game.Enemies[enemy].Absorb, Game.Enemies[enemy].Hits, Game.Enemies[enemy].Hit, Game.Enemies[enemy].Damage, Game.Enemies[enemy].Critical, Game.Enemies[enemy].Reserved, Game.Enemies[enemy].Attack, Game.Enemies[enemy].Categories, Game.Enemies[enemy].MagicDefense, Game.Enemies[enemy].Weak, Game.Enemies[enemy].Resist }));
			}

			root.Nodes.Add(enemies);

			// Load Logic
			RomLogic.Load();

			var logicNode = Node("Logic", null);

			for (int logic = 0; logic < GameRom.EnemyCount; logic++)
			{
				logicNode.Nodes.Add(Node(logic.ToString("X2"), new { Logic = logic, Game.Logic[logic].Magic, Game.Logic[logic].Special, Game.Logic[logic].MagicOptions, Game.Logic[logic].SpecialOptions }));
			}

			root.Nodes.Add(logicNode);

			// Load Formations
			RomFormations.Load();

			var formations = Node("Formations", null);

			for (int formation = 0; formation < GameRom.FormationCount; formation++)
			{
				var data = Game.Formations[formation];

				formations.Nodes.Add(Node(formation.ToString("X2"), new { data.Enemy1, data.EnemyMinimum1, data.EnemyMaximum1, data.Enemy2, data.EnemyMinimum2, data.EnemyMaximum2,data.Enemy3, data.EnemyMinimum3, data.EnemyMaximum3, data.Enemy4, data.EnemyMinimum4,data.EnemyMaximum4, data.AlternateEnemyMinimum1, data.AlternateEnemyMaximum1, data.AlternateEnemyMinimum2, data.AlternateEnemyMaximum2 }));
			}

			root.Nodes.Add(formations);

			// Load Dialogs
			RomDialogs.Load();

			var dialogs = Node("Dialogs", null);

			for (int dialog = 0; dialog < GameRom.DialogCount; dialog++)
			{
				dialogs.Nodes.Add(Node(dialog.ToString("X2") + ": " + Game.Dialogs[dialog], new { Dialog = dialog, Name = Game.Dialogs[dialog] }));
			}

			root.Nodes.Add(dialogs);

			// Load Objects
			RomObjects.Load();

			var objects = Node("Objects", null);

			for (int obj = 0; obj < GameRom.ObjectCount; obj++)
			{
				var objectNode = Node(obj.ToString("X2"), null);

				for (int dialog = 0; dialog < GameRom.ObjectDialogCount; dialog++)
				{
					objectNode.Nodes.Add(Game.ObjectDialogs[obj][dialog].ToString("X2"));
				}

				objects.Nodes.Add(objectNode);
			}

			root.Nodes.Add(objects);

			// Load Songs
			RomSongs.Load(0);

			var songs = Node("Songs", null);

			for (int song = 0; song < GameRom.SongCount; song++)
			{
				var songNode = Folder(song.ToString("X2") + ": " + Game.Songs[song], new SongNode { Song = song });

				songs.Nodes.Add(songNode);
			}

			root.Nodes.Add(songs);

			// Load Classes
			RomClasses.Load();

			var classes = Node("Classes", null);

			for (int @class = 0; @class < GameRom.ClassCount; @class++)
			{
				var classNode = Node(@class.ToString("X2"), new ClassNode { ID = Game.Classes[@class].ID, Health = Game.Classes[@class].Health });

				classes.Nodes.Add(classNode);
			}

			root.Nodes.Add(classes);

			// Load Characters
			RomCharacters.Load();

			// Export Font Characters
			Image.Colors = new Color[]
			{
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(85, 85, 85),
					Color.FromArgb(170, 170, 170),
					Color.FromArgb(255, 255, 255),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0)
			};

			Image.Width = 8;
			Image.Height = 8;

			for (var character = 0; character < Game.FontCharacters.Length; character++)
			{
				Image.Values = Game.FontCharacters[character];

				BitmapImage.SaveImage();

				BitmapFile.Save("character_" + character + ".bmp");
			}

			// Export World Characters
			for (var character = 0; character < World.Characters.Length; character++)
			{
				Image.Values = World.Characters[character];

				BitmapImage.SaveImage();

				BitmapFile.Save("world_" + character + ".bmp");
			}

			// Export Class Characters
			for (var @class = 0; @class < Game.Classes.Length; @class++)
			{
				for (var character = 0; character < Game.Classes[@class].Characters.Length; character++)
				{
					Image.Values = Game.Classes[@class].Characters[character];

					BitmapImage.SaveImage();

					BitmapFile.Save("class_" + @class + "_character_" + character + ".bmp");
				}
			}

			// Export Background Characters
			for (var background = 0; background < World.BackgroundCharacters.Length; background++)
			{
				for (var character = 0; character < World.BackgroundCharacters[background].Length; character++)
				{
					Image.Values = World.BackgroundCharacters[background][character];

					BitmapImage.SaveImage();

					BitmapFile.Save("background_" + background + "_character_" + character + ".bmp");
				}
			}

			//var characters = Node("Characters", null);

			//for (int character = 0; character < GameRom.ClassCount; character++)
			//{
			//	var characterNode = Node(character.ToString("X2"), new CharacterNode { ID = Game.Classes[character].ID, Health = Game.Classes[character].Health });

			//	characters.Nodes.Add(characterNode);
			//}

			//root.Nodes.Add(characters);

			Form.TreeView.Nodes.Add(root);

			Form.TreeView.AfterSelect += TreeView_AfterSelect;
			Form.TreeView.AfterExpand += TreeView_AfterExpand;
			Form.TreeView.BeforeExpand += TreeView_BeforeExpand;

			Application.Run(Form);
		}

		private static TreeNode Node(string text, object tag)
		{
			var node = new TreeNode(text);

			node.Tag = tag;

			return node;
		}

		private static TreeNode Folder(string text, object tag)
		{
			var node = new TreeNode(text);

			node.Tag = tag;

			node.Nodes.Add("Loading...");

			return node;
		}

		private static void TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			Form.TreeView.BeginUpdate();
		}

		private static void TreeView_AfterExpand(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Tag is WorldNode)
			{
				e.Node.Nodes.Clear();

				// Load Rows
				RomMap.LoadWorld();

				var rows = Node("Rows", null);

				for (var row = 0; row < World.Rows.Length; row++)
				{
					var rowNode = Node(row.ToString(), null);

					for (var segment = 0; segment < World.Rows[row].Length; segment++)
					{
						rowNode.Nodes.Add(Node(World.Rows[row][segment].Tile.ToString("X2") + " (x" + World.Rows[row][segment].Count + ")", null));
					}

					rows.Nodes.Add(rowNode);
				}

				e.Node.Nodes.Add(rows);

				// Load Tiles
				RomTiles.LoadWorld();

				var tiles = Node("Tiles", null);

				for (var tile = 0; tile < World.Tiles.Length; tile++)
				{
					var tile2 = World.Tiles[tile];

					tiles.Nodes.Add(Node(tile.ToString("X2") + " " + (tile2.Forest ? "Forest" : "Open"), new WorldTileNode { Tile = tile, Forest = tile2.Forest, Dock = tile2.Dock, Type = tile2.Type, Teleport = tile2.Teleport, Battle = tile2.Battle, Value = tile2.Value, Background = tile2.Background }));
				}

				e.Node.Nodes.Add(tiles);

				// Load Portals
				RomPortals.LoadWorldPortals();

				var portals = Node("Portals", null);

				for (int portal = 0; portal < World.Portals.Length; portal++)
				{
					var node = Node(portal.ToString("X2") + " " + Game.Maps[World.Portals[portal].Map] + " (" + World.Portals[portal].X + ", " + World.Portals[portal].Y + ")", new PortalNode { Portal = portal, Map = World.Portals[portal].Map, X = World.Portals[portal].X, Y = World.Portals[portal].Y });

					portals.Nodes.Add(node);
				}

				e.Node.Nodes.Add(portals);

				// Load Domains
				RomDomains.LoadWorld();

				var domains = Node("Domains", null);

				for (int domain = 0; domain < World.Domains.GetLength(0); domain++)
				{
					var node = Node(domain.ToString("X2"), null);

					for (int formation = 0; formation < World.Domains.GetLength(1); formation++)
					{
						var node2 = Node(formation.ToString("X2") + ": " + World.Domains[domain, formation].Formation.ToString("X2"), null);

						node.Nodes.Add(node2);
					}

					domains.Nodes.Add(node);
				}

				e.Node.Nodes.Add(domains);
			}
			else if (e.Node.Tag is MapNode map)
			{
				e.Node.Nodes.Clear();

				RomMap.LoadMap(((MapNode)e.Node.Tag).Map);

				var segments = Node("Segments", null);

				for (var segment = 0; segment < Map.Segments.Length; segment++)
				{
					segments.Nodes.Add(Node(Map.Segments[segment].Tile.ToString("X2") + " (x" + Map.Segments[segment].Count + ")", null));
				}

				e.Node.Nodes.Add(segments);

				RomObjects.LoadMap(((MapNode)e.Node.Tag).Map);

				var objects = Node("Objects", null);

				for (var obj = 0; obj < Map.Objects.Length; obj++)
				{
					objects.Nodes.Add(Node("(" + Map.Objects[obj].X.ToString() + ", " + Map.Objects[obj].Y + ") " + Map.Objects[obj].Type.ToString("X2"), new ObjectNode { Object = obj, X = Map.Objects[obj].X, Y = Map.Objects[obj].Y, Type = Map.Objects[obj].Type, Flags = Map.Objects[obj].Flags }));
				}

				e.Node.Nodes.Add(objects);

				RomDomains.LoadMap(((MapNode)e.Node.Tag).Map);

				var formations = Node("Formations", null);

				for (var formation = 0; formation < Map.Formations.Length; formation++)
				{
					formations.Nodes.Add(Node(formation.ToString("X2") + ": " + Map.Formations[formation].Formation.ToString("X2"), null));
				}

				e.Node.Nodes.Add(formations);
			}
			else if (e.Node.Tag is TilesetNode tileset)
			{
				e.Node.Nodes.Clear();

				RomTiles.LoadTileset(tileset.Tileset);

				for (var tile = 0; tile < Map.Tiles.Length; tile++)
				{
					e.Node.Nodes.Add(Node(tile.ToString("X2"), new MapTileNode { Tile = tile, Battle = Map.Tiles[tile].Battle, Blocked = Map.Tiles[tile].Blocked, Teleport = Map.Tiles[tile].TeleportType, Type = Map.Tiles[tile].TileType, Value = Map.Tiles[tile].Value }));
				}

				// Export characters
				RomCharacters.LoadTileset(tileset.Tileset);

				Image.Colors = new Color[]
				{
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(85, 85, 85),
					Color.FromArgb(170, 170, 170),
					Color.FromArgb(255, 255, 255),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 0)
				};

				Image.Width = 8;
				Image.Height = 8;

				for (var character = 0; character < Map.Characters.Length; character++)
				{
					Image.Values = Map.Characters[character];

					BitmapImage.SaveImage();

					BitmapFile.Save("tileset_" + tileset.Tileset + "_" + character + ".bmp");
				}
			}
			else if (e.Node.Tag is SongNode song)
			{
				e.Node.Nodes.Clear();

				RomSongs.Load(song.Song);

				for (var channel = 0; channel < 3; channel++)
				{
					var channelNode = Node(channel.ToString("X2"), null);

					for(var note = 0; note < Song.Channels[channel].Length; note++)
						channelNode.Nodes.Add(Node(Song.Channels[channel][note].Address.ToString("X2"), new { Note = note, Song.Channels[channel][note].Address, Song.Channels[channel][note].Type, Song.Channels[channel][note].Value, Song.Channels[channel][note].Value2, }));

					e.Node.Nodes.Add(channelNode);
				}
			}

			Form.TreeView.EndUpdate();
		}

		private static void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			Form.PropertyGrid.SelectedObject = e.Node.Tag;
		}

		public class MapNode
		{
			public int Map;

			public string Name { get; set; }
			public int Bank { get; set; }
			public int Address { get; set; }
			public int Tileset { get; set; }
		}

		public class WorldNode
		{
		}

		private class ObjectNode
		{
			public int Object { get; set; }
			public int X { get; set; }
			public int Y { get; set; }
			public int Type { get; set; }
			public int Flags { get; set; }
		}

		private class MapTileNode
		{
			public int Tile { get; set; }
			public bool Blocked { get; set; }
			public bool Battle { get; set; }
			public Map.TileType Type { get; set; }
			public Map.TeleportType Teleport { get; set; }
			public int Value { get; set; }
		}

		private class WorldTileNode
		{
			public int Tile { get; set; }
			public bool Dock { get; set; }
			public bool Forest { get; set; }
			public World.TileType Type { get; set; }
			public bool Teleport { get; set; }
			public bool Battle { get; set; }
			public int Value { get; set; }
			public byte Background { get; set; }
		}

		private class PortalNode
		{
			public int Portal { get; set; }
			public int Map { get; set; }
			public int X { get; set; }
			public int Y { get; set; }
		}

		private class TilesetNode
		{
			public int Tileset { get; set; }
		}

		private class SongNode : IMenuCommandService, ISite, IComponent
		{
			public int Song { get; set; }

			[Browsable(false)]
			public DesignerVerbCollection Verbs => new DesignerVerbCollection(new DesignerVerb[] { new DesignerVerb("Play", Play) });

			[Browsable(false)]
			public IContainer Container => null;

			[Browsable(false)]
			public bool DesignMode => true;

			[Browsable(false)]
			public string Name { get => "Song"; set => throw new NotImplementedException(); }

			[Browsable(false)]
			public ISite Site { get => this; set => throw new NotImplementedException(); }

			[Browsable(false)]
			public IComponent Component => this;

			public event EventHandler Disposed;

			private void Play(object sender, EventArgs e)
			{
				RomSongs.Load(Song);

				PlayerForm.Show();

				SongMidi.Play();
			}

			public void AddCommand(MenuCommand command)
			{
			}

			public void AddVerb(DesignerVerb verb)
			{
			}

			public MenuCommand FindCommand(CommandID commandID)
			{
				throw new NotImplementedException();
			}

			public bool GlobalInvoke(CommandID commandID)
			{
				throw new NotImplementedException();
			}

			public void RemoveCommand(MenuCommand command)
			{
				throw new NotImplementedException();
			}

			public void RemoveVerb(DesignerVerb verb)
			{
				throw new NotImplementedException();
			}

			public void ShowContextMenu(CommandID menuID, int x, int y)
			{
				throw new NotImplementedException();
			}

			public object GetService(Type serviceType)
			{
				if(serviceType == typeof(IMenuCommandService))
					return this;

				return null;
			}

			public void Dispose()
			{
				Disposed?.Invoke(this, new EventArgs());
			}
		}

		private class ClassNode
		{
			public int ID { get; set; }
			public int Health { get; set; }
		}
	}
}