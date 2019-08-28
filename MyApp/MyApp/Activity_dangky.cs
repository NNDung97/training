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
    [Activity(Label = "Activity_dangky")]
    public class Activity_dangky : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dangky);
            var tvbackdangnhap = FindViewById<TextView>(Resource.Id.tvbackdangnhap);
            var btnLogin = FindViewById<Button>(Resource.Id.buttonLogIn);
            var btnDKExit = FindViewById<TextView>(Resource.Id.btnDKExit);
            btnDKExit.Click += BtnDKExit_Click;
            btnLogin.Click += BtnLogin_Click;
            tvbackdangnhap.Click += tvbackdangnhap_Click;

            // Create your application here
        }

        private void tvbackdangnhap_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity_dangnhap));
            StartActivity(intent);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity_dangkychinhthuc));
            StartActivity(intent);
        }

        private void BtnDKExit_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}