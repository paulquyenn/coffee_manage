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
            lbTitle.Text = btnEmployee.Text;
            OpenChildForm(new FormEmployeeADO());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            lbTitle.Text = btnProduct.Text;
            OpenChildForm(new fProduct());
        }

        private void btnBill_Info_Click(object sender, EventArgs e)
        {
            lbTitle.Text = btnBill_Info.Text;
            OpenChildForm(new fBillinfo());
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            lbTitle.Text = btnBill.Text;
            OpenChildForm(new fBill());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            lbTitle.Text = btnCategory.Text;
            OpenChildForm(new fCategoryADO());
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            lbTitle.Text = btnRevenue.Text;
            OpenChildForm(new fRevenue());
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            lbTitle.Text = btnTable.Text;
            OpenChildForm(new FormTableADO());
        }

    }
}
