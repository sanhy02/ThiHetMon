using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLBanSach.Models
{
    public class SachDAO : DataProvider
    {
        public List<Sach> getAll()
        {
            var ds = new List<Sach>();
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Sach", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var sach = new Sach
                {
                    MaSach = int.Parse(rd["masach"].ToString()),
                    TenSach = rd["tensach"].ToString(),                   
                    Dongia = int.Parse(rd["dongia"].ToString()),                  
                    MaCD = int.Parse(rd["macd"].ToString()),
                    Hinh = rd["hinh"].ToString(),
                    KhuyenMai = bool.Parse(rd["khuyenmai"].ToString()),
                    NgayCapNhat = DateTime.Parse(rd["ngaycapnhat"].ToString())
                };
                ds.Add(sach);
            }
            return ds;
        }

        public List<Sach> laySachTheoChuDe(int macd)
        {
            var ds = new List<Sach>();
            using (SqlConnection conn = getConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Sach WHERE MaCD = @macd", conn))
                {
                    cmd.Parameters.AddWithValue("@macd", macd);
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var sach = new Sach
                            {
                                MaSach = int.Parse(rd["masach"].ToString()),
                                TenSach = rd["tensach"].ToString(),
                                Dongia = int.Parse(rd["dongia"].ToString()),
                                MaCD = int.Parse(rd["macd"].ToString()),
                                Hinh = rd["hinh"].ToString(),
                                KhuyenMai = bool.Parse(rd["khuyenmai"].ToString()),
                                NgayCapNhat = DateTime.Parse(rd["ngaycapnhat"].ToString())
                            };
                            ds.Add(sach);
                        }
                    }
                }
            }
            return ds;
        }

        internal bool ThemSach(Sach sach)
        {
            using (SqlConnection conn = getConnection())
            {
                string sql = "INSERT INTO Sach (TenSach, Dongia, MaCD, Hinh, KhuyenMai, NgayCapNhat) VALUES (@TenSach, @Dongia, @MaCD, @Hinh, @KhuyenMai, @NgayCapNhat)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenSach", sach.TenSach);
                cmd.Parameters.AddWithValue("@Dongia", sach.Dongia);
                cmd.Parameters.AddWithValue("@MaCD", sach.MaCD);
                cmd.Parameters.AddWithValue("@Hinh", sach.Hinh);
                cmd.Parameters.AddWithValue("@KhuyenMai", sach.KhuyenMai);
                cmd.Parameters.AddWithValue("@NgayCapNhat", sach.NgayCapNhat);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public List<Sach> laySachTheoTen(string tensach)
        {
            var ds = new List<Sach>();
            using (SqlConnection conn = getConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Sach WHERE TenSach LIKE @tensach", conn))
                {
                    cmd.Parameters.AddWithValue("@tensach", "%" + tensach + "%");
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var sach = new Sach
                            {
                                MaSach = int.Parse(rd["masach"].ToString()),
                                TenSach = rd["tensach"].ToString(),
                                Dongia = int.Parse(rd["dongia"].ToString()),
                                MaCD = int.Parse(rd["macd"].ToString()),
                                Hinh = rd["hinh"].ToString(),
                                KhuyenMai = bool.Parse(rd["khuyenmai"].ToString()),
                                NgayCapNhat = DateTime.Parse(rd["ngaycapnhat"].ToString())
                            };
                            ds.Add(sach);
                        }
                    }
                }
            }
            return ds;
        }

        public int Update(Sach x)
        {
            try
            {
                SqlConnection conn = getConnection();
                conn.Open();
                //hiệu chỉnh code tại đây
                SqlCommand cmd = new SqlCommand("update sach set dongia=@dongia where masach=@masach", conn);
                cmd.Parameters.AddWithValue("@dongia", x.Dongia);
                cmd.Parameters.AddWithValue("@masach", x.MaSach);                
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Delete(Sach x)
        {
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from sach where masach=@masach", conn);
            cmd.Parameters.AddWithValue("@masach", x.MaSach);
            return cmd.ExecuteNonQuery();
        }
        public int Insert(Sach x)
        {
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Sach(tensach,dongia,macd,hinh,khuyenmai,ngaycapnhat)" +
                " values(@tensach,@dongia,@macd,@hinh,@khuyenmai,@ngaycapnhat)", conn);
            cmd.Parameters.AddWithValue("@tensach", x.TenSach);          
            cmd.Parameters.AddWithValue("@dongia", x.Dongia);
            cmd.Parameters.AddWithValue("@macd", x.MaCD);
            cmd.Parameters.AddWithValue("@hinh", x.Hinh);
            cmd.Parameters.AddWithValue("@khuyenmai", x.KhuyenMai);
            cmd.Parameters.AddWithValue("@ngaycapnhat", x.NgayCapNhat);
            return cmd.ExecuteNonQuery();
        }
    }
}