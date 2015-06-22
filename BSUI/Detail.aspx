<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="BSUI.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="col-sm-11 blog-main">
        <h2 class="blog-post-title"><%= _Post.Title %></h2>
        <hr />
        <p class="blog-post-meta"><b>Tarih :</b> <%= _Post.Date %>  <b>Yazar :</b> <a href="#"><%= _Post.User %></a></p>
        <hr />
        <p><%= _Post.Content %></p>
        <br />
        <div class="well">
            <h4>Yorum Oluştur</h4>
                <div class="form-group">
                    <input class="form-control" type="text" value="" placeholder="İsim" id="CommenterName" runat="server" required /><br />
                    <textarea class="form-control" rows="3" placeholder="Yorum İçerik" id="CommentContent" runat="server" required></textarea>
                </div>
                <asp:Button ID="btnSendComment" runat="server" Text="Gönder" CssClass="btn btn-primary" OnClick="btnSendComment_Click" />
        </div>
        <hr />
        <asp:Repeater ID="rptComment" runat="server">
            <ItemTemplate>
                <div class="media">
                    <a class="pull-left" href="#">
                        <img class="media-object" src="../../img/user-64x64.png" alt="">
                    </a>
                    <div class="media-body">
                        <h4 class="media-heading"><%# Eval("CommenterName") %>
                            <small><%# Eval("Date") %></small>
                        </h4>
                        <%# Eval("Content") %>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
