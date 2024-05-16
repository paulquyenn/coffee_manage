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

        COFFEESTOREEntities myCoffeeStore = new COFFEESTOREEntities();
        private bool AddNew = false;

        private void LoadGridDataBillinfo()
        {
            var queryBillinfo = from item in myCoffeeStore.tblBILL_INFO
                                select item;
            dgvBillinfo.DataSource = queryBillinfo.ToList();
        }


       private void LoadGridDataBill()
       {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM tblBILL";
            cbBillID.ValueMember = "BillID";
            cbBillID.DataSource = db.getData(sql);
       }

        private void LoadGridDataProduct()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM tblPRODUCT";
            cbProductID.ValueMember = "ProductID";
            cbProductID.DisplayMember = "ProductName";
            cbProductID.DataSource = db.getData(sql);
        }

        private void fBillinfo_Load(object sender, EventArgs e)
        {
            LoadGridDataBillinfo();
            LoadGridDataBill();
            LoadGridDataProduct();
        }

        private void dgvBillinfo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if(i >= 0 )
            {
                cbBillID.SelectedValue = dgvBillinfo.Rows[i].Cells["BillID"].Value.ToString();
                cbProductID.SelectedValue = dgvBillinfo.Rows[i].Cells["ProductID"].Value.ToString();
                tbQuantity.Text = dgvBillinfo.Rows[i].Cells["Quantity"].Value.ToString();
            }
        }

        private void setEnable(bool check)
        {
            cbBillID.Enabled = check;
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
                tblBILL_INFO Billinfo = new tblBILL_INFO();
                Billinfo.BillID = int.Parse(cbBillID.SelectedValue.ToString());
                Billinfo.ProductID = int.Parse(cbProductID.SelectedValue.ToString());
                Billinfo.Quantity = int.Parse(tbQuantity.Text.ToString());
                myCoffeeStore.tblBILL_INFO.Add(Billinfo);
                myCoffeeStore.SaveChanges();
                LoadGridDataBillinfo();
            }
            else
            {
                int BillID = int.Parse(cbBillID.SelectedValue.ToString());
                int ProductID = int.Parse(cbProductID.SelectedValue.ToString());
                var queryBillinfo = from item in myCoffeeStore.tblBILL_INFO
                                    where item.BillID == BillID && item.ProductID == ProductID
                                    select item;
                tblBILL_INFO Billinfo = queryBillinfo.First();
                Billinfo.Quantity = int.Parse(tbQuantity.Text);
                myCoffeeStore.SaveChanges();
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
                int BillID = int.Parse(cbBillID.SelectedValue.ToString());
                int ProductID = int.Parse(cbProductID.SelectedValue.ToString());
                var queryBillinfo = from item in myCoffeeStore.tblBILL_INFO
                                    where item.BillID == BillID && item.ProductID == ProductID
                                    select item;
                myCoffeeStore.tblBILL_INFO.Remove(queryBillinfo.First());
                myCoffeeStore.SaveChanges();
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
