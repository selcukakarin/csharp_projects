<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="SiteIletisim.aspx.cs" Inherits="koleksiyoner.com.SiteIletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="center_content">
        <div class="center_title_bar">&#304;leti&#351;im</div>
        <div class="prod_box_big" style="width: 531px">
            <div class="top_prod_box_big" style="width: 528px"></div>
            <div class="center_prod_box_big" style="width: 529px">
                <div class="contact_form">
                    <div class="form_row">
                        <label class="contact"><strong>Ad-Soyad</strong></label>
                        <asp:TextBox ID="TextBox1" runat="server" class="contact_input"></asp:TextBox>
                    </div>
                    <div class="form_row" style="width: 334px">
                        <label class="contact"><strong>e-mail</strong></label>
                        <asp:TextBox ID="TextBox2" runat="server" class="contact_input"></asp:TextBox>
                    </div>
                    <div class="form_row">
                        <label class="contact"><strong>Message:</strong></label>
                        <asp:TextBox ID="TextBox3" runat="server" class="contact_input" Height="52px" TextMode="MultiLine" Width="205px"></asp:TextBox>
                    </div>
                    <div class="form_row">
                        <asp:Button ID="Button1" runat="server" Text="Gönder" class="contact" OnClick="Button1_Click"/></div>
                </div>
            </div>
            <div class="bottom_prod_box_big"></div>
        </div>
    </div>
    <div class="left_content">

        <asp:DataList ID="DatalistProfilBilgi" runat="server">
            <ItemTemplate>
                <div class="title_box">Ho&#351;geldiniz</div>
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
        <asp:Panel ID="Panel2" runat="server">
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
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server">
            <div class="title_box">Profil &#304;&#351;lemleri</div>
            <ul class="left_menu">
                <li class="odd"><a href="KullaniciGiris.aspx">Giri&#351; yap</a></li>
                <li class="even"><a href="KullaniciKaydol.aspx">Kaydol</a></li>
                <li>
                    <div style="margin-top: 10px;">
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="30px" ImageUrl="~/images/exit.png" Width="30px" OnClick="ImageButton1_Click" />
                    </div>
                </li>
            </ul>
        </asp:Panel>
        
        <div class="title_box">En çok tıklananlar</div>
        <ul class="left_menu">
            <li class="odd"><a href="#">Sony</a></li>
            <li class="even"><a href="#">Samsung</a></li>
            <li class="odd"><a href="#">Daewoo</a></li>
            <li class="even"><a href="#">LG</a></li>
            <li class="odd"><a href="#">Fujitsu Siemens</a></li>
            <li class="even"><a href="#">Motorola</a></li>
            <li class="odd"><a href="#">Phillips</a></li>
            <li class="even"><a href="#">Beko</a></li>
        </ul>

    </div>
</asp:Content>
