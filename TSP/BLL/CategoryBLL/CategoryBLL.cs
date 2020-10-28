using DAL.entity.category;
using DAL.Persistence.CategoryDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CategoryBLL
{
    public class CategoryBLL
    {
        public bool ReadCSV(string fileName)
        {
            try
            {
                List<Category> lstCategoryDAL = new List<Category>();
                CategoryDAL categoryDAL = new CategoryDAL();
                StreamReader reader = new StreamReader(fileName, Encoding.GetEncoding("iso-8859-1"));
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    DAL.entity.category.Category objCategoryDAL = new DAL.entity.category.Category();
                    objCategoryDAL.cate_name = line.ToString();
                    lstCategoryDAL.Add(objCategoryDAL);
                }
                if (categoryDAL.SaveCategory(lstCategoryDAL))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Category> ListAllCategory()
        {
            try
            {
                CategoryDAL categoryDAL = new CategoryDAL();
                List<Category> lstCategory = categoryDAL.ListAllCategory();
                return lstCategory;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
