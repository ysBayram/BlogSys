<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BSUI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-sm-8 blog-main">

        <asp:Repeater ID="rptPost" runat="server">
            <ItemTemplate>
                <h2 class="blog-post-title"><%# Eval("Title") %></h2>
                <p class="blog-post-meta"><%# Eval("Date") %> by <a href="#"><%# Eval("User")%></a></p>
                <p><%# Eval("Content") %></p>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    <!-- /.blog-main -->

    <div class="col-sm-3 col-sm-offset-1 blog-sidebar">
        <div class="sidebar-module sidebar-module-inset">
            <form class="form-signin">
                <h2 class="form-signin-heading">Lütfen giriş Yapınız</h2>
                <label for="inputEmail" class="sr-only">Kullanıcı adı</label>
                <input type="email" id="inputEmail" class="form-control" placeholder="Email address" required autofocus>
                <label for="inputPassword" class="sr-only">Şifre</label>
                <input type="password" id="inputPassword" class="form-control" placeholder="Password" required>
                <button class="btn btn-lg btn-primary btn-block" type="submit">Giriş</button>
            </form>
        </div>
    </div>
    <!-- /.blog-sidebar -->
</asp:Content>
