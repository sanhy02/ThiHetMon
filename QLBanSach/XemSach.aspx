<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="XemSach.aspx.cs" Inherits="QLBanSach.XemSach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    <h3>Trang xem sách</h3>
    <hr />
    <div class="alert alert-info">
        <div class="form-inline justify-content-center">
            <label class="font-weight-bold">Chủ đề</label>
            <asp:DropDownList
                ID="ddlChuDe"
                CssClass="form-control ml-2"
                runat="server"
                AutoPostBack="True"
                OnSelectedIndexChanged="ddlChuDe_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource
                ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MSSQL %>" SelectCommand="SELECT [MaCD], [TenCD] FROM [ChuDe]"></asp:SqlDataSource>
        </div>
    </div>


    <div class="row mt-2">
        <asp:Repeater ID="rptSach" runat="server">
            <HeaderTemplate>
                <div class="row">
            </HeaderTemplate>

            <ItemTemplate>
                <div class="col-md-4">
                    <div class="card mb-2">
                        <div class="card-header">
                            <img class="card-img-top" src='Bia_sach/<%# Eval("Hinh") %>' alt="Bìa sách" />
                        </div>
                        <div class="card-body">
                            <p><strong>Tên sách:</strong> <%# Eval("TenSach") %></p>
                            <p>
                                <strong>Giá bán:</strong>
                                <%# (bool)Eval("KhuyenMai") ? ((int)Eval("Dongia") * 0.8).ToString("N0") + " VNĐ" : ((int)Eval("Dongia")).ToString("N0") + " VNĐ" %>
                            </p>
                        </div>
                        <div class="card-footer text-center">
                            <a href="XemChiTiet.aspx?MaSach=<%# Eval("MaSach") %>" class="btn btn-success mr-3">Xem chi tiết</a>
                            <a href="ThemVaoGio.aspx?MaSach=<%# Eval("MaSach") %>" class="btn btn-info">Đặt mua</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>

            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
