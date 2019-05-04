using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Collections;
using ClassLibrary;
using System.Drawing;           // required for using Color values

namespace Project2
{
    public partial class book : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        ArrayList arrBooks = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String sqlSelect = "SELECT * FROM Books";
                gvBooks.DataSource = objDB.GetDataSet(sqlSelect);
                String[] price = new string[1];
                price[0] = "BasePrice";
                gvBooks.DataKeyNames = price;
                gvBooks.Columns[4].Visible = false;
                gvBooks.DataBind();
            }
        }

        public void ShowConfirm()
        {
            gvConfirm.DataSource = arrBooks;
            gvConfirm.DataBind();

            int totalQty = 0;
            double totalCost = 0;
            for (int i = 0; i < gvConfirm.Rows.Count; i++)
            {
                totalQty = totalQty + int.Parse(gvConfirm.Rows[i].Cells[5].Text);
                totalCost = totalCost + double.Parse(gvConfirm.Rows[i].Cells[6].Text, System.Globalization.NumberStyles.Currency);
            }
            // Put the values into the corresponding footer column
            gvConfirm.Columns[0].FooterText = "Totals:";
            gvConfirm.Columns[5].FooterText = totalQty.ToString();
            gvConfirm.Columns[6].FooterText = totalCost.ToString("C2");     // C2 formats as currency
            gvConfirm.Columns[0].FooterStyle.ForeColor = Color.Red;
            gvConfirm.Columns[5].FooterStyle.ForeColor = Color.Red;
            gvConfirm.Columns[6].FooterStyle.ForeColor = Color.Red;
            // Re-Bind the GridView with the changes made to the footer
            gvConfirm.DataBind();
        }

        public void ShowManagement()
        {
            String sqlSelect = "SELECT Title, TotalSales, TotalQuantityRented, TotalQuantitySold " +
                                 "FROM Books ORDER BY TotalSales DESC";
            gvManagement.DataSource = objDB.GetDataSet(sqlSelect);
            gvManagement.DataBind();
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String id = txtID.Text;
            String address = txtAddress.Text;
            String phone = txtPhone.Text;
            String campus = ddlCampus.Text;

            // Display student information
            String studentInfo = "";
            studentInfo = "<h3>Order Confirmation </h3>" + "Name: " + name + "<br /> ID: " + id + "<br />Address: " + address + "<br />Phone: " + phone + "<br />Campus: " + campus;
            lblInfo.Text = studentInfo;
            // Hide order table and place order button
            gvBooks.Visible = false;
            btnOrder.Visible = false;
            // Display order confirmation table and management report button and make new order button
            gvConfirm.Visible = true;
            btnReport.Visible = true;
            btnNew.Visible = true;

            DropDownList ddlType;
            DropDownList ddlRentBuy;
            TextBox quantity;
            BookLibrary objBook;

            for (int row = 0; row < gvBooks.Rows.Count; row++)
            {
                double price = Convert.ToDouble(gvBooks.DataKeys[row].Value);
                ddlType = (DropDownList)gvBooks.Rows[row].FindControl("ddlType");
                ddlRentBuy = (DropDownList)gvBooks.Rows[row].FindControl("ddlRentBuy");
                quantity = (TextBox)gvBooks.Rows[row].FindControl("txtQuantity");

                // price conditions for different book types and buy/rent
                if (ddlRentBuy.SelectedValue.ToString() == "buy" && ddlType.SelectedValue.ToString() == "paper_back")
                {
                    price = price * 1;
                }
                else if (ddlRentBuy.SelectedValue.ToString() == "buy" && ddlType.SelectedValue.ToString() == "hard_cover")
                {
                    price = price * 1.5;
                }
                else if (ddlRentBuy.SelectedValue.ToString() == "buy" && ddlType.SelectedValue.ToString() == "e_book")
                {
                    price = price * 0.5;
                }
                else if (ddlRentBuy.SelectedValue.ToString() == "rent" && ddlType.SelectedValue.ToString() == "paper_back")
                {
                    price = price * 0.5;
                }
                else if (ddlRentBuy.SelectedValue.ToString() == "rent" && ddlType.SelectedValue.ToString() == "hard_cover")
                {
                    price = price * 1;
                }
                else if (ddlRentBuy.SelectedValue.ToString() == "rent" && ddlType.SelectedValue.ToString() == "e_book")
                {
                    price = price * 0.25;
                }

                int rentQty = 0;
                int buyQty = 0;

                CheckBox cbox = (CheckBox)gvBooks.Rows[row].FindControl("chkSelect");
                if (cbox.Checked)
                {
                    objBook = new BookLibrary();
                    objBook.ISBN = gvBooks.Rows[row].Cells[3].Text;
                    objBook.Title = gvBooks.Rows[row].Cells[1].Text;
                    objBook.BookType = ddlType.SelectedValue.ToString();
                    objBook.BuyRent = ddlRentBuy.SelectedValue.ToString();
                    objBook.Price = price;
                    objBook.Quantity = Convert.ToInt32(quantity.Text.ToString());
                    objBook.TotalCost = price * Convert.ToInt32(quantity.Text.ToString());
                    arrBooks.Add(objBook);
                    
                    if (objBook.BuyRent == "rent")
                    {
                        rentQty = rentQty + objBook.Quantity;
                    }
                    else if (objBook.BuyRent == "buy")
                    {
                        buyQty = buyQty + objBook.Quantity;
                    }
                    String sqlUpdate = "UPDATE Books SET TotalSales = TotalSales + " + objBook.TotalCost + ", " +
                                    "TotalQuantityRented = TotalQuantityRented + " + rentQty + ", " +
                                    "TotalQuantitySold = TotalQuantitySold + " + buyQty + " WHERE Title = '" + objBook.Title + "'";
                    objDB.DoUpdate(sqlUpdate);
                }
                //else if (!cbox.Checked)
                //{
                    //lblDisplay.Text = "Please select a book!";
                //}
            }
            ShowConfirm();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            ShowManagement();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("book.aspx");
        }
    }

}