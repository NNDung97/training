using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MyApp
{
    [Activity(Label = "Trang chủ", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private List<HoiVienDetails> mhoiVienDetails;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            mhoiVienDetails = new List<HoiVienDetails>();
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Hàn Mạnh Tiến", ChucVu = "Chủ tịch VACD" });
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Công ty ApecSoft", ChucVu = " " });
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Nguyễn Đức Thuận", ChucVu = "Phó chủ tịch VACD" });

            ListView hvlist = FindViewById<ListView>(Resource.Id.lvhoivienmoi);
            hvlist.Adapter = new CustomListViewAdapter(mhoiVienDetails);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            //fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.NavigationItemSelected += (s, e) =>
            {
                switch (e.Item.ItemId)
                {
                    case Resource.Id.btnav_home:
                        Intent intenthome = new Intent(this, typeof(MainActivity));
                        StartActivity(intenthome);
                        break;
                    case Resource.Id.btnav_trangthai:
                        Intent intent = new Intent(this, typeof(Activity_TrangThai));
                        StartActivity(intent);
                        break;
                    case Resource.Id.btnav_uudai:
                        Intent intentUU = new Intent(this, typeof(Activity_UuDai));
                        StartActivity(intentUU);
                        break;
                    case Resource.Id.btnav_kienthuc:
                        Intent intentKT = new Intent(this, typeof(Activity_KienThuc));
                        StartActivity(intentKT);
                        break;
                    case Resource.Id.btnav_loikhuyen:
                        Intent LKintent = new Intent(this, typeof(Activity_LoiKhuyen));
                        StartActivity(LKintent);
                        break;
                }
            };

        }
        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                Toast.MakeText(this, "không có thông báo mới", ToastLength.Short).Show();
       
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_group)
            {
                Intent intentInfor = new Intent(this, typeof(ActivityInfor));
                StartActivity(intentInfor);
            }
            else if (id == Resource.Id.nav_meetup)
            {
                Intent intent = new Intent(this, typeof(Activity_Meetup));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_event)
            {

            }
            else if (id == Resource.Id.nav_VACD)
            {
                Intent intent = new Intent(this, typeof(ActivityVACD));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_VNHR)
            {
                Intent intent = new Intent(this, typeof(ActivityVACD));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_CFO)
            {
                Intent intent = new Intent(this, typeof(ActivityVACD));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_CSMO)
            {
                Intent intent = new Intent(this, typeof(ActivityVACD));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_logout)
            {
                Intent intent = new Intent(this, typeof(Activity_dangnhap));
                StartActivity(intent);
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
    public class CustomListViewAdapter : BaseAdapter<HoiVienDetails>
    {
        private List<HoiVienDetails> mhoiVienDetails;
        public override HoiVienDetails this[int position]
        {
            get { return mhoiVienDetails[position]; }
        }

        public override int Count
        {
            get { return mhoiVienDetails.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.hoivien_gridview_item, parent, false);
                var imgavatar = view.FindViewById<ImageView>(Resource.Id.imageViewAvatar);
                var tvTenHV = view.FindViewById<TextView>(Resource.Id.tvTenHoiVien);
                var tvChucVu = view.FindViewById<TextView>(Resource.Id.tvChucVu);
                view.Tag = new HVViewHolder() { ImageAvatar = imgavatar, tvTenHV = tvTenHV, tvChucVu = tvChucVu };
            }
            var holder = (HVViewHolder)view.Tag;
            holder.ImageAvatar.SetImageResource(thumbIds[position]);
            holder.tvTenHV.Text = mhoiVienDetails[position].TenHV;
            holder.tvChucVu.Text = mhoiVienDetails[position].ChucVu;
            return view;
        }
        int[] thumbIds = {
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
        };

        public CustomListViewAdapter(List<HoiVienDetails> mhoiVienDetails)
        {
            this.mhoiVienDetails = mhoiVienDetails;
        }
    }

    internal class HVViewHolder : Java.Lang.Object
    {
        public ImageView ImageAvatar { get; set; }
        public TextView tvTenHV { get; set; }
        public TextView tvChucVu { get; set; }
    }
}

