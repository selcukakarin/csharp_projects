<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="SiteHakkimizda.aspx.cs" Inherits="koleksiyoner.com.SiteHakkimizda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="center_content" style="height:auto;">
        <div class="center_title_bar">Hakk&#305;m&#305;zda</div>
        <div class="prod_box_big">
            <div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">
                <div class="prod_box">
                    <div class="top_prod_box"></div>
                    <div class="center_prod_box" style="height:450px;">
                        <div class="product_title">
                            <asp:Label ID="Label1" CssClass="price" runat="server" Text='&#350;irketimiz'></asp:Label>
                        </div>
                        <div class="product_img">
                                <asp:Image ID="Image1" Width="94px" Height="92px" runat="server" ImageUrl='/images/sirket.jpg' />
                        </div>
                        <div class="prod_price">
                            <asp:Label ID="Label2" CssClass="price" runat="server" Text='Ekrem&Selcuk Holding'></asp:Label>
                        </div>
                    </div>
                    <div class="bottom_prod_box"></div>

                </div>
                <div style="background-color: #f7f3f3; width: 340px; margin-left: 5px; margin-top: 10px; height: 200px; float: left;">
                    <div style="background-color: #f7f3f3; color: #4f4f4f; margin: 5px;">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec eleifend diam eu turpis vulputate, eget tincidunt libero tempor. Integer at viverra diam, non laoreet enim. Pellentesque nibh odio, accumsan non tincidunt et, condimentum in lacus. Aliquam erat volutpat. Fusce placerat, lacus sed semper facilisis, mauris dui rhoncus neque, nec pharetra libero nisl mattis magna. Nulla placerat facilisis dui, ut faucibus felis ullamcorper sed. Suspendisse convallis condimentum diam eget ultricies. Cras scelerisque quis magna pellentesque facilisis. Aenean leo massa, sodales eget quam et, tempus facilisis diam. Ut finibus erat in hendrerit pulvinar. Vestibulum porttitor metus risus, sed hendrerit nisl efficitur ac. Donec nunc diam, euismod non lacus quis, posuere volutpat turpis. Sed vel turpis pretium, sodales velit vel, ornare ligula. Duis scelerisque felis ut tortor euismod, pellentesque condimentum velit auctor. Donec sed interdum nulla, vel blandit velit. Interdum et malesuada fames ac ante ipsum primis in faucibus.

Nulla id sem ut sem interdum elementum. Praesent blandit enim id tortor faucibus, eu aliquam mi scelerisque. Fusce mi ipsum, venenatis at ipsum eu, fringilla scelerisque erat. Duis porttitor, enim vel sagittis egestas, augue justo mattis nisi, et tempor nibh metus eu metus. Etiam sed odio nulla. Nunc vel risus est. Nunc efficitur est ut urna vulputate, ut tempus ante elementum. Nam finibus viverra lectus, in vulputate justo aliquam at. Suspendisse vel mauris ex. Quisque interdum porttitor posuere. Sed eleifend mattis libero, a viverra nisl fermentum ut.

Morbi hendrerit tempor luctus. Praesent facilisis semper quam, tincidunt tincidunt urna ornare a. Curabitur suscipit arcu id augue lacinia varius. Phasellus condimentum augue sapien, lobortis rutrum ante rutrum ullamcorper. Vestibulum porttitor iaculis arcu sed venenatis. Quisque gravida pulvinar odio ac pulvinar. Pellentesque et nibh sed enim hendrerit tincidunt ut eget est. Curabitur et auctor neque, at sollicitudin quam.
                    </div>
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
