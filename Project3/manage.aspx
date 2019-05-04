<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="Project3.manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="layout.css" />
    <title>Management</title>
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
                    <li class="nav-item active">
                        <a class="nav-link" href="manage.aspx">Management <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="login.aspx">Login</a>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
    <!--Management-->
    <form id="frmManage" runat="server">
        <div class="d-flex justify-content-center">
            <h3>Management</h3>
        </div>
        <br />
        <div class="d-flex justify-content-center">
            <asp:Button ID="btnManageRestaurant" runat="server" Text="Manage Restaurant" Width="175px" OnClick="btnManageRestaurant_Click" />
        </div>
        <div class="d-flex justify-content-center">
            <asp:GridView ID="gvRestaurant" runat="server" AutoGenerateColumns="False" 
                OnRowEditing="gvRestaurant_RowEditing" OnRowCancelingEdit="gvRestaurant_RowCancelingEdit" OnRowUpdating="gvRestaurant_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="restaurant_id" HeaderText="ID" ReadOnly="true" />
                    <asp:BoundField DataField="restaurant_name" HeaderText="Restaurant" />
                    <asp:BoundField DataField="img_url" HeaderText="Image URL" />
                    <asp:BoundField DataField="cuisine" HeaderText="Category" ReadOnly="true" />
                    <asp:CommandField ButtonType="Button" HeaderText="Modify" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="d-flex justify-content-center">
            <asp:Button ID="btnManageReservation" runat="server" Text="Manage Reservation" Width="175px" OnClick="btnManageReservation_Click" />
        </div>
        <div class="d-flex justify-content-center">
            <asp:GridView ID="gvReservation" runat="server" AutoGenerateColumns="False" 
                OnRowEditing="gvReservation_RowEditing" OnRowCancelingEdit="gvReservation_RowCancelingEdit" OnRowUpdating="gvReservation_RowUpdating" OnRowDeleting="gvReservation_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="reserve_id" HeaderText="ID" ReadOnly="true" />
                    <asp:BoundField DataField="restaurant_name" HeaderText="Restaurant" ReadOnly="true" />
                    <asp:BoundField DataField="name" HeaderText="Person Name" />
                    <asp:BoundField DataField="date" HeaderText="Date" />
                    <asp:BoundField DataField="time" HeaderText="Time" />
                    <asp:BoundField DataField="table_size" HeaderText="Table Size" />
                    <asp:CommandField ButtonType="Button" HeaderText="Modify" ShowEditButton="True" />
                    <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="d-flex justify-content-center">
            <asp:Button ID="btnManageReview" runat="server" Text="Manage Review" Width="175px" OnClick="btnManageReview_Click" />
        </div>
        <div class="d-flex justify-content-center">
            <asp:GridView ID="gvReview" runat="server" AutoGenerateColumns="False" 
                OnRowEditing="gvReview_RowEditing" OnRowCancelingEdit="gvReview_RowCancelingEdit" OnRowUpdating="gvReview_RowUpdating" OnRowDeleting="gvReview_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="review_id" HeaderText="ID" ReadOnly="true" />
                    <asp:BoundField DataField="restaurant_name" HeaderText="Restaurant" ReadOnly="true" />
                    <asp:BoundField DataField="comment" HeaderText="Comment" />
                    <asp:BoundField DataField="rate_quality" HeaderText="Quality" />
                    <asp:BoundField DataField="rate_service" HeaderText="Service" />
                    <asp:BoundField DataField="rate_atmos" HeaderText="Atmosphere" />
                    <asp:BoundField DataField="rate_price" HeaderText="Price" />
                    <asp:CommandField ButtonType="Button" HeaderText="Edit Review" ShowEditButton="True" />
                    <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="d-flex justify-content-center">
            <asp:Label ID="lblDisplay" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
