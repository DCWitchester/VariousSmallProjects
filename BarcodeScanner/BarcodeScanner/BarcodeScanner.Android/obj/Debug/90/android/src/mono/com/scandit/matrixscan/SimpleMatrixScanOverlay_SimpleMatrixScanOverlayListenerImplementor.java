package mono.com.scandit.matrixscan;


public class SimpleMatrixScanOverlay_SimpleMatrixScanOverlayListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.scandit.matrixscan.SimpleMatrixScanOverlay.SimpleMatrixScanOverlayListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getColorForCode:(Lcom/scandit/recognition/TrackedBarcode;J)I:GetGetColorForCode_Lcom_scandit_recognition_TrackedBarcode_JHandler:ScanditBarcodePicker.Android.Matrixscan.SimpleMatrixScanOverlay/ISimpleMatrixScanOverlayListenerInvoker, ScanditSDK\n" +
			"n_onCodeTouched:(Lcom/scandit/recognition/TrackedBarcode;J)V:GetOnCodeTouched_Lcom_scandit_recognition_TrackedBarcode_JHandler:ScanditBarcodePicker.Android.Matrixscan.SimpleMatrixScanOverlay/ISimpleMatrixScanOverlayListenerInvoker, ScanditSDK\n" +
			"";
		mono.android.Runtime.register ("ScanditBarcodePicker.Android.Matrixscan.SimpleMatrixScanOverlay+ISimpleMatrixScanOverlayListenerImplementor, ScanditSDK", SimpleMatrixScanOverlay_SimpleMatrixScanOverlayListenerImplementor.class, __md_methods);
	}


	public SimpleMatrixScanOverlay_SimpleMatrixScanOverlayListenerImplementor ()
	{
		super ();
		if (getClass () == SimpleMatrixScanOverlay_SimpleMatrixScanOverlayListenerImplementor.class)
			mono.android.TypeManager.Activate ("ScanditBarcodePicker.Android.Matrixscan.SimpleMatrixScanOverlay+ISimpleMatrixScanOverlayListenerImplementor, ScanditSDK", "", this, new java.lang.Object[] {  });
	}


	public int getColorForCode (com.scandit.recognition.TrackedBarcode p0, long p1)
	{
		return n_getColorForCode (p0, p1);
	}

	private native int n_getColorForCode (com.scandit.recognition.TrackedBarcode p0, long p1);


	public void onCodeTouched (com.scandit.recognition.TrackedBarcode p0, long p1)
	{
		n_onCodeTouched (p0, p1);
	}

	private native void n_onCodeTouched (com.scandit.recognition.TrackedBarcode p0, long p1);

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
