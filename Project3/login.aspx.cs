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
    public partial class login : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String userType = ddlUserType.SelectedValue;
            String name = txtName.Text;
            Session.Add("name", "");
            Session.Add("userType", "");

            if (userType == "false")
            {
                lblDisplay.Text = "Please select an user type!";
            }

            else if (userType == "reviewer")
            {
                // Set the SQLCommand object's properties for executing a Stored Procedure
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetUser";
                //objCommand.Parameters.AddWithValue("@theName", txtName.Text);
                SqlParameter inputParameter = new SqlParameter("@theName", txtName.Text);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 20;
                objCommand.Parameters.Add(inputParameter);
                // Execute the stored procedure using the DBConnect object and the SQLCommand object
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

                try
                {
                    lblDisplay.Text = "You have succesfully logged in as: " + userType + " '<b>" + myDataSet.Tables[0].Rows[0]["user_name"].ToString() + "</b>'"; //Give the first table that found in the dataset
                    Session.Clear();
                    Session["name"] = txtName.Text;
                    Session["userType"] = ddlUserType.SelectedValue;
                }
                catch
                {
                    lblDisplay.Text = "User <b>NOT FOUND</b>! Please enter a correct user name!";
                }
            }
            else if (userType == "representative")
            {
                // Set the SQLCommand object's properties for executing a Stored Procedure
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetRepresentative";
                //objCommand.Parameters.AddWithValue("@theName", name);
                SqlParameter inputParameter = new SqlParameter("@theName", txtName.Text);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 20;
                objCommand.Parameters.Add(inputParameter);
                // Execute the stored procedure using the DBConnect object and the SQLCommand object
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

                try
                { 
                    lblDisplay.Text = "You have succesfully logged in as: " + userType + " '<b>" + myDataSet.Tables[0].Rows[0]["rep_name"].ToString() + "</b>'";
                    Session.Clear();
                    Session["name"] = txtName.Text;
                    Session["userType"] = ddlUserType.SelectedValue;
                }
                catch
                {
                    lblDisplay.Text = "User <b>NOT FOUND</b>! Please enter a correct user name!";
                }
            }
            txtName.Text = "";

        }
    }
}