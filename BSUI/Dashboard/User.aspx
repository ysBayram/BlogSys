<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="BSUI.Dashboard.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="widget first mainForm">
        <div class="head">
            <h5 class="iPencil">Kullanıcılar</h5>
        </div>
        <div class="rowElem">
            <label>Kullanıcı Adı :</label>
            <div class="formRight">
                <asp:TextBox runat="server" ID="txtAccount" CssClass="validate[required]"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Şifre :</label>
            <div class="formRight">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Mail :</label>
            <div class="formRight">
                <asp:TextBox runat="server" ID="txtMail" TextMode="Email"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Ad :</label>
            <div class="formRight">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Soyad :</label>
            <div class="formRight">
                <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Resim :</label><div class="formRight">
                <asp:FileUpload ID="fuAvatar" runat="server"/>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Rol :</label>
            <div class="formRight">
                <asp:DropDownList ID="ddlRole" runat="server"></asp:DropDownList>
            </div>
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
            <h5 class="iFrames">Kullanıcılar</h5>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" class="display" id="example">
            <thead>
                <tr>
                    <th>Kullanıcı Adı</th>
                    <th>Mail</th>
                    <th>Ad</th>
                    <th>Rol</th>
                    <th>Düzenle</th>
                    <th>Sil</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptUsers" runat="server" OnItemCommand="rptUsers_ItemCommand">
                    <ItemTemplate>
                        <tr class="gradeA even">
                            <td><%# Eval("Account") %></td>
                            <td><%# Eval("Mail") %></td>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("Role") %></td>
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
