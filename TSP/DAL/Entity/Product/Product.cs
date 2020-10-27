using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity.Product
{
    public class Product
    {
        public int prod_id { get; set; }
        public string prod_name { get; set; }
        public string prod_description { get; set; }
        public double prod_price { get; set; }
        public Product(int prod_id, string prod_name, string prod_description, double prod_price)
        {
            this.prod_id = prod_id;
            this.prod_name = prod_name;
            this.prod_description = prod_description;
            this.prod_price = prod_price;
        }
        public Product()
        {}
    }
}