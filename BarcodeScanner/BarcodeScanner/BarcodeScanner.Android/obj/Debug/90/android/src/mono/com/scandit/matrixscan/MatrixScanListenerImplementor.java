package mono.com.scandit.matrixscan;


public class MatrixScanListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.scandit.matrixscan.MatrixScanListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_matrixScan:(Lcom/scandit/matrixscan/MatrixScan;Lcom/scandit/matrixscan/Frame;)V:GetMatrixScan_Lcom_scandit_matrixscan_MatrixScan_Lcom_scandit_matrixscan_Frame_Handler:ScanditBarcodePicker.Android.Matrixscan.IMatrixScanListenerInvoker, ScanditSDK\n" +
			"n_shouldRejectCode:(Lcom/scandit/matrixscan/MatrixScan;Lcom/scandit/recognition/TrackedBarcode;)Z:GetShouldRejectCode_Lcom_scandit_matrixscan_MatrixScan_Lcom_scandit_recognition_TrackedBarcode_Handler:ScanditBarcodePicker.Android.Matrixscan.IMatrixScanListenerInvoker, ScanditSDK\n" +
			"";
		mono.android.Runtime.register ("ScanditBarcodePicker.Android.Matrixscan.IMatrixScanListenerImplementor, ScanditSDK", MatrixScanListenerImplementor.class, __md_methods);
	}


	public MatrixScanListenerImplementor ()
	{
		super ();
		if (getClass () == MatrixScanListenerImplementor.class)
			mono.android.TypeManager.Activate ("ScanditBarcodePicker.Android.Matrixscan.IMatrixScanListenerImplementor, ScanditSDK", "", this, new java.lang.Object[] {  });
	}


	public void matrixScan (com.scandit.matrixscan.MatrixScan p0, com.scandit.matrixscan.Frame p1)
	{
		n_matrixScan (p0, p1);
	}

	private native void n_matrixScan (com.scandit.matrixscan.MatrixScan p0, com.scandit.matrixscan.Frame p1);


	public boolean shouldRejectCode (com.scandit.matrixscan.MatrixScan p0, com.scandit.recognition.TrackedBarcode p1)
	{
		return n_shouldRejectCode (p0, p1);
	}

	private native boolean n_shouldRejectCode (com.scandit.matrixscan.MatrixScan p0, com.scandit.recognition.TrackedBarcode p1);

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
