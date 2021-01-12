package mono.com.scandit.barcodepicker;


public class WarningsListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.scandit.barcodepicker.WarningsListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onWarnings:(Ljava/util/Set;)V:GetOnWarnings_Ljava_util_Set_Handler:ScanditBarcodePicker.Android.IWarningsListenerInvoker, ScanditSDK\n" +
			"";
		mono.android.Runtime.register ("ScanditBarcodePicker.Android.IWarningsListenerImplementor, ScanditSDK", WarningsListenerImplementor.class, __md_methods);
	}


	public WarningsListenerImplementor ()
	{
		super ();
		if (getClass () == WarningsListenerImplementor.class)
			mono.android.TypeManager.Activate ("ScanditBarcodePicker.Android.IWarningsListenerImplementor, ScanditSDK", "", this, new java.lang.Object[] {  });
	}


	public void onWarnings (java.util.Set p0)
	{
		n_onWarnings (p0);
	}

	private native void n_onWarnings (java.util.Set p0);

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
