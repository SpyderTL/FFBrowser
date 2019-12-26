using System;
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

			Form.TreeView.Nodes.Add(root);

			Form.TreeView.AfterSelect += TreeView_AfterSelect;
			Form.TreeView.AfterExpand += TreeView_AfterExpand;

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

					tiles.Nodes.Add(Node(tile.ToString("X2") + " " + (tile2.Forest ? "Forest" : "Open"), new WorldTileNode { Tile = tile, Forest = tile2.Forest, Dock = tile2.Dock, Type = tile2.Type, Teleport = tile2.Teleport, Battle = tile2.Battle, Value = tile2.Value }));
				}

				e.Node.Nodes.Add(tiles);

				// Load Portals
				RomPortals.LoadWorld();

				var portals = Node("Portals", null);

				for (int portal = 0; portal < Game.WorldPortals.Length; portal++)
				{
					var node = Node(portal.ToString("X2") + " " + Game.Maps[Game.WorldPortals[portal].Map] + " (" + Game.WorldPortals[portal].X + ", " + Game.WorldPortals[portal].Y + ")", new PortalNode { Portal = portal, Map = Game.WorldPortals[portal].Map, X = Game.WorldPortals[portal].X, Y = Game.WorldPortals[portal].Y });

					portals.Nodes.Add(node);
				}

				e.Node.Nodes.Add(portals);

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

				RomObjects.Load(((MapNode)e.Node.Tag).Map);

				var objects = Node("Objects", null);

				for (var obj = 0; obj < Map.Objects.Length; obj++)
				{
					objects.Nodes.Add(Node("(" + Map.Objects[obj].X.ToString() + ", " + Map.Objects[obj].Y + ") " + Map.Objects[obj].Type, new ObjectNode { Object = obj, X = Map.Objects[obj].X, Y = Map.Objects[obj].Y, Type = Map.Objects[obj].Type, Flags = Map.Objects[obj].Flags }));
				}

				e.Node.Nodes.Add(objects);
			}
			else if (e.Node.Tag is TilesetNode tileset)
			{
				e.Node.Nodes.Clear();

				RomTiles.Load(tileset.Tileset);

				for (var tile = 0; tile < Map.Tiles.Length; tile++)
				{
					e.Node.Nodes.Add(Node(tile.ToString("X2"), new MapTileNode { Tile = tile, Battle = Map.Tiles[tile].Battle, Blocked = Map.Tiles[tile].Blocked, Teleport = Map.Tiles[tile].TeleportType, Type = Map.Tiles[tile].TileType, Value = Map.Tiles[tile].Value }));
				}
			}
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
	}
}