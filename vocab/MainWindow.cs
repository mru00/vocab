
using System;
using System.Data;
using System.Xml;
using Gtk;
using System.Collections;

namespace vocab
{
	public partial class MainWindow : Gtk.Window
	{

		Gtk.NodeStore store;
		Gtk.NodeStore Store {
			get {
				if (store == null) {
					store = new Gtk.NodeStore (typeof(LessonNode));					
				}
				return store;
			}
		}


		public MainWindow () : base(Gtk.WindowType.Toplevel)
		{
			Build ();
			nodeview1.NodeStore = Store;
			nodeview1.AppendColumn ("Lesson", new Gtk.CellRendererSpin (), "text", 0);
			nodeview1.AppendColumn ("Description", new Gtk.CellRendererText (), "text", 1);
			nodeview1.ShowAll ();
			load ();
		}



		private XmlDataDocument xml_doc = new XmlDataDocument ();
		private const String xml_path = "/home/mru/uni/current/dotnet/vocab/vocab/myvocab.xml";
		private void load ()
		{
			
			xml_doc.Load (xml_path);
			
			var nodes = xml_doc.SelectNodes ("//lesson");
			Console.Out.WriteLine (nodes.Count);
			
			Console.Out.WriteLine ("loading");
			foreach (XmlNode n in nodes) {
				Console.Out.WriteLine ("node!");
				Console.Out.WriteLine ("{0} - {1}", n.Name, n.Attributes["id"].Value);
				
				int id = Convert.ToInt32 (getAttributeOrDefault(n,"id", "-1"));
				string description = getAttributeOrDefault(n, "description", "No description set");
				Store.AddNode (new LessonNode (id, description));
			}
		}

		private string getAttributeOrDefault(XmlNode n, string attribute, string _default) {
			var att = n.Attributes[attribute];
			if (att==null) return _default;
			return att.Value;
		}



		#region event handlers

		protected virtual void OnAboutActionActivated (object sender, System.EventArgs e)
		{
			var d = new AboutDialog ();
			d.Version = "1.0";
			d.Website = "http://sisyphus.teil.cc/~mru";
			d.Authors = new string[] { "mru" };
			
			d.Run ();
			d.Destroy ();
		}

		protected virtual void OnAddActionActivated (object sender, System.EventArgs e)
		{
			Store.AddNode (new LessonNode (-1, "No description set"));
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}

		protected virtual void OnQuitActionActivated (object sender, System.EventArgs e)
		{
			Application.Quit ();
		}

		#endregion
		protected virtual void OnNodeview1RowActivated (object o, Gtk.RowActivatedArgs args)
		{
			NodeView v = (NodeView)o;
			
			Console.Out.Write("dict size: {0}", v.Selection.Data.Count);
			foreach(DictionaryEntry e in v.Selection.Data) {
				Console.Out.WriteLine("dict: {0} -> {1}", e.Key, e.Value);
			}
			
			
//			Gtk.NodeSelection selection = (Gtk.NodeSelection) v.Selection;
//			LessonNode node = (LessonNode) selection.SelectedNode;

			LessonNode l = (LessonNode)v.NodeSelection.SelectedNode;
			Console.Out.WriteLine("Activated! {0}", l.Description);
//			notebook1.Add(new LessonView());
		}
		
	}
	
}
