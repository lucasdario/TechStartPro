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
        public List<ProductCategory> SearchProduct(string name, string description, string price, int category_id)
        {
            try
            {
                string comand = "SELECT pc.prca_id AS id, p.prod_name AS product_name, p.prod_description AS product_descripton, p.prod_price AS product_price, c.cate_name AS category_name FROM productcategory pc"
                                + " INNER JOIN product p ON pc.prca_product_fk = p.prod_id"
                                    + " INNER JOIN category c ON pc.prca_category_fk = c.cate_id WHERE 1 = 1";
                if (!string.IsNullOrEmpty(name))
                {
                    comand += " AND p.prod_name LIKE '%" + name + "%'";
                }
                if (!string.IsNullOrEmpty(description))
                {
                    comand += " AND p.prod_description LIKE '%" + description + "%'";
                }
                if (!string.IsNullOrEmpty(price))
                {
                    comand += " AND p.prod_price=" + Convert.ToDouble(price);
                }
                if (category_id != 0)
                {
                    comand += " AND pc.prca_category_fk=" + category_id;
                }

                ProductCategoryDAL productCategoryDAL = new ProductCategoryDAL();
                List<ProductCategory> lstProductCategory = productCategoryDAL.ListFilterProducts(comand);

                return lstProductCategory;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
