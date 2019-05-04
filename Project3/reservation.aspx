<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reservation.aspx.cs" Inherits="Project3.reservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="layout.css" />
    <title>Reservation</title>
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
                    <li class="nav-item active">
                        <a class="nav-link" href="reservation.aspx">Reservation <span class="sr-only">(current)</span></a>
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
    <!--Reservation-->
    <div class="container">
        <div class="row">
            <!--Column-2-->
            <div class="col-md-2"></div>
            <!--Column-8-->
            <div class="col-md-8">
                <form id="frmReservation" runat="server">
                    <div class="d-flex justify-content-center">
                        <h3>Make a reservation</h3>
                    </div>
                    <div class="d-flex justify-content-center">
                        <p>Select a category and a restaurant</p>
                    </div>
                    <div class="d-flex justify-content-center">
                        <asp:ListBox class="form-control" ID="lstCategory" runat="server" DataTextField="cuisine" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="lstCategory_SelectedIndexChanged" required="true"></asp:ListBox>
                    </div>
                    <br />
                    <div class="d-flex justify-content-center">
                        <asp:ListBox class="form-control" ID="lstRestaurant" runat="server" DataTextField="restaurant_name" AutoPostBack="true" Width="200px" required="true"></asp:ListBox>
                    </div>
                    <br />
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <asp:Label ID="lblName" runat="server">Name:</asp:Label>
                            <asp:TextBox class="form-control" ID="txtName" runat="server" required="true" placeholder="first name & last name"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="lblTable" runat="server">Table size:</asp:Label>
                            <asp:TextBox class="form-control" type="number" ID="txtTable" runat="server" min="2" max="12" required="true" placeholder="2 - 12"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-2">
                            <asp:Label ID="lblDate" runat="server">Date:</asp:Label>
                            <asp:TextBox type="number" class="form-control" ID="txtMonth" runat="server" min="1" max="12" required="true" placeholder="month"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Label ID="lblEmpty1" runat="server">.</asp:Label>
                            <asp:TextBox type="number" class="form-control" ID="txtDay" runat="server" min="1" max="31" required="true" placeholder="day"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Label ID="lblEmpty2" runat="server">.</asp:Label>
                            <asp:TextBox type="number" class="form-control" ID="txtYear" runat="server" min="2019" max="2020" required="true" placeholder="year"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Label ID="lblTime" runat="server">Time:</asp:Label>
                            <asp:TextBox type="number" class="form-control" ID="txtHour" runat="server" min="00" max="12" required="true" placeholder="00"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Label ID="lblEmpty3" runat="server">.</asp:Label>
                            <asp:TextBox type="number" class="form-control" ID="txtMinute" runat="server" min="00" max="59" required="true" placeholder="00"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Label ID="lblEmpty4" runat="server">.</asp:Label>
                            <asp:DropDownList class="form-control" ID="txtAMPM" runat="server" required="true">
                                <asp:ListItem Value="am">AM</asp:ListItem>
                                <asp:ListItem Value="pm">PM</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit Reservation" OnClick="btnSubmit_Click"/>
                    <br />
                    <div class="d-flex justify-content-center">
                        <asp:Label ID="lblDisplay" runat="server"></asp:Label>
                    </div>
                </form>
            </div>
            <!--Column-2-->
            <div class="col-md-2"></div>
        </div>
    </div>
</body>
</html>
