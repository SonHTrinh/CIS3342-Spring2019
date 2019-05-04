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
    public partial class restaurant : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //drop down list of cuisine
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCategory_ListBox";
                DataSet CategoryDS = objDB.GetDataSetUsingCmdObj(objCommand);
                //String sqlCategory = "SELECT * FROM Category";
                ddlCategory.DataSource = CategoryDS;
                ddlCategory.DataBind();

                //drop down list of representative that has not got assigned a restaurant
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetRepresentative_ListBox";
                DataSet RepresentativeDS = objDB.GetDataSetUsingCmdObj(objCommand);
                //String sqlRepresentative = "SELECT * FROM Representative WHERE Representative.restaurant_id = NULL";
                ddlRepresentative.DataSource = RepresentativeDS;
                ddlRepresentative.DataBind();

                //list box of cuisine
                lstCategory.DataSource = CategoryDS;
                lstCategory.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String url = txtURL.Text;
            String category = ddlCategory.SelectedValue;
            String representative = ddlRepresentative.SelectedValue;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetCategoryID";
            objCommand.Parameters.AddWithValue("@theCuisine", category);
            SqlParameter outputParameter = new SqlParameter("@theCategoryID", 0);
            outputParameter.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(outputParameter);
            //Execute stored procedure
            objDB.GetDataSetUsingCmdObj(objCommand);
            int category_id = int.Parse(objCommand.Parameters["@theCategoryID"].Value.ToString());

            //Got "too many arguments" error without this line - Clear the collection
            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertRestaurant";
            objCommand.Parameters.AddWithValue("@theRestaurant", name);
            objCommand.Parameters.AddWithValue("@theURL", url);
            objCommand.Parameters.AddWithValue("@theID", category_id);
            objDB.GetDataSetUsingCmdObj(objCommand);

            //Got "too many arguments" error without this line - Clear the collection
            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantID";
            objCommand.Parameters.AddWithValue("@theRestaurant", name);
            SqlParameter outputID = new SqlParameter("@theRestaurantID", 0);
            outputID.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(outputID);
            //Execute stored procedure
            objDB.GetDataSetUsingCmdObj(objCommand);
            int restaurant_id = int.Parse(objCommand.Parameters["@theRestaurantID"].Value.ToString());
            
            //Got "too many arguments" error without this line - Clear the collection
            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateRepresentative_RestaurantID";
            objCommand.Parameters.AddWithValue("@theID", restaurant_id);
            objCommand.Parameters.AddWithValue("@theName", representative);
            objDB.DoUpdateUsingCmdObj(objCommand);

            lblDisplay.Text = "Restaurant <b>" + name + "</b> was added";
            Response.AddHeader("REFRESH", "3;URL=restaurant.aspx");
        }
        
        protected void btnDisplayByCategory_Click(object sender, EventArgs e)
        {
            DataSet myDS = null, tempDS = null;
            Boolean atleastOneItemFound = false;
            String sqlDisplayByCategory = "";

            for (int i = 0; i < lstCategory.Items.Count; i++)
            {
                if (lstCategory.Items[i].Selected)

                {
                    String cuisine = lstCategory.Items[i].Value;
                    sqlDisplayByCategory = "SELECT restaurant_id, restaurant_name, cuisine, img_url FROM Restaurant LEFT JOIN Category " +
                                            "ON Restaurant.category_id = Category.category_id WHERE cuisine = '" + cuisine + "'";
                    tempDS = objDB.GetDataSet(sqlDisplayByCategory);
                    // Merge the dataset data when more than one item is selected
                    if (atleastOneItemFound == false)
                    {
                        myDS = tempDS;
                        atleastOneItemFound = true;
                    }
                    else
                    {
                        // More than one item was found
                        // Merge datasets
                        myDS.Merge(tempDS);
                    }
                }
            }
            gvRestaurant.DataSource = myDS;
            gvRestaurant.DataBind();
        }

        protected void btnDisplayAll_Click(object sender, EventArgs e)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAllRestaurant";
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            gvRestaurant.DataSource = myDS;
            gvRestaurant.DataBind();
        }

        protected void gvRestaurant_RowCommand(Object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            String restaurant = gvRestaurant.Rows[rowIndex].Cells[1].Text;
            int restaurant_id = int.Parse(gvRestaurant.Rows[rowIndex].Cells[0].Text);

            if (e.CommandName == "ViewReview")
            {
                String sqlReview = "SELECT review_id, user_name, comment, rate_quality, rate_service, rate_atmos, rate_price FROM Review " +
                                   "LEFT JOIN [User] ON Review.user_id = [User].user_id WHERE restaurant_id = " + restaurant_id;
                gvReview.DataSource = objDB.GetDataSet(sqlReview);
                gvReview.DataBind();
                lblReview.Text = "Review for restaurant: " + "<b>" + restaurant + "</b>";
            }
        }
    }
}