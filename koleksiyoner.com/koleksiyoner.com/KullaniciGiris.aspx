<%@ Page Title="" Language="C#" MasterPageFile="~/SiteKullanici.Master" AutoEventWireup="true" CodeBehind="KullaniciGiris.aspx.cs" Inherits="koleksiyoner.com.KullaniciGiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentKullanici" runat="server">

    <div class="center_content" style="margin-left: 85px;">
        <div class="center_title_bar">Giri&#351;</div>
        <div class="prod_box_big">
            <div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">
                <div class="contact_form">
                    <div class="form_row">
                        <label class="contact"><strong>Email:</strong></label>
                        <asp:TextBox ID="TextBox1" CssClass="contact_input" runat="server"></asp:TextBox>
                    </div>
                    <div class="form_row">
                        <label class="contact"><strong>&#350;ifre:</strong></label>

                        <asp:TextBox ID="TextBox2" CssClass="contact_input" runat="server"></asp:TextBox>
                    </div>
                    <div class="form_row">
                        <asp:Button ID="Button1" runat="server" Text="Giri&#351;" Style="float: right; height: 26px;" OnClick="Button1_Click1" />
                    </div>
                </div>
            </div>
            <div class="bottom_prod_box_big"></div>
        </div>

    </div>
    <div class="left_content">
        <asp:Panel ID="Panel1" runat="server">
            <div class="title_box">Profil &#304;&#351;lemleri</div>
            <ul class="left_menu">
                <li class="odd"><a href="KullaniciGiris.aspx">Giri&#351; yap</a></li>
                <li class="even"><a href="KullaniciKaydol.aspx">Kaydol</a></li>
                <li>
                    <div style="margin-top: 10px;">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/images/exit.png" Width="30px" OnClick="ImageButton1_Click" />
                    </div>
                </li>
            </ul>
        </asp:Panel>
    </div>
</asp:Content>
