using System;
using Gtk;
namespace vocab
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class LessonView : Gtk.Bin
	{
		public event EventHandler closeEvent;
		private LessonNode lesson;
		
		public Boolean CanEditRemove {
			set { editAction.Sensitive = removeAction.Sensitive = value; }
		}
		
		public LessonView (LessonNode lesson)
		{
			Build ();
			this.lesson = lesson;
			this.Name = lesson.Description;
			nodeview2.NodeStore = lesson.PairStore;
			nodeview2.AppendColumn ("en", new Gtk.CellRendererText (), "text", 0);
			nodeview2.AppendColumn ("de", new Gtk.CellRendererText (), "text", 1);
			for(int i = 0; i< 2; i++ ) {
				nodeview2.Columns[i].Resizable=true;
			}
			entry3.Text = lesson.Description;
			ShowAll ();
			CanEditRemove = false;
		}

		protected virtual void OnAddActionActivated (object sender, System.EventArgs e)
		{
			var pair = new PairNode ("", "");
			var dlg = new EditPairDialog ();
			dlg.De = pair.De;
			dlg.En = pair.En;
			if (dlg.Run () == (int)ResponseType.Ok) {
				pair.En = dlg.En;
				pair.De = dlg.De;
				nodeview2.NodeStore.AddNode (pair);
			}
			dlg.Destroy ();
		}

		protected virtual void OnCloseActionActivated (object sender, System.EventArgs e)
		{
			lesson.Description = entry3.Text;
			closeEvent (this, e);
		}
		protected virtual void OnEditActionActivated (object sender, System.EventArgs e)
		{
			
			var pair = (PairNode)nodeview2.NodeSelection.SelectedNode;
			if (pair != null) {
				var dlg = new EditPairDialog ();
				dlg.De = pair.De;
				dlg.En = pair.En;
				if (dlg.Run () == (int)ResponseType.Ok) {
					pair.En = dlg.En;
					pair.De = dlg.De;
					
				}
				dlg.Destroy ();
			}
		}

		protected virtual void OnRemoveActionActivated (object sender, System.EventArgs e)
		{
			var node = nodeview2.NodeSelection.SelectedNode;
			if (node != null) {
				nodeview2.NodeStore.RemoveNode (node);
				CanEditRemove = false;
			}
		}

		protected virtual void OnNodeview2CursorChanged (object sender, System.EventArgs e)
		{
			CanEditRemove = true;
		}
		
	}
}

