
// This file has been generated by the GUI designer. Do not modify.
namespace vocab
{
	public partial class LessonView
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.Action addAction;

		private global::Gtk.Action closeAction;

		private global::Gtk.Action editAction;

		private global::Gtk.Action removeAction;

		private global::Gtk.VBox vbox2;

		private global::Gtk.Toolbar toolbar2;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label label1;

		private global::Gtk.Entry entry3;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.NodeView nodeview2;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget vocab.LessonView
			Stetic.BinContainer w1 = global::Stetic.BinContainer.Attach (this);
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup ("Default");
			this.addAction = new global::Gtk.Action ("addAction", null, null, "gtk-add");
			this.addAction.IsImportant = true;
			w2.Add (this.addAction, null);
			this.closeAction = new global::Gtk.Action ("closeAction", null, null, "gtk-close");
			this.closeAction.IsImportant = true;
			w2.Add (this.closeAction, null);
			this.editAction = new global::Gtk.Action ("editAction", null, null, "gtk-edit");
			this.editAction.IsImportant = true;
			w2.Add (this.editAction, null);
			this.removeAction = new global::Gtk.Action ("removeAction", null, null, "gtk-remove");
			this.removeAction.IsImportant = true;
			w2.Add (this.removeAction, null);
			this.UIManager.InsertActionGroup (w2, 0);
			this.Name = "vocab.LessonView";
			// Container child vocab.LessonView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar2'><toolitem name='editAction' action='editAction'/><toolitem name='addAction' action='addAction'/><toolitem name='removeAction' action='removeAction'/><toolitem name='closeAction' action='closeAction'/></toolbar></ui>");
			this.toolbar2 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar2")));
			this.toolbar2.Name = "toolbar2";
			this.toolbar2.ShowArrow = false;
			this.vbox2.Add (this.toolbar2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.toolbar2]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			this.hbox1.BorderWidth = ((uint)(3));
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Lesson title:");
			this.hbox1.Add (this.label1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label1]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entry3 = new global::Gtk.Entry ();
			this.entry3.CanFocus = true;
			this.entry3.Name = "entry3";
			this.entry3.IsEditable = true;
			this.entry3.InvisibleChar = '•';
			this.hbox1.Add (this.entry3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.entry3]));
			w5.Position = 1;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.nodeview2 = new global::Gtk.NodeView ();
			this.nodeview2.CanFocus = true;
			this.nodeview2.Name = "nodeview2";
			this.nodeview2.Reorderable = true;
			this.GtkScrolledWindow.Add (this.nodeview2);
			this.vbox2.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow]));
			w8.Position = 2;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			w1.SetUiManager (UIManager);
			this.Hide ();
			this.addAction.Activated += new global::System.EventHandler (this.OnAddActionActivated);
			this.closeAction.Activated += new global::System.EventHandler (this.OnCloseActionActivated);
			this.editAction.Activated += new global::System.EventHandler (this.OnEditActionActivated);
			this.removeAction.Activated += new global::System.EventHandler (this.OnRemoveActionActivated);
			this.entry3.Activated += new global::System.EventHandler (this.OnEntry3Activated);
			this.nodeview2.CursorChanged += new global::System.EventHandler (this.OnNodeview2CursorChanged);
		}
	}
}
