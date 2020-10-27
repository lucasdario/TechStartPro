using DAL.entity.productCategory;
using DAL.Entity.Product;
using DAL.Persistence.ProductCategoryDAL;
using DAL.Persistence.ProductDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ProductBLL
{
    public class ProductBLL
    {
        public string SaveProduct(string name, string description, double price, int category_id)
        {
            try
            {
                Product objProduct = new Product();
                ProductDAL productDAL = new ProductDAL();
                ProductCategoryDAL productCategoryDAL = new ProductCategoryDAL();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || category_id == 0)
                {
                    return "Invalid reported values.";
                }
                else
                {
                    objProduct.prod_name = name;
                    objProduct.prod_description = description;
                    objProduct.prod_price = price;
                    productDAL.SaveProduct(objProduct);
                    if (objProduct.prod_id > 0)
                    {
                        ProductCategory objProductCategory = new ProductCategory();
                        objProductCategory.category_id.cate_id = category_id;
                        objProductCategory.product_id.prod_id = objProduct.prod_id;
                        productCategoryDAL.SaveProductCategory(objProductCategory);
                    }
                }
                return "Registration completed.";
            }
            catch (Exception ex)
            {
                return "Error processing data.";
            }
        }
    }
}
