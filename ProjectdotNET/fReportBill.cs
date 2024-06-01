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
    public partial class fReportBill : Form
    {
        private string BillID;

        public string ID {  get; set; }

        public fReportBill(string Billid)
        {
            InitializeComponent();
            BillID = Billid;
        }

        COFFEESTOREEntities myCoffeeStore = new COFFEESTOREEntities();

        private void fReportBill_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.report_BillTableAdapter.Fill(this.cOFFEESTOREDataSet.Report_Bill, int.Parse(BillID));
            this.report_BillInfoTableAdapter.Fill(this.cOFFEESTOREDataSet.Report_BillInfo, int.Parse(BillID));
            this.reportViewer1.RefreshReport();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {
            int BillId = int.Parse(BillID);
            var queryBill = from item in myCoffeeStore.tblBILL
                            where item.BillID == BillId
                            select item;

            tblBILL bill = queryBill.First();
            bill.Status = "Đã thanh toán";
            myCoffeeStore.SaveChanges();
            this.Close();
        }
    }
}
