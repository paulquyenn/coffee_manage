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
    public partial class fProduct_ADO : Form
    {
        public fProduct_ADO()
        {
            InitializeComponent();
        }

        DBServices db = new DBServices();
        bool AddNew = false;

        private void Product_ADO_Load(object sender, EventArgs e)
        {
            LoadGridDataProduct();
            LoadGridDataCategory();
        }

        private void LoadGridDataProduct()
        {
            dgvProduct.DataSource = db.getData("SELECT * FROM tblPRODUCT");
        }

        private void LoadGridDataCategory()
        {
            string sql = "SELECT * FROM tblCATEGORY";
            cbCategoryID.DisplayMember = "CategoryName";
            cbCategoryID.ValueMember = "CategoryID";
            cbCategoryID.DataSource = db.getData(sql);
        }

        private void dgvProduct_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            tbProductID.Text = dgvProduct.Rows[i].Cells["ProductID"].Value.ToString();
            tbProductName.Text = dgvProduct.Rows[i].Cells["ProductName"].Value.ToString();
            cbCategoryID.SelectedValue = dgvProduct.Rows[i].Cells["CategoryID"].Value.ToString();
            tbPrice.Text = dgvProduct.Rows[i].Cells["Price"].Value.ToString();
            tbUnit.Text = dgvProduct.Rows[i].Cells["Unit"].Value.ToString();
            tbDescription.Text = dgvProduct.Rows[i].Cells["Description"].Value.ToString();
        }

        private void setEnable(bool check)
        {
            tbProductID.Enabled = false;
            tbProductName.Enabled = check;
            tbPrice.Enabled = check;
            cbCategoryID.Enabled = check;
            tbUnit.Enabled = check;
            tbDescription.Enabled = check;
            btnAdd.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnExit.Enabled = !check;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbProductID.Clear();
            tbProductName.Clear();
            tbPrice.Clear();
            tbUnit.Clear();
            tbDescription.Clear();
            AddNew = true;
            setEnable(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AddNew)
            {
                string ProductName = tbProductName.Text;
                float Price = float.Parse(tbPrice.Text);
                string CategoryID = cbCategoryID.SelectedValue.ToString();
                string Unit = tbUnit.Text;
                string Description = tbDescription.Text;
                string sql = string.Format("INSERT INTO tblPRODUCT VALUES (N'{0}', {1}, {2}, N'{3}', N'{4}')",
                    ProductName, CategoryID, Price, Unit, Description);
                db.runQuery(sql);
                LoadGridDataProduct();
            }
            else
            {
                string ProductID = tbProductID.Text;
                string ProductName = tbProductName.Text;
                float Price = float.Parse(tbPrice.Text);
                string CategoryID = cbCategoryID.SelectedValue.ToString();
                string Unit = tbUnit.Text;
                string Description = tbDescription.Text;
                string sql = string.Format("UPDATE tblPRODUCT SET ProductName = N'{0}', CategoryID = {1}, " +
                    "Price = {2}, Unit = N'{3}', Description = N'{4}' WHERE ProductID = {5}", ProductName,
                    CategoryID, Price, Unit, Description, ProductID);
                db.runQuery(sql);
                LoadGridDataProduct();
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
                int ProductID = int.Parse(tbProductID.Text);
                string sql = string.Format("DELETE FROM tblPRODUCT WHERE ProductID = {0}", ProductID);
                db.runQuery(sql);
                LoadGridDataProduct();
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
