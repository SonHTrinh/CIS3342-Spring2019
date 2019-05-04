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
    public partial class create_account : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            String userType = Request["ddlUserType"];
            String name = Request["txtName"];

            // Set the SQLCommand object's properties for executing a Stored Procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertUser";
            objCommand.Parameters.AddWithValue("@theName", name);
            // Execute the stored procedure using the DBConnect object and the SQLCommand object
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            lblDisplay.Text = "Your account '<b>" + name + "</b>' has been succesfully created!";
            lblRedirect.Text = "The page will automatically redirect you to Login page in a few seconds...";
            txtName.Text = "";
            Response.AddHeader("REFRESH", "5;URL=login.aspx");
        }

        protected void btnCreateRep_Click(object sender, EventArgs e)
        {
            String userType = Request["ddlUserType"];
            String name = Request["txtName"];

            // Set the SQLCommand object's properties for executing a Stored Procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertRepresentative";
            objCommand.Parameters.AddWithValue("@theName", name);
            // Execute the stored procedure using the DBConnect object and the SQLCommand object
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            lblDisplay.Text = "Your account '<b>" + name + "</b>' has been succesfully created!";
            lblRedirect.Text = "The page will automatically redirect you to Login page in a few seconds...";
            txtName.Text = "";
            Response.AddHeader("REFRESH", "5;URL=login.aspx");
        }
    }
}