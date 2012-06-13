using System;
namespace EncryptionSamples
{
	public partial class StreamCipher : Gtk.Window
	{
		public StreamCipher () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			button25.Clicked += new EventHandler (encrypt);
			button26.Clicked += new EventHandler (decrypt);
		}
				
		private void encrypt (object sender, EventArgs e)
		{
			byte[] inputBytes = new byte[textview6.Buffer.Text.Length] ;
			byte[] keyBytes = new byte[textview6.Buffer.Text.Length];
			byte[] outputBytes = new byte[textview6.Buffer.Text.Length];
			
			inputBytes = StrToByteArray(textview6.Buffer.Text);
			keyBytes = StrToByteArray(entry10.Text);
			keyBytes = PRG(keyBytes,textview6.Buffer.Text.Length);
			XOR(inputBytes,keyBytes , ref outputBytes);
			System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
			textview7.Buffer.Text = ConvertStringToHex(enc.GetString(outputBytes));
		}
		
		private void decrypt (object sender, EventArgs e)
		{
			byte[] cipherBytes = new byte[textview6.Buffer.Text.Length];
            byte[] keyBytes = new byte[textview6.Buffer.Text.Length];
            byte[] outputBytes = new byte[textview6.Buffer.Text.Length];
			
			cipherBytes = StrToByteArray(ConvertHexToString(textview6.Buffer.Text));
			keyBytes = StrToByteArray(entry10.Text);
			keyBytes = PRG(keyBytes,(textview6.Buffer.Text.Length / 2));
			XOR(cipherBytes,keyBytes , ref outputBytes);
			System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
			textview7.Buffer.Text = enc.GetString(outputBytes);
		}
		
        private void XOR(byte[] input,byte[]key ,ref byte[]output)
        {
            for (int i = 0; i < input.Length; i++)
                output[i] = (byte)(key[i] ^ input[i]);
        }
		
		public static byte[] StrToByteArray(string str)
		{
   			System.Text.UTF8Encoding  encoding=new System.Text.UTF8Encoding();
   			return encoding.GetBytes(str);
		}

		public string ConvertStringToHex(string asciiString)
    	{
    		string hex = "";
    		foreach (char c in asciiString)
    		{			
    			int tmp = c;
    			hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
    		}
    		return hex;
    	}
     
    	public string ConvertHexToString(string HexValue)
    	{
    		string StrValue = "";
    		while (HexValue.Length > 0)
    		{
    			StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
    			HexValue = HexValue.Substring(2, HexValue.Length - 2);
    		}
    		return StrValue;
    	}
		
		private byte[] PRG (byte[] key, int length)
		{	
			System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
			string keytext = enc.GetString(key);
			int number; 
			//if (Parse.Int32(keytext) > 1) number = Parse.Int32(keytext);
			/*else*/ number = Convert.ToInt32(26 * 8576 + 65);
    		while (length >= keytext.Length) {
				int[] scramblers = { 3, 5, 7, 31, 343, 2348, 89897 };
    			keytext += Convert.ToChar((length / 7) + 6);
    			foreach (int scrambler in scramblers) 
    			{
      				keytext += Convert.ToString(((number * scrambler) % length) + ((number * scrambler) / length));
    			}
			}
			return StrToByteArray(keytext);
  		}
		
		private void outputkthnx (byte[] stuff)
		{
			System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
			string stufflol = enc.GetString(stuff);
			Console.WriteLine(stufflol);
		}
	}
}

