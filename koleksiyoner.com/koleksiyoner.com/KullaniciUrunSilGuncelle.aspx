<%@ Page Title="" Language="C#" MasterPageFile="~/SiteKullanici.Master" AutoEventWireup="true" CodeBehind="KullaniciUrunSilGuncelle.aspx.cs" Inherits="koleksiyoner.com.KullaniciUrunSilGuncelle" %>

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
    <asp:Panel ID="PanelKategoriSilGuncelle" runat="server">
        <asp:DataList ID="DataListKategoriGetir" runat="server" Width="757px">

            <HeaderTemplate>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 150px">Ürün Resim</td>
                        <td style="width: 200px">Ürün Ad&#305;</td>
                        <td style="width: 130px">Ürün ID</td>
                        <td align="center" style="width: 60px">Sil</td>
                        <td>Güncelle</td>
                    </tr>
                </table>
            </HeaderTemplate>

            <ItemTemplate>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 150px">
                            <asp:Image ID="Image1" Width="94px" Height="92px" runat="server" ImageUrl='<%# Eval("ResimLogo") %>' />

                        </td>
                        <td style="width: 200px">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("UrunAdi") %>'></asp:Literal></td>
                        <td style="width: 130px">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("UrunID") %>'></asp:Literal></td>
                        <td id="sil" align="center" style="width: 60px">
                            <a href="KullaniciUrunSilGuncelle.aspx?UrunID=<%# Eval("UrunID") %>&islem=sil">
                                <img src="images/delete.png" align="middle" /></a></td>
                        <td id="guncelle" align="center">
                            <a href="KullaniciUrunGuncelle.aspx?UrunID=<%# Eval("UrunID") %>">
                                <img src="images/update.png" /></a></td>
                    </tr>
                </table>
            </ItemTemplate>

        </asp:DataList>
        <asp:DataList ID="DataList1" runat="server" Width="757px">

            <HeaderTemplate>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 150px">Ürün Resim</td>
                        <td style="width: 200px">Ürün Ad&#305;</td>
                        <td style="width: 130px">Ürün ID</td>
                        <td align="center" style="width: 60px">Sil</td>
                        <td>Güncelle</td>
                    </tr>
                </table>
            </HeaderTemplate>

            <ItemTemplate>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 150px">
                            <asp:Image ID="Image1" Width="94px" Height="92px" runat="server" ImageUrl='<%# Eval("ResimLogo") %>' />

                        </td>
                        <td style="width: 200px">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("UrunAdi") %>'></asp:Literal></td>
                        <td style="width: 130px">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("UrunID") %>'></asp:Literal></td>
                        <td id="sil" align="center" style="width: 60px">
                            </td>
                        <td id="guncelle" align="center">
                            </td>
                    </tr>
                </table>
            </ItemTemplate>

        </asp:DataList>






    </asp:Panel>
</asp:Content>
