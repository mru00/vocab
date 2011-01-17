using System;
using Gtk;
using System.Windows.Forms;
namespace vocab
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			try {
				Gtk.Application.Init ();
				MainWindow win = new MainWindow ();
				win.Show ();
				Gtk.Application.Run ();
			} catch (Exception e) {
				System.Windows.Forms.MessageBox.Show (e.ToString(), "got exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}

