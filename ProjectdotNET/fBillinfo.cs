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
    public partial class fBillinfo: Form
    {
        public fBillinfo()
        {
            InitializeComponent();
        }

        DBServices db = new DBServices();
        private bool AddNew = false;

        private void LoadGridDataBillinfo()
        {
            dgvBillinfo.DataSource = db.getData("SELECT * FROM tblBILL_INFO");
        }

        private void LoadGridDataProduct()
        {
            string sql = "SELECT * FROM tblProduct";
            cbProductID.ValueMember = "ProductID";
            cbProductID.DisplayMember = "ProductName";
            cbProductID.DataSource = db.getData(sql);
        }

        private void fBillinfo_Load(object sender, EventArgs e)
        {
            LoadGridDataBillinfo();
            LoadGridDataProduct();
        }

        private void dgvBillinfo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if(i >= 0 )
            {
                tbBillID.Text = dgvBillinfo.Rows[i].Cells["BillID"].Value.ToString();
                cbProductID.SelectedValue = dgvBillinfo.Rows[i].Cells["ProductID"].Value.ToString();
                tbQuantity.Text = dgvBillinfo.Rows[i].Cells["Quantity"].Value.ToString();
            }
        }

        private void setEnable(bool check)
        {
            tbBillID.Enabled = check;
            cbProductID.Enabled = check;
            tbQuantity.Enabled = check;
            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnAdd.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnExit.Enabled = !check;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setEnable(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AddNew)
            {
                string BillID = tbBillID.Text;
                string ProductID = cbProductID.SelectedValue.ToString();
                string Quantity = tbQuantity.Text;
                string sql = string.Format("INSERT INTO tblBILL_INFO VALUES ({0}, {1}, {2})", BillID, ProductID, Quantity);
                db.runQuery(sql);
                LoadGridDataBillinfo();
            }
            else
            {
                string BillID = tbBillID.Text;
                string ProductID = cbProductID.SelectedValue.ToString();
                string Quantity = tbQuantity.Text;
                string sql = string.Format("UPDATE tblBILL_INFO SET Quantity = {0} WHERE BillID = {1} AND ProductID = {2}", Quantity, BillID, ProductID);
                db.runQuery(sql);
                LoadGridDataBillinfo();
            }
            setEnable(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setEnable(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Thông báo",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string BillID = tbBillID.Text;
                string ProductID = cbProductID.SelectedValue.ToString();
                string sql = string.Format("DELETE FROM tblBILL_INFO WHERE BillID = {0} AND ProductID = {1}", BillID, ProductID);
                db.runQuery(sql);
                LoadGridDataBillinfo();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setEnable(true);
            AddNew = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
