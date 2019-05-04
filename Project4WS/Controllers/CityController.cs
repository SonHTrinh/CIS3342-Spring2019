using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;
using Utilities;
using ClassLibrary;

namespace Project4WS.Controllers
{
    [Produces("application/json")]
    [Route("api/City")]

    public class CityController : Controller
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        //API Get all city
        [HttpGet]
        [HttpGet("GetCity")]
        public List<City> GetCity()
        {
            List<City> cityList = new List<City>();
            String sqlSelect = "SELECT * FROM City ORDER BY state ASC";
            DataSet myDS = objDB.GetDataSet(sqlSelect);

            int count = myDS.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                City city = new City();
                city.City_Name = objDB.GetField("city_name", i).ToString();
                city.State = objDB.GetField("state", i).ToString();
                city.Population = int.Parse(objDB.GetField("population", i).ToString());
                city.Income = int.Parse(objDB.GetField("income", i).ToString());
                city.Percent_Own = double.Parse(objDB.GetField("percent_own", i).ToString());
                city.Percent_Rent = double.Parse(objDB.GetField("percent_rent", i).ToString());
                city.Home_Value = int.Parse(objDB.GetField("home_value", i).ToString());
                city.Age_Male = int.Parse(objDB.GetField("age_male", i).ToString());
                city.Age_Female = int.Parse(objDB.GetField("age_female", i).ToString());
                city.Unemployment = double.Parse(objDB.GetField("unemployment", i).ToString());
                city.Crime = double.Parse(objDB.GetField("crime", i).ToString());

                cityList.Add(city);
            }

            return cityList;
        }

        //API Get city by name
        [HttpGet("GetCityByName/{city_name}")]
        public List<City> GetCityByName(String city_name)
        {
            List<City> cityList = new List<City>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "P4_GetCityByName";
            objCommand.Parameters.AddWithValue("@theName", city_name);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            int count = myDS.Tables[0].Rows.Count;
            
            for (int i = 0; i < count; i++)
            {
                City city = new City();
                city.City_Name = objDB.GetField("city_name", i).ToString();
                city.State = objDB.GetField("state", i).ToString();
                city.Population = int.Parse(objDB.GetField("population", i).ToString());
                city.Income = int.Parse(objDB.GetField("income", i).ToString());
                city.Percent_Own = double.Parse(objDB.GetField("percent_own", i).ToString());
                city.Percent_Rent = double.Parse(objDB.GetField("percent_rent", i).ToString());
                city.Home_Value = int.Parse(objDB.GetField("home_value", i).ToString());
                city.Age_Male = int.Parse(objDB.GetField("age_male", i).ToString());
                city.Age_Female = int.Parse(objDB.GetField("age_female", i).ToString());
                city.Unemployment = double.Parse(objDB.GetField("unemployment", i).ToString());
                city.Crime = double.Parse(objDB.GetField("crime", i).ToString());

                cityList.Add(city);
            }

            return cityList;
        }

        //API Get city by state
        [HttpGet("GetCityByState/{state}")]
        public List<City> GetCityByState(String state)
        {
            List<City> cityList = new List<City>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "P4_GetCityByState";
            objCommand.Parameters.AddWithValue("@theState", state);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            int count = myDS.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                City city = new City();
                city.City_Name = objDB.GetField("city_name", i).ToString();
                city.State = objDB.GetField("state", i).ToString();
                city.Population = int.Parse(objDB.GetField("population", i).ToString());
                city.Income = int.Parse(objDB.GetField("income", i).ToString());
                city.Percent_Own = double.Parse(objDB.GetField("percent_own", i).ToString());
                city.Percent_Rent = double.Parse(objDB.GetField("percent_rent", i).ToString());
                city.Home_Value = int.Parse(objDB.GetField("home_value", i).ToString());
                city.Age_Male = int.Parse(objDB.GetField("age_male", i).ToString());
                city.Age_Female = int.Parse(objDB.GetField("age_female", i).ToString());
                city.Unemployment = double.Parse(objDB.GetField("unemployment", i).ToString());
                city.Crime = double.Parse(objDB.GetField("crime", i).ToString());

                cityList.Add(city);
            }

            return cityList;
        }

        //API Get city by population - GREATER
        [HttpGet("GetCityByPopulation/Greater/{Population}")]
        public List<City> GetCityByPopulation_Greater(String population)
        {
            List<City> cityList = new List<City>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "P4_GetCityByPopulation_Greater"; 
            objCommand.Parameters.AddWithValue("@thePopulation", population); 
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            int count = myDS.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                City city = new City();
                city.City_Name = objDB.GetField("city_name", i).ToString();
                city.State = objDB.GetField("state", i).ToString();
                city.Population = int.Parse(objDB.GetField("population", i).ToString());
                city.Income = int.Parse(objDB.GetField("income", i).ToString());
                city.Percent_Own = double.Parse(objDB.GetField("percent_own", i).ToString());
                city.Percent_Rent = double.Parse(objDB.GetField("percent_rent", i).ToString());
                city.Home_Value = int.Parse(objDB.GetField("home_value", i).ToString());
                city.Age_Male = int.Parse(objDB.GetField("age_male", i).ToString());
                city.Age_Female = int.Parse(objDB.GetField("age_female", i).ToString());
                city.Unemployment = double.Parse(objDB.GetField("unemployment", i).ToString());
                city.Crime = double.Parse(objDB.GetField("crime", i).ToString());

                cityList.Add(city);
            }

            return cityList;
        }

        //API Get city by population - LESS
        [HttpGet("GetCityByPopulation/Less/{Population}")]
        public List<City> GetCityByPopulation_Less(String population)
        {
            List<City> cityList = new List<City>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "P4_GetCityByPopulation_Less"; 
            objCommand.Parameters.AddWithValue("@thePopulation", population); 
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            int count = myDS.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                City city = new City();
                city.City_Name = objDB.GetField("city_name", i).ToString();
                city.State = objDB.GetField("state", i).ToString();
                city.Population = int.Parse(objDB.GetField("population", i).ToString());
                city.Income = int.Parse(objDB.GetField("income", i).ToString());
                city.Percent_Own = double.Parse(objDB.GetField("percent_own", i).ToString());
                city.Percent_Rent = double.Parse(objDB.GetField("percent_rent", i).ToString());
                city.Home_Value = int.Parse(objDB.GetField("home_value", i).ToString());
                city.Age_Male = int.Parse(objDB.GetField("age_male", i).ToString());
                city.Age_Female = int.Parse(objDB.GetField("age_female", i).ToString());
                city.Unemployment = double.Parse(objDB.GetField("unemployment", i).ToString());
                city.Crime = double.Parse(objDB.GetField("crime", i).ToString());

                cityList.Add(city);
            }

            return cityList;
        }

        //API Get city by income - GREATER
        [HttpGet("GetCityByIncome/Greater/{Income}")]
        public List<City> GetCityByIncome_Greater(String income)
        {
            List<City> cityList = new List<City>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "P4_GetCityByIncome_Greater"; 
            objCommand.Parameters.AddWithValue("@theIncome", income); 
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            int count = myDS.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                City city = new City();
                city.City_Name = objDB.GetField("city_name", i).ToString();
                city.State = objDB.GetField("state", i).ToString();
                city.Population = int.Parse(objDB.GetField("population", i).ToString());
                city.Income = int.Parse(objDB.GetField("income", i).ToString());
                city.Percent_Own = double.Parse(objDB.GetField("percent_own", i).ToString());
                city.Percent_Rent = double.Parse(objDB.GetField("percent_rent", i).ToString());
                city.Home_Value = int.Parse(objDB.GetField("home_value", i).ToString());
                city.Age_Male = int.Parse(objDB.GetField("age_male", i).ToString());
                city.Age_Female = int.Parse(objDB.GetField("age_female", i).ToString());
                city.Unemployment = double.Parse(objDB.GetField("unemployment", i).ToString());
                city.Crime = double.Parse(objDB.GetField("crime", i).ToString());

                cityList.Add(city);
            }

            return cityList;
        }

        //API Get city by income - LESS
        [HttpGet("GetCityByIncome/Less/{Income}")]
        public List<City> GetCityByIncome_Less(String income)
        {
            List<City> cityList = new List<City>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "P4_GetCityByIncome_Less"; 
            objCommand.Parameters.AddWithValue("@theIncome", income); 
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            int count = myDS.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                City city = new City();
                city.City_Name = objDB.GetField("city_name", i).ToString();
                city.State = objDB.GetField("state", i).ToString();
                city.Population = int.Parse(objDB.GetField("population", i).ToString());
                city.Income = int.Parse(objDB.GetField("income", i).ToString());
                city.Percent_Own = double.Parse(objDB.GetField("percent_own", i).ToString());
                city.Percent_Rent = double.Parse(objDB.GetField("percent_rent", i).ToString());
                city.Home_Value = int.Parse(objDB.GetField("home_value", i).ToString());
                city.Age_Male = int.Parse(objDB.GetField("age_male", i).ToString());
                city.Age_Female = int.Parse(objDB.GetField("age_female", i).ToString());
                city.Unemployment = double.Parse(objDB.GetField("unemployment", i).ToString());
                city.Crime = double.Parse(objDB.GetField("crime", i).ToString());

                cityList.Add(city);
            }

            return cityList;
        }

        //API Get City by unemployment rate
        [HttpGet("GetCityByUnemployment/{Unemployment}")]
        public List<City> GetCityByUnemployment(Double unemployment)
        {
            List<City> cityList = new List<City>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "P4_GetCityByUnemployment"; 
            objCommand.Parameters.AddWithValue("@theUnemployment", unemployment); 
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            int count = myDS.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                City city = new City();
                city.City_Name = objDB.GetField("city_name", i).ToString();
                city.State = objDB.GetField("state", i).ToString();
                city.Population = int.Parse(objDB.GetField("population", i).ToString());
                city.Income = int.Parse(objDB.GetField("income", i).ToString());
                city.Percent_Own = double.Parse(objDB.GetField("percent_own", i).ToString());
                city.Percent_Rent = double.Parse(objDB.GetField("percent_rent", i).ToString());
                city.Home_Value = int.Parse(objDB.GetField("home_value", i).ToString());
                city.Age_Male = int.Parse(objDB.GetField("age_male", i).ToString());
                city.Age_Female = int.Parse(objDB.GetField("age_female", i).ToString());
                city.Unemployment = double.Parse(objDB.GetField("unemployment", i).ToString());
                city.Crime = double.Parse(objDB.GetField("crime", i).ToString());

                cityList.Add(city);
            }

            return cityList;
        }

        //API Get City by crime rate
        [HttpGet("GetCityByCrime/{Crime}")]
        public List<City> GetCityByCrime(Double crime)
        {
            List<City> cityList = new List<City>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "P4_GetCityByCrime"; 
            objCommand.Parameters.AddWithValue("@theCrime", crime); 
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            int count = myDS.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                City city = new City();
                city.City_Name = objDB.GetField("city_name", i).ToString();
                city.State = objDB.GetField("state", i).ToString();
                city.Population = int.Parse(objDB.GetField("population", i).ToString());
                city.Income = int.Parse(objDB.GetField("income", i).ToString());
                city.Percent_Own = double.Parse(objDB.GetField("percent_own", i).ToString());
                city.Percent_Rent = double.Parse(objDB.GetField("percent_rent", i).ToString());
                city.Home_Value = int.Parse(objDB.GetField("home_value", i).ToString());
                city.Age_Male = int.Parse(objDB.GetField("age_male", i).ToString());
                city.Age_Female = int.Parse(objDB.GetField("age_female", i).ToString());
                city.Unemployment = double.Parse(objDB.GetField("unemployment", i).ToString());
                city.Crime = double.Parse(objDB.GetField("crime", i).ToString());

                cityList.Add(city);
            }

            return cityList;
        }

        //API Insert city
        [HttpPost()]
        [HttpPost("AddCity")]
        public Boolean AddCity([FromBody]City city)
        {
            //Check if there is already a city with this name and state
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "P4_GetCityByNameAndState";
            objCommand.Parameters.AddWithValue("@theName", city.City_Name);
            objCommand.Parameters.AddWithValue("@theState", city.State);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables[0].Rows.Count == 0) //If there is no other city with this name and state
            {
                if (city != null)
                {
                    objCommand.Parameters.Clear();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "P4_AddCity";
                    objCommand.Parameters.AddWithValue("@theCity", city.City_Name);
                    objCommand.Parameters.AddWithValue("@theState", city.State);
                    objCommand.Parameters.AddWithValue("@thePopulation", city.Population);
                    objCommand.Parameters.AddWithValue("@theIncome", city.Income);
                    objCommand.Parameters.AddWithValue("@thePercentOwn", city.Percent_Own);
                    objCommand.Parameters.AddWithValue("@thePercentRent", city.Percent_Rent);
                    objCommand.Parameters.AddWithValue("@theHomeValue", city.Home_Value);
                    objCommand.Parameters.AddWithValue("@theAgeMale", city.Age_Male);
                    objCommand.Parameters.AddWithValue("@theAgeFemale", city.Age_Female);
                    objCommand.Parameters.AddWithValue("@theUnemployment", city.Unemployment);
                    objCommand.Parameters.AddWithValue("@theCrime", city.Crime);

                    int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

                    if (returnValue > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else { return false; } //Return false if a city with name and state already exists
        }

        //API Update city
        [HttpPut()]
        [HttpPut("UpdateCity")]
        public Boolean UpdateCity([FromBody]City city)
        {
            return false;
        }
    }
}