using QLBanSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLBanSach
{
    public partial class XemSach : System.Web.UI.Page
    {
        SachDAO sachDAO = new SachDAO();
        ChuDeDAO chuDeDAO = new ChuDeDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadChuDe();
                LoadSachTheoChuDe();
            }
        }

        private void LoadChuDe()
        {
            ddlChuDe.DataSource = chuDeDAO.getAll();
            ddlChuDe.DataTextField = "TenCD";  // Hiển thị tên chủ đề
            ddlChuDe.DataValueField = "MaCD";  // Giá trị MaCD
            ddlChuDe.DataBind();

            ddlChuDe.Items.Insert(0, new ListItem("-- Chọn Chủ Đề --", "0"));  // Thêm lựa chọn mặc định
        }

        protected void ddlChuDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSachTheoChuDe();
        }
        private void LoadSachTheoChuDe()
        {
            int maCD = int.Parse(ddlChuDe.SelectedValue);
            List<Sach> danhSachSach = sachDAO.laySachTheoChuDe(maCD);

            foreach (var sach in danhSachSach)
            {
                // Kiểm tra nếu sách có khuyến mãi, giảm giá 20%
                sach.Dongia = sach.KhuyenMai ? (int)(sach.Dongia * 0.8) : sach.Dongia;
            }

            rptSach.DataSource = danhSachSach;
            rptSach.DataBind();
        }
    }
}