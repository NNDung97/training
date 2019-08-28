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
    [Activity(Label = "Activity_Meetup")]
    public class Activity_Meetup : Activity
    {
        private List<MeetupDetails> mmeetupDetails;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.meet_upacti);

            mmeetupDetails = new List<MeetupDetails>();
            mmeetupDetails.Add(new MeetupDetails() { TenHV = "Hoàng Văn Tiến", ChucVu = "Chủ tịch",TrangThai="Chờ xử lý",NoiDung="Hội VACD tổ chức gặp mặt,giao lưu giữa các doanh nghiệp việt",TimeToChuc="22/05/2019-10:30AM",NoiToChuc= "Mahagany Coworking Space, Ha Noi" });
            mmeetupDetails.Add(new MeetupDetails() { TenHV = "Trần Đăng Nam", ChucVu = "Chủ tịch", TrangThai = "Chờ xử lý", NoiDung = "Chương trình gặp gỡ, giao lưu đầu xuân Kỷ Hợi 2019", TimeToChuc = "22/05/2019-10:30AM", NoiToChuc = "Mahagany Coworking Space, Ha Noi" });
            mmeetupDetails.Add(new MeetupDetails() { TenHV = "Nguyễn Thị Loan", ChucVu = "Giám đốc", TrangThai = "Chờ xử lý", NoiDung = "Lãnh đạo VACD gặp và làm việc với ban điều hành CLB VNHR", TimeToChuc = "14/05/2019-09:30AM", NoiToChuc = "Mahagany Coworking Space, Ha Noi" });
            mmeetupDetails.Add(new MeetupDetails() { TenHV = "Nguyễn Thị Loan", ChucVu = "Giám đốc", TrangThai = "Chờ xử lý", NoiDung = "Hà Nội - gặp gỡ chia sẽ kinh nghiệm quản trị kinh doanh", TimeToChuc = "10/05/2019-08:15AM", NoiToChuc = "Mahagany Coworking Space, Ha Noi" });

            ListView mulist = FindViewById<ListView>(Resource.Id.lvmeetup);
            mulist.Adapter = new MUCustomListViewAdapter(mmeetupDetails);

            var btnTaoMeetup = FindViewById<Button>(Resource.Id.btnTaoMeetup);
            btnTaoMeetup.Click += BtnTaoMeetup_Click;
            var btnExit = FindViewById<TextView>(Resource.Id.btnExit);
            btnExit.Click += BtnExit_Click;

            // Create your application here
        }

        private void BtnTaoMeetup_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity_TaoMeetUp));
            StartActivity(intent);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
    public class MUCustomListViewAdapter : BaseAdapter<MeetupDetails>
    {
        private List<MeetupDetails> mmeetupDetails;
        public override MeetupDetails this[int position]
        {
            get { return mmeetupDetails[position]; }
        }

        public override int Count
        {
            get { return mmeetupDetails.Count; }
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
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.meetup_acti_item, parent, false);
                var imgavatar = view.FindViewById<ImageView>(Resource.Id.imgavatar);
                var tvTenHV = view.FindViewById<TextView>(Resource.Id.tvTenHV);
                var tvChucVu = view.FindViewById<TextView>(Resource.Id.tvChucVu);
                var tvTrangThai = view.FindViewById<TextView>(Resource.Id.tvTrangthai);
                var tvNoiDung = view.FindViewById<TextView>(Resource.Id.tvNoiDung);
                var tvTimeToChuc = view.FindViewById<TextView>(Resource.Id.tvTime);
                var tvNoiToChuc = view.FindViewById<TextView>(Resource.Id.tvNoiToChuc);
                view.Tag = new MUViewHolder() { ImageAvatar = imgavatar, tvTenHV = tvTenHV, tvChucVu = tvChucVu, tvTrangThai = tvTrangThai,
                    tvNoiDung = tvNoiDung,tvTimeToChuc=tvTimeToChuc,tvNoiToChuc=tvNoiToChuc };
            }
            var holder = (MUViewHolder)view.Tag;
            holder.ImageAvatar.SetImageResource(MUthumbIds[position]);
            holder.tvTenHV.Text = mmeetupDetails[position].TenHV;
            holder.tvChucVu.Text = mmeetupDetails[position].ChucVu;
            holder.tvTrangThai.Text = mmeetupDetails[position].TrangThai;
            holder.tvNoiDung.Text = mmeetupDetails[position].NoiDung;
            holder.tvTimeToChuc.Text = mmeetupDetails[position].TimeToChuc;
            holder.tvNoiToChuc.Text = mmeetupDetails[position].NoiToChuc;
            return view;
        }
        int[] MUthumbIds = {
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
            Resource.Drawable.android,
        };

        public MUCustomListViewAdapter(List<MeetupDetails> mmeetupDetails)
        {
            this.mmeetupDetails = mmeetupDetails;
        }
    }

    internal class MUViewHolder : Java.Lang.Object
    {
        public ImageView ImageAvatar { get; set; }
        public TextView tvTenHV { get; set; }
        public TextView tvChucVu { get; set; }
        public TextView tvTrangThai { get; set; }
        public TextView tvNoiDung { get; set; }
        public TextView tvTimeToChuc { get; set; }
        public TextView tvNoiToChuc { get; set; }
    }
}