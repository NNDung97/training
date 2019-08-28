using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MyApp
{
    [Activity(Label = "ActivityInfor")]
    public class ActivityInfor : Activity
    {
        private RecyclerView recyclerView;
        private RecyclerView.LayoutManager layoutManager;
        private RecyclerView.Adapter rvadapter;
        private List<HoiVienDetails> mhoiVienDetails;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.hoivien_Infor);
            var btnHVExit = FindViewById<TextView>(Resource.Id.btnHVExit);
            btnHVExit.Click += BtnHVExit_Click;
            // Create your application here 

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewHoiVien);
            mhoiVienDetails = new List<HoiVienDetails>();
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Hàn Mạnh Tiến", ChucVu = "Chủ tịch VACD" });
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Công ty ApecSoft", ChucVu = " " });
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Nguyễn Đức Thuận", ChucVu = "Phó chủ tịch VACD" });
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Nguyễn Thị Hoa", ChucVu = "Giám đốc" });
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Vũ Văn Thanh", ChucVu = "Giám đốc" });
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Hoàng Văn Vũ", ChucVu = "Giám đốc" });
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Phan Văn Nghĩa", ChucVu = "Chủ tịch" });
            mhoiVienDetails.Add(new HoiVienDetails() { TenHV = "Phạm Văn Tuấn", ChucVu = "Giám đốc" });

            layoutManager = new LinearLayoutManager(this);
            //layoutManager = new GridLayoutManager(this, 2);
            recyclerView.SetLayoutManager(layoutManager);
            rvadapter = new RecycleAdapter(mhoiVienDetails);
            recyclerView.SetAdapter(rvadapter);
        }
        private void BtnHVExit_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
    public class RecycleAdapter : RecyclerView.Adapter
    {
        private List<HoiVienDetails> mhoiVienDetails;
        public RecycleAdapter(List<HoiVienDetails> hoiVienDetails)
        {
            mhoiVienDetails = hoiVienDetails;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public ImageView mimageView { get; set; }
            public TextView mTenHV { get; set; }
            public TextView mChucVu { get; set; }

            public MyView(View view) : base(view)
            {
                mMainView = view;
            }
        }
        public override int ItemCount
        {
            get { return mhoiVienDetails.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView myHolder = holder as MyView;
            myHolder.mimageView.SetImageResource(thumbIds[position]);
            myHolder.mTenHV.Text = mhoiVienDetails[position].TenHV;
            myHolder.mChucVu.Text = mhoiVienDetails[position].ChucVu;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View items = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.hoivien_gridview_item, parent, false);
            ImageView imageView = items.FindViewById<ImageView>(Resource.Id.imageViewAvatar);
            TextView tvTenHV = items.FindViewById<TextView>(Resource.Id.tvTenHoiVien);
            TextView tvChucVu = items.FindViewById<TextView>(Resource.Id.tvChucVu);
            MyView view = new MyView(items) { mimageView = imageView, mTenHV = tvTenHV, mChucVu = tvChucVu };
            return view;
        }
        int[] thumbIds = {
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
        };
    }
}