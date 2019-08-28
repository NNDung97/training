using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Java.Lang;
using MyApp.Fragments;

namespace MyApp.Fragments
{
    [Activity(Label = "Trang chủ", Theme = "@style/AppTheme.NoActionBar",MainLauncher = false)]
    public class ActivityHome : Activity
    {
        private List<HoiVienDetails> mhoiVienDetails;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.content_main);
            mhoiVienDetails = new List<HoiVienDetails>();
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Hàn Mạnh Tiến", ChucVu = "Chủ tịch VACD" });
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Công ty ApecSoft", ChucVu = " " });
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Nguyễn Đức Thuận", ChucVu = "Phó chủ tịch VACD" });

            ListView hvlist = FindViewById<ListView>(Resource.Id.lvhoivienmoi);
            hvlist.Adapter = new CustomListViewAdapter(mhoiVienDetails);
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
                view.Tag = new ViewHolder() { ImageAvatar = imgavatar, tvTenHV = tvTenHV, tvChucVu = tvChucVu };
            }
            var holder = (ViewHolder)view.Tag;
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

    internal class ViewHolder : Java.Lang.Object
    {
        public ImageView ImageAvatar { get; set; }
        public TextView tvTenHV { get; set; }
        public TextView tvChucVu { get; set; }
    }
}