<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminUrunListe.aspx.cs" Inherits="koleksiyoner.com.AdminUrunListe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

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
                        <td align="center" style="width: 60px">
                            <a href="KullaniciUrunSilGuncelle.aspx?UrunID=<%# Eval("UrunID") %>&islem=sil">
                                <img src="images/delete.png" align="middle" /></a></td>
                        <td align="center">
                            <a href="KullaniciUrunGuncelle.aspx?UrunID=<%# Eval("UrunID") %>">
                                <img src="images/update.png" /></a></td>
                    </tr>
                </table>
            </ItemTemplate>

        </asp:DataList>
</asp:Content>
