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
    public partial class Product_LINQ : Form
    {
        public Product_LINQ()
        {
            InitializeComponent();
        }

        COFFEESTOREEntities myCoffeeStore = new COFFEESTOREEntities();
        private bool AddNew = false;

        private void Product_LINQ_Load(object sender, EventArgs e)
        {
            LayDuLieu();
            LayDulieuCategory();
        }

        private void LayDuLieu()
        {
            var queryCoffee = from item in myCoffeeStore.tblPRODUCT
                              select item;
            dgvProduct.DataSource = queryCoffee.ToList();
        }

        private void LayDulieuCategory()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM tblCATEGORY";
            cbCategoryID.DisplayMember = "CategoryName";
            cbCategoryID.ValueMember = "CategoryID";
            cbCategoryID.DataSource = db.getData(sql);
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
                tblPRODUCT product = new tblPRODUCT();
                product.ProductName = txtProductName.Text;
                product.CategoryID = int.Parse(cbCategoryID.Text);
                product.Price = (Decimal)float.Parse(txtPrice.Text);
                product.Unit = txtUnit.Text;
                product.Description = txtDescription.Text;
                myCoffeeStore.tblPRODUCT.Add(product);
                myCoffeeStore.SaveChanges();
                LayDuLieu();
            }
            else
            {
                int ProductID = int.Parse(txtProductID.Text);
                var queryProduct = from item in myCoffeeStore.tblPRODUCT
                                   where item.ProductID == ProductID
                                   select item;
                tblPRODUCT product = queryProduct.First();
                product.ProductName = txtProductName.Text;
                product.CategoryID = int.Parse(cbCategoryID.Text);
                product.Price = (Decimal)float.Parse(txtPrice.Text);
                product.Unit = txtUnit.Text;
                product.Description = txtDescription.Text;
                myCoffeeStore.SaveChanges();
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
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Thông báo",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int ProductID = int.Parse(txtProductID.Text);
                    var queryProduct = from item in myCoffeeStore.tblPRODUCT
                                       where item.ProductID == ProductID
                                       select item;
                    myCoffeeStore.tblPRODUCT.Remove(queryProduct.First());
                    myCoffeeStore.SaveChanges();
                    LayDuLieu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
