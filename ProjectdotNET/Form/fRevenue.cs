using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectdotNET
{
    public partial class fRevenue : Form
    {
        public fRevenue()
        {
            InitializeComponent();
        }

        COFFEESTOREEntities myCoffeeStore = new COFFEESTOREEntities();

        private void LoadGridDataBillStatistical()
        {
            DateTime datestart = dtStart.Value.Date;
            DateTime dateend = dtEnd.Value.Date;

            var query = from item in myCoffeeStore.tblBILL
                        join item1 in myCoffeeStore.tblEMPLOYEE on item.EmployeeID equals item1.EmployeeID
                        where item.OrderDate >= datestart && item.OrderDate <= dateend
                        select new 
                        {
                            BillID = item.BillID, 
                            EmployeeName = item1.EmployeeName, 
                            OrderDate = item.OrderDate,
                            TableID = item.TableID,
                            Status = item.Status
                        };
            dgvStatistical.DataSource = query.ToList();
        }
        private void fRevenue_Load(object sender, EventArgs e)
        {
            //LoadGridDataBillStatistical();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            LoadGridDataBillStatistical();

            DateTime datestart = dtStart.Value.Date;
            DateTime dateend = dtEnd.Value.Date;

            var queryBill = from item in myCoffeeStore.tblBILL
                        where item.OrderDate >= datestart && item.OrderDate <= dateend
                        select item;

            int totalbill = queryBill.Count();
            tbTotalBill.Text = totalbill.ToString();


            decimal totalMoney = 0;
            foreach(var item in queryBill)
            {
                var queryBillinfo = from billInfo in myCoffeeStore.tblBILL_INFO
                                    join product in myCoffeeStore.tblPRODUCT on billInfo.ProductID equals product.ProductID
                                    select billInfo.Quantity * product.Price;

                totalMoney += decimal.Parse(queryBillinfo.First().ToString());
            }
            tbTotalRevemue.Text = totalMoney.ToString();

            var queryProductMax = from bill in myCoffeeStore.tblBILL
                                  join billInfo in myCoffeeStore.tblBILL_INFO on bill.BillID equals billInfo.BillID
                                  join product in myCoffeeStore.tblPRODUCT on billInfo.ProductID equals product.ProductID
                                  where bill.OrderDate >= datestart && bill.OrderDate <= dateend
                                  group billInfo by new { product.ProductName } into g
                                  select new
                                  {
                                      ProductName = g.Key.ProductName,
                                      TotalQuantity = g.Sum(billInfo => billInfo.Quantity)
                                  };

            dgcProduct.DataSource = queryProductMax.OrderByDescending(item => item.TotalQuantity).ToList();
        }

        private void dgvStatistical_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if(i >= 0 )
            {
                int billID = int.Parse(dgvStatistical.Rows[i].Cells["BillID"].Value.ToString());
                
                var queryBillinfo = from item in myCoffeeStore.tblBILL_INFO
                                    join item1 in myCoffeeStore.tblPRODUCT on item.ProductID equals item1.ProductID
                                    where item.BillID == billID
                                    select new { ProductName = item1.ProductName, Quantity = item.Quantity};
                dgvBillinfo.DataSource = queryBillinfo.ToList();
            }
        }
    }
}
