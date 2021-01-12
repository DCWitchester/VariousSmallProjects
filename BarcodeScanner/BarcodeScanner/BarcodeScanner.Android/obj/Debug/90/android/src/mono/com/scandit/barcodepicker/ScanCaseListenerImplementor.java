package mono.com.scandit.barcodepicker;


public class ScanCaseListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.scandit.barcodepicker.ScanCaseListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_didChangeState:(Lcom/scandit/barcodepicker/ScanCase;II)V:GetDidChangeState_Lcom_scandit_barcodepicker_ScanCase_IIHandler:ScanditBarcodePicker.Android.IScanCaseListenerInvoker, ScanditSDK\n" +
			"n_didInitializeScanCase:(Lcom/scandit/barcodepicker/ScanCase;)V:GetDidInitializeScanCase_Lcom_scandit_barcodepicker_ScanCase_Handler:ScanditBarcodePicker.Android.IScanCaseListenerInvoker, ScanditSDK\n" +
			"n_didProcess:([BIILcom/scandit/barcodepicker/ScanCaseSession;)I:GetDidProcess_arrayBIILcom_scandit_barcodepicker_ScanCaseSession_Handler:ScanditBarcodePicker.Android.IScanCaseListenerInvoker, ScanditSDK\n" +
			"n_didScan:(Lcom/scandit/barcodepicker/ScanCase;Lcom/scandit/barcodepicker/ScanCaseSession;)I:GetDidScan_Lcom_scandit_barcodepicker_ScanCase_Lcom_scandit_barcodepicker_ScanCaseSession_Handler:ScanditBarcodePicker.Android.IScanCaseListenerInvoker, ScanditSDK\n" +
			"";
		mono.android.Runtime.register ("ScanditBarcodePicker.Android.IScanCaseListenerImplementor, ScanditSDK", ScanCaseListenerImplementor.class, __md_methods);
	}


	public ScanCaseListenerImplementor ()
	{
		super ();
		if (getClass () == ScanCaseListenerImplementor.class)
			mono.android.TypeManager.Activate ("ScanditBarcodePicker.Android.IScanCaseListenerImplementor, ScanditSDK", "", this, new java.lang.Object[] {  });
	}


	public void didChangeState (com.scandit.barcodepicker.ScanCase p0, int p1, int p2)
	{
		n_didChangeState (p0, p1, p2);
	}

	private native void n_didChangeState (com.scandit.barcodepicker.ScanCase p0, int p1, int p2);


	public void didInitializeScanCase (com.scandit.barcodepicker.ScanCase p0)
	{
		n_didInitializeScanCase (p0);
	}

	private native void n_didInitializeScanCase (com.scandit.barcodepicker.ScanCase p0);


	public int didProcess (byte[] p0, int p1, int p2, com.scandit.barcodepicker.ScanCaseSession p3)
	{
		return n_didProcess (p0, p1, p2, p3);
	}

	private native int n_didProcess (byte[] p0, int p1, int p2, com.scandit.barcodepicker.ScanCaseSession p3);


	public int didScan (com.scandit.barcodepicker.ScanCase p0, com.scandit.barcodepicker.ScanCaseSession p1)
	{
		return n_didScan (p0, p1);
	}

	private native int n_didScan (com.scandit.barcodepicker.ScanCase p0, com.scandit.barcodepicker.ScanCaseSession p1);

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
