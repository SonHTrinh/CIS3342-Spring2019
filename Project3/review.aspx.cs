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
    public partial class review : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCategory_ListBox";
                DataSet CategoryDS = objDB.GetDataSetUsingCmdObj(objCommand);
                lstCategory.DataSource = CategoryDS;
                lstCategory.DataBind();
            }
        }

        protected void DisplayByCategory(String cuisine)
        {
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
            if (Session["userType"] == null)
            {
                lblDispaly.Text = "Please <a href='login.aspx'>Login</a> as 'Reviewer' to be able to submit a review!";
            }
            else if (Session["userType"].ToString() == "reviewer")
            { 
                String comment = txtComment.Text;
                int quality = int.Parse(txtQuality.Text);
                int service = int.Parse(txtService.Text);
                int atmosphere = int.Parse(txtAtmosphere.Text);
                int price = int.Parse(txtPrice.Text);
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

                //Got "too many arguments" error without this line - Clear the collection
                objCommand.Parameters.Clear();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetUserID";
                objCommand.Parameters.AddWithValue("@theName", Session["name"].ToString());

                SqlParameter outputName = new SqlParameter("@theUserID", 0);
                outputName.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(outputName);
                //Execute stored procedure
                objDB.GetDataSetUsingCmdObj(objCommand);
                int user_id = int.Parse(objCommand.Parameters["@theUserID"].Value.ToString());

                //Got "too many arguments" error without this line - Clear the collection
                objCommand.Parameters.Clear();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "InsertReview";
                objCommand.Parameters.AddWithValue("@theComment", comment);
                objCommand.Parameters.AddWithValue("@theQuality", quality);
                objCommand.Parameters.AddWithValue("@theService", service);
                objCommand.Parameters.AddWithValue("@theAtmosphere", atmosphere);
                objCommand.Parameters.AddWithValue("@thePrice", price);
                objCommand.Parameters.AddWithValue("@theRestaurantID", restaurant_id);
                objCommand.Parameters.AddWithValue("@theUserID", user_id);
                objDB.GetDataSetUsingCmdObj(objCommand);

                txtComment.Text = ""; txtQuality.Text = ""; txtService.Text = ""; txtAtmosphere.Text = ""; txtPrice.Text = "";
                lstCategory.ClearSelection(); lstRestaurant.ClearSelection();
                lblDispaly.Text = "Thank you " + "<b>" + Session["name"].ToString() + "</b>" + " for submitting the review!";
            }
            else
            {
                lblDispaly.Text = "Please <a href='login.aspx'>Login</a> as 'Reviewer' to be able to submit a review!";
            }
        }
    }
}