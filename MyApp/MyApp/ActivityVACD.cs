using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyApp
{
    [Activity(Label = "ActivityVACD")]
    public class ActivityVACD : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.VACDActivity);

            var btnVACDExit = FindViewById<TextView>(Resource.Id.btnVACDExit);
            btnVACDExit.Click += BtnVACDExit_Click;
        }

        private void BtnVACDExit_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}