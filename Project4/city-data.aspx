<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="city-data.aspx.cs" Inherits="Project4.city_data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <title>City Data</title>
</head>
<body style="background-color: #D0FEB6;">
    <form id="frmCity" runat="server">
        <div class="container">
            <div style="text-align: center;">
                <h1>CIS 3342 - Project 4</h1>
                <h3>City Data Provider Web API</h3>
                <a href="http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/">Home Page</a>
                <hr />
            </div>
            <div class="row">
                <!--Add City Column-->
                <div class="col-md-6">
                    <h3>Add New City</h3>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                            <asp:TextBox ID="txtCity" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                            <asp:TextBox ID="txtState" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="lblPopulation" runat="server" Text="Population"></asp:Label>
                            <asp:TextBox type="number" ID="txtPopulation" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblIncome" runat="server" Text="Median Household Income"></asp:Label>
                            <asp:TextBox type="number" ID="txtIncome" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="lblPercentOwn" runat="server" Text="Percentage of House Owners"></asp:Label>
                            <asp:TextBox type="number" step="0.01" ID="txtPercentOwn" class="form-control" runat="server" min="0" max="100"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblPercentRent" runat="server" Text="Percentage of House Renters"></asp:Label>
                            <asp:TextBox type="number" step="0.01" ID="txtPercentRent" class="form-control" runat="server" min="0" max="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="lblHomeValue" runat="server" Text="Median Home Value"></asp:Label>
                            <asp:TextBox type="number" ID="txtHomeValue" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="lblAgeMale" runat="server" Text="Median Age of Male"></asp:Label>
                            <asp:TextBox type="number" ID="txtAgeMale" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblAgeFemale" runat="server" Text="Median Age of Female"></asp:Label>
                            <asp:TextBox type="number" ID="txtAgeFemale" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="lblUnemployment" runat="server" Text="Unemployment Rate"></asp:Label>
                            <asp:TextBox type="number" step="0.01" ID="txtUnemployment" class="form-control" runat="server" min="0" max="100"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblCrime" runat="server" Text="Crime Rate"></asp:Label>
                            <asp:TextBox type="number" step="0.01" ID="txtCrime" class="form-control" runat="server" min="0" max="100"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" Text="Add City" OnClick="btnAdd_Click" />
                    <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
                </div>
                <!--Find City Column-->
                <div class="col-md-6">
                    <h3>Find City By</h3>
                    <asp:Label ID="lblFindCity" runat="server" Text="Search By"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlFindCity" class="form-control" runat="server" AutoPostBack="true">
                        <asp:ListItem Text="Show All" Value="all" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="City" Value="city"></asp:ListItem>
                        <asp:ListItem Text="State" Value="state"></asp:ListItem>
                        <asp:ListItem Text="Population" Value="population"></asp:ListItem>
                        <asp:ListItem Text="Median Household Income" Value="income"></asp:ListItem>
                        <asp:ListItem Text="Unemployment Rate" Value="unemployment"></asp:ListItem>
                        <asp:ListItem Text="Crime Rate" Value="crime"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <!---->
                    <div id="findCity" runat="server" visible="false">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblFindCityName" runat="server" Text="City"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtFindCityName" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <!---->
                    <div id="findState" runat="server" visible="false">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblFindState" runat="server" Text="State"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtFindState" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <!---->
                    <div id="findPopulation" runat="server" visible="false">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblFintPopulation" runat="server" Text="Population"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlPopulation" class="form-control" runat="server" AutoPostBack="true">
                                    <asp:ListItem Text="Greater than" Value="greater" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Less than" Value="less"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-5">
                                <asp:TextBox type="number" ID="txtFindPopulation" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <!---->
                    <div id="findIncome" runat="server" visible="false">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblFindIncome" runat="server" Text="Income $"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlIncome" class="form-control" runat="server" AutoPostBack="true">
                                    <asp:ListItem Text="Greater than" Value="greater" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Less than" Value="less"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-5">
                                <asp:TextBox type="number" ID="txtFindIncome" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <!---->
                    <div id="findUnemployment" runat="server" visible="false">
                        <div class="row">
                            <div class="col-md-7">
                                <asp:Label ID="lblFindUnemployment" runat="server" Text="Unemployment rate LESS THAN %"></asp:Label>
                            </div>
                            <div class="col-md-5">
                                <asp:TextBox type="number" step="0.01" ID="txtFindUnemployment" class="form-control" runat="server" min="0" max="100"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <!---->
                    <div id="findCrime" runat="server" visible="false">
                        <div class="row">
                            <div class="col-md-7">
                                <asp:Label ID="lblFindCrime" runat="server" Text="Crime rate LESS THAN %"></asp:Label>
                            </div>
                            <div class="col-md-5">
                                <asp:TextBox type="number" step="0.01" ID="txtFindCrime" class="form-control" runat="server" min="0" max="100"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <asp:Button ID="btnFind" class="btn btn-info" runat="server" Text="Find City" OnClick="btnFind_Click" />
                    <asp:Label ID="lblFind" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <br />
            <!--Table for repeater-->
            <table class="table table-light table-bordered">
                <thead class="thead-dark">
                <tr>
                    <th>City</th>
                    <th>State</th>
                    <th>Population</th>
                    <th>Median Household Income</th>
                    <th>Percentage of Owners</th>
                    <th>Percentage of Renters</th>
                    <th>Median Home Value</th>
                    <th>Median Age of Male</th>
                    <th>Median Age of Female</th>
                    <th>Unemployment Rate</th>
                    <th>Crime Rate</th>
                </tr>
                    </thead>
                <asp:Repeater ID="rptCity" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "city_name") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "state") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "population", "{0:N0}") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "income", "{0:c0}") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "percent_own", "{0:N}")+"%" %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "percent_rent", "{0:N}")+"%" %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "home_value", "{0:c0}") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "age_male") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "age_female") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "unemployment", "{0:N}")+"%" %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "crime", "{0:N}")+"%" %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
