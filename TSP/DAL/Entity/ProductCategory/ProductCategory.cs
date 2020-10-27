using DAL.entity.category;
using DAL.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.entity.productCategory
{
    public class ProductCategory
    {
        public int prca_id { get; set; }
        public Product product_id { get; set; }
        public Category category_id { get; set; }
        public ProductCategory(int prca_id, Product product_id, Category category_id)
        {
            this.prca_id = prca_id;
            this.product_id = product_id;
            this.category_id = category_id;
        }
        public ProductCategory()
        {
            product_id = new Product();
            category_id = new Category();
        }
    }
}
