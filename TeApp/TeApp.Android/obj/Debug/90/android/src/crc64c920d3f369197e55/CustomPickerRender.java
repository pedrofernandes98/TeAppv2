package crc64c920d3f369197e55;


public class CustomPickerRender
	extends crc643f46942d9dd1fff9.PickerRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TeApp.Droid.Helpers.CustomPickerRender, TeApp.Android", CustomPickerRender.class, __md_methods);
	}


	public CustomPickerRender (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomPickerRender.class)
			mono.android.TypeManager.Activate ("TeApp.Droid.Helpers.CustomPickerRender, TeApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CustomPickerRender (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomPickerRender.class)
			mono.android.TypeManager.Activate ("TeApp.Droid.Helpers.CustomPickerRender, TeApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CustomPickerRender (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomPickerRender.class)
			mono.android.TypeManager.Activate ("TeApp.Droid.Helpers.CustomPickerRender, TeApp.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
