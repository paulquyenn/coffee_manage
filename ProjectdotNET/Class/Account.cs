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

        DBServices db = new DBServices();

        public int Login(string userName, string passWord)
        {
            string query0 = "SELECT * FROM tblACCOUNT WHERE UserName = '" + userName + "' AND Password = '" + passWord + "' AND TypeAccount = 0";
            string query1 = "SELECT * FROM tblACCOUNT WHERE UserName = '" + userName + "' AND Password = '" + passWord + "' AND TypeAccount = 1";

            DataTable result0 = db.getData(query0);
            DataTable result1 = db.getData(query1);

            if (result0.Rows.Count > 0) { return 0; }
            else if(result1.Rows.Count > 0) { return 1; }
            else return -1;
        }
    }
}
