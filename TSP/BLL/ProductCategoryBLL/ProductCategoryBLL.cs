using DAL.entity.productCategory;
using DAL.Persistence.ProductCategoryDAL;
using System;
using System.Collections.Generic;
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
    }
}
