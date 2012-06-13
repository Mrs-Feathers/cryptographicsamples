using System;
namespace EncryptionSamples
{
	public partial class XOR : Gtk.Window
	{
		public XOR () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			button11.Clicked += new EventHandler (onclickXOR);
		}
		
		private void onclickXOR (object sender, EventArgs e)
		{
			string binary;
			int _base = 2;
			
    		int number1 = Int32.Parse(entry7.Text);
			binary = Convert.ToString(number1, _base).PadLeft(8, '0');
			entry7.Text = binary;
			
			int number2 = Int32.Parse(entry8.Text);
			binary = Convert.ToString(number2, _base).PadLeft(8, '0');
			entry8.Text = binary;
		
			int answer = number1^number2;
    		binary = Convert.ToString(answer, _base).PadLeft(8, '0');
			entry9.Text = binary;
     
   			 /*/To Integer From Binary
    			string binary = "111";
   				int base = 2;
    			int integer = Convert.ToInt32(binary, base); */
		}
	}
}

