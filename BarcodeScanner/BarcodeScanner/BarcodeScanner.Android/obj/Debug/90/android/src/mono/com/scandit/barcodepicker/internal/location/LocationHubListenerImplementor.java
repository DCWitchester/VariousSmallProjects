package mono.com.scandit.barcodepicker.internal.location;


public class LocationHubListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.scandit.barcodepicker.internal.location.LocationHubListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLocationUpdate:(Landroid/location/Location;)V:GetOnLocationUpdate_Landroid_location_Location_Handler:Com.Scandit.Barcodepicker.Internal.Location.ILocationHubListenerInvoker, ScanditSDK\n" +
			"";
		mono.android.Runtime.register ("Com.Scandit.Barcodepicker.Internal.Location.ILocationHubListenerImplementor, ScanditSDK", LocationHubListenerImplementor.class, __md_methods);
	}


	public LocationHubListenerImplementor ()
	{
		super ();
		if (getClass () == LocationHubListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Scandit.Barcodepicker.Internal.Location.ILocationHubListenerImplementor, ScanditSDK", "", this, new java.lang.Object[] {  });
	}


	public void onLocationUpdate (android.location.Location p0)
	{
		n_onLocationUpdate (p0);
	}

	private native void n_onLocationUpdate (android.location.Location p0);

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
