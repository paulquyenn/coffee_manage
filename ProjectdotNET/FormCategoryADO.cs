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
    public partial class FormCategoryADO : Form
    {
        DBServices db = new DBServices();
        bool AddNew = false;

        public FormCategoryADO()
        {
            InitializeComponent();
        }

        private void setEnable(bool check)
        {
            txbCategoryID.Enabled = false;
            txbCategoryName.Enabled = check;
            rtbDescription.Enabled = check;
            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnAdd.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnClose.Enabled = !check;
            dgvCategoryADO.Enabled = !check;
        }

        private void FormCategoryADO_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void LoadGridData()
        {
            string sql = "SELECT * FROM tblCATEGORIES";
            dgvCategoryADO.DataSource = db.getData(sql);
            setEnable(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setEnable(true);
            txbCategoryID.Clear();
            txbCategoryName.Clear();
            rtbDescription.Clear();
            txbCategoryName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setEnable(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ( txbCategoryName.Text.Trim() == "")
            {
                MessageBox.Show("Thông tin loại sản phẩm không được để trống!", "Thông báo");
                txbCategoryName.Focus();
                return;
            }
            string cn = txbCategoryName.Text;
            string de = rtbDescription.Text;
            if( AddNew )
            {
                string sql = string.Format("INSERT INTO tblCATEGORIES (CategoryName, Description) VALUES " + 
                    "(N'{0}', N'{1}')", cn, de);
                db.runQuery(sql);
                LoadGridData();
            }
            else
            {
                int id = int.Parse (txbCategoryID.Text);
                string sql = string.Format("UPDATE tblCATEGORIES SET " +
                    "CategoryName=N'{0}'," +
                    "Description=N'{1}' WHERE CategoryID={2}", cn, de, id);
                db.runQuery(sql);
                LoadGridData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddNew = false;
            setEnable(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ( MessageBox.Show("Bạn có muốn xóa không", "Thông Báo", 
                MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                int id = int.Parse( txbCategoryID.Text );
                string sql = string.Format("DELETE FROM tblCATEGORIES WHERE CategoryID={0}" , id);
                db.runQuery(sql);
                LoadGridData();
            }
        }

        private void dgvCategoryADO_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txbCategoryID.Text = dgvCategoryADO.Rows[i].Cells["CategoryID"].Value.ToString();
                txbCategoryName.Text = dgvCategoryADO.Rows[i].Cells["CategoryName"].Value.ToString();
                rtbDescription.Text = dgvCategoryADO.Rows[i].Cells["Description"].Value.ToString();
            }
        }
    }
}
