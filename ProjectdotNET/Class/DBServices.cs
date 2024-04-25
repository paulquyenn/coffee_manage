using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectdotNET
{
    internal class DBServices
    {
        private string conString = @"Data Source=.;Initial Catalog=COFFEESTORE;Integrated Security=True";
        private SqlConnection mySqlConnection;

        public DBServices()
        {
            mySqlConnection = new SqlConnection(conString);
        }

        public DataTable getData(string sql)
        {
            try
            {
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(sql, mySqlConnection);
                DataTable myDataTable = new DataTable();
                mySqlDataAdapter.Fill(myDataTable);
                return myDataTable;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void runQuery(string sql)
        {
            try
            {
                mySqlConnection.Open();
                SqlCommand mySqlCommand = new SqlCommand(sql, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
