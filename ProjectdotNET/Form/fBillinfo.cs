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
                                select new
                                {
                                    BillID = item.BillID,
                                    ProductID = item.ProductID,
                                    Quantity = item.Quantity
                                };
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
            //kiểm tra dữ liệu nhập vào
            if (cbBillID.SelectedValue == null)
            {
                MessageBox.Show("Thông tin mã đơn hàng không đúng!", "Thông báo");
                goto index;
            }
            if(cbProductID.SelectedValue == null)
            {
                MessageBox.Show("Thông tin sản phẩm không đúng!", "Thông báo");
                goto index;
            }
            int a;
            if(tbQuantity.Text.Trim() == "" || !int.TryParse(tbQuantity.Text, out a))
            {
                MessageBox.Show("Thông tin số lượng không đúng!", "Thông báo");
                goto index;
            }

            if (AddNew)
            {
                string BillID = (cbBillID.SelectedValue.ToString());
                string ProductID = (cbProductID.SelectedValue.ToString());
                string Quantity = (tbQuantity.Text.ToString());
                DBServices db = new DBServices();
                string sql = string.Format("INSERT INTO tblBILL_INFO VALUES ({0}, {1}, {2})", BillID, ProductID, Quantity);
                db.runQuery(sql);
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
            index:
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
