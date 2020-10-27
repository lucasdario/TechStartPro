using DAL.entity.category;
using DAL.Resources.Data.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence.CategoryDAL
{
    public class CategoryDAL : Connection
    {
        public bool SaveCategory(List<Category> lstCategory)
        {
            try
            {
                OpenConnection();
                for (int i = 0; i < lstCategory.Count; i++)
                {
                    Cmd = new MySqlCommand("SP_SaveCategory", Con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    Cmd.Parameters.AddWithValue("cate_name_", lstCategory[i].cate_name);
                    Cmd.ExecuteNonQuery();
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

        public List<Category> ListAllCategory()
        {
            try
            {
                OpenConnection();
                Cmd = new MySqlCommand("SP_ListAllCategory", Con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Dr = Cmd.ExecuteReader();
                List<Category> lstCategoryDAL = new List<Category>();
                while (Dr.Read())
                {
                    Category objCategoryDAL = new Category();
                    objCategoryDAL.cate_id = Convert.ToInt32(Dr["cate_id"]);
                    objCategoryDAL.cate_name = Convert.ToString(Dr["cate_name"]);
                    lstCategoryDAL.Add(objCategoryDAL);
                }
                return lstCategoryDAL;
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
    }
}
