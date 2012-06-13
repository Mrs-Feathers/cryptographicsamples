using System;
namespace EncryptionSamples
{
	public partial class OTP : Gtk.Window
	{	
		public OTP () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			button23.Clicked += new EventHandler (encrypt);
			button24.Clicked += new EventHandler (decrypt);
		}
		
		private void encrypt (object sender, EventArgs e)
		{
			byte[] inputBytes = new byte[textview3.Buffer.Text.Length] ;
			byte[] keyBytes = new byte[textview3.Buffer.Text.Length];
			byte[] outputBytes = new byte[textview3.Buffer.Text.Length];
			
			try {
				inputBytes = StrToByteArray(textview3.Buffer.Text);
				keyBytes = StrToByteArray(textview4.Buffer.Text);
				} catch {
				textview5.Buffer.Text = "Error: Input is not formatted correctly.";
			} try {
				XOR(inputBytes,keyBytes , ref outputBytes);
				System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
				textview5.Buffer.Text = ConvertStringToHex(enc.GetString(outputBytes));
			} catch {
				textview5.Buffer.Text = "Error: Key length needs to be greater than or equal to the message length";
			}
		}
		
		private void decrypt (object sender, EventArgs e)
		{
			byte[] cipherBytes = new byte[textview3.Buffer.Text.Length];
            byte[] keyBytes = new byte[textview3.Buffer.Text.Length];
            byte[] outputBytes = new byte[textview3.Buffer.Text.Length];

			try {
				cipherBytes = StrToByteArray(ConvertHexToString(textview3.Buffer.Text));
				keyBytes = StrToByteArray(textview4.Buffer.Text);
				} catch {
				textview5.Buffer.Text = "Error: Input is not hex. Please put the message to decrypt in the Message box.";
			} try {
				XOR(cipherBytes,keyBytes , ref outputBytes);
				System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
				textview5.Buffer.Text = enc.GetString(outputBytes);
			} catch {
				textview5.Buffer.Text = "Error: Key length needs to be greater than or equal to the message length";
			}
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
				Console.WriteLine(asciiString.Length);			
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
	}
}
