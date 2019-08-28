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
    [Activity(Label = "Activity_TaoMeetUp")]
    public class Activity_TaoMeetUp : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.taomeetupacti);

            var btnExit = FindViewById<TextView>(Resource.Id.btnExit);
            btnExit.Click += BtnExit_Click;

            // Create your application here
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}