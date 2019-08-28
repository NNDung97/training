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
    [Activity(Label = "Activity_UuDai")]
    public class Activity_UuDai : Activity
    {
        private RecyclerView recyclerView;
        private RecyclerView.LayoutManager layoutManager;
        private RecyclerView.Adapter rvadapter;
        private List<UudaiItemDetails> muudaiItemDetails;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.uudai_acti);
            var btnUDExit = FindViewById<TextView>(Resource.Id.btnUDExit);
            btnUDExit.Click += BtnUDExit_Click;
            // Create your application here 
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewHoiVien);
            muudaiItemDetails = new List<UudaiItemDetails>();
            muudaiItemDetails.Add(new UudaiItemDetails() { Details = "Giảm 50% khóa học đào tạo nhân sự chuyên nghiệp", ItemTienTietKiem = "1.200.000Đ", TenCongty = "Công ty đào tạo nhân lực Learn" });
            muudaiItemDetails.Add(new UudaiItemDetails() { Details = "Giảm 30% các san phẩm tại các chũi cửa hàng VinDS", ItemTienTietKiem = "3.200.000Đ", TenCongty = "VinDS fashion" });
            muudaiItemDetails.Add(new UudaiItemDetails() { Details = "Giảm 50% cho các doanh nghiệp mới đăng ký xây dựng website", ItemTienTietKiem = "5.500.000Đ", TenCongty = "Công ty Apecsoft" });
            layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            rvadapter = new UDRecycleAdapter(muudaiItemDetails);
            recyclerView.SetAdapter(rvadapter);


        }
        private void BtnUDExit_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
    public class UDRecycleAdapter : RecyclerView.Adapter
    {
        private List<UudaiItemDetails> muudaiItemDetails;
        public UDRecycleAdapter(List<UudaiItemDetails> uudaiItemDetails)
        {
            muudaiItemDetails = uudaiItemDetails;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public ImageView mimageView { get; set; }
            public TextView mDetails { get; set; }
            public TextView mItemTietietkiem { get; set; }
            public TextView mTenCongty { get; set; }
            public MyView(View view) : base(view)
            {
                mMainView = view;
            }
        }
        public override int ItemCount
        {
            get { return muudaiItemDetails.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView myHolder = holder as MyView;
            myHolder.mimageView.SetImageResource(thumbIds[position]);
            myHolder.mDetails.Text = muudaiItemDetails[position].Details;
            myHolder.mItemTietietkiem.Text = muudaiItemDetails[position].ItemTienTietKiem;
            myHolder.mTenCongty.Text = muudaiItemDetails[position].TenCongty ;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View items = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.uudai_items, parent, false);
            ImageView imageView = items.FindViewById<ImageView>(Resource.Id.imgitemDetail);
            TextView tvDetails = items.FindViewById<TextView>(Resource.Id.tvDetails);
            TextView tvItemtietkiem = items.FindViewById<TextView>(Resource.Id.tvitemtientietkiem);
            TextView tvTenCongty = items.FindViewById<TextView>(Resource.Id.tvtencongty);
            MyView view = new MyView(items) { mimageView = imageView, mDetails = tvDetails, mItemTietietkiem = tvItemtietkiem, mTenCongty = tvTenCongty };
            return view;
        }
        int[] thumbIds = {
            Resource.Drawable.Capture3,
            Resource.Drawable.Capture4,
            Resource.Drawable.Capture5,
        };
    }
}