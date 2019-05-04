using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Project3
{
    public partial class reservation : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*String sqlDisplay = "SELECT * FROM Category";
                lstCategory.DataSource = objDB.GetDataSet(sqlDisplay);
                lstCategory.DataBind();*/
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCategory_ListBox";
                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                lstCategory.DataSource = myDS;
                lstCategory.DataBind();
            }
        }

        protected void DisplayByCategory(String cuisine)
        {
            /*String sqlDisplayByCategory = "SELECT restaurant_name FROM Restaurant LEFT JOIN Category " +
                                            "ON Restaurant.category_id = Category.category_id WHERE cuisine = '" + cuisine + "'";
            lstRestaurant.DataSource = objDB.GetDataSet(sqlDisplayByCategory);
            lstRestaurant.DataBind();*/
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurant_ListBox";
            objCommand.Parameters.AddWithValue("@theCuisine", cuisine);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            lstRestaurant.DataSource = myDS;
            lstRestaurant.DataBind();
        }

        protected void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayByCategory(lstCategory.SelectedValue);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            int table = int.Parse(txtTable.Text);
            String date = txtMonth.Text + "-" + txtDay.Text + "-" + txtYear.Text;
            String time = txtHour.Text + ":" + txtMinute.Text + " " + txtAMPM.SelectedItem;
            String restaurant = lstRestaurant.SelectedValue.ToString();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantID";
            objCommand.Parameters.AddWithValue("@theRestaurant", restaurant);

            SqlParameter outputParameter = new SqlParameter("@theRestaurantID", 0);
            outputParameter.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(outputParameter);
            //Execute stored procedure
            objDB.GetDataSetUsingCmdObj(objCommand);
            int restaurant_id = int.Parse(objCommand.Parameters["@theRestaurantID"].Value.ToString());

            /*String sqlInsert = "INSERT INTO [Reservation] (restaurant_id, name, date, time, table_size) " +
                                "VALUES (" + restaurant_id + ", '" + name + "', '" + date + "', '" + time + "', " + table + ")";
            objDB.DoUpdate(sqlInsert);*/
            //Got "too many arguments" error without this line - Clear the collection
            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertReservation";
            objCommand.Parameters.AddWithValue("@theRestaurantID", restaurant_id);
            objCommand.Parameters.AddWithValue("@theName", name);
            objCommand.Parameters.AddWithValue("@theDate", date);
            objCommand.Parameters.AddWithValue("@theTime", time);
            objCommand.Parameters.AddWithValue("@theTable", table);
            objDB.GetDataSetUsingCmdObj(objCommand);

            lblDisplay.Text = "Your reservation was submitted succesfully!";
            txtName.Text = ""; txtTable.Text = ""; txtMonth.Text = ""; txtDay.Text = ""; txtYear.Text = ""; txtHour.Text = ""; txtMinute.Text = "";
            lstCategory.ClearSelection(); lstRestaurant.ClearSelection();
        }
    }
}