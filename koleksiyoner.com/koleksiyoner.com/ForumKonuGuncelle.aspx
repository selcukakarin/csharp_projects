<%@ Page Title="" Language="C#" MasterPageFile="~/SiteKullanici.Master" AutoEventWireup="true" CodeBehind="ForumKonuGuncelle.aspx.cs" Inherits="koleksiyoner.com.ForumKonuGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentKullanici" runat="server">
    <div class="left_content">
        <div class="title_box">Ho&#351;geldiniz</div>
        <asp:DataList ID="DatalistProfilBilgi" runat="server">
            <ItemTemplate>
                <div class="border_box">
                    <div class="product_title">
                        <asp:Label ID="LabelKoleksiyoner1" CssClass="price" runat="server" Text='<%# Eval("KoleksiyonerAdi") %>'></asp:Label>
                    </div>
                    <div class="product_img">

                        <asp:Image ID="Image1" Width="94px" Height="92px" runat="server" ImageUrl='<%# Eval("KoleksiyonerResimYolu") %>' />

                    </div>
                    <div class="prod_price">
                        <asp:Label ID="LabelKoleksiyoner2" CssClass="price" runat="server" Text='<%# Eval("KoleksiyonerEmail") %>'></asp:Label>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <div class="title_box">&#304;&#351;lemler</div>
        <ul class="left_menu">
            <li class="odd"><a href="KullaniciProfilGuncelle.aspx">Profil Bilgilerini Güncelle</a></li>
            <li class="odd"><a href="KullaniciUrunEkle.aspx">Ürün Ekle</a></li>
            <li class="even"><a href="KullaniciUrunSilGuncelle.aspx">Ürün Sil & Güncelle</a></li>
            <li class="odd"><a href="#">Takip Edilen Ürünler</a></li>
            <li>
                <div style="margin-top: 10px;">
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="30px" ImageUrl="~/images/exit.png" Width="30px" OnClick="ImageButton1_Click" />
                </div>
            </li>
        </ul>
        <div class="title_box">&#304;&#351;lemler</div>
        <ul class="left_menu">
            <li class="odd"><a href="ForumKonuAc.aspx">Forumda konu aç</a></li>
            <li class="even"><a href="ForumKonuSilGuncelle.aspx">Açt&#305;&#287;&#305;n konuyu Sil & Güncelle</a></li>
            <li>
                <div style="margin-top: 10px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/images/exit.png" Width="30px" OnClick="ImageButton1_Click" />
                </div>
            </li>
        </ul>

    </div>
    <div class="center_content" >
        <div class="center_title_bar">Konu Guncelle</div>
        <div class="prod_box_big">
            <div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">
                <div class="contact_form">
                    <div class="form_row">
                        <label class="contact"><strong>Konu Baslik:</strong></label>
                        <asp:TextBox ID="txtKonuAdi" CssClass="contact_input" runat="server"></asp:TextBox>
                    </div>
                    <div class="form_row">
                        <label class="contact"><strong>Kategori:</strong></label>
                        <asp:DropDownList ID="DropDownListKonu" runat="server"></asp:DropDownList>

                    </div>
                    <div class="form_row">
                        <label class="contact"><strong>İçerik:</strong></label>

                        <asp:TextBox ID="txtIcerik" CssClass="contact_input" runat="server" Height="50px" TextMode="MultiLine" Width="240px"></asp:TextBox>
                    </div>
                    
                    
                    
                    
                    
                    <div class="form_row">
                        <asp:Button ID="Button1" runat="server" Text="Konu Güncelle" Style="float: right; height: 26px;" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
            <div class="bottom_prod_box_big"></div>
        </div>
    </div>
</asp:Content>
