<%@ Page Title="" Language="C#" MasterPageFile="~/SiteKullanici.Master" AutoEventWireup="true" CodeBehind="KullaniciUrunEkle.aspx.cs" Inherits="koleksiyoner.com.KullaniciUrunEkle" %>

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
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/images/exit.png" Width="30px" OnClick="ImageButton1_Click" />
                </div>
            </li>
        </ul>

    </div>
    <div class="center_content">
        <div class="center_title_bar">Urun Ekle</div>
        <div class="prod_box_big">
            <div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">
                <div class="contact_form">
                    <div class="form_row">
                        <label class="contact"><strong>Ürün Ad&#305;:</strong></label>
                        <asp:TextBox ID="txtUrunAdi" CssClass="contact_input" runat="server"></asp:TextBox>
                    </div>
                    <div class="form_row">
                        <label class="contact"><strong>Kategori:</strong></label>
                        <asp:DropDownList ID="DropDownListKategori" runat="server"></asp:DropDownList>

                    </div>
                    <div class="form_row">
                        <label class="contact"><strong>Fiyat:</strong></label>
                        <asp:TextBox ID="txtFiyat" CssClass="contact_input" runat="server" TextMode="Number"></asp:TextBox>
                    </div>
                    <div class="form_row">
                        <label class="contact"><strong>&#304;lan Süresi:</strong></label>

                        <asp:TextBox ID="txtIlanSuresi" CssClass="contact_input" runat="server" TextMode="Number"></asp:TextBox>
                    </div>
                    <div class="form_row">
                        <label class="contact"><strong>Aç&#305;klama:<strong></label>

                        <asp:TextBox ID="txtAciklama" CssClass="contact_input" runat="server" Height="50px" TextMode="MultiLine" Width="240px"></asp:TextBox>
                    </div>
                    <div class="form_row">
                        <label class="contact"><strong>Urun Logo:</strong></label>
                        <asp:FileUpload ID="FileUploadResim1" runat="server" />
                    </div>
                    <div class="form_row">
                        <label class="contact"><strong>Resim 1:</strong></label>
                        <asp:FileUpload ID="FileUploadResim2" runat="server" />
                    </div>
                    
                    
                    
                    
                    <div class="form_row">
                        <asp:Button ID="Button1" runat="server" Text="Ürün Ekle" Style="float: right; height: 26px;" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
            <div class="bottom_prod_box_big"></div>
        </div>
    </div>

</asp:Content>
