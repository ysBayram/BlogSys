<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="BSUI.Dashboard.Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

    <div class="widget first mainForm">
        <div class="head">
            <h5 class="iPencil">Yazılar</h5>
        </div>
        <div class="rowElem">
            <label>Başlık :</label>
            <div class="formRight">
                <asp:TextBox runat="server" ID="txtTitle" CssClass="validate[required]"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Tarih :</label>
            <div class="formRight">
                <asp:TextBox ID="txtDate" runat="server" CssClass="maskDateTime"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Yazar :</label>
            <div class="formRight">
                <asp:DropDownList ID="ddlUser" runat="server"></asp:DropDownList>
            </div>
            <div class="fix"></div>
        </div>
        <div>
            <fieldset>
                <div class="head">
                    <h5 class="iPencil">İçerik</h5>
                </div>
                <textarea class="wysiwyg" rows="5" cols="1" runat="server" id="tbIcerik"></textarea>
            </fieldset>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <asp:Button ID="btnProcess" runat="server" Text="Kaydet" CssClass="nomargin submitForm redBtn" OnClick="btnProcess_Click" />
            <div class="fix"></div>
        </div>
    </div>

    <!-- Dynamic table -->
    <div class="table">
        <div class="head">
            <h5 class="iFrames">Yazılar</h5>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" class="display" id="example">
            <thead>
                <tr>
                    <th>Başlık</th>
                    <th>Tarih</th>
                    <th>Yazar</th>
                    <th>Düzenle</th>
                    <th>Sil</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptPosts" runat="server" OnItemCommand="rptPosts_ItemCommand">
                    <ItemTemplate>
                        <tr class="gradeA even">
                            <td><%# Eval("Title") %></td>
                            <td><%# Eval("Date") %></td>
                            <td><%# Eval("User") %></td>
                            <td class="center">
                                <asp:ImageButton ID="IbtnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("ID") %>' ImageUrl="~/Dashboard/images/icons/color/pencil.png" /></td>
                            <td class="center">
                                <asp:ImageButton ID="IbtnSil" runat="server" CommandName="Sil" CommandArgument='<%# Eval("ID") %>' ImageUrl="~/Dashboard/images/icons/color/cross.png" OnClientClick="return confirm('Silme işlemini onaylıyor musunuz?');" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
