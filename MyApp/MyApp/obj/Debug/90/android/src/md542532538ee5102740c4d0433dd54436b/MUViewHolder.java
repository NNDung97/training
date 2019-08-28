package md542532538ee5102740c4d0433dd54436b;


public class MUViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MyApp.MUViewHolder, MyApp", MUViewHolder.class, __md_methods);
	}


	public MUViewHolder ()
	{
		super ();
		if (getClass () == MUViewHolder.class)
			mono.android.TypeManager.Activate ("MyApp.MUViewHolder, MyApp", "", this, new java.lang.Object[] {  });
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
