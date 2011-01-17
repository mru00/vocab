
using System;
using System.Data;
using System.Xml;
using Gtk;
using System.Collections;

namespace vocab
{
	public partial class MainWindow : Gtk.Window
	{

		Gtk.NodeStore lessonStore;
		Gtk.NodeStore LessonStore {
			get {
				if (lessonStore == null) {
					lessonStore = new Gtk.NodeStore (typeof(LessonNode));
				}
				return lessonStore;
			}
		}


		LessonOverviewView overview;

		public MainWindow () : base(Gtk.WindowType.Toplevel)
		{
			Build ();
			load ();
			
			overview = new LessonOverviewView (LessonStore);
			overview.openLesson += OnOpenLesson;
			overview.ShowAll ();
			placeholderwidget1.Current = overview;
			
		}



		private const String xml_path = "/home/mru/uni/current/dotnet/vocab/vocab/myvocab.xml";
		private void load ()
		{
			XmlDataDocument xml_doc = new XmlDataDocument ();
			
			xml_doc.Load (xml_path);
			
			var lessonNodes = xml_doc.SelectNodes ("//lesson");
			
			foreach (XmlNode ln in lessonNodes) {
				
				int id = Convert.ToInt32 (getAttributeOrDefault (ln, "id", "-1"));
				string description = getAttributeOrDefault (ln, "description", "No description set");
				
				var lesson = new LessonNode (id, description);
				
				var pairNodes = ln.SelectNodes ("pair");
				foreach (XmlNode pn in pairNodes) {
					lesson.PairStore.AddNode (new PairNode (SelectTextNode(pn,"en"), SelectTextNode(pn, "de")));
				}
				
				LessonStore.AddNode (lesson);
			}
		}

		string SelectTextNode(XmlNode n, string name) {
			var node = n.SelectSingleNode (name + "/text()");
			if (node !=null) {
				return node.Value;
			}
			return "";
		}
		
		private void save ()
		{
			XmlDataDocument xml_doc = new XmlDataDocument ();
			XmlNode root = xml_doc.CreateElement ("vocab");
			
			foreach (LessonNode l in LessonStore) {
				
				XmlNode lesson = xml_doc.CreateElement ("lesson");
				
				XmlAttribute a_id = xml_doc.CreateAttribute ("id");
				XmlAttribute a_description = xml_doc.CreateAttribute ("description");
				a_id.Value = l.Id.ToString ();
				a_description.Value = l.Description;
				
				lesson.Attributes.Append (a_id);
				lesson.Attributes.Append (a_description);
				
				foreach (PairNode p in l.PairStore) {
					
					XmlNode pair = xml_doc.CreateElement ("pair");
					
					XmlNode en = xml_doc.CreateElement ("en");
					XmlNode de = xml_doc.CreateElement ("de");
					
					en.InnerText = p.En;
					de.InnerText = p.De;
					
					pair.AppendChild (en);
					pair.AppendChild (de);
					
					lesson.AppendChild (pair);
				}
				
				root.AppendChild (lesson);
			}
			
			xml_doc.AppendChild (root);
			xml_doc.Save (xml_path);
			
		}

		private string getAttributeOrDefault (XmlNode n, string attribute, string _default)
		{
			var att = n.Attributes[attribute];
			if (att == null)
				return _default;
			return att.Value;
		}



		#region event handlers

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}

		#endregion

		void OnOpenLesson (object o, System.EventArgs args)
		{
			var args2 = (OpenLessonEventArgs)args;
			var lesson = args2.Node;
			var view = new LessonView (lesson);
			view.ShowAll ();
			view.closeEvent += OnCloseLesson;
			ShowAll ();
			
			placeholderwidget1.Current = view;
		}

		void OnCloseLesson (object o, System.EventArgs args)
		{
			
			Widget old = placeholderwidget1.Current;
			placeholderwidget1.Current = overview;
			old.Destroy ();
		}

		protected virtual void OnAboutAction1Activated (object sender, System.EventArgs e)
		{
			var d = new AboutDialog ();
			d.Version = "1.0";
			d.Website = "http://sisyphus.teil.cc/~mru";
			d.Authors = new string[] { "mru" };
			
			d.Run ();
			d.Destroy ();
		}

		protected virtual void OnQuitAction1Activated (object sender, System.EventArgs e)
		{
			save ();
			Application.Quit ();
		}
		
		protected virtual void OnSaveActionActivated (object sender, System.EventArgs e)
		{
			save();
		}
		
		
	}

	public class OpenLessonEventArgs : EventArgs
	{
		public LessonNode Node;
		public OpenLessonEventArgs (LessonNode n)
		{
			Node = n;
		}
	}
	
}
