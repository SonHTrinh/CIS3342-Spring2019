using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary
{
    public class City
    {
        private String city_name;
        private String state;
        private int population;
        private double income;
        private double percent_own;
        private double percent_rent;
        private double home_value;
        private int age_male;
        private int age_female;
        private double unemployment;
        private double crime;

        public City()
        {
            city_name = "";
            state = "";
            population = 0;
            income = 0.00;
            percent_own = 0.00;
            percent_rent = 0.00;
            home_value = 0.00;
            age_male = 0;
            age_female = 0;
            unemployment = 0.00;
            crime = 0.00;
        }

        public String City_Name
        {
            set { this.city_name = value; }
            get { return city_name; }
        }

        public String State
        {
            set { this.state = value; }
            get { return state; }
        }

        public int Population
        {
            set { this.population = value; }
            get { return population; }
        }

        public double Income
        {
            set { this.income = value; }
            get { return income; }
        }

        public double Percent_Own
        {
            set { this.percent_own = value; }
            get { return percent_own; }
        }

        public double Percent_Rent
        {
            set { this.percent_rent = value; }
            get { return percent_rent; }
        }

        public double Home_Value
        {
            set { this.home_value = value; }
            get { return home_value; }
        }

        public int Age_Male
        {
            set { this.age_male = value; }
            get { return age_male; }
        }

        public int Age_Female
        {
            set { this.age_female = value; }
            get { return age_female; }
        }

        public double Unemployment
        {
            set { this.unemployment = value; }
            get { return unemployment; }
        }

        public double Crime
        {
            set { this.crime = value; }
            get { return crime; }
        }
    }
}