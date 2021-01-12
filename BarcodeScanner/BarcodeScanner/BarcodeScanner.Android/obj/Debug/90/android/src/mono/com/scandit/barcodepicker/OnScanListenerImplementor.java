package mono.com.scandit.barcodepicker;


public class OnScanListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.scandit.barcodepicker.OnScanListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_didScan:(Lcom/scandit/barcodepicker/ScanSession;)V:GetDidScan_Lcom_scandit_barcodepicker_ScanSession_Handler:ScanditBarcodePicker.Android.IOnScanListenerInvoker, ScanditSDK\n" +
			"";
		mono.android.Runtime.register ("ScanditBarcodePicker.Android.IOnScanListenerImplementor, ScanditSDK", OnScanListenerImplementor.class, __md_methods);
	}


	public OnScanListenerImplementor ()
	{
		super ();
		if (getClass () == OnScanListenerImplementor.class)
			mono.android.TypeManager.Activate ("ScanditBarcodePicker.Android.IOnScanListenerImplementor, ScanditSDK", "", this, new java.lang.Object[] {  });
	}


	public void didScan (com.scandit.barcodepicker.ScanSession p0)
	{
		n_didScan (p0);
	}

	private native void n_didScan (com.scandit.barcodepicker.ScanSession p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
