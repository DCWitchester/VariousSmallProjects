package mono.com.scandit.barcodepicker;


public class ProcessFrameListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.scandit.barcodepicker.ProcessFrameListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_didProcess:([BIILcom/scandit/barcodepicker/ScanSession;)V:GetDidProcess_arrayBIILcom_scandit_barcodepicker_ScanSession_Handler:ScanditBarcodePicker.Android.IProcessFrameListenerInvoker, ScanditSDK\n" +
			"";
		mono.android.Runtime.register ("ScanditBarcodePicker.Android.IProcessFrameListenerImplementor, ScanditSDK", ProcessFrameListenerImplementor.class, __md_methods);
	}


	public ProcessFrameListenerImplementor ()
	{
		super ();
		if (getClass () == ProcessFrameListenerImplementor.class)
			mono.android.TypeManager.Activate ("ScanditBarcodePicker.Android.IProcessFrameListenerImplementor, ScanditSDK", "", this, new java.lang.Object[] {  });
	}


	public void didProcess (byte[] p0, int p1, int p2, com.scandit.barcodepicker.ScanSession p3)
	{
		n_didProcess (p0, p1, p2, p3);
	}

	private native void n_didProcess (byte[] p0, int p1, int p2, com.scandit.barcodepicker.ScanSession p3);

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
