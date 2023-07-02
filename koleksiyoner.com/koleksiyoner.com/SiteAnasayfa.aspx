<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="SiteAnasayfa.aspx.cs" Inherits="koleksiyoner.com.anasayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentSite" runat="server">

    <div class="center_content">
        <div class="center_title_bar">Urunler</div>
        <div style="width: 565px; height: auto;">
            <asp:DataList ID="DataListUrun" runat="server">
                <ItemTemplate>
                    <div class="prod_box">
                        <div class="top_prod_box"></div>
                        <div class="center_prod_box">
                            <div class="product_title">
                                <a href="UrunDetay.aspx?UrunID=<%# Eval("UrunID") %>">
                                    <asp:Label ID="Label1" CssClass="price" runat="server" Text='<%# Eval("UrunAdi") %>'></asp:Label>
                                </a>
                            </div>
                            <div class="product_img">
                                <a href="UrunDetay.aspx?UrunID=<%# Eval("UrunID") %>">
                                    <asp:Image ID="Image1" Width="94px" Height="92px" runat="server" ImageUrl='<%# Eval("ResimLogo") %>' />

                                </a>
                            </div>
                            <div class="prod_price">
                                <a href="UrunDetay.aspx?UrunID=<%# Eval("UrunID") %>">
                                    <asp:Label ID="Label2" CssClass="price" runat="server" Text='<%# Eval("UrunFiyat") %>'></asp:Label>
                                </a>
                            </div>
                        </div>
                        <div class="bottom_prod_box"></div>
                        <div class="prod_details_tab">
                            <a href="#" title="header=[Add to cart] body=[&nbsp;] fade=[on]">
                                <img src="images/cart.gif" alt="" border="0" class="left_bt" /></a> <a href="#" title="header=[Specials] body=[&nbsp;] fade=[on]">
                                    <img src="images/favs.gif" alt="" border="0" class="left_bt" /></a> <a href="#" title="header=[Gifts] body=[&nbsp;] fade=[on]">
                                        <img src="images/favorites.gif" alt="" border="0" class="left_bt" /></a> <a href="details.html" class="prod_details">details</a>
                        </div>

                    </div>
                    <div style="background-color: #f7f3f3; width: 340px; margin-left: 5px; margin-top: 10px; height: 200px; float: left;">
                        <a href="UrunDetay.aspx?UrunID=<%# Eval("UrunID") %>">
                                    <asp:Label ID="Label3" CssClass="price" runat="server" Text='<%# Eval("Aciklama") %>'></asp:Label>
                                </a>
                    </div>
                </ItemTemplate>
            </asp:DataList>
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
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="30px" ImageUrl="~/images/exit.png" Width="30px" OnClick="ImageButton1_Click" />
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
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/images/exit.png" Width="30px" OnClick="ImageButton1_Click" />
                    </div>
                </li>
            </ul>
        </asp:Panel>
        <div class="title_box">En çok t&#305;klananlar</div>
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
