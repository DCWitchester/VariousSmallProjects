package mono.com.scandit.barcodepicker;


public class LicenseValidationListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.scandit.barcodepicker.LicenseValidationListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_failedToValidateLicense:(Ljava/lang/String;)V:GetFailedToValidateLicense_Ljava_lang_String_Handler:ScanditBarcodePicker.Android.ILicenseValidationListenerInvoker, ScanditSDK\n" +
			"";
		mono.android.Runtime.register ("ScanditBarcodePicker.Android.ILicenseValidationListenerImplementor, ScanditSDK", LicenseValidationListenerImplementor.class, __md_methods);
	}


	public LicenseValidationListenerImplementor ()
	{
		super ();
		if (getClass () == LicenseValidationListenerImplementor.class)
			mono.android.TypeManager.Activate ("ScanditBarcodePicker.Android.ILicenseValidationListenerImplementor, ScanditSDK", "", this, new java.lang.Object[] {  });
	}


	public void failedToValidateLicense (java.lang.String p0)
	{
		n_failedToValidateLicense (p0);
	}

	private native void n_failedToValidateLicense (java.lang.String p0);

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
