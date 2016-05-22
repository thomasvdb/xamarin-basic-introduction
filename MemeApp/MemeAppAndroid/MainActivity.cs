using Android.App;
using Android.Widget;
using Android.OS;
using Android;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using MemeApp.Core;

namespace MemeAppAndroid
{
    [Activity(Label = "MemeAppAndroid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        List<MemeModel> memes;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // TODO: use dependecy injection instead
            memes = new MemeService().GetMemes();

            // Get our button from the layout resource,
            // and attach an event to it
            ListView list = FindViewById<ListView>(Resource.Id.ListMemes);
            list.Adapter = new ArrayAdapter<string>(this.BaseContext, Resource.Layout.ListItem, memes.Select(m => m.DisplayName).ToArray());
            list.ItemClick += List_Click;
        }

        void List_Click(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this.BaseContext, typeof(DetailActivity));
            intent.PutExtra("imageUrl", memes[e.Position].ImageUrl);

            StartActivity(intent);
        }
    }
}


