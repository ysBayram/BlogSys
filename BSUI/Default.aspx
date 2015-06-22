<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BSUI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

    <div class="col-sm-11 blog-main">
        <asp:Repeater ID="rptPost" runat="server">
            <ItemTemplate>
                <h2 class="blog-post-title"><%# Eval("Title") %></h2>
                <p class="blog-post-meta"><%# Eval("Date") %> by <a href="#"><%# Eval("User")%></a></p>
                <p><%# BSDAL.Tools.ControlLength(Eval("Content").ToString(),450) %><a href="Detay-<%# BSDAL.Tools.ControlLength(Eval("Title").ToString(),20) %>-<%# Eval("ID") %>">  Devamını Oku...</a></p>
            </ItemTemplate>
        </asp:Repeater>
        <nav>
            <ul class="pager">
                <li><asp:Button ID="btnPrev" runat="server" Text="Önceki" OnClick="btnPrev_Click" CssClass="btn btn-lg btn-primary"/></li>
                <li><asp:Label ID="PageNumber" runat="server" Text="Sayfa"></asp:Label></li>
                <li><asp:Button ID="btnNext" runat="server" Text="Sonraki" OnClick="btnNext_Click" CssClass="btn btn-lg btn-primary"/></li>
            </ul>
        </nav>
    </div>
    <!-- /.blog-main -->

</asp:Content>
