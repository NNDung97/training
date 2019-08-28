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
    public class TrangThaiItem
    {
        public string TTAvatar { get; set; }
        public string TTTenHV { get; set; }
        public string TimeDangBai { get; set; }
        public string TTChucVu { get; set; }
        public string TTNoiDung { get; set; }
        public string TTIMGMieuTa { get; set; }
        public string TTSoLike { get; set; }
        public string TTSoComment { get; set; }
    }
}