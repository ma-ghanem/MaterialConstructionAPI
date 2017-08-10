using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MaterialConstructionAPI
{
    public class DBContext
    {
        string connetionString = null;
        SqlConnection conn;

        public DBContext()
        {
            InitConnection();
        }

        public void InitConnection()
        {
            connetionString = ConfigurationManager.ConnectionStrings["MaterialConstructionConnection"].ConnectionString;
            conn = new SqlConnection(connetionString);
        }

        public SqlConnection GetConnection()
        {
            return conn;
        }

        public void OpenConnection()
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                //("Can not open connection !");
            }
        }

        public void CloseConnection()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                //("Can not close connection !");
            }
        }
    }
}