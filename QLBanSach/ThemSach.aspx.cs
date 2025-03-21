using QLBanSach.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLBanSach
{
    public partial class ThemSach : System.Web.UI.Page
    {
        SachDAO sachDAO = new SachDAO();
        ChuDeDAO chuDeDAO = new ChuDeDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadChuDe();
            }
        }

        private void LoadChuDe()
        {
            ddlChuDe.DataSource = chuDeDAO.getAll();
            ddlChuDe.DataTextField = "TenCD";
            ddlChuDe.DataValueField = "MaCD";
            ddlChuDe.DataBind();
            ddlChuDe.Items.Insert(0, new ListItem("-- Chọn Chủ Đề --", "0"));
        }

        protected void btXuLy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                Response.Write("<script>alert('Tên sách không được để trống!');</script>");
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia <= 0)
            {
                Response.Write("<script>alert('Đơn giá phải là số và lớn hơn 0!');</script>");
                return;
            }

            if (ddlChuDe.SelectedValue == "0")
            {
                Response.Write("<script>alert('Vui lòng chọn chủ đề!');</script>");
                return;
            }

            if (!FHinh.HasFile)
            {
                Response.Write("<script>alert('Vui lòng chọn ảnh bìa sách!');</script>");
                return;
            }

            string fileName = Path.GetFileName(FHinh.FileName);
            string filePath = Server.MapPath("~/Bia_sach/" + fileName);
            FHinh.SaveAs(filePath);

            Sach sach = new Sach
            {
                TenSach = txtTen.Text.Trim(),
                Dongia = (int)donGia,
                MaCD = int.Parse(ddlChuDe.SelectedValue),
                Hinh = "Bia_sach/" + fileName,
                KhuyenMai = chkKhuyenMai.Checked,
                NgayCapNhat = DateTime.Now
            };

            bool ketQua = sachDAO.ThemSach(sach);
            if (ketQua)
            {
                Response.Write("<script>alert('Thêm sách thành công!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Thêm sách thất bại!');</script>");
            }
        }
    }
}