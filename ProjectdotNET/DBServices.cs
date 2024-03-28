using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectdotNET
{
    internal class DBServices
    {
        private string conString = @"Data Source=DManh; Initial Catalog=COFFEESTORE;
                                        Integrated Security=True";
        private SqlConnection myCon;

        public DBServices()
        {
            myCon = new SqlConnection(conString);
        }

        public DataTable GetData(string sql)
        {
            try
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(sql, myCon);
                DataTable dt = new DataTable();
                myAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void runQuery(string sql)
        {
            try
            {
                myCon.Open();
                SqlCommand command = new SqlCommand(sql, myCon);
                command.ExecuteNonQuery();
                myCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
