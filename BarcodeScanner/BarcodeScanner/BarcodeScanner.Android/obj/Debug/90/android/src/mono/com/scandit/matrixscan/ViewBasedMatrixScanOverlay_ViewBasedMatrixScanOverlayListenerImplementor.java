package mono.com.scandit.matrixscan;


public class ViewBasedMatrixScanOverlay_ViewBasedMatrixScanOverlayListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.scandit.matrixscan.ViewBasedMatrixScanOverlay.ViewBasedMatrixScanOverlayListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getOffsetForCode:(Lcom/scandit/recognition/TrackedBarcode;J)Landroid/graphics/Point;:GetGetOffsetForCode_Lcom_scandit_recognition_TrackedBarcode_JHandler:ScanditBarcodePicker.Android.Matrixscan.ViewBasedMatrixScanOverlay/IViewBasedMatrixScanOverlayListenerInvoker, ScanditSDK\n" +
			"n_getViewForCode:(Lcom/scandit/recognition/TrackedBarcode;J)Landroid/view/View;:GetGetViewForCode_Lcom_scandit_recognition_TrackedBarcode_JHandler:ScanditBarcodePicker.Android.Matrixscan.ViewBasedMatrixScanOverlay/IViewBasedMatrixScanOverlayListenerInvoker, ScanditSDK\n" +
			"n_onCodeTouched:(Lcom/scandit/recognition/TrackedBarcode;J)V:GetOnCodeTouched_Lcom_scandit_recognition_TrackedBarcode_JHandler:ScanditBarcodePicker.Android.Matrixscan.ViewBasedMatrixScanOverlay/IViewBasedMatrixScanOverlayListenerInvoker, ScanditSDK\n" +
			"";
		mono.android.Runtime.register ("ScanditBarcodePicker.Android.Matrixscan.ViewBasedMatrixScanOverlay+IViewBasedMatrixScanOverlayListenerImplementor, ScanditSDK", ViewBasedMatrixScanOverlay_ViewBasedMatrixScanOverlayListenerImplementor.class, __md_methods);
	}


	public ViewBasedMatrixScanOverlay_ViewBasedMatrixScanOverlayListenerImplementor ()
	{
		super ();
		if (getClass () == ViewBasedMatrixScanOverlay_ViewBasedMatrixScanOverlayListenerImplementor.class)
			mono.android.TypeManager.Activate ("ScanditBarcodePicker.Android.Matrixscan.ViewBasedMatrixScanOverlay+IViewBasedMatrixScanOverlayListenerImplementor, ScanditSDK", "", this, new java.lang.Object[] {  });
	}


	public android.graphics.Point getOffsetForCode (com.scandit.recognition.TrackedBarcode p0, long p1)
	{
		return n_getOffsetForCode (p0, p1);
	}

	private native android.graphics.Point n_getOffsetForCode (com.scandit.recognition.TrackedBarcode p0, long p1);


	public android.view.View getViewForCode (com.scandit.recognition.TrackedBarcode p0, long p1)
	{
		return n_getViewForCode (p0, p1);
	}

	private native android.view.View n_getViewForCode (com.scandit.recognition.TrackedBarcode p0, long p1);


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
