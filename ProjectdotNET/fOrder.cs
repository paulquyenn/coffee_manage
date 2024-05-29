using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectdotNET
{
    public partial class fOrder : Form
    {
        public fOrder()
        {
            InitializeComponent();

            loadTable();
        }

        public class Table
        {
            public Table(int id, string status)
            {
                this.id = id;
                this.status = status;
            }

            public Table(DataRow row)
            {
                this.id = (int)row["TableID"];
                this.status = (string)row["Status"];
            }

            private int id;
            private string status;

            public int ID
            {
                get { return id; }
                set { id = value; }
            }

            public string Status
            {
                get { return status; }
                set { status = value; }
            }
        }

        public class TableDAO
        {
            private static TableDAO instance;

            public static TableDAO Instance
            {
                get { if (instance == null) instance = new TableDAO(); return instance; }
                private set { TableDAO.instance = value; }
            }

            public TableDAO() { }

            public List<Table> LoadTableList()
            {
                List<Table> tablelist = new List<Table>();

                DBServices dBServices = new DBServices();
                DataTable datatable = dBServices.getData("SELECT * FROM tblTABLE");


                foreach (DataRow row in datatable.Rows)
                {
                    Table table = new Table(row);
                    tablelist.Add(table);
                }

                return tablelist;
            }
        }

        

        void loadTable()
        {
            List<Table> tablelist = TableDAO.Instance.LoadTableList();

            foreach(Table table in tablelist)
            {
                Button btn = new Button() { Width = 100, Height = 50};
                btn.Text = table.ID + Environment.NewLine + table.Status;
                
                switch (table.Status)
                {
                    case "Đặt":
                        btn.BackColor = Color.FromArgb(255, 192, 192);
                        break;
                    default: 
                        btn.BackColor = Color.FromArgb(192, 255, 192);
                        break;
                }

                flpTable.Controls.Add(btn);

            }
        }
    }
}
