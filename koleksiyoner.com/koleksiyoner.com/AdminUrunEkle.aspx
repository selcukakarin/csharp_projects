<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminUrunEkle.aspx.cs" Inherits="koleksiyoner.com.AdminUrunEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <form runat="server">
        <div id="page-heading">
            <h1>Ürün Ekle</h1>
        </div>



        <!--  start step-holder -->
        <!--  end step-holder -->

        <!-- start id-form -->
        <table border="0" cellpadding="0" cellspacing="0" id="id-form">
            <tr>
                <th valign="top">Ürün Adı</th>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" class="inp-form"></asp:TextBox></td>
                <td></td>
            </tr>

            <tr>
                <th valign="top">Kategori</th>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" class="styledselect_form_1"></asp:DropDownList>
                </td>
                <td></td>
            </tr>

            <tr>
                <th valign="top">Fiyat</th>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" class="inp-form"></asp:TextBox></td>
                <td></td>
            </tr>

            <tr>
                <th valign="top">İlan Süresi</th>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" class="inp-form"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <th valign="top">Açıklama</th>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" class="form-textarea" TextMode="MultiLine"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <th>Resim 1</th>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" class="file_1" /></td>
                <td>
                    <div class="bubble-left"></div>
                    <div class="bubble-inner">JPEG, GIF 5MB max per image</div>
                    <div class="bubble-right"></div>
                </td>
            </tr>
            <tr>
                <th>Resim 2</th>
                <td>
                    <asp:FileUpload ID="FileUpload2" runat="server" class="file_1" />
                </td>
                <td>
                    <div class="bubble-left"></div>
                    <div class="bubble-inner">JPEG, GIF 5MB max per image</div>
                    <div class="bubble-right"></div>
                </td>
            </tr>

            <tr>
                <th>&nbsp;</th>
                <td valign="top">
                    <asp:Button ID="Button1" runat="server" Text=" " class="form-submit" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text=" " class="form-reset" />
                </td>
                <td></td>
            </tr>
        </table>

        <!-- end id-form  -->

    </form>
</asp:Content>
