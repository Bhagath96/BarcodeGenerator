using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace BarcodeGenerator
{
    public class DBOperations
    {
        public static string strcon = ConfigurationManager.ConnectionStrings["AxobisConnectionMain"].ToString();

        public static DataTable GetTable(string sql)
        {
            string connectionstring = string.Empty;
            DataTable dt = new DataTable();

            connectionstring = strcon;

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetTable (SqlCommand cmd)
        {
            string connectionstring = string.Empty;
            DataTable dt = new DataTable();

            connectionstring = strcon;

            using (SqlConnection con = new SqlConnection(connectionstring))
            {

                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public static int ExecuteNonQuery(SqlCommand cmd)
        {
            int i = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                i = cmd.ExecuteNonQuery();
            }

            return i;
        }
        public static DataTable ExecuteStoreProcedure(SqlCommand cmd)
        {
            string connectionstring = string.Empty;
            DataTable dt = new DataTable();

            connectionstring = strcon;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                return dt;
            }

        }

        public static DataTable GetTableWithParameters(SqlCommand cmd)
        {
            string connectionstring = string.Empty;
            DataTable dt = new DataTable();

            connectionstring = strcon;

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }



    }
}