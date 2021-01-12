package crc64d476148050e2fc28;


public class BarcodePickerEx
	extends com.scandit.barcodepicker.BarcodePicker
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Scandit.BarcodePickerEx, Scandit.BarcodePicker.Unified", BarcodePickerEx.class, __md_methods);
	}


	public BarcodePickerEx (android.content.Context p0)
	{
		super (p0);
		if (getClass () == BarcodePickerEx.class)
			mono.android.TypeManager.Activate ("Scandit.BarcodePickerEx, Scandit.BarcodePicker.Unified", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public BarcodePickerEx (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == BarcodePickerEx.class)
			mono.android.TypeManager.Activate ("Scandit.BarcodePickerEx, Scandit.BarcodePicker.Unified", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public BarcodePickerEx (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == BarcodePickerEx.class)
			mono.android.TypeManager.Activate ("Scandit.BarcodePickerEx, Scandit.BarcodePicker.Unified", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public BarcodePickerEx (android.content.Context p0, com.scandit.barcodepicker.ScanSettings p1)
	{
		super (p0, p1);
		if (getClass () == BarcodePickerEx.class)
			mono.android.TypeManager.Activate ("Scandit.BarcodePickerEx, Scandit.BarcodePicker.Unified", "Android.Content.Context, Mono.Android:ScanditBarcodePicker.Android.ScanSettings, ScanditSDK", this, new java.lang.Object[] { p0, p1 });
	}

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
