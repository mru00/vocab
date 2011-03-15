// vocab - simple vocabulary trainer
// 
// mru 2011-01
// 

using System;
using Gtk;
namespace vocab
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class LessonOverviewView : Gtk.Bin
	{

		public event EventHandler openLesson;
		public event EventHandler startAssessment;
		
		public Boolean CanEditRemove {
			set { mediaPlayAction.Sensitive = editAction.Sensitive = removeAction.Sensitive = value; }
		}

		public LessonOverviewView (Gtk.NodeStore store)
		{
			this.Build ();
			
			nodeview3.NodeStore = store;
			
//			TreeViewColumn cl = new TreeViewColumn("Lesson", new Gtk.CellRendererSpin (), "text", 0);
//			cl.Resizable = true;
//			cl.Reorderable = true;

			CellRenderer r = new Gtk.CellRendererText ();
			//r.Mode = CellRendererMode.Editable;
			TreeViewColumn cd = new TreeViewColumn("Description", r, "text", 1);
			cd.Resizable = true;
			cd.Reorderable = true;
			
			
			
			TreeViewColumn cn = new TreeViewColumn("Number of Entries", new Gtk.CellRendererText (), "text", 2);
			cn.Resizable = true;
			cn.Reorderable = true;
			
			//nodeview3.AppendColumn (cl);
			nodeview3.AppendColumn (cd);
			nodeview3.AppendColumn (cn);

			
			CanEditRemove = false;
			ShowAll ();
		}

		protected virtual void OnRemoveActionActivated (object sender, System.EventArgs e)
		{
			var node = nodeview3.NodeSelection.SelectedNode;
			if (node != null) {
				nodeview3.NodeStore.RemoveNode(node);
				CanEditRemove = false;
			}
		}

		protected virtual void OnAddActionActivated (object sender, System.EventArgs e)
		{
			var lesson = new LessonNode (0, "New Lesson");
			
			var dlg = new EditLessonDialog ();
			dlg.Id = lesson.Id;
			dlg.Description = lesson.Description;
			
			if (dlg.Run () == (int)ResponseType.Ok) {
				lesson.Id = dlg.Id;
				lesson.Description = dlg.Description;
				nodeview3.NodeStore.AddNode (lesson);
			}
			dlg.Destroy ();
		}

		protected virtual void OnEditActionActivated (object sender, System.EventArgs e)
		{
			LessonNode lesson = (LessonNode)nodeview3.NodeSelection.SelectedNode;
			openLesson.Invoke (this, new OpenLessonEventArgs (lesson));
		}

		protected virtual void OnNodeview3RowActivated (object o, Gtk.RowActivatedArgs args)
		{
			NodeView v = (NodeView)o;
			var lesson = (LessonNode)v.NodeSelection.SelectedNode;
			if (lesson != null)
			openLesson.Invoke (this, new OpenLessonEventArgs (lesson));
		}

		protected virtual void OnNodeview3CursorChanged (object sender, System.EventArgs e)
		{
			CanEditRemove = true;
		}
		
		protected virtual void OnMediaPlayActionActivated (object sender, System.EventArgs e)
		{
			var lesson = (LessonNode)nodeview3.NodeSelection.SelectedNode;
			if (lesson != null)
			startAssessment.Invoke(this, new StartAssessmentEventArgs(lesson));
		}	
	}
}

