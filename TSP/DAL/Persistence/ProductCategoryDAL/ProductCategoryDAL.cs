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
        public ProductCategory FindByIdProduct(int productId)
        {
            try
            {
                OpenConnection();
                Cmd = new MySqlCommand("SP_FindByProductId", Con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Cmd.Parameters.AddWithValue("prca_id_", productId);

                Dr = Cmd.ExecuteReader();
                ProductCategory objProductCategory = new ProductCategory();
                while (Dr.Read())
                {
                    objProductCategory.prca_id = Convert.ToInt32(Dr["prca_id"]);
                    objProductCategory.product_id.prod_id = Convert.ToInt32(Dr["prod_id"]);
                    objProductCategory.product_id.prod_name = Convert.ToString(Dr["prod_name"]);
                    objProductCategory.product_id.prod_description = Convert.ToString(Dr["prod_description"]);
                    objProductCategory.product_id.prod_price = Convert.ToDouble(Dr["prod_price"]);
                    objProductCategory.category_id.cate_id = Convert.ToInt32(Dr["cate_id"]);
                }
                if (objProductCategory.prca_id != 0)
                {
                    return objProductCategory;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool UpdateProduct(ProductCategory objProductCategory)
        {
            try
            {
                OpenConnection();
                Cmd = new MySqlCommand("SP_UpdateProduct", Con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Cmd.Parameters.AddWithValue("prca_id_", objProductCategory.prca_id);
                Cmd.Parameters.AddWithValue("prod_name_", objProductCategory.product_id.prod_name);
                Cmd.Parameters.AddWithValue("prod_description_", objProductCategory.product_id.prod_description);
                Cmd.Parameters.AddWithValue("prod_price_", objProductCategory.product_id.prod_price);
                Cmd.Parameters.AddWithValue("cate_id_", objProductCategory.category_id.cate_id);

                Cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}




