package md542532538ee5102740c4d0433dd54436b;


public class LKRecycleAdapter_MyView
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MyApp.LKRecycleAdapter+MyView, MyApp", LKRecycleAdapter_MyView.class, __md_methods);
	}


	public LKRecycleAdapter_MyView (android.view.View p0)
	{
		super (p0);
		if (getClass () == LKRecycleAdapter_MyView.class)
			mono.android.TypeManager.Activate ("MyApp.LKRecycleAdapter+MyView, MyApp", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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