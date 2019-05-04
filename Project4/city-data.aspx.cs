using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Script.Serialization;  // needed for JSON serializers
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;                       // needed for the Web Request
using System.Data;                      // needed for DataSet class
using ClassLibrary;                     // needed for the City class

namespace Project4
{
    public partial class city_data : System.Web.UI.Page
    {
        //String webAPIurl = "http://localhost:65438/api/City/";
        String webAPIurl = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/Project4WS/api/City/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create(webAPIurl + "GetCity/");
                WebResponse response = request.GetResponse();

                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<City> city = js.Deserialize<List<City>>(data);

                // Bind the list to the GridView to display all city.
                rptCity.DataSource = city;
                rptCity.DataBind();
            }
            
            if (IsPostBack)
            {
                lblDisplay.Text = ""; lblFind.Text = "";
                findCity.Visible = false; findState.Visible = false; findPopulation.Visible = false; findIncome.Visible = false; findUnemployment.Visible = false; findCrime.Visible = false;
                if (ddlFindCity.SelectedValue == "city")
                {
                    findCity.Visible = true;
                }
                else if (ddlFindCity.SelectedValue == "state")
                {
                    findState.Visible = true;
                }
                else if (ddlFindCity.SelectedValue == "population")
                {
                    findPopulation.Visible = true;
                }
                else if (ddlFindCity.SelectedValue == "income")
                {
                    findIncome.Visible = true;
                }
                else if (ddlFindCity.SelectedValue == "unemployment")
                {
                    findUnemployment.Visible = true;
                }
                else if (ddlFindCity.SelectedValue == "crime")
                {
                    findCrime.Visible = true;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            City city = new City();

            try
            {
                city.City_Name = txtCity.Text;
                city.State = txtState.Text;
                city.Population = int.Parse(txtPopulation.Text);
                city.Income = int.Parse(txtIncome.Text);
                city.Percent_Own = double.Parse(txtPercentOwn.Text);
                city.Percent_Rent = double.Parse(txtPercentRent.Text);
                city.Home_Value = int.Parse(txtHomeValue.Text);
                city.Age_Male = int.Parse(txtAgeMale.Text);
                city.Age_Female = int.Parse(txtAgeFemale.Text);
                city.Unemployment = double.Parse(txtUnemployment.Text);
                city.Crime = double.Parse(txtCrime.Text);
            }
            catch
            {
                lblDisplay.Text = "Please fill in all the blank.";
            }

            // Serialize a City object into a JSON string
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonCity = js.Serialize(city);

            if(txtCity.Text=="" || txtState.Text=="" || txtPopulation.Text=="" || txtIncome.Text=="" || txtPercentOwn.Text=="" || txtPercentRent.Text=="" || 
                txtHomeValue.Text=="" || txtAgeMale.Text=="" || txtAgeFemale.Text=="" || txtUnemployment.Text=="" || txtCrime.Text == "")
            {
                lblDisplay.Text = "Please fill in all the blank.";
            }
            else
            {
                lblDisplay.Text = "";
                try
                {
                    // Send the City object to the Web API that will be used to store a new city record in the database.
                    // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create(webAPIurl + "AddCity/");
                    request.Method = "POST";
                    request.ContentLength = jsonCity.Length;
                    request.ContentType = "application/json";

                    // Write the JSON data to the Web Request
                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonCity);
                    writer.Flush();
                    writer.Close();

                    // Read the data from the Web Response, which requires working with streams.
                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    if (data == "true")
                    {
                        lblDisplay.Text = "The city was successfully added to the database.";
                        txtCity.Text = ""; txtState.Text = ""; txtPopulation.Text = ""; txtIncome.Text = ""; txtPercentOwn.Text= ""; txtPercentRent.Text = "";
                        txtHomeValue.Text = ""; txtAgeMale.Text = ""; txtAgeFemale.Text = ""; txtUnemployment.Text = ""; txtCrime.Text = "";
                    }
                    else
                    { 
                        lblDisplay.Text = "A problem occurred while adding the city to the database. The data wasn't recorded.";
                    }
                }
                catch (Exception ex)
                {
                    lblDisplay.Text = "Error: " + ex.Message;
                }
            }
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            if (ddlFindCity.SelectedValue == "all")
            {
                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create(webAPIurl + "GetCity/");
                WebResponse response = request.GetResponse();

                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<City> city = js.Deserialize<List<City>>(data);

                // Bind the list to the GridView to display all city.
                rptCity.DataSource = city;
                rptCity.DataBind();
            }
            else if (ddlFindCity.SelectedValue == "city")
            {
                if (txtFindCityName.Text == "")
                {
                    lblFind.Text = "Please enter a value.";
                }
                else
                {
                    // Retrieve the list containing all the city returned by the web servier method via proxy.
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create(webAPIurl + "GetCityByName/" + txtFindCityName.Text);
                    WebResponse response = request.GetResponse();

                    // Read the data from the Web Response, which requires working with streams.
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    List<City> city = js.Deserialize<List<City>>(data);

                    // Bind the list to the GridView to display all city.
                    rptCity.DataSource = city;
                    rptCity.DataBind();
                    lblFind.Text = "";

                    if (city.Count == 0)
                    {
                        lblFind.Text = "No records found.";
                    }
                }
            }
            else if (ddlFindCity.SelectedValue == "state")
            {
                if (txtFindState.Text == "")
                {
                    lblFind.Text = "Please enter a value.";
                }
                else
                {
                    // Retrieve the list containing all the city returned by the web servier method via proxy.
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create(webAPIurl + "GetCityByState/" + txtFindState.Text);
                    WebResponse response = request.GetResponse();

                    // Read the data from the Web Response, which requires working with streams.
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    List<City> city = js.Deserialize<List<City>>(data);

                    // Bind the list to the GridView to display all city.
                    rptCity.DataSource = city;
                    rptCity.DataBind();
                    lblFind.Text = "";

                    if (city.Count == 0)
                    {
                        lblFind.Text = "No records found.";
                    }
                }
            }
            else if (ddlFindCity.SelectedValue == "population")
            {
                if (ddlPopulation.SelectedValue == "greater")
                {
                    if (txtFindPopulation.Text == "")
                    {
                        lblFind.Text = "Please enter a value.";
                    }
                    else
                    {
                        // Retrieve the list containing all the city returned by the web servier method via proxy.
                        // Create an HTTP Web Request and get the HTTP Web Response from the server.
                        WebRequest request = WebRequest.Create(webAPIurl + "GetCityByPopulation/Greater/" + txtFindPopulation.Text);
                        WebResponse response = request.GetResponse();

                        // Read the data from the Web Response, which requires working with streams.
                        Stream theDataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(theDataStream);
                        String data = reader.ReadToEnd();
                        reader.Close();
                        response.Close();

                        // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        List<City> city = js.Deserialize<List<City>>(data);

                        // Bind the list to the GridView to display all city.
                        rptCity.DataSource = city;
                        rptCity.DataBind();
                        lblFind.Text = "";

                        if (city.Count == 0)
                        {
                            lblFind.Text = "No records found.";
                        }
                    }
                }
                else if (ddlPopulation.SelectedValue == "less")
                {
                    if (txtFindPopulation.Text == "")
                    {
                        lblFind.Text = "Please enter a value.";
                    }
                    else
                    {
                        // Retrieve the list containing all the city returned by the web servier method via proxy.
                        // Create an HTTP Web Request and get the HTTP Web Response from the server.
                        WebRequest request = WebRequest.Create(webAPIurl + "GetCityByPopulation/Less/" + txtFindPopulation.Text);
                        WebResponse response = request.GetResponse();

                        // Read the data from the Web Response, which requires working with streams.
                        Stream theDataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(theDataStream);
                        String data = reader.ReadToEnd();
                        reader.Close();
                        response.Close();

                        // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        List<City> city = js.Deserialize<List<City>>(data);

                        // Bind the list to the GridView to display all city.
                        rptCity.DataSource = city;
                        rptCity.DataBind();
                        lblFind.Text = "";

                        if (city.Count == 0)
                        {
                            lblFind.Text = "No records found.";
                        }
                    }
                }
            }
            else if (ddlFindCity.SelectedValue == "income")
            {
                if (ddlIncome.SelectedValue == "greater")
                {
                    if (txtFindIncome.Text == "")
                    {
                        lblFind.Text = "Please enter a value.";
                    }
                    else
                    {
                        // Retrieve the list containing all the city returned by the web servier method via proxy.
                        // Create an HTTP Web Request and get the HTTP Web Response from the server.
                        WebRequest request = WebRequest.Create(webAPIurl + "GetCityByIncome/Greater/" + txtFindIncome.Text);
                        WebResponse response = request.GetResponse();

                        // Read the data from the Web Response, which requires working with streams.
                        Stream theDataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(theDataStream);
                        String data = reader.ReadToEnd();
                        reader.Close();
                        response.Close();

                        // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        List<City> city = js.Deserialize<List<City>>(data);

                        // Bind the list to the GridView to display all city.
                        rptCity.DataSource = city;
                        rptCity.DataBind();
                        lblFind.Text = "";

                        if (city.Count == 0)
                        {
                            lblFind.Text = "No records found.";
                        }
                    }
                }
                else if (ddlIncome.SelectedValue == "less")
                {
                    if (txtFindIncome.Text == "")
                    {
                        lblFind.Text = "Please enter a value.";
                    }
                    else
                    {
                        // Retrieve the list containing all the city returned by the web servier method via proxy.
                        // Create an HTTP Web Request and get the HTTP Web Response from the server.
                        WebRequest request = WebRequest.Create(webAPIurl + "GetCityByIncome/Less/" + txtFindIncome.Text);
                        WebResponse response = request.GetResponse();

                        // Read the data from the Web Response, which requires working with streams.
                        Stream theDataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(theDataStream);
                        String data = reader.ReadToEnd();
                        reader.Close();
                        response.Close();

                        // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        List<City> city = js.Deserialize<List<City>>(data);

                        // Bind the list to the GridView to display all city.
                        rptCity.DataSource = city;
                        rptCity.DataBind();
                        lblFind.Text = "";

                        if (city.Count == 0)
                        {
                            lblFind.Text = "No records found.";
                        }
                    }
                }
            }
            else if (ddlFindCity.SelectedValue == "unemployment")
            {
                if (txtFindUnemployment.Text == "")
                {
                    lblFind.Text = "Please enter a value.";
                }
                else
                {
                    // Retrieve the list containing all the city returned by the web servier method via proxy.
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create(webAPIurl + "GetCityByUnemployment/" + txtFindUnemployment.Text);
                    WebResponse response = request.GetResponse();

                    // Read the data from the Web Response, which requires working with streams.
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    List<City> city = js.Deserialize<List<City>>(data);

                    // Bind the list to the GridView to display all city.
                    rptCity.DataSource = city;
                    rptCity.DataBind();
                    lblFind.Text = "";

                    if (city.Count == 0)
                    {
                        lblFind.Text = "No records found.";
                    }
                }
            }
            else if (ddlFindCity.SelectedValue == "crime")
            {
                if (txtFindCrime.Text == "")
                {
                    lblFind.Text = "Please enter a value.";
                }
                else
                {
                    // Retrieve the list containing all the city returned by the web servier method via proxy.
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create(webAPIurl + "GetCityByCrime/" + txtFindCrime.Text);
                    WebResponse response = request.GetResponse();

                    // Read the data from the Web Response, which requires working with streams.
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    List<City> city = js.Deserialize<List<City>>(data);

                    // Bind the list to the GridView to display all city.
                    rptCity.DataSource = city;
                    rptCity.DataBind();
                    lblFind.Text = "";

                    if (city.Count == 0)
                    {
                        lblFind.Text = "No records found.";
                    }
                }
            }
            else
            {
                lblFind.Text = "Error";
            }
        }
    }
}