using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBanSach.Models
{
    public class Sach
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }        
        public int Dongia { get; set; }       
        public int MaCD { get; set; }
        public string Hinh { get; set; }
        public bool KhuyenMai { get; set; }
        public DateTime NgayCapNhat { set; get; }
    }
}