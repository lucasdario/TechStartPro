using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace DAL.Resources.Data.Connection
{
    public class Connection
    {
        public MySqlConnection Con;
        public MySqlCommand Cmd;
        public MySqlDataReader Dr;

        public void OpenConnection()
        {
            Con = new MySqlConnection(ConfigurationManager.ConnectionStrings["TSP"].ConnectionString);
            Con.Open();
        }
        public void CloseConnection()
        {
            Con.Close();
        }
    }
}
