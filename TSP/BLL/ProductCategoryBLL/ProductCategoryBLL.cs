using DAL.entity.productCategory;
using DAL.Persistence.ProductCategoryDAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ProductCategoryBLL
{
    public class ProductCategoryBLL
    {
        public List<ProductCategory> ListAllProducts()
        {
            try
            {
                ProductCategoryDAL productCategoryDAL = new ProductCategoryDAL();
                return productCategoryDAL.ListAllProducts();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteProduct(int productId)
        {
            try
            {
                if (productId != 0)
                {
                    ProductCategoryDAL productCategoryDAL = new ProductCategoryDAL();
                    productCategoryDAL.DeleteProduct(productId);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public ProductCategory FindByProductId(int productId)
        {
            try
            {
                if (productId != 0)
                {
                    ProductCategoryDAL productCategoryDAL = new ProductCategoryDAL();
                    return productCategoryDAL.FindByIdProduct(productId);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string UpdateProduct(int prca_id, string name, string description, string price, int category_id)
        {
            try
            {
                ProductCategory objProductCategory = new ProductCategory();
                if (string.IsNullOrEmpty(price))
                {
                    price = "0";
                }
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || category_id == 0)
                {
                    return "Invalid reported values.";
                }
                else
                {
                    objProductCategory.prca_id = prca_id;
                    objProductCategory.product_id.prod_name = name;
                    objProductCategory.product_id.prod_description = description;
                    objProductCategory.product_id.prod_price = Convert.ToDouble(price, CultureInfo.InvariantCulture);
                    objProductCategory.category_id.cate_id = category_id;

                    ProductCategoryDAL productCategoryDAL = new ProductCategoryDAL();
                    if (productCategoryDAL.UpdateProduct(objProductCategory))
                    {
                        return "Update completed.";
                    }
                    else
                    {
                        return "Error update data.";
                    }
                }
            }
            catch (Exception)
            {
                return "Error processing data.";
            }
        }
    }
}
