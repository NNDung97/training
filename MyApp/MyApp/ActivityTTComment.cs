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
    [Activity(Label = "Bình Luận")]
    public class ActivityTTComment : Activity
    {
        private RecyclerView ttblrecyclerView;
        private RecyclerView.LayoutManager ttbllayoutManager;
        private RecyclerView.Adapter ttblrvadapter;
        private List<CommentDetails> mcommentDetails;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TTCommentActi);

            // Create your application here
            ttblrecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewComment);
            mcommentDetails = new List<CommentDetails>();
            mcommentDetails.Add(new CommentDetails() { TTBLTenHV = "Vũ Văn Thanh", BLTimeDangBai = "10:22 AM", TTBLChucVu = "Giám đốc", TTBLNoiDung="Bài viết của bạn hay quá, rất nhiều kiến thức bổ ích cho mình", TTBLSoLike = "10 lượt thích"});
            mcommentDetails.Add(new CommentDetails() { TTBLTenHV = "Phạm Đăng Anh", BLTimeDangBai = "10:22 AM", TTBLChucVu = "Trưởng phòng", TTBLNoiDung = "Cảm ơn bạn đã chia sẽ bài viết, bài viết rất hay, cho bạn 1 like", TTBLSoLike = "10 lượt thích" });
            mcommentDetails.Add(new CommentDetails() { TTBLTenHV = "Phan Văn Nghĩa", BLTimeDangBai = "10:22 AM", TTBLChucVu = "Chủ tịch", TTBLNoiDung = "Rất ủng hộ những bài viết chia sẽ kinh nghiệm như thế này, rất hay.", TTBLSoLike = "10 lượt thích" });

            ttbllayoutManager = new LinearLayoutManager(this);
            ttblrecyclerView.SetLayoutManager(ttbllayoutManager);
            ttblrvadapter = new BLRecycleAdapter(mcommentDetails);
            ttblrecyclerView.SetAdapter(ttblrvadapter);
        }
    }
    public class BLRecycleAdapter : RecyclerView.Adapter
    {
        private List<CommentDetails> mcommentDetails;
        public BLRecycleAdapter(List<CommentDetails> commentDetails)
        {
            mcommentDetails = commentDetails;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public ImageView mblimageView { get; set; }
            public TextView mblTenHV { get; set; }
            public TextView mblChucVu { get; set; }
            public TextView mblTimeDangBai { get; set; }
            public TextView mblNoiDung { get; set; }
            public TextView mblsoLike { get; set; }

            public MyView(View view) : base(view)
            {
                mMainView = view;
            }
        }
        public override int ItemCount
        {
            get { return mcommentDetails.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView myHolder = holder as MyView;
            myHolder.mblimageView.SetImageResource(thumbBLIds[position]);
            myHolder.mblTenHV.Text = mcommentDetails[position].TTBLTenHV;
            myHolder.mblChucVu.Text = mcommentDetails[position].TTBLChucVu;
            myHolder.mblTimeDangBai.Text = mcommentDetails[position].BLTimeDangBai;
            myHolder.mblNoiDung.Text = mcommentDetails[position].TTBLNoiDung;
            myHolder.mblsoLike.Text = mcommentDetails[position].TTBLSoLike;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View items = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.TTCommentItems, parent, false);
            ImageView blimageView = items.FindViewById<ImageView>(Resource.Id.imgblttitemavar);
            TextView bltvTenHV = items.FindViewById<TextView>(Resource.Id.tvBLtenHVtt);
            TextView bltvChucVu = items.FindViewById<TextView>(Resource.Id.tvchucvuttBL);
            TextView bltvTimeDangBai = items.FindViewById<TextView>(Resource.Id.tvtimedangbaiBL);
            TextView bltvNoiDung = items.FindViewById<TextView>(Resource.Id.tvnoidungttBL);
            TextView bltvsoLike = items.FindViewById<TextView>(Resource.Id.tvsolikeBL);
            MyView view = new MyView(items) { mblimageView = blimageView, mblTenHV = bltvTenHV, mblChucVu = bltvChucVu, mblTimeDangBai = bltvTimeDangBai
            ,mblNoiDung = bltvNoiDung, mblsoLike = bltvsoLike};
            return view;
        }
        int[] thumbBLIds = {
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
        };
    }
}