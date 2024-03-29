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
    public partial class Product_ADO : Form
    {
        public Product_ADO()
        {
            InitializeComponent();
        }

        DBServices db = new DBServices();
        bool AddNew = false;

        private void Product_ADO_Load(object sender, EventArgs e)
        {
            LayDuLieu();
            LayDulieuCategory();
        }

        private void LayDuLieu()
        {
            dgvProduct.DataSource = db.GetData("SELECT * FROM tblPRODUCT");
        }

        private void LayDulieuCategory()
        {
            string sql = "SELECT * FROM tblCATEGORY";
            cbCategoryID.DisplayMember = "CategoryName";
            cbCategoryID.ValueMember = "CategoryID";
            cbCategoryID.DataSource = db.GetData(sql);
        }

        private void dgvProduct_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtProductID.Text = dgvProduct.Rows[i].Cells["ProductID"].Value.ToString();
            txtProductName.Text = dgvProduct.Rows[i].Cells["ProductName"].Value.ToString();
            cbCategoryID.SelectedValue = dgvProduct.Rows[i].Cells["CategoryID"].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[i].Cells["Price"].Value.ToString();
            txtUnit.Text = dgvProduct.Rows[i].Cells["Unit"].Value.ToString();
            txtDescription.Text = dgvProduct.Rows[i].Cells["Description"].Value.ToString();
        }

        private void setEnable(bool check)
        {
            txtProductID.Enabled = false;
            txtProductName.Enabled = check;
            txtPrice.Enabled = check;
            cbCategoryID.Enabled = check;
            txtUnit.Enabled = check;
            txtDescription.Enabled = check;
            btnAdd.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnExit.Enabled = !check;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtUnit.Clear();
            txtDescription.Clear();
            AddNew = true;
            setEnable(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AddNew)
            {
                string ProductName = txtProductName.Text;
                float Price = float.Parse(txtPrice.Text);
                string CategoryID = cbCategoryID.SelectedValue.ToString();
                string Unit = txtUnit.Text;
                string Description = txtDescription.Text;
                string sql = string.Format("INSERT INTO tblPRODUCT VALUES (N'{0}', {1}, {2}, N'{3}', N'{4}')",
                    ProductName, CategoryID, Price, Unit, Description);
                db.runQuery(sql);
                LayDuLieu();
            }
            else
            {
                string ProductID = txtProductID.Text;
                string ProductName = txtProductName.Text;
                float Price = float.Parse(txtPrice.Text);
                string CategoryID = cbCategoryID.SelectedValue.ToString();
                string Unit = txtUnit.Text;
                string Description = txtDescription.Text;
                string sql = string.Format("UPDATE tblPRODUCT SET ProductName = N'{0}', CategoryID = {1}, " +
                    "Price = {2}, Unit = N'{3}', Description = N'{4}' WHERE ProductID = {5}", ProductName,
                    CategoryID, Price, Unit, Description, ProductID);
                db.runQuery(sql);
                LayDuLieu();
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
                int ProductID = int.Parse(txtProductID.Text);
                string sql = string.Format("DELETE FROM tblPRODUCT WHERE ProductID = {0}", ProductID);
                db.runQuery(sql);
                LayDuLieu();
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
