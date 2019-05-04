<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="review.aspx.cs" Inherits="Project3.review" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="layout.css" />
    <title>Revview</title>
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
                    <li class="nav-item active">
                        <a class="nav-link" href="review.aspx">Review <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="reservation.aspx">Reservation</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="manage.aspx">Management</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="login.aspx">Login</a>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
    <!--Review-->
    <div class="container">
        <div class="row">
            <!--Column-2-->
            <div class="col-md-2"></div>
            <!--Column-8-->
            <div class="col-md-8">
                <form id="frmReview" runat="server">
                    <div class="d-flex justify-content-center">
                        <h3>Add a New Review</h3>
                    </div>
                    <div class="d-flex justify-content-center">
                        <p>Select a category and a restaurant to write review</p>
                    </div>
                    <div class="d-flex justify-content-center">
                        <asp:ListBox class="form-control" ID="lstCategory" runat="server" DataTextField="cuisine" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="lstCategory_SelectedIndexChanged" required="true"></asp:ListBox>
                    </div>
                    <br />
                    <div class="d-flex justify-content-center">
                        <asp:ListBox class="form-control" ID="lstRestaurant" runat="server" DataTextField="restaurant_name" AutoPostBack="true" Width="200px" required="true"></asp:ListBox>
                    </div>
                    <br />
                    <div class="d-flex justify-content-center">
                        Restaurant not listed?&nbsp;<a href="restaurant.aspx">Add new</a>
                    </div>
                    <br />
                    <div class="d-flex justify-content-center">
                        <asp:Label ID="lblMessage" runat="server">Rate the restaurant from 1-5</asp:Label>
                    </div>
                    <br />
                    <div class="form-row">
                        <div class="form-group col-sm-2">
                            </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="lblQuality" runat="server">Quality:</asp:Label>
                            <asp:TextBox type="number" ID="txtQuality" runat="server" Width="30px" min="1" max="5" required="true"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="lblService" runat="server">Service:</asp:Label>
                            <asp:TextBox type="number" ID="txtService" runat="server" Width="30px" min="1" max="5" required="true"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:Label ID="lblAtmosphere" runat="server">Atmosphere:</asp:Label>
                            <asp:TextBox type="number" ID="txtAtmosphere" runat="server" Width="30px" min="1" max="5" required="true"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="lblPrice" runat="server">Price:</asp:Label>
                            <asp:TextBox type="number" ID="txtPrice" runat="server" Width="30px" min="1" max="5" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblComment" runat="server">Comment</asp:Label>
                        <asp:TextBox class="form-control" ID="txtComment" placeholder="Leave your comments here" runat="server" required="true"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit Review" OnClick="btnSubmit_Click"/>
                    <br />
                    <div class="d-flex justify-content-center">
                    <asp:Label ID="lblDispaly" runat="server"></asp:Label>
                    </div>
                </form>
            </div>
            <!--Column-2-->
            <div class="col-md-2"></div>
        </div>
    </div>
</body>
</html>
