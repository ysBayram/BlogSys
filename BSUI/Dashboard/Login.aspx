<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BSUI.Dashboard.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <title>Blog Sys Dashboard Giriş</title>

    <link href="../Dashboard/css/main.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Cuprum' rel='stylesheet' type='text/css' />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
    <script>
        $(function () {
            $("#divSonuc").click(function () {
                $(this).hide("slow");
            })
        });
    </script>
</head>
<body>
    <!-- Top navigation bar -->
    <div id="topNav">
        <div class="fixed">
            <div class="wrapper">
                <div class="backTo">
                    <a href="../Anasayfa" title="">
                        <img src="../Dashboard/images/icons/topnav/mainWebsite.png" alt="" /><span>Siteye Geri Dön</span></a>
                </div>
                <div class="fix"></div>
            </div>
        </div>
    </div>

    <!-- Login form area -->
    <div class="loginWrapper">
        <div class="loginLogo">
            <img src="../Dashboard/images/loginLogo.png" alt="" />
        </div>
        <div class="loginPanel">
            <div class="head">
                <h5 class="iUser">Kullanıcı Girişi</h5>
            </div>
            <form id="valid" class="mainForm" runat="server">
                <fieldset>
                    <div class="loginRow noborder">
                        <label for="req1">Kullanıcı:</label>
                        <div class="loginInput">
                            <input type="text" name="login" id="req1" runat="server" required />
                        </div>
                        <div class="fix"></div>
                    </div>

                    <div class="loginRow">
                        <label for="req2">Şifre:</label>
                        <div class="loginInput">
                            <input type="password" name="password" id="req2" runat="server" required />
                        </div>
                        <div class="fix"></div>
                    </div>

                    <div class="loginRow">
                        <asp:Button ID="btnGiris" runat="server" Text="Giriş" CssClass="greyishBtn submitForm" OnClick="btnGiris_Click" />
                        <div class="fix"></div>
                        <div class="nNote nFailure hideit" runat="server" visible="false" id="divSonuc">
                            <p>
                                <strong>Kullanıcı Adı veya Şifre Hatalı!</strong><br />
                                İlgili Alanları Kontrol Ediniz!
                            </p>
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>

    <!-- Footer -->
    <div id="footer">
        <div class="wrapper">
            <span>&copy; Copyright 2015. All rights reserved. It's Brain admin theme by <a href="#" title="">Eugene Kopyov</a></span>
        </div>
    </div>
</body>
</html>
