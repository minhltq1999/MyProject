using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CoffeeDTO
    {
        public string coffeeID { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string description { get; set; }
        public float price { get; set; }

        public string typeName { get; set; }
        public int QuantityCart { get; set; }
        public float Total { get; set; }
    }
}
