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
    [Activity(Label = "Activity_LoiKhuyen")]
    public class Activity_LoiKhuyen : Activity
    {
        private RecyclerView recyclerView;
        private RecyclerView.LayoutManager layoutManager;
        private RecyclerView.Adapter rvadapter;
        private List<LoiKhuyenDetails> mloiKhuyenDetails;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.loikhuyen_acti);
            var btnLKExit = FindViewById<TextView>(Resource.Id.btnLKExit);
            btnLKExit.Click += BtnLKExit_Click;

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewHoiVien);
            mloiKhuyenDetails = new List<LoiKhuyenDetails>();
            mloiKhuyenDetails.Add(new LoiKhuyenDetails() { TenNv = "Nguyễn Thị Hoa", Chucvu = "Giám đốc", ChucVu1 = "Làm cách nào để thu hút nhân tài về đầu quân cho doanh nghiệp?", ChucVu2 = "20 câu trả lời", ChucVu3 = "TRẢ LỜI" });
            mloiKhuyenDetails.Add(new LoiKhuyenDetails() { TenNv = "Phạm Đặng Anh", Chucvu = "Phó giám đốc", ChucVu1 = "Đầu quan trọng là bạn phải đánh giá được tình hình hoạt động của công ty?", ChucVu2 = "37 câu trả lời", ChucVu3 = "TRẢ LỜI" });
            mloiKhuyenDetails.Add(new LoiKhuyenDetails() { TenNv = "Phạm Văn Nghĩa", Chucvu = "Chủ tịch", ChucVu1 = "Công ty cua mình muốn kiinh doanh sản xuất rượu công nghiệp, không biết ngành này có thủ tục gì không?", ChucVu2 = "19 câu trả lời", ChucVu3 = "TRẢ LỜI" });

            layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            rvadapter = new LKRecycleAdapter(mloiKhuyenDetails);
            recyclerView.SetAdapter(rvadapter);
        }
        private void BtnLKExit_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
    public class LKRecycleAdapter : RecyclerView.Adapter
    {
        private List<LoiKhuyenDetails> mloiKhuyenDetails;
        public LKRecycleAdapter(List<LoiKhuyenDetails> loiKhuyenDetails)
        {
            mloiKhuyenDetails = loiKhuyenDetails;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public ImageView mimageView { get; set; }
            public TextView mTenNv { get; set; }
            public TextView mChucvu { get; set; }
            public TextView mChucvu1 { get; set; }
            public TextView mChucvu2 { get; set; }
            public TextView mChucvu3 { get; set; }

            public MyView(View view) : base(view)
            {
                mMainView = view;
            }
        }
        public override int ItemCount
        {
            get { return mloiKhuyenDetails.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView myHolder = holder as MyView;
            myHolder.mimageView.SetImageResource(thumbIds[position]);
            myHolder.mTenNv.Text = mloiKhuyenDetails[position].TenNv;
            myHolder.mChucvu.Text = mloiKhuyenDetails[position].Chucvu;
            myHolder.mChucvu1.Text = mloiKhuyenDetails[position].ChucVu1;
            myHolder.mChucvu2.Text = mloiKhuyenDetails[position].ChucVu2;
            myHolder.mChucvu3.Text = mloiKhuyenDetails[position].ChucVu3;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View items = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.loikhuyen_item, parent, false);
            ImageView imageView = items.FindViewById<ImageView>(Resource.Id.imageViewAvatar);
            TextView TenNv = items.FindViewById<TextView>(Resource.Id.tvTenHoiVien);
            TextView tvChucVu = items.FindViewById<TextView>(Resource.Id.tvChucVu);
            TextView tvChucVu1 = items.FindViewById<TextView>(Resource.Id.tvChucVu1);
            TextView tvChucVu2 = items.FindViewById<TextView>(Resource.Id.tvChucVu2);
            TextView tvChucVu3 = items.FindViewById<TextView>(Resource.Id.tvChucVu3);

            MyView view = new MyView(items) { mimageView = imageView, mTenNv = TenNv, mChucvu = tvChucVu, mChucvu1 = tvChucVu1, mChucvu2 = tvChucVu2, mChucvu3 = tvChucVu3 };
            return view;
        }
        int[] thumbIds = {
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,

        };
    }
}