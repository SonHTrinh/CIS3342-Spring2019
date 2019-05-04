<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="book.aspx.cs" Inherits="Project2.book" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Store</title>
    <link rel="stylesheet" type="text/css" href="layout.css" />
    <script lang="javascript" type="text/javascript" src="validate.js"></script>
</head>
<body>
    <header>
        <h1>Temple University Book Store</h1>
        <a href="http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/">Home Page</a>
    </header>
    <form id="frmBookStore" runat="server">
        <div>
            <h3>Enter information: </h3>
            <!-- Student information -->
            <asp:Label ID="lblName" runat="server" Text="Full Name:"></asp:Label> <br />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox> <br />
            <asp:Label ID="lblID" runat="server" Text="Student TUid:"></asp:Label> <br />
            <asp:TextBox type="number" ID="txtID" runat="server" placeholder="9xxxxxxxx" maxlength="9" 
                oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"></asp:TextBox> <br />
            <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label> <br />
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox> <br />
            <asp:Label ID="lblPhone" runat="server" Text="Phone Number:"></asp:Label> <br />
            <asp:TextBox type="number" ID="txtPhone" runat="server" maxlength="10" 
                oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"></asp:TextBox> <br />
            <asp:Label ID="lblCampus" runat="server" Text="Campus:"></asp:Label> <br />
            <asp:DropDownList ID="ddlCampus" runat="server">
                <asp:ListItem Enabled="true" Text="Select Campus" Value="-1"></asp:ListItem>
                <asp:ListItem Text="Main" Value="main"></asp:ListItem>
                <asp:ListItem Text="TUCC" Value="tucc"></asp:ListItem>
                <asp:ListItem Text="Ambler" Value="ambler"></asp:ListItem>
                <asp:ListItem Text="Tokyo - Japan"  Value="tokyo"></asp:ListItem>
                <asp:ListItem Text="Rome - Italy" Value="rome"></asp:ListItem>
            </asp:DropDownList>  
            <br /> <br />
            <!-- Generate Order Grid View -->
            <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" name="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Authors" HeaderText="Authors" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="BasePrice" HeaderText="Base Pride" />
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlType" runat="server">
                                <asp:ListItem Enabled="true" Text="Paper-back" Value="paper_back" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Hardcover" Value="hard_cover"></asp:ListItem>
                                <asp:ListItem Text="E-book" Value="e_book"></asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Buy/Rent">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlRentBuy" runat="server">
                                <asp:ListItem Value="buy" Selected="True">Buy</asp:ListItem>
                                <asp:ListItem Value="rent">Rent</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity" >
                        <ItemTemplate>
                            <asp:TextBox type="number" ID="txtQuantity" runat="server" Width="50px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView> 
            <br />
        </div>
        <!-- Place Order button -->
        <div class="button">
            <asp:Button ID="btnOrder" Text="Place Order" OnClientClick="return Validate();" runat="server" OnClick="btnOrder_Click" /> <br />
            <asp:Label ID="lblDisplay" runat="server" ForeColor="#CC3300"></asp:Label> 
        </div>
        <div class="button">
            <asp:Button ID="btnNew" runat="server" Text="Make New Order" OnClick="btnNew_Click" Visible="False" /> <br />
        </div>
        <!-- Generate Order Comfirmation Grid View -->
        <div class="confirmation">
            <asp:Label ID="lblInfo" runat="server"></asp:Label>
            <asp:GridView ID="gvConfirm" runat="server" AutoGenerateColumns="False" Visible="False" ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField HeaderText="Type" DataField="BookType" />
                    <asp:BoundField HeaderText="Buy/Rent" DataField="BuyRent" />
                    <asp:BoundField DataField="Price" DataFormatString="{0:$###,##0.00}" HeaderText="Price" />
                    <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                    <asp:BoundField HeaderText="Total Cost" DataFormatString="{0:$###,##0.00}" DataField="TotalCost" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
        <!-- Place Management Report button -->
        <div class="button">
            <asp:Button ID="btnReport" Text="Management Report" runat="server" Visible="False" OnClick="btnReport_Click" /> <br /> <br />
        </div>
        <!-- Generate Management Report Grid View -->
        <div class="management">
            <asp:GridView ID="gvManagement" runat="server" AutoGenerateColumns="False" OnRowUpdating="btnReport_Click">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="TotalSales" DataFormatString="{0:$###,##0.00}" HeaderText="Total Sales" />
                    <asp:BoundField DataField="TotalQuantityRented" HeaderText="Qty Rented" />
                    <asp:BoundField DataField="TotalQuantitySold" HeaderText="Qty Sold" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
    </form>
    <footer>
        <p>CIS 3342 - Project 2</p>
        <p>Son Trinh - Information Science & Technology B.S.</p>
    </footer>
</body>
</html>
