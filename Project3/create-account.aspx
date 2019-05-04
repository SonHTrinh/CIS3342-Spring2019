<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create-account.aspx.cs" Inherits="Project3.create_account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="layout.css" />
    <title>Create an Account</title>
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
                    <li class="nav-item">
                        <a class="nav-link" href="login.aspx">Login <span class="sr-only"></span></a>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
    <br />
    <!--Create Account-->
    <form id="frmCreate" runat="server">
        <div class="d-flex justify-content-center">
            <h3>Create an account</h3>
        </div>
        <div class="d-flex justify-content-center">
            <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
            &nbsp;<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="btnCreateUser" runat="server" Text="Create User Account" OnClick="btnCreateUser_Click" />
            &nbsp;<asp:Button ID="btnCreateRep" runat="server" Text="Create Representative Account" OnClick="btnCreateRep_Click" />
        </div>
        <br />
        <div class="d-flex justify-content-center">
            <asp:Label ID="lblDisplay" runat="server"></asp:Label>
        </div>
        <div class="d-flex justify-content-center">
            <asp:Label ID="lblRedirect" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
