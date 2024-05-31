using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectdotNET
{
    public partial class fBill : Form
    {
        public fBill()
        {
            InitializeComponent();
        }

        COFFEESTOREEntities myCoffeeStore = new COFFEESTOREEntities();
        private bool AddNew = false;

        private void LoadGridDataBill()
        {
            var queryBill = from item in myCoffeeStore.tblBILL
                            select new
                            {
                                BillID = item.BillID,
                                EmployeeID = item.EmployeeID,
                                OrderDate = item.OrderDate,
                                TableID = item.TableID,
                                Status = item.Status
                            };
            dgvBill.DataSource = queryBill.ToList();
        }

        private void LoadGridDataEmployeeID()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM tblEMPLOYEE";
            cbEmployeeID.DisplayMember = "EmployeeName";
            cbEmployeeID.ValueMember = "EmployeeID";
            cbEmployeeID.DataSource = db.getData(sql);
        }

        private void LoadGridDataTableID()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM tblTABLE WHERE Status = N'Chưa'";
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
                cbTableID.Text = dgvBill.Rows[i].Cells["TableID"].Value.ToString();
                cbStatus.Text = dgvBill.Rows[i].Cells["Status"].Value.ToString();
            }
        }

        private void setEnable(bool check)
        {
            tbBillID.Enabled = false;
            cbEmployeeID.Enabled = check;
            dtOrderDate.Enabled = check;
            cbTableID.Enabled = check;
            //cbStatus.Enabled = check;
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
            cbStatus.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AddNew)
            {
                tblBILL bill = new tblBILL();
                bill.EmployeeID = int.Parse(cbEmployeeID.SelectedValue.ToString());
                bill.OrderDate = dtOrderDate.Value;
                bill.TableID = int.Parse(cbTableID.SelectedValue.ToString());
                bill.Status = cbStatus.Text;
                myCoffeeStore.tblBILL.Add(bill);
                myCoffeeStore.SaveChanges();
                LoadGridDataBill();
            }
            else
            {
                int BillID = int.Parse(tbBillID.Text);
                var queryBill = from item in myCoffeeStore.tblBILL
                                where item.BillID == BillID
                                select item;
                tblBILL bill = queryBill.First();
                bill.EmployeeID = int.Parse(cbEmployeeID.SelectedValue.ToString());
                bill.OrderDate = dtOrderDate.Value;
                bill.TableID = int.Parse(cbTableID.Text);
                bill.Status = cbStatus.Text;
                myCoffeeStore.SaveChanges();
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
                int BillID = int.Parse(tbBillID.Text);

                var queryBill = from item in myCoffeeStore.tblBILL
                            where item.BillID == BillID
                            select item;

                myCoffeeStore.tblBILL.Remove(queryBill.First());
                myCoffeeStore.SaveChanges();
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

        private void btnPay_Click(object sender, EventArgs e)
        {
            int BillID = int.Parse(tbBillID.Text);
            var queryBill = from item in myCoffeeStore.tblBILL
                            where item.BillID == BillID
                            select item;
            if (queryBill.First().Status == "Đã thanh toán")
            {
                MessageBox.Show("Đơn hàng đã thanh toán", "Thông báo");
                return;
            }

            fReportBill freportbill = new fReportBill(tbBillID.Text);
            freportbill.ShowDialog();

            
            tblBILL bill = queryBill.First();
            cbStatus.SelectedIndex = 1;
            bill.Status = cbStatus.Text;
            myCoffeeStore.SaveChanges();
            LoadGridDataBill();
        }
    }
}
