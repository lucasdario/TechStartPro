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
                Cmd.Parameters.AddWithValue("product_id_", objProductCategory.product_id.prod_id);
                Cmd.Parameters.AddWithValue("category_id_", objProductCategory.category_id.cate_id);
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
    }
}
