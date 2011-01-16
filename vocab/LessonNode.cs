using System;
using Gtk;

namespace vocab
{
	[TreeNode (ListOnly=true)]
	public class LessonNode : Gtk.TreeNode
	{
		[Gtk.TreeNodeValue (Column=0)]
		public int Id;
		
		public LessonNode (int id)
		{
			Id = id;
		}
		
		
	}
}

