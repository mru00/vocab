// vocab - simple vocabulary trainer
// 
// mru 2011-01
// 

using System;
using Gtk;
namespace vocab
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class PlaceHolderWidget : Gtk.Bin
	{
		public PlaceHolderWidget ()
		{
			this.Build ();
		}
		
		public Widget Current {
			get { return Child;  }
			set { if(Child != null) {Remove(Child);}; Child = value; ShowAll(); }
		}
	}
}

