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
    public partial class manage : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ShowRestaurant()
        {
            //Got "too many arguments" error without this line - Clear the collection
            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantID_From_Representative";
            objCommand.Parameters.AddWithValue("@theRepresentative", Session["name"].ToString());
            SqlParameter outputName = new SqlParameter("@theID", 0);
            outputName.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(outputName);
            //Execute stored procedure
            objDB.GetDataSetUsingCmdObj(objCommand);
            int restaurant_id = int.Parse(objCommand.Parameters["@theID"].Value.ToString());

            //Got "too many arguments" error without this line - Clear the collection
            objCommand.Parameters.Clear();

            // Set the SQLCommand object's properties for executing a Stored Procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurant_GV";     // identify the name of the stored procedure to execute
                                                             // Execute the stored procedure using the DBConnect object and the SQLCommand object
            objCommand.Parameters.AddWithValue("@theID", restaurant_id);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            gvRestaurant.DataSource = myDS;
            gvRestaurant.DataBind();
        }

        protected void ShowReservation()
        {
            //Got "too many arguments" error without this line - Clear the collection
            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantID_From_Representative";
            objCommand.Parameters.AddWithValue("@theRepresentative", Session["name"].ToString());
            SqlParameter outputName = new SqlParameter("@theID", 0);
            outputName.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(outputName);
            //Execute stored procedure
            objDB.GetDataSetUsingCmdObj(objCommand);
            int restaurant_id = int.Parse(objCommand.Parameters["@theID"].Value.ToString());

            //Got "too many arguments" error without this line - Clear the collection
            objCommand.Parameters.Clear();

            // Set the SQLCommand object's properties for executing a Stored Procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReservation_GV";     // identify the name of the stored procedure to execute
                                                              // Execute the stored procedure using the DBConnect object and the SQLCommand object
            objCommand.Parameters.AddWithValue("@theID", restaurant_id);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            gvReservation.DataSource = myDS;
            gvReservation.DataBind();
        }

        protected void ShowReview()
        {
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

            // Set the SQLCommand object's properties for executing a Stored Procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReview_GV";     // identify the name of the stored procedure to execute
                                                         // Execute the stored procedure using the DBConnect object and the SQLCommand object
            objCommand.Parameters.AddWithValue("@theID", user_id);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            gvReview.DataSource = myDS;
            gvReview.DataBind();
        }

        protected void btnManageRestaurant_Click(object sender, EventArgs e)
        {
            if (Session["userType"] == null)
            {
                lblDisplay.Text = "Please <a href='login.aspx'>Login</a> as 'Representative' in order to Manage Restaurant!";
            }
            else if (Session["userType"].ToString() == "representative")
            {
                ShowRestaurant();
                lblDisplay.Text = "";
            }
            else
            {
                lblDisplay.Text = "Please <a href='login.aspx'>Login</a> as 'Representative' in order to Manage Restaurant!";
            }

        }
        
        protected void btnManageReservation_Click(object sender, EventArgs e)
        {
            if (Session["userType"] == null)
            {
                lblDisplay.Text = "Please <a href='login.aspx'>Login</a> as 'Representative' in order to Manage Reservation!";
            }
            else if (Session["userType"].ToString() == "representative")
            {
                ShowReservation();
                lblDisplay.Text = "";
            }
            else
            {
                lblDisplay.Text = "Please <a href='login.aspx'>Login</a> as 'Representative' in order to Manage Reservation!";
            }
        }

        protected void btnManageReview_Click(object sender, EventArgs e)
        {
            if (Session["userType"] == null)
            {
                lblDisplay.Text = "Please <a href='login.aspx'>Login</a> as 'Representative' in order to Manage Review!";
            }
            else if (Session["userType"].ToString() == "reviewer")
            {
                ShowReview();
                lblDisplay.Text = "";
            }
            else
            {
                lblDisplay.Text = "Please <a href='login.aspx'>Login</a> as 'Representative' in order to Manage Review!";
            }
        }

        protected void gvRestaurant_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            // Set the row to edit-mode in the GridView
            gvRestaurant.EditIndex = e.NewEditIndex;
            ShowRestaurant();
        }

        protected void gvRestaurant_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int id = int.Parse(gvRestaurant.Rows[rowIndex].Cells[0].Text);
            TextBox TBox;
            TBox = (TextBox)gvRestaurant.Rows[rowIndex].Cells[1].Controls[0];
            String name = TBox.Text;
            TBox = (TextBox)gvRestaurant.Rows[rowIndex].Cells[2].Controls[0];
            String url = TBox.Text;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateRestaurant";
            objCommand.Parameters.AddWithValue("@theName", name);
            objCommand.Parameters.AddWithValue("@theURL", url);
            objCommand.Parameters.AddWithValue("@theID", id);
            objDB.DoUpdateUsingCmdObj(objCommand);

            gvRestaurant.EditIndex = -1;
            ShowRestaurant();
        }

        protected void gvRestaurant_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            // Set the GridView back to the original state
            // No rows currently being edited
            gvRestaurant.EditIndex = -1;
            ShowRestaurant();
        }

        protected void gvReservation_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            // Set the row to edit-mode in the GridView
            gvReservation.EditIndex = e.NewEditIndex;
            ShowReservation();
        }

        protected void gvReservation_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int id = int.Parse(gvReservation.Rows[rowIndex].Cells[0].Text);
            TextBox TBox;
            TBox = (TextBox)gvReservation.Rows[rowIndex].Cells[2].Controls[0];
            String name = TBox.Text;
            TBox = (TextBox)gvReservation.Rows[rowIndex].Cells[3].Controls[0];
            String date = TBox.Text;
            TBox = (TextBox)gvReservation.Rows[rowIndex].Cells[4].Controls[0];
            String time = TBox.Text;
            TBox = (TextBox)gvReservation.Rows[rowIndex].Cells[5].Controls[0];
            int table = int.Parse(TBox.Text);

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateReservation";
            objCommand.Parameters.AddWithValue("@theName", name);
            objCommand.Parameters.AddWithValue("@theDate", date);
            objCommand.Parameters.AddWithValue("@theTime", time);
            objCommand.Parameters.AddWithValue("@theTable", table);
            objCommand.Parameters.AddWithValue("@theID", id);
            objDB.DoUpdateUsingCmdObj(objCommand);

            gvReservation.EditIndex = -1;
            ShowReservation();
        }

        protected void gvReservation_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            // Set the GridView back to the original state
            // No rows currently being edited
            gvReservation.EditIndex = -1;
            ShowReservation();
        }

        protected void gvReservation_RowDeleting(Object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int id = int.Parse(gvReservation.Rows[rowIndex].Cells[0].Text);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReservation";
            objCommand.Parameters.AddWithValue("@theID", id);
            objDB.DoUpdateUsingCmdObj(objCommand);

            ShowReservation();
            lblDisplay.Text = "A reservation was <b>DELETED</b>";
        }

        protected void gvReview_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            // Set the row to edit-mode in the GridView
            gvReview.EditIndex = e.NewEditIndex;
            ShowReview();
        }

        protected void gvReview_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int id = int.Parse(gvReview.Rows[rowIndex].Cells[0].Text);
            TextBox TBox;
            TBox = (TextBox)gvReview.Rows[rowIndex].Cells[2].Controls[0];
            String comment = TBox.Text;
            TBox = (TextBox)gvReview.Rows[rowIndex].Cells[3].Controls[0];
            int quality = int.Parse(TBox.Text);
            TBox = (TextBox)gvReview.Rows[rowIndex].Cells[4].Controls[0];
            int service = int.Parse(TBox.Text);
            TBox = (TextBox)gvReview.Rows[rowIndex].Cells[5].Controls[0];
            int atmosphere = int.Parse(TBox.Text);
            TBox = (TextBox)gvReview.Rows[rowIndex].Cells[6].Controls[0];
            int price = int.Parse(TBox.Text);

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateReview";
            objCommand.Parameters.AddWithValue("@theComment", comment);
            objCommand.Parameters.AddWithValue("@theQuality", quality);
            objCommand.Parameters.AddWithValue("@theService", service);
            objCommand.Parameters.AddWithValue("@theAtmosphere", atmosphere);
            objCommand.Parameters.AddWithValue("@thePrice", price);
            objCommand.Parameters.AddWithValue("@theID", id);
            objDB.DoUpdateUsingCmdObj(objCommand);

            gvReview.EditIndex = -1;
            ShowReview();
        }

        protected void gvReview_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            // Set the GridView back to the original state
            // No rows currently being edited
            gvReview.EditIndex = -1;
            ShowReview();
        }

        protected void gvReview_RowDeleting(Object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int id = int.Parse(gvReview.Rows[rowIndex].Cells[0].Text);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReview";
            objCommand.Parameters.AddWithValue("@theID", id);
            objDB.DoUpdateUsingCmdObj(objCommand);

            ShowReview();
            lblDisplay.Text = "A review was <b>DELETED</b>";
        }
    }
}