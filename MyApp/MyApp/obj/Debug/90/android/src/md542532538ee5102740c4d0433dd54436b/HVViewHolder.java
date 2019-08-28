package md542532538ee5102740c4d0433dd54436b;


public class HVViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MyApp.HVViewHolder, MyApp", HVViewHolder.class, __md_methods);
	}


	public HVViewHolder ()
	{
		super ();
		if (getClass () == HVViewHolder.class)
			mono.android.TypeManager.Activate ("MyApp.HVViewHolder, MyApp", "", this, new java.lang.Object[] {  });
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
