package md5c8de90c22535d37f6d0af5cb53f28557;


public class DetailActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("MemeAppAndroid.DetailActivity, MemeAppAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DetailActivity.class, __md_methods);
	}


	public DetailActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DetailActivity.class)
			mono.android.TypeManager.Activate ("MemeAppAndroid.DetailActivity, MemeAppAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
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
