package crc64c920d3f369197e55;


public class FlatButtonRenderer
	extends crc643f46942d9dd1fff9.ButtonRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDraw:(Landroid/graphics/Canvas;)V:GetOnDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("TeApp.Droid.Helpers.FlatButtonRenderer, TeApp.Android", FlatButtonRenderer.class, __md_methods);
	}


	public FlatButtonRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == FlatButtonRenderer.class)
			mono.android.TypeManager.Activate ("TeApp.Droid.Helpers.FlatButtonRenderer, TeApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public FlatButtonRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == FlatButtonRenderer.class)
			mono.android.TypeManager.Activate ("TeApp.Droid.Helpers.FlatButtonRenderer, TeApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public FlatButtonRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == FlatButtonRenderer.class)
			mono.android.TypeManager.Activate ("TeApp.Droid.Helpers.FlatButtonRenderer, TeApp.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onDraw (android.graphics.Canvas p0)
	{
		n_onDraw (p0);
	}

	private native void n_onDraw (android.graphics.Canvas p0);

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
