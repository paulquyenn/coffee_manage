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
            fProduct_ADO fproduct_ADO = new fProduct_ADO();
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
            fBill_ADO fbill = new fBill_ADO();
            fbill.TopLevel = false;

            pnlMain.Controls.Add(fbill);

            fbill.BringToFront();
            fbill.Show();
        }
    }
}
