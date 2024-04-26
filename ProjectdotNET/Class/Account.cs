using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectdotNET
{
    internal class Account
    {
        private static Account instance;

        public static Account Instance
        {
            get { if (instance == null) instance = new Account(); return instance; }
            private set { instance = value; }
        }

        private Account() { }

        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM tblACCOUNT WHERE UserName = N'" + userName + "' AND Password = N'" + passWord + "' ";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }
    }
}
