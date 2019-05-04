<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Project3.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="layout.css" />
    <title>Login</title>
</head>
<body>
    <!--Navigation-->
    <div class="container">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark rounded">
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExample10" aria-controls="navbarsExample10" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse justify-content-md-center" id="navbarsExample10">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/">Home Page</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="restaurant.aspx">Restaurant</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="review.aspx">Review</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="reservation.aspx">Reservation</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="manage.aspx">Management</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="login.aspx">Login <span class="sr-only">(current)</span></a>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
    <!--Login-->
    <form id="frmLogin" runat="server">
        <div class="d-flex justify-content-center">
            <h3>Login</h3>
        </div>
        <div class="d-flex justify-content-center">
            <asp:Label ID="lblUserType" runat="server" Text="User Type: "></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlUserType" runat="server">
                <asp:ListItem Selected="True" Value="false">--Select--</asp:ListItem>
                <asp:ListItem Value="reviewer">Reviewer</asp:ListItem>
                <asp:ListItem Value="representative">Representative</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
            &nbsp;<asp:TextBox ID="txtName" required="true" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
        <br />
        <div class="d-flex justify-content-center">
            Do not have an account?&nbsp;
            <a href="create-account.aspx">Create an account</a>
        </div>
        <br />
        <div class="d-flex justify-content-center">
            <asp:Label ID="lblMessage" runat="server" Visible="False">You have succesfully logged in as: </asp:Label>&nbsp;
            <asp:Label ID="lblDisplay" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
