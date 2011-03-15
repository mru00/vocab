// vocab - simple vocabulary trainer
// 
// mru 2011-01
// 

using System;
using Gtk;

namespace vocab
{
	[TreeNode (ListOnly=true)]
	public class LessonNode : Gtk.TreeNode
	{
		[Gtk.TreeNodeValue (Column=0)]
		public int Id;
		
		[Gtk.TreeNodeValue (Column=1)]
		public String Description;

		[Gtk.TreeNodeValue (Column=2)]
		public int PairCount {
			get { int i = 0; foreach(var _ in PairStore) { i++; }; return i;}
		}	
		
		Gtk.NodeStore pairStore;
		public Gtk.NodeStore PairStore {
			get {
				if (pairStore == null) {
					pairStore = new Gtk.NodeStore (typeof(PairNode));					
				}
				return pairStore;
			}
		}
		
		public LessonNode (int id, string description)
		{
			Id = ID;
			Description = description;
		}
	}
	
	public class PairNode : Gtk.TreeNode
	{
		[Gtk.TreeNodeValue (Column=0)]
		public String En;

		[Gtk.TreeNodeValue (Column=1)]
		public String De;

		public PairNode(string en, string de) 
		{
			En = en; De = de;
		}
		
	}
	
}

