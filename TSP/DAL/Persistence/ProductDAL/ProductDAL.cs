using DAL.Entity.Product;
using DAL.Resources.Data.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence.ProductDAL
{
    public class ProductDAL : Connection
    {
        public bool SaveProduct(Product objProduct)
        {
            try
            {
                OpenConnection();

                Cmd = new MySqlCommand("SP_SaveProduct", Con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Cmd.Parameters.AddWithValue("prod_name_", objProduct.prod_name);
                Cmd.Parameters.AddWithValue("prod_description_", objProduct.prod_description);
                Cmd.Parameters.AddWithValue("prod_price_", objProduct.prod_price);

                int lastId = Convert.ToInt32(Cmd.ExecuteScalar());

                if (lastId > 0)
                {
                    objProduct.prod_id = lastId;
                }
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
