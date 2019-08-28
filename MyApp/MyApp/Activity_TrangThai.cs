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
    [Activity(Label = "Activity_TrangThai")]
    public class Activity_TrangThai : Activity
    {
        private RecyclerView recyclerViewTrangThai;
        private RecyclerView.LayoutManager layoutTTManager;
        private RecyclerView.Adapter rvadapter;
        private List<TrangThaiItem> mtrangThaiItem;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.trangthaiacti);
            var btnTTExit = FindViewById<TextView>(Resource.Id.btnTTExit);
            btnTTExit.Click += BtnTTExit_Click;

            recyclerViewTrangThai = FindViewById<RecyclerView>(Resource.Id.recyclerViewTrangThai);
            mtrangThaiItem = new List<TrangThaiItem>();
            mtrangThaiItem.Add(new TrangThaiItem() { TTTenHV = "Nguyễn Thị Hoa", TimeDangBai = "10:22AM", TTChucVu = "Giám đốc", TTNoiDung = "Thương hiêu mạnh không chỉ là ...", TTSoLike = "59", TTSoComment = "76" });
            mtrangThaiItem.Add(new TrangThaiItem() { TTTenHV = "Hoàng Văn Phú", TimeDangBai = "10:22AM", TTChucVu = "Chủ tịch", TTNoiDung = "Thương hiêu mạnh không chỉ là ...", TTSoLike = "295", TTSoComment = "20" });
            mtrangThaiItem.Add(new TrangThaiItem() { TTTenHV = "Hoàng Văn Phú", TimeDangBai = "10:22AM", TTChucVu = "Chủ tịch", TTNoiDung = "Thương hiêu mạnh không chỉ là ...", TTSoLike = "155", TTSoComment = "67" });
            mtrangThaiItem.Add(new TrangThaiItem() { TTTenHV = "Lê Hoàng Hải", TimeDangBai = "10:22AM", TTChucVu = "Chủ tịch", TTNoiDung = "Thương hiêu mạnh không chỉ là ...", TTSoLike = "233", TTSoComment = "46" });

            layoutTTManager = new LinearLayoutManager(this);
            recyclerViewTrangThai.SetLayoutManager(layoutTTManager);
            rvadapter = new RecyclerAdapter(mtrangThaiItem);
            recyclerViewTrangThai.SetAdapter(rvadapter);

            // Create your application here
        }
        private void BtnTTExit_Click(object sender, EventArgs e)
        {
            Finish();
        }

    }
    public class RecyclerAdapter : RecyclerView.Adapter
    {
        private List<TrangThaiItem> mtrangThaiItem;
        public RecyclerAdapter(List<TrangThaiItem> trangThaiItem)
        {
            mtrangThaiItem = trangThaiItem;
        }
        public class MyView : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public ImageView mimgavarView { get; set; }
            public TextView mTenHVtt { get; set; }
            public TextView mChucVutt { get; set; }
            public TextView mTimeDangBaitt { get; set; }
            public TextView mNoiDungtt { get; set; }
            public ImageView mImgMieuTatt { get; set; }
            public TextView mSoLikett { get; set; }
            public TextView mSoCommenttt { get; set; }

            public MyView(View view) : base(view)
            {
                mMainView = view;
            }
        }
        public override int ItemCount {
            get { return mtrangThaiItem.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView myHolder = holder as MyView;
            myHolder.mimgavarView.SetImageResource(thumbIds[position]);
            myHolder.mImgMieuTatt.SetImageResource(mieutalist[position]);
            myHolder.mTenHVtt.Text = mtrangThaiItem[position].TTTenHV;
            myHolder.mTimeDangBaitt.Text = mtrangThaiItem[position].TimeDangBai;
            myHolder.mChucVutt.Text = mtrangThaiItem[position].TTChucVu;
            myHolder.mNoiDungtt.Text = mtrangThaiItem[position].TTNoiDung;
            myHolder.mSoLikett.Text = mtrangThaiItem[position].TTSoLike;
            myHolder.mSoCommenttt.Text = mtrangThaiItem[position].TTSoComment;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View items = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.trangthai_item, parent, false);
            ImageView imageView = items.FindViewById<ImageView>(Resource.Id.imgttitemavar);
            ImageView imgMieuTaTT = items.FindViewById<ImageView>(Resource.Id.imgmieutatt);
            TextView tvTenHVtt = items.FindViewById<TextView>(Resource.Id.tvtenHVtt);
            TextView tvChucVutt = items.FindViewById<TextView>(Resource.Id.tvchucvutt);
            TextView tvTimeDangBai = items.FindViewById<TextView>(Resource.Id.tvtimedangbai);
            TextView tvSoLike = items.FindViewById<TextView>(Resource.Id.tvsolike);
            TextView tvsoComment = items.FindViewById<TextView>(Resource.Id.tvsocomment);
            TextView tvnoiDungtt = items.FindViewById<TextView>(Resource.Id.tvnoidungtt);
            MyView view = new MyView(items) { mimgavarView = imageView, mTenHVtt = tvTenHVtt, mChucVutt = tvChucVutt ,mImgMieuTatt = imgMieuTaTT,
            mTimeDangBaitt = tvTimeDangBai, mSoLikett = tvSoLike, mSoCommenttt = tvsoComment, mNoiDungtt = tvnoiDungtt};
            return view;
        }
        int[] thumbIds = {
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
        };
        int[] mieutalist =
        {
            Resource.Drawable.office_01,
            Resource.Drawable.office_01,
            Resource.Drawable.office_01,
            Resource.Drawable.office_01,
        };
    }
}