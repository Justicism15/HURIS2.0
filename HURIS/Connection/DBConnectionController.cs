using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;

namespace HURIS
{
    public class DBConnectionController
    {
        static SqlConnection connection = new SqlConnection();

        static string connetionString = null;
        static string server, dbname, dbuser, dbpass;
        DataTable dtItems = new DataTable();

        public DBConnectionController()
        {

        }

        private static void ConnectionOpen()
        {
            // server = "192.168.1.200";
            // dbname = "USLS";
            // dbuser = "sa";
            //  dbpass = "Hybrain2018";

            server = "JUSTINE-PC";
            dbname = "HURIS3";
            dbuser = "justin";
            dbpass = "123";
            connetionString = "Data Source=" + server + ";Initial Catalog =" + dbname + ";User ID =" + dbuser +
                            ";Password=" + dbpass + "";// +192.168.1.200; Initial Catalog=USLS;User ID=sa;Password=Hybrain2018";
            connection = new SqlConnection(connetionString);
            connection.Open();
        }

        /// <summary>
        /// to close db connection
        /// </summary>
        private static void ConnectionClose()
        {
            connection.Close();
        }

        /// <summary>
        /// execute non query (to insert or update data for db)
        /// </summary>
        /// <param name="cmd">partial sql command from controller</param>
        /// <returns></returns>
        public static bool ExecNonQuery(SqlCommand cmd)
        {
            try
            {
                bool result;
                //connection.Open();
                ConnectionOpen();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                //connection.Close();
                ConnectionClose();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// execute non scalar (to insert and get the primary key or return value.)
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public int ExecuteScalar(SqlCommand cmd)
        {
            try
            {
                int result;
                ConnectionOpen();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                ConnectionClose();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
        }

        public DataTable ExecuteReader(SqlCommand cmd)
        {
            try
            {
                ConnectionOpen();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                dtItems = new DataTable();
                dtItems.Load(sdr);

                ConnectionClose();
                return dtItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dtItems;
            }
        }

        public DataTable ExecuteReaderWithParams(SqlCommand cmd)
        {
            try
            {
                ConnectionOpen();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                dtItems = new DataTable();
                dtItems.Load(sdr);

                ConnectionClose();
                return dtItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dtItems;
            }
        }

        

        /// <summary>
        /// to read data without parameters
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public DataTable ExecuteReaderNoParams(SqlCommand cmd)
        {
            try
            {
                ConnectionOpen();

                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                dtItems = new DataTable();
                dtItems.Load(sdr);

                ConnectionClose();
                return dtItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dtItems;
            }
        }
    }
}
