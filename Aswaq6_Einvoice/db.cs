using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aswaq6_Einvoice
{
    class   db
    {
        public static string dbname;
        public static string ip;
        public static string sql_pass;
        public static string sql_user;
        public static string id;
        public static string secret;
        public static string pinToken;
        public static string Certfication;

        public static string DBxx;
        public static SqlConnection conn;
        public static SqlCommand cmd;

        static db()
        {
            db.dbname = "";
            db.ip = "";
            db.sql_user = "";
            db.sql_pass = "";

            string dbs = File.ReadAllText("cn.txt");
            string[] strarr = dbs.Split(',');
            int n = 0;
            foreach (string items in strarr)
            {
                n++;
                Console.WriteLine(items);
                if (n == 1) db.ip = items.Trim();
                if (n == 2) db.dbname = items.Trim();
                if (n == 3) db.sql_user = items.Trim();
                if (n == 4) db.sql_pass = items.Trim();
                if (n == 5) db.id = items.Trim();
                if (n == 6) db.secret = items.Trim();
                if (n == 7) db.pinToken = items.Trim();
                if (n == 8) db.Certfication = items;

            }


            //db.dbname = "sadko";
            //db.ip = ".";
            //db.sql_user = "sa";
            //db.sql_pass = "sa@123456";

            db.DBxx = "Data Source=" + db.ip + " ;Initial Catalog=" + db.dbname + " ;Integrated Security=False ; USER ID='" + db.sql_user + "' ; Password='" + db.sql_pass + "'";
            db.conn = new SqlConnection(db.DBxx);
            db.cmd = new SqlCommand("", db.conn);
        }



        public static void Open(ref string  error)
        {
            try
            {
                if (db.conn.State != ConnectionState.Closed)
                {
                   // error="Error connection database  ....مش عارف اوصل الي قاعدة او مش شايف الجهاز وهقفل ومش هبعت فواتير لحد مالمشكلة تتحل ";
                    return;
                }
                else
                {
                    db.conn.Open();
                    db.log_error("Connect Database Successfully..." + db.dbname);
                }
            }
            catch (Exception ex)

            {
                error = ex.Message + "       \n  مش شايف اي بي الجهاز الرئيسي او السيرفيس مش عارفة تخش علي القاعده او سكول ضرب او .....مش عارف بس في مشكلة وربنا يسهلها ان شاء الله  \n";
                db.log_error(ex.Message+"..." + error);
                return;
            }
        }

        public static void Close()
        {
            if (db.conn.State != ConnectionState.Open)
                return;
            db.conn.Close();
        }

        public static DataTable GetData(string select)

        {
            DataTable dataTable = new DataTable();
            db.cmd.CommandText = select;
            dataTable.Load(cmd.ExecuteReader());
            return dataTable;
        }
        public static DataTable GetData2(string select)

        {
            DataTable dataTable = new DataTable();
            db.cmd.CommandText = select;
            dataTable.Load(cmd.ExecuteReader());
            return dataTable;
        }
        public static DataTable GetData_for_log(string select)
        {
            DataTable dataTable = new DataTable();
            db.cmd.CommandText = select;
            dataTable.Load(cmd.ExecuteReader());
            return dataTable;
        }

        public static void GetData_DGV(string select, DataTable tb)
        {
            try
            {
                db.cmd.CommandText = select;
                tb.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
                db.log_error(string.Concat(ex));
            }
        }

        public static void Run(string SQL)
        {
            db.cmd.CommandText = SQL;
            db.cmd.ExecuteNonQuery();
            db.log_error(SQL ?? "");
        }

        public static void wright(string txt)
        {
            StreamWriter streamWriter = new StreamWriter("data.txt", true);
            streamWriter.WriteLine(txt);
            streamWriter.Close();
        }
        public static void create_txt_inEinv(string NameFile, string txt)
        {
            try
            {
                if (File.Exists(NameFile + ".txt")) File.Delete(NameFile + ".txt");
                FileStream fs = File.Create(@"Einvoice\" + NameFile + ".txt");
                fs.Close();
                StreamWriter streamWriter = new StreamWriter(@"Einvoice\" + NameFile + ".txt", true);
                streamWriter.WriteLine(txt);
                streamWriter.Close();
            }
            catch (Exception)
            {


            }
        }
        public static void log_error(string error)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<<" + DateTime.Now + ">> \n \t" + error + "\n \t");
            File.AppendAllText("log.txt", (stringBuilder).ToString());
        }
        public static string convert_date_aswaq(string date_aswaq)
        {
            int n = 0;
            string data_aswaq_handel = date_aswaq.Trim();
            if (data_aswaq_handel.Contains(" "))
            {
                data_aswaq_handel = data_aswaq_handel.Replace(" ","");
            }
            // string dateq = "20230402";
            string date = "";
            foreach (char c in data_aswaq_handel)
            {

                n++;
                date = date + c;
                if (n == 4)
                {
                    date = date + "-";
                }
                if (n == 6)
                {
                    date = date + "-";
                }
               
            }

            return Convert.ToDateTime(date).ToString("yyyy-MM-dd") + "T" + ("07:00:00") + "Z";
        }



    }

}
