<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BSUI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-sm-11 blog-main">
        <asp:Repeater ID="rptPost" runat="server">
            <ItemTemplate>
                <h2 class="blog-post-title"><%# Eval("Title") %></h2>
                <p class="blog-post-meta"><%# Eval("Date") %> by <a href="#"><%# Eval("User")%></a></p>
                <p><%# BSDAL.Tools.ControlLength(Eval("Content").ToString(),450) %><a href="Detay-<%# BSDAL.Tools.ControlLength(Eval("Title").ToString(),20) %>-<%# Eval("ID") %>">  Devamını Oku...</a></p>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    <!-- /.blog-main -->
    
</asp:Content>
