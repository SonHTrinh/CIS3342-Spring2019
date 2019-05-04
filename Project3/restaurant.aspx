<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="restaurant.aspx.cs" Inherits="Project3.restaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="layout.css" />
    <title>Restaurant</title>
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
                    <li class="nav-item active">
                        <a class="nav-link" href="restaurant.aspx">Restaurant <span class="sr-only">(current)</span></a>
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
                        <a class="nav-link" href="login.aspx">Login</a>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
    <!--Restaurant-->
    <div class="container">
        <div class="row">
            <!--Column-2-->
            <div class="col-md-2"></div>
            <!--Column-8-->
            <div class="col-md-8">
                <form id="frmRestaurant" runat="server">
                    <div class="d-flex justify-content-center">
                        <h3>Add a New Restaurant</h3>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <asp:Label ID="lblName" runat="server">Restaurant</asp:Label>
                            <asp:TextBox class="form-control" ID="txtName" runat="server" placeholder="Restaurant Name"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="lblURL" runat="server">Image URL</asp:Label>
                            <asp:TextBox class="form-control" ID="txtURL" runat="server" placeholder="Image URL"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <asp:Label ID="lblCategory" runat="server">Cuisines</asp:Label>
                            <asp:DropDownList class="form-control" ID="ddlCategory" runat="server" DataTextField="cuisine">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="lblRepresentative" runat="server">Representative</asp:Label>
                            <asp:DropDownList class="form-control" ID="ddlRepresentative" runat="server" DataTextField="rep_name">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Restaurant" OnClick="btnAdd_Click" />
                    <div class="d-flex justify-content-center">
                        <asp:Label ID="lblDisplay" runat="server"></asp:Label>
                        <br />
                    </div>
                    <div class="d-flex justify-content-center">
                        <h3>Restaurant List</h3>
                    </div>
                    <div class="d-flex justify-content-center">
                        <asp:ListBox class="form-control" ID="lstCategory" runat="server" DataTextField="cuisine" AutoPostBack="True"
                            SelectionMode="Multiple" Width="200px"></asp:ListBox>
                    </div>
                    <div class="d-flex justify-content-center">
                        <asp:Button ID="btnDisplayByCategory" runat="server" Text="Display By Category" Width="200px" OnClick="btnDisplayByCategory_Click" />
                    </div>
                    <div class="d-flex justify-content-center">
                        <asp:Button ID="btnDisplayAll" runat="server" Text="Display All" OnClick="btnDisplayAll_Click" Width="200px" />
                    </div>
                    <br />
                    <!--<div class="d-flex justify-content-center">-->
                        <asp:GridView ID="gvRestaurant" runat="server" AutoGenerateColumns="False" OnRowCommand="gvRestaurant_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="restaurant_id" HeaderText="ID" />
                                <asp:BoundField DataField="restaurant_name" HeaderText="Restaurant" />
                                <asp:BoundField DataField="cuisine" HeaderText="Category" />
                                <asp:BoundField DataField="img_url" HeaderText="Image" />
                                <asp:ButtonField ButtonType="Button" Text="View Review" CommandName="ViewReview"/>
                            </Columns>
                        </asp:GridView>
                    <!--</div>-->
                    <br />
                    <div class="d-flex justify-content-center">
                        <asp:Label ID="lblReview" runat="server"></asp:Label>
                    </div>
                    <div class="d-flex justify-content-center">
                        <asp:GridView ID="gvReview" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="review_id" HeaderText="Review ID" />
                                <asp:BoundField DataField="user_name" HeaderText="Reviewer" />
                                <asp:BoundField DataField="comment" HeaderText="Comment" />
                                <asp:BoundField DataField="rate_quality" HeaderText="Quality" />
                                <asp:BoundField DataField="rate_service" HeaderText="Service" />
                                <asp:BoundField DataField="rate_atmos" HeaderText="Atmosphere" />
                                <asp:BoundField DataField="rate_price" HeaderText="Price" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </form>
            </div>
            <!--Column-2-->
            <div class="col-md-2"></div>
        </div>
    </div>
</body>
</html>
