using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bill
    {
        ////COFFEE
        //public string coffeeID { get; set; }
        //public string name { get; set; }
        //public int type { get; set; }
        //public string description { get; set; }
        //public float price { get; set; }

        //public string typeName { get; set; }
        //public int QuantityCart { get; set; }
        //public float Total { get; set; }

        ////USER
        //public int userID { get; set; }
        //public string username { get; set; }
        //public string password { get; set; }
        //public string fullName { get; set; }
        //public string phone { get; set; }
        //public string email { get; set; }
        //public string address { get; set; }
        //public int role { get; set; }

        public int orderID { get; set; }
        public int quantity { get; set; }
        public string coffeeID { get; set; }
        public float price { get; set; }
    }
}
