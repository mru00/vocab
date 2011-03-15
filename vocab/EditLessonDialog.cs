// vocab - simple vocabulary trainer
// 
// mru 2011-01
// 

using System;
namespace vocab
{
	public partial class EditLessonDialog : Gtk.Dialog
	{
		public int Id {
			get { return spinbutton1.ValueAsInt ; }
			set { spinbutton1.Value = value ; }
		}
			
		public string Description {
			get { return entry1.Text; }
			set { entry1.Text = value; }
		}
		
		public EditLessonDialog ()
		{
			this.Build ();
		}
	}
}

