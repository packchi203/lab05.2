using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5._2
{
    public class Product
    {
        public int id { get; set; }
        public string proName { get; set; }
        public string proDesc { get; set; }
        public decimal price { get; set; }
        public Product() { }
        public Product(int id, string proName, string proDesc, decimal price)
        {
            id = id;
            this.proName = proName;
            this.proDesc = proDesc;
            this.price = price;
        }
    }
}

