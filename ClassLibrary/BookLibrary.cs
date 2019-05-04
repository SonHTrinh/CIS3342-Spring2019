using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary
{
    public class BookLibrary
    {
        private String isbn;
        private String title;
        private String buyrent;
        private String bookType;
        private int quantity;
        private double price;
        private double totalCost;

        public String ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public String BuyRent
        {
            get { return buyrent; }
            set { buyrent = value; }
        }

        public String BookType
        {
            get { return bookType; }
            set { bookType = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public double TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }
    }
}