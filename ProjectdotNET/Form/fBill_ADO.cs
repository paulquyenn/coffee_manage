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
    public partial class fBill_ADO : Form
    {
        public fBill_ADO()
        {
            InitializeComponent();
        }

        DBServices db = new DBServices();
        private bool AddNew = false;

        private void LoadGridDataBill()
        {
            dgvBill.DataSource = db.getData("SELECT * FROM tblBILL");
        }

        private void LoadGridDataEmployeeID()
        {
            string sql = "SELECT * FROM tblEMPLOYEE";
            cbEmployeeID.DisplayMember = "EmployeeName";
            cbEmployeeID.ValueMember = "EmployeeID";
            cbEmployeeID.DataSource = db.getData(sql);
        }

        private void LoadGridDataTableID()
        {
            string sql = "SELECT * FROM tblTABLE";
            cbTableID.ValueMember = "TableID";
            cbTableID.DataSource = db.getData(sql);
        }

        private void fBill_ADO_Load(object sender, EventArgs e)
        {
            LoadGridDataBill();
            LoadGridDataEmployeeID();
            LoadGridDataTableID();
        }

        private void dgvBill_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                tbBillID.Text = dgvBill.Rows[i].Cells["BillID"].Value.ToString();
                cbEmployeeID.SelectedValue = dgvBill.Rows[i].Cells["EmployeeID"].Value.ToString();
                dtOrderDate.Text = dgvBill.Rows[i].Cells["OrderDate"].Value.ToString();
                cbTableID.SelectedValue = dgvBill.Rows[i].Cells["TableID"].Value.ToString();
                cbStatus.SelectedItem = dgvBill.Rows[i].Cells["Status"].Value.ToString();
            }
        }

        private void setEnable(bool check)
        {
            tbBillID.Enabled = false;
            cbEmployeeID.Enabled = check;
            dtOrderDate.Enabled = check;
            cbTableID.Enabled = check;
            cbStatus.Enabled = check;
            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnAdd.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnExit.Enabled = !check;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbBillID.Clear();
            AddNew = true;
            setEnable(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AddNew)
            {
                string EmployeeID = cbEmployeeID.SelectedValue.ToString();
                string OrderDate = dtOrderDate.Text;
                string TableID = cbTableID.SelectedValue.ToString();
                string Status = cbStatus.SelectedItem.ToString();
                string sql = string.Format("INSERT INTO tblBILL VALUES ({0}, '{1}', {2}, N'{3}')", EmployeeID, OrderDate, TableID, Status);
                db.runQuery(sql);
                LoadGridDataBill();
            }
            else
            {
                string BillID = tbBillID.Text;
                string EmployeeID = cbEmployeeID.SelectedValue.ToString();
                string OrderDate = dtOrderDate.Text;
                string TableID = cbTableID.SelectedValue.ToString();
                string Status = cbStatus.SelectedItem.ToString();
                string sql = string.Format("UPDATE tblBILL SET EmployeeID = {0}, OrderDate = '{1}', TableID = {2}, " +
                    "Status = N'{3}' WHERE BillID = {4}", EmployeeID, OrderDate, TableID, Status, BillID);
                db.runQuery(sql);
                LoadGridDataBill();
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
                string sql = string.Format("DELETE FROM tblBILL WHERE BillID = {0}", BillID);
                db.runQuery(sql);
                LoadGridDataBill();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddNew = false;
            setEnable(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
