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
    [Activity(Label = "Activity_KienThuc")]
    public class Activity_KienThuc : Activity
    {
        private RecyclerView recyclerView;
        private RecyclerView.LayoutManager layoutManager;
        private RecyclerView.Adapter rvadapter;
        private List<KienThucDetails> mkienThucDetails;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.kienthuc_acti);
            var btnKTExit = FindViewById<TextView>(Resource.Id.btnKTExit);
            btnKTExit.Click += BtnKTExit_Click;

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewKienThuc);
            mkienThucDetails = new List<KienThucDetails>();
            mkienThucDetails.Add(new KienThucDetails() { tvTenKienThuc = "Xuất phát từ ý tưởng của Pate Frates, cầu thủ bóng chày đại học boston,...", tvlike = "358", tvcm = "38" });
            mkienThucDetails.Add(new KienThucDetails() { tvTenKienThuc = "Từ một học sinh yếu kém trở thành một doanh nhân thành đạt ở tuổi 26,....", tvlike = "445", tvcm = "59" });
            mkienThucDetails.Add(new KienThucDetails() { tvTenKienThuc = "cốt lõi của tinh thần lãnh đạo là kết nooi61 với moin người, ... ", tvlike = "129", tvcm = "20" });
            layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            rvadapter = new KTRecycleAdapter(mkienThucDetails);
            recyclerView.SetAdapter(rvadapter);
        }
        private void BtnKTExit_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
    public class KTRecycleAdapter : RecyclerView.Adapter
    {
        private List<KienThucDetails> mkienThucDetails;
        public KTRecycleAdapter(List<KienThucDetails> kienThucDetails)
        {
            mkienThucDetails = kienThucDetails;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public ImageView mimageView { get; set; }
            public TextView mtvTenKienThuc { get; set; }
            public TextView mtvlike { get; set; }
            public TextView mtvcm { get; set; }

            public MyView(View view) : base(view)
            {
                mMainView = view;
            }
        }
        public override int ItemCount
        {
            get { return mkienThucDetails.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView myHolder = holder as MyView;
            myHolder.mimageView.SetImageResource(thumbIds[position]);
            myHolder.mtvTenKienThuc.Text = mkienThucDetails[position].tvTenKienThuc;
            myHolder.mtvlike.Text = mkienThucDetails[position].tvlike;
            myHolder.mtvcm.Text = mkienThucDetails[position].tvcm;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View items = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.kienthuc_item, parent, false);
            ImageView imageView = items.FindViewById<ImageView>(Resource.Id.imageViewAvatar);
            TextView tvTenKienThuc = items.FindViewById<TextView>(Resource.Id.tvTenKienThuc);
            TextView tvlike = items.FindViewById<TextView>(Resource.Id.tvlike);
            TextView tvcm = items.FindViewById<TextView>(Resource.Id.tvcm);
            MyView view = new MyView(items) { mimageView = imageView, mtvTenKienThuc = tvTenKienThuc, mtvlike = tvlike, mtvcm = tvcm };
            return view;
        }
        int[] thumbIds = {
            Resource.Drawable.captu1,
            Resource.Drawable.captu2,
            Resource.Drawable.captu3,
        };
    }
}