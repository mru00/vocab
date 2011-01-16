
using System;
using System.Data;
using System.Xml;
using Gtk;

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
			nodeview1.AppendColumn ("Lesson", new Gtk.CellRendererText (), "text", 0);
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
				
				Store.AddNode (new LessonNode (Convert.ToInt32 (n.Attributes["id"].Value)));
			}
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
			var root = xml_doc.SelectSingleNode ("/vocab");
			var lessonElement = xml_doc.CreateElement ("lesson");
			lessonElement.SetAttribute ("id", "100");
			root.AppendChild (lessonElement);
			xml_doc.Save (xml_path);
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

		protected virtual void OnDestroyEvent (object o, Gtk.DestroyEventArgs args)
		{
			
		}

		protected virtual void OnFrameEvent (object o, Gtk.FrameEventArgs args)
		{
			
		}
		
		#endregion
		
		
		
		
		
		
	}
	
}
