
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

		
		LessonOverviewView overview;
			
		public MainWindow () : base(Gtk.WindowType.Toplevel)
		{
			Build ();
			load ();
			
			overview = new LessonOverviewView(Store);
			overview.openLesson += OnOpenLesson;
			overview.ShowAll();
			placeholderwidget1.Current = overview;
			
		}



		private XmlDataDocument xml_doc = new XmlDataDocument ();
		private const String xml_path = "/home/mru/uni/current/dotnet/vocab/vocab/myvocab.xml";
		private void load ()
		{
			
			xml_doc.Load (xml_path);
			
			var lessonNodes = xml_doc.SelectNodes ("//lesson");
			Console.Out.WriteLine (lessonNodes.Count);
			
			Console.Out.WriteLine ("loading");
			foreach (XmlNode ln in lessonNodes) {
				Console.Out.WriteLine ("node!");
				Console.Out.WriteLine ("{0} - {1}", ln.Name, ln.Attributes["id"].Value);
				
				int id = Convert.ToInt32 (getAttributeOrDefault(ln,"id", "-1"));
				string description = getAttributeOrDefault(ln, "description", "No description set");
				
				var lesson = new LessonNode (id, description);
				
				var pairNodes = ln.SelectNodes ("pair");
				foreach (XmlNode pn in pairNodes) {
					lesson.PairStore.AddNode(new PairNode(pn.SelectSingleNode("en/text()").Value, 
					                                      pn.SelectSingleNode("de/text()").Value));
				}
				
				Store.AddNode (lesson);
			}
		}

		private string getAttributeOrDefault(XmlNode n, string attribute, string _default) {
			var att = n.Attributes[attribute];
			if (att==null) return _default;
			return att.Value;
		}



		#region event handlers



		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}

		#endregion

		void OnOpenLesson(object o, System.EventArgs args) {
			var args2 = (OpenLessonEventArgs) args;
			var lesson = args2.Node;
			var view = new LessonView(lesson);
			view.ShowAll();
			view.closeEvent += OnCloseLesson;
			ShowAll();
			
			placeholderwidget1.Current = view;
		}
		
		void OnCloseLesson(object o, System.EventArgs args) {
			
			Widget old = placeholderwidget1.Current;
			placeholderwidget1.Current = overview;
			old.Destroy();
		}
		
		protected virtual void OnAboutAction1Activated (object sender, System.EventArgs e)
		{			var d = new AboutDialog ();
			d.Version = "1.0";
			d.Website = "http://sisyphus.teil.cc/~mru";
			d.Authors = new string[] { "mru" };
			
			d.Run ();
			d.Destroy ();
		}
		
		protected virtual void OnQuitAction1Activated (object sender, System.EventArgs e)
		{
			Application.Quit ();
		}
		
	}
	
	public class OpenLessonEventArgs : EventArgs {
		public LessonNode Node;
		public OpenLessonEventArgs(LessonNode n) {
			Node = n;
		}
	}
	
}
