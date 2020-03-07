<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="UrunDetay.aspx.cs" Inherits="koleksiyoner.com.urunDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="center_content">
        <asp:DataList ID="Datalist1" runat="server">
            
            <ItemTemplate>
                <div class="center_title_bar">
                <asp:Label ID="Label9" runat="server" Text='<%# Eval("UrunAdi") %>'></asp:Label></div>

                <div class="prod_box_big">
                    <div class="top_prod_box_big"></div>
                    <div class="center_prod_box_big">
                        <div class="product_img_big">
                            <a href="javascript:popImage('images/big_pic.jpg','Some Title')" title="header=[Zoom] body=[&nbsp;] fade=[on]">

                                <asp:Image ID="Image2" Width="94px" Height="92px" runat="server" ImageUrl='<%# Eval("ResimLogo") %>' />
                            </a>

                        </div>
                        <div class="details_big_box">
                            <%--<div class="product_title_big">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("KoleksiyonerAdi") %>'></asp:Label></div>--%>
                            <div class="specifications">
                                Ürün Ad&#305;: <span class="blue">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("UrunAdi") %>'></asp:Label></span><br />
                                Ürünün Eklenme Tarihi: <span class="blue">
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("EklenmeTarihi") %>'></asp:Label></span><br />
                                Ürün Aç&#305;klamas&#305;: <span class="blue">
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Aciklama") %>'></asp:Label></span><br />
                                Kategori Ad&#305; <span class="blue">
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("KategoriAdi") %>'></asp:Label></span><br />
                            </div>
                            <div class="prod_price_big">
                                <span class="price">
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("UrunFiyat") %>'></asp:Label></span>
                            </div>
                            <a href="#" class="addtocart">add to cart</a> <a href="#" class="compare">compare</a>
                        </div>
                    </div>
                    <div class="bottom_prod_box_big"></div>
                </div>

            </ItemTemplate>
        </asp:DataList>

        <%--<div class="center_title_bar">Similar products</div>
        <div class="prod_box">
            <div class="top_prod_box"></div>
            <div class="center_prod_box">
                <div class="product_title"><a href="details.html">Motorola 156 MX-VL</a></div>
                <div class="product_img">
                    <a href="details.html">
                        <img src="images/laptop.gif" alt="" border="0" /></a>
                </div>
                <div class="prod_price"><span class="reduce">350$</span> <span class="price">270$</span></div>
            </div>
            <div class="bottom_prod_box"></div>
            <div class="prod_details_tab">
                <a href="#" title="header=[Add to cart] body=[&nbsp;] fade=[on]">
                    <img src="images/cart.gif" alt="" border="0" class="left_bt" /></a> <a href="#" title="header=[Specials] body=[&nbsp;] fade=[on]">
                        <img src="images/favs.gif" alt="" border="0" class="left_bt" /></a> <a href="#" title="header=[Gifts] body=[&nbsp;] fade=[on]">
                            <img src="images/favorites.gif" alt="" border="0" class="left_bt" /></a> <a href="details.html" class="prod_details">details</a>
            </div>
        </div>--%>
        <%--<div class="prod_box">
            <div class="top_prod_box"></div>
            <div class="center_prod_box">
                <div class="product_title"><a href="details.html">Iphone Apple</a></div>
                <div class="product_img">
                    <a href="details.html">
                        <img src="images/p4.gif" alt="" border="0" /></a>
                </div>
                <div class="prod_price"><span class="price">270$</span></div>
            </div>
            <div class="bottom_prod_box"></div>
            <div class="prod_details_tab">
                <a href="#" title="header=[Add to cart] body=[&nbsp;] fade=[on]">
                    <img src="images/cart.gif" alt="" border="0" class="left_bt" /></a> <a href="#" title="header=[Specials] body=[&nbsp;] fade=[on]">
                        <img src="images/favs.gif" alt="" border="0" class="left_bt" /></a> <a href="#" title="header=[Gifts] body=[&nbsp;] fade=[on]">
                            <img src="images/favorites.gif" alt="" border="0" class="left_bt" /></a> <a href="details.html" class="prod_details">details</a>
            </div>
        </div>--%>
        <%--<div class="prod_box">
            <div class="top_prod_box"></div>
            <div class="center_prod_box">
                <div class="product_title"><a href="details.html">Samsung Webcam</a></div>
                <div class="product_img">
                    <a href="details.html">
                        <img src="images/p5.gif" alt="" border="0" /></a>
                </div>
                <div class="prod_price"><span class="reduce">350$</span> <span class="price">270$</span></div>
            </div>
            <div class="bottom_prod_box"></div>
            <div class="prod_details_tab">
                <a href="#" title="header=[Add to cart] body=[&nbsp;] fade=[on]">
                    <img src="images/cart.gif" alt="" border="0" class="left_bt" /></a> <a href="#" title="header=[Specials] body=[&nbsp;] fade=[on]">
                        <img src="images/favs.gif" alt="" border="0" class="left_bt" /></a> <a href="#" title="header=[Gifts] body=[&nbsp;] fade=[on]">
                            <img src="images/favorites.gif" alt="" border="0" class="left_bt" /></a> <a href="details.html" class="prod_details">details</a>
            </div>
        </div>--%>
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
