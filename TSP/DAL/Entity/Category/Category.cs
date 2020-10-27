using DAL.Resources.Data.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.entity.category
{
    public class Category
    {
        public int cate_id { get; set; }
        public string cate_name { get; set; }
        public Category(int cate_id, string cate_name)
        {
            this.cate_id = cate_id;
            this.cate_name = cate_name;
        }
        public Category()
        { }
    }
}
