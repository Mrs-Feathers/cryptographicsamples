using System;
using Gtk;
using EncryptionSamples;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		button14.Clicked += new EventHandler (XORload);
		button15.Clicked += new EventHandler (OTPload);
		button16.Clicked += new EventHandler (streamload);
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	public void XORload (object sender, EventArgs e)
	{
		XOR xorstuff = new XOR ();
		xorstuff.Show ();
	}
	
	public void OTPload (object sender, EventArgs e)
	{
		OTP otpstuff = new OTP ();
		otpstuff.Show ();
	}
	
	public void streamload (object sender, EventArgs e)
	{
		StreamCipher streamstuff = new StreamCipher ();
		streamstuff.Show ();
	}
}
