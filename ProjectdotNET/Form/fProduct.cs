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
    public partial class fProduct : Form
    {
        public fProduct()
        {
            InitializeComponent();
        }

        COFFEESTOREEntities myCoffeeStore = new COFFEESTOREEntities();
        bool AddNew = false;

        private void Product_ADO_Load(object sender, EventArgs e)
        {
            LoadGridDataProduct();
            LoadGridDataCategory();
        }

        private void LoadGridDataProduct()
        {
            var queryProduct = from item in myCoffeeStore.tblPRODUCT
                               select new
                               {
                                   ProductID = item.ProductID,
                                   ProductName = item.ProductName,
                                   CategoryID = item.CategoryID,
                                   Price = item.Price,
                                   Unit = item.Unit,
                                   Description = item.Description
                               };
            dgvProduct.DataSource = queryProduct.ToList();
        }

        private void LoadGridDataCategory()
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
            if(i >= 0)
            {
                tbProductID.Text = dgvProduct.Rows[i].Cells["ProductID"].Value.ToString();
                tbProductName.Text = dgvProduct.Rows[i].Cells["ProductName"].Value.ToString();
                cbCategoryID.SelectedValue = dgvProduct.Rows[i].Cells["CategoryID"].Value.ToString();
                tbPrice.Text = dgvProduct.Rows[i].Cells["Price"].Value.ToString();
                tbUnit.Text = dgvProduct.Rows[i].Cells["Unit"].Value.ToString();
                tbDescription.Text = dgvProduct.Rows[i].Cells["Description"].Value.ToString();
            }
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
                tblPRODUCT product = new tblPRODUCT();
                product.ProductName = tbProductName.Text;
                product.CategoryID = int.Parse(cbCategoryID.SelectedValue.ToString());
                product.Price = (Decimal)float.Parse(tbPrice.Text);
                product.Unit = tbUnit.Text;
                product.Description = tbDescription.Text;
                myCoffeeStore.tblPRODUCT.Add(product);
                myCoffeeStore.SaveChanges();
                LoadGridDataProduct();
            }
            else
            {
                int ProductID = int.Parse(tbProductID.Text);
                var queryProduct = from item in myCoffeeStore.tblPRODUCT
                                   where item.ProductID == ProductID
                                   select item;
                tblPRODUCT product = queryProduct.First();
                product.ProductName = tbProductName.Text;
                product.CategoryID = int.Parse(cbCategoryID.SelectedValue.ToString());
                product.Price = (Decimal)float.Parse(tbPrice.Text);
                product.Unit = tbUnit.Text;
                product.Description = tbDescription.Text;
                myCoffeeStore.SaveChanges();
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
                var queryProduct = from item in myCoffeeStore.tblPRODUCT
                                   where item.ProductID == ProductID
                                   select item;
                myCoffeeStore.tblPRODUCT.Remove(queryProduct.First());
                myCoffeeStore.SaveChanges();
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
