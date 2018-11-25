using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CUESYSv._01
{
    public class dbConn
    {

        ///// DB CONFIG START //////////////////////////////////////////////////////
        public string varConfigServer { get; set; }
        public string varConfigDatabase { get; set; }
        public string varConfigUser { get; set; }
        public string varConfigPass { get; set; }

        private string connString;
        public MySqlConnection conn;
        public MySqlDataAdapter mySQLda;


        ///// DB CONFIG END ////////////////////////////////////////////////////////



        public void connect()
        {//Connect to database (insecure, not using SSL or stored procedures)
            connString = "SERVER=" + varConfigServer + ";" +
                "DATABASE=" + varConfigDatabase + ";" +
                "UID=" + varConfigUser + ";" +
                "PASSWORD=" + varConfigPass + ";" +
                "SslMode=none;";
            conn = new MySqlConnection(connString);
        }
        public bool connOpen()
        {
            try { conn.Open(); return true; }
            catch (MySqlException err)
            {//Connection error handling control statement
                switch (err.Number)
                {
                    case 0:
                        MessageBox.Show("Server connection failure");
                        break;
                    case 1045:
                        MessageBox.Show("User/Password Error");
                        break;
                    default:
                        MessageBox.Show(err.Message);
                        break;
                }
                return false;
            }
        }
        public bool connClose()
        {//Connection close with error handling
            try { conn.Close(); return true; }
            catch (MySqlException err) { MessageBox.Show("Error: " + err.Message); return false; }
        }
        public DataSet qry(string sql)
        {//Run sql qry in argument and return dataset
            mySQLda = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            mySQLda.Fill(ds);
            connClose();
            return ds;
        }

        
    }
}
