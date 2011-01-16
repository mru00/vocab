
// This file has been generated by the GUI designer. Do not modify.
namespace vocab
{
	public partial class MainWindow
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.Action FileAction;

		private global::Gtk.Action HelpAction;

		private global::Gtk.Action aboutAction1;

		private global::Gtk.Action quitAction1;

		private global::Gtk.VBox vbox1;

		private global::Gtk.MenuBar menubar3;

		private global::vocab.PlaceHolderWidget placeholderwidget1;

		private global::Gtk.Statusbar statusbar1;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget vocab.MainWindow
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("_File"), null, null);
			this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
			w1.Add (this.FileAction, null);
			this.HelpAction = new global::Gtk.Action ("HelpAction", global::Mono.Unix.Catalog.GetString ("Help"), null, null);
			this.HelpAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Help");
			w1.Add (this.HelpAction, null);
			this.aboutAction1 = new global::Gtk.Action ("aboutAction1", global::Mono.Unix.Catalog.GetString ("_About"), null, "gtk-about");
			this.aboutAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("_About");
			w1.Add (this.aboutAction1, null);
			this.quitAction1 = new global::Gtk.Action ("quitAction1", global::Mono.Unix.Catalog.GetString ("_Quit"), null, "gtk-quit");
			this.quitAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Quit");
			w1.Add (this.quitAction1, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "vocab.MainWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child vocab.MainWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name='menubar3'><menu name='FileAction' action='FileAction'><menuitem name='quitAction1' action='quitAction1'/></menu><menu name='HelpAction' action='HelpAction'><menuitem name='aboutAction1' action='aboutAction1'/></menu></menubar></ui>");
			this.menubar3 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar3")));
			this.menubar3.Name = "menubar3";
			this.vbox1.Add (this.menubar3);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.menubar3]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.placeholderwidget1 = new global::vocab.PlaceHolderWidget ();
			this.placeholderwidget1.Events = ((global::Gdk.EventMask)(256));
			this.placeholderwidget1.Name = "placeholderwidget1";
			this.vbox1.Add (this.placeholderwidget1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.placeholderwidget1]));
			w3.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.statusbar1 = new global::Gtk.Statusbar ();
			this.statusbar1.Name = "statusbar1";
			this.statusbar1.Spacing = 6;
			this.vbox1.Add (this.statusbar1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.statusbar1]));
			w4.PackType = ((global::Gtk.PackType)(1));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 609;
			this.DefaultHeight = 560;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.aboutAction1.Activated += new global::System.EventHandler (this.OnAboutAction1Activated);
			this.quitAction1.Activated += new global::System.EventHandler (this.OnQuitAction1Activated);
		}
	}
}
