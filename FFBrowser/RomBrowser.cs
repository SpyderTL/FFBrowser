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

			// Load Maps
			RomMap.LoadMaps();

			var maps = Node("Maps", null);

			maps.Nodes.Add(Folder("World", new WorldNode()));

			for (int map = 0; map < Game.Maps.Length; map++)
			{
				var node = Folder(Game.Maps[map], new MapNode { Map = map, Bank = RomMap.MapBanks[map], Address = RomMap.MapAddresses[map], Name = Game.Maps[map] });

				maps.Nodes.Add(node);
			}

			root.Nodes.Add(maps);

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

				RomMap.LoadWorld();

				var rows = Node("Rows", null);

				for (var row = 0; row < World.Rows.Length; row++)
				{
					var rowNode = Node(row.ToString(), null);

					for (var segment = 0; segment < World.Rows[row].Length; segment++)
					{
						rowNode.Nodes.Add(Node(World.Rows[row][segment].Tile.ToString("X2") + " (x" + (World.Rows[row][segment].Repeat + 1) + ")", null));
					}

					rows.Nodes.Add(rowNode);
				}

				e.Node.Nodes.Add(rows);
			}
			else if (e.Node.Tag is MapNode)
			{
				var map = (MapNode)e.Node.Tag;

				e.Node.Nodes.Clear();

				RomMap.LoadMap(((MapNode)e.Node.Tag).Map);

				var segments = Node("Segments", null);

				for (var segment = 0; segment < Map.Segments.Length; segment++)
				{
					segments.Nodes.Add(Node(Map.Segments[segment].Tile.ToString("X2") + " (x" + (Map.Segments[segment].Repeat + 1) + ")", null));
				}

				e.Node.Nodes.Add(segments);

				RomObjects.LoadObjects(((MapNode)e.Node.Tag).Map);

				var objects = Node("Objects", null);

				for (var obj = 0; obj < Map.Objects.Length; obj++)
				{
					objects.Nodes.Add(Node("(" + Map.Objects[obj].X.ToString() + ", " + Map.Objects[obj].Y + ") " + Map.Objects[obj].Type, new ObjectNode { X = Map.Objects[obj].X, Y = Map.Objects[obj].Y, Type = Map.Objects[obj].Type, Flags = Map.Objects[obj].Flags }));
				}

				e.Node.Nodes.Add(objects);
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
		}

		public class WorldNode
		{
		}

		private class ObjectNode
		{
			public int X { get; set; }
			public int Y { get; set; }
			public int Type { get; set; }
			public int Flags { get; set; }
		}
	}
}