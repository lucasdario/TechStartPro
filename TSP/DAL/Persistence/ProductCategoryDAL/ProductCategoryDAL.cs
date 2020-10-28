using DAL.entity.productCategory;
using DAL.Resources.Data.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence.ProductCategoryDAL
{
    public class ProductCategoryDAL : Connection
    {
        public bool SaveProductCategory(ProductCategory objProductCategory)
        {
            try
            {
                OpenConnection();
                Cmd = new MySqlCommand("SP_SaveCategoryAndProduct", Con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Cmd.Parameters.AddWithValue("category_id_", objProductCategory.category_id.cate_id);
                Cmd.Parameters.AddWithValue("product_id_", objProductCategory.product_id.prod_id);
                Cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
        public List<ProductCategory> ListAllProducts()
        {
            try
            {
                OpenConnection();
                Cmd = new MySqlCommand("SP_ListAllCategoryAndProduct", Con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                Dr = Cmd.ExecuteReader();
                List<ProductCategory> lstProductCategory = new List<ProductCategory>();
                while (Dr.Read())
                {
                    ProductCategory objProductCategory = new ProductCategory();
                    objProductCategory.prca_id = Convert.ToInt32(Dr["prca_id"]);
                    objProductCategory.product_id.prod_name = Convert.ToString(Dr["prod_name"]);
                    objProductCategory.product_id.prod_description = Convert.ToString(Dr["prod_description"]);
                    objProductCategory.product_id.prod_price = Convert.ToDouble(Dr["prod_price"]);
                    objProductCategory.category_id.cate_name = Convert.ToString(Dr["cate_name"]);

                    lstProductCategory.Add(objProductCategory);
                }
                return lstProductCategory;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool DeleteProduct(int productId)
        {
            try
            {
                OpenConnection();
                Cmd = new MySqlCommand("SP_DeleteProduct", Con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Cmd.Parameters.AddWithValue("prca_id_", productId);
                Cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
