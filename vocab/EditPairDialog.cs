// vocab - simple vocabulary trainer
// 
// mru 2011-01
// 

using System;
namespace vocab
{
	public partial class EditPairDialog : Gtk.Dialog
	{
		public string En {
			get { return entry_en.Text; }
			set { entry_en.Text = value; }
		}
		
		public string De {
			get { return entry_de.Text; }
			set { entry_de.Text =value; }
		}
		
		
		public EditPairDialog ()
		{
			this.Build ();
		}
	}
}

