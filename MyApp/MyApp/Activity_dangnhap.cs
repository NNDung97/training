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
    [Activity(Label = "Activity_dangnhap")]
    public class Activity_dangnhap : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.dangnhap);
            var tvdangky = FindViewById<TextView>(Resource.Id.tvdangkyngay);
            var btnLogin = FindViewById<Button>(Resource.Id.buttonLogIn);
            btnLogin.Click += BtnLogin_Click;
            tvdangky.Click += tvdangky_Click;

            // Create your application here
        }

        private void tvdangky_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity_dangky));
            StartActivity(intent);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}