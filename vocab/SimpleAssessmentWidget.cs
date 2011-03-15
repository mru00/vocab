// vocab - simple vocabulary trainer
// 
// mru 2011-01
// 


using System;
using Gtk;
namespace vocab
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class SimpleAssessmentWidget : Gtk.Bin
	{

		public event EventHandler closeEvent;
		private LessonNode lesson;
		private Random rand = new Random();
		private string correctAnswer;
		private Button[] submitButtons;
		private int buttonCount;
		
		
		public SimpleAssessmentWidget (LessonNode lesson)
		{
			this.Build ();
			this.lesson = lesson;
						
			buttonCount = min(5, lesson.PairCount);
			
			submitButtons = new Button[buttonCount];
			for (int i = 0; i < buttonCount; i++) {
				var b = new Button();
				vbuttonbox1.Add(b);
				b.Clicked += submit;
				submitButtons[i] = b;
			}
			newTest();
		}
		
		int min(params int[] args) {
			if (args.Length == 0) throw new Exception("nothing given");
			
			int min = args[0];
			foreach(int a in args) {
				if (a < min) min = a;
			}
			return min;
		}
		
		protected virtual void OnCloseActionActivated (object sender, System.EventArgs e)
		{
			closeEvent.Invoke(this, e);
		}		
		
		
		void newTest() {
			
			int r_source = rand.Next(lesson.PairCount);
			PairNode p_source = null;
			
			{
				int j =0;
				foreach (PairNode p in lesson.PairStore) {
					if (j++ == r_source) {p_source = p; break;}
				}
			
				if (p_source == null) return;
				
				label1.Text = p_source.En;
			}
			
			for (int i = 0; i < buttonCount; i++) {
				int r = rand.Next(lesson.PairCount);
				PairNode pair = null;
				int j =0;
				foreach (PairNode p in lesson.PairStore) {
					if (j++ == r) {pair = p; break;}
				}
				submitButtons[i].Label = pair.De;
				
			}
			
			int r_dest = rand.Next(buttonCount);
			correctAnswer = p_source.De;
			submitButtons[r_dest].Label = correctAnswer;
			
		}

		void submit(object o, EventArgs e) {
			Button b = (Button)o;
			MessageDialog d;
			if (b.Label == correctAnswer) {
				d = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "correct!");
			}
			else {
				d = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "wrong!");
			}
			d.Run();
			d.Destroy();
			newTest();
		}		
	}
}

