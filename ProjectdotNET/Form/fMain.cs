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
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private Form currentChildForm;

        private void OpenChildForm(Form childForm)
        {
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormEmployeeADO());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            fProduct fproduct_ADO = new fProduct();
            fproduct_ADO.TopLevel = false;

            pnlMain.Controls.Add(fproduct_ADO);

            fproduct_ADO.BringToFront();
            fproduct_ADO.Show();
        }

        private void btnBill_Info_Click(object sender, EventArgs e)
        {
            fBillinfo fbillinfo = new fBillinfo();
            fbillinfo.TopLevel = false;

            pnlMain.Controls.Add(fbillinfo);

            fbillinfo.BringToFront();
            fbillinfo.Show();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            fBill fbill = new fBill();
            fbill.TopLevel = false;

            pnlMain.Controls.Add(fbill);

            fbill.BringToFront();
            fbill.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            fCategoryADO fcategoryADO = new fCategoryADO();
            fcategoryADO.TopLevel = false;

            pnlMain.Controls.Add(fcategoryADO);

            fcategoryADO.BringToFront();
            fcategoryADO.Show();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            fRevenue frevenue = new fRevenue();
            frevenue.TopLevel = false;

            pnlMain.Controls.Add(frevenue);

            frevenue.BringToFront();
            frevenue.Show();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {

        }
    }
}
