package mono.com.scandit.barcodepicker.ocr;


public class TextRecognitionListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.scandit.barcodepicker.ocr.TextRecognitionListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_didRecognizeText:(Lcom/scandit/barcodepicker/ocr/RecognizedText;)I:GetDidRecognizeText_Lcom_scandit_barcodepicker_ocr_RecognizedText_Handler:ScanditBarcodePicker.Android.Ocr.ITextRecognitionListenerInvoker, ScanditSDK\n" +
			"";
		mono.android.Runtime.register ("ScanditBarcodePicker.Android.Ocr.ITextRecognitionListenerImplementor, ScanditSDK", TextRecognitionListenerImplementor.class, __md_methods);
	}


	public TextRecognitionListenerImplementor ()
	{
		super ();
		if (getClass () == TextRecognitionListenerImplementor.class)
			mono.android.TypeManager.Activate ("ScanditBarcodePicker.Android.Ocr.ITextRecognitionListenerImplementor, ScanditSDK", "", this, new java.lang.Object[] {  });
	}


	public int didRecognizeText (com.scandit.barcodepicker.ocr.RecognizedText p0)
	{
		return n_didRecognizeText (p0);
	}

	private native int n_didRecognizeText (com.scandit.barcodepicker.ocr.RecognizedText p0);

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
