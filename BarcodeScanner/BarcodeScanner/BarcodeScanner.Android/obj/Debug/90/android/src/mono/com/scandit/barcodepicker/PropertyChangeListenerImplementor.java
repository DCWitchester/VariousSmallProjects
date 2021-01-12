package mono.com.scandit.barcodepicker;


public class PropertyChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.scandit.barcodepicker.PropertyChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPropertyChange:(II)V:GetOnPropertyChange_IIHandler:ScanditBarcodePicker.Android.IPropertyChangeListenerInvoker, ScanditSDK\n" +
			"";
		mono.android.Runtime.register ("ScanditBarcodePicker.Android.IPropertyChangeListenerImplementor, ScanditSDK", PropertyChangeListenerImplementor.class, __md_methods);
	}


	public PropertyChangeListenerImplementor ()
	{
		super ();
		if (getClass () == PropertyChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("ScanditBarcodePicker.Android.IPropertyChangeListenerImplementor, ScanditSDK", "", this, new java.lang.Object[] {  });
	}


	public void onPropertyChange (int p0, int p1)
	{
		n_onPropertyChange (p0, p1);
	}

	private native void n_onPropertyChange (int p0, int p1);

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
