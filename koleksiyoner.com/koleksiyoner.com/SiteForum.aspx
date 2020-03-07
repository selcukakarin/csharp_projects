<%@ Page Title="" Language="C#" MasterPageFile="~/SiteKullanici.Master" AutoEventWireup="true" CodeBehind="SiteForum.aspx.cs" Inherits="koleksiyoner.com.SiteForum" %>

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
    <div class="center_content" style="width: 757px;">
        <div class="center_title_bar">
            Lütfen Aramak istedi&#287;iniz kategoriyi seçin  
            
                <asp:DropDownList ID="DropdownForumKonu" runat="server" Style="width: 250px;" AutoPostBack="True" OnSelectedIndexChanged="DropdownForumKonu_SelectedIndexChanged"></asp:DropDownList>


        </div>
        <asp:Panel ID="PanelKategoriSilGuncelle" runat="server">
            <asp:DataList ID="DataListForumKonuGetir" runat="server" Width="757px">
                <ItemTemplate>
                    <table style="width: 100%; border-style: solid; border-width: 2px;" >
                        <div style="border-bottom: double;">
                            <tr>
                                <td style="height: 30px">
                                    <a href="ForumKonuYorum.aspx?ForumKonuID=<%# Eval("ForumKonuID") %>">
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("ForumKonuBaslik") %>'></asp:Literal>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 59px">
                                    <a href="ForumKonuYorum.aspx?ForumKonuID=<%# Eval("ForumKonuID") %>">
                                        <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("ForumKonuIcerik") %>'></asp:Literal>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 24px">
                                    <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("ForumKonuTarihi") %>'></asp:Literal>
                                    <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("ForumKonuOkunmaSayisi") %>'></asp:Literal>
                                </td>
                            </tr>
                        </div>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
    </div>
</asp:Content>
