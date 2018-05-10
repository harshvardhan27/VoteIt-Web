<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="VoteITClient.login" ClientIDMode="Static" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>VOTE IT | Login</title>

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />

    <link href="css/animate.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
</head>
<body class="gray-bg">

    <div class="middle-box text-center loginscreen animated fadeInDown">
        <div>
            <div>
                <h3 class="logo-name">VT</h3>
            </div>
            <h3>Welcome to Vote IT</h3>
            <p>Login in. To see it in action.</p>
            <form class="m-t" role="form" runat="server" autocomplete="off">
                <div class="row panel panel-danger" runat="server" id="errorPanel" visible="false">
                    <div class="panel-heading">
                        <span id="panelHead" runat="server"></span>
                        <button aria-hidden="true" class="close" type="button">×</button>
                    </div>
                    <div class="panel-body">
                        <p id="panelContent" runat="server"></p>
                    </div>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" MaxLength="50" placeholder="Email"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" MaxLength="16" placeholder="Password" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary block full-width m-b" OnClick="btnLogin_Click" />

                <a href="#"><small>Forgot password?</small></a>
                <p class="text-muted text-center"><small>Do not have an account?</small></p>
                <a class="btn btn-sm btn-white btn-block" href="register.aspx">Create an account</a>
            </form>
        </div>
    </div>

    <!-- Mainly scripts -->
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
