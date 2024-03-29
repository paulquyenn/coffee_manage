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
    public partial class FormCategoryLinQ : Form
    {
        COFFEESTOREEntities myCoffee = new COFFEESTOREEntities();
        private bool AddNew = false;
        public FormCategoryLinQ()
        {
            InitializeComponent();
        }

        private void FormCategoryLinQ_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void LoadGridData()
        {
            var queryCoffee = from item in myCoffee.tblCATEGORY
                              select item;
            dgvCategoryLinQ.DataSource = queryCoffee.ToList();       
        }

        private void setEnable(bool check)
        {
            tbCategoryID.Enabled = false;
            tbCategoryName.Enabled = check;
            rtbDescription.Enabled = check;
            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnAdd.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnClose.Enabled = !check;
            dgvCategoryLinQ.Enabled = !check;
        }
        private void dgvCategoryLinQ_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            tbCategoryID.Text = dgvCategoryLinQ.Rows[i].Cells["CategoryID"].Value.ToString();
            tbCategoryName.Text = dgvCategoryLinQ.Rows[i].Cells["CategoryName"].Value.ToString();
            rtbDescription.Text = dgvCategoryLinQ.Rows[i].Cells["Description"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbCategoryID.Clear();
            tbCategoryName.Clear();
            rtbDescription.Clear();
            AddNew = true;
            setEnable(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbCategoryID.Text.Trim() == "")
            {
                MessageBox.Show("Thông tin không được để trống!", "Thông Báo");
                tbCategoryName.Focus();
                return;
            }
            if (AddNew)
            {
                tblCATEGORY myCategory = new tblCATEGORY();
                myCategory.CategoryName = tbCategoryName.Text;
                myCategory.Description = rtbDescription.Text;
                myCoffee.tblCATEGORY.Add(myCategory);
                myCoffee.SaveChanges();
                LoadGridData();
            }
            else
            {
                int id = int.Parse(tbCategoryID.Text);
                var queryCoffee = from item in myCoffee.tblCATEGORY
                                  where (item.CategoryID == id)
                                  select item;
                tblCATEGORY itemUse = queryCoffee.First();
                itemUse.CategoryName = tbCategoryName.Text;
                itemUse.Description = rtbDescription.Text;
                myCoffee.SaveChanges();
                LoadGridData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(tbCategoryID.Text);
                var queryDelete = from item in myCoffee.tblCATEGORY
                                  where (item.CategoryID == id)
                                  select item;
                myCoffee.tblCATEGORY.Remove(queryDelete.First());
                myCoffee.SaveChanges();
                LoadGridData();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setEnable(false);
            tbCategoryID.Clear();
            tbCategoryName.Clear();
            rtbDescription.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddNew = false;
            setEnable(true);
        }
    }
}
