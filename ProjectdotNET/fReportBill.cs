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
        string Billid;
        public fReportBill(string BillID)
        {
            InitializeComponent();
            Billid = BillID;
        }

        private void fReportBill_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.report_BillTableAdapter.Fill(this.cOFFEESTOREDataBill.Report_Bill, int.Parse(Billid));
            this.report_BillInfoTableAdapter.Fill(this.cOFFEESTOREDataBill.Report_BillInfo, int.Parse(Billid));
            this.rpvBill.RefreshReport();
        }
    }
}
