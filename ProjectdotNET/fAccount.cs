using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectdotNET
{
    public partial class fAccount : Form
    {
        DBServices db = new DBServices();
        bool AddNew = false;
        public fAccount()
        {
            InitializeComponent();
        }

        private void setEnable(bool check)
        {
            tbAccountID.Enabled = false;
            tbUserName.Enabled = check;
            tbPassword.Enabled = check;
            cbTypeAccount.Enabled = check;
            btnAdd.Enabled = !check;
            btnCancel.Enabled = check;
            btnClose.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnSave.Enabled = check;
            dgvAccount.Enabled = !check;
        }

        private void LoadGridData()
        {
            string sql = "select * from tblACCOUNT";
            dgvAccount.DataSource = db.getData(sql);
            setEnable(false);
        }
        private void dgvAccount_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                tbAccountID.Text = dgvAccount.Rows[i].Cells["AccountID"].Value.ToString();
                tbUserName.Text = dgvAccount.Rows[i].Cells["UserName"].Value.ToString();
                tbPassword.Text = dgvAccount.Rows[i].Cells["PassWord"].Value.ToString();
                cbTypeAccount.Text = dgvAccount.Rows[i].Cells["TypeAccount"].Value.ToString();
            }
        }

        private void fAccount_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setEnable(true);
            tbAccountID.Clear();
            tbUserName.Clear();
            tbPassword.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.Trim() == "")
            {
                MessageBox.Show("Thông tin tài khoản không được để trống!", "Thông báo");
                tbUserName.Focus();
                return;
            }
            string un = tbUserName.Text;
            string pw = tbPassword.Text;
            int ta = int.Parse(cbTypeAccount.Text);
            if (AddNew)
            {
                string sql = string.Format("INSERT INTO tblACCOUNT (UserName, PassWord, TypeAccount) VALUES " +
                    "(N'{0}', N'{1}', '{2}')", un, pw, ta);
                db.runQuery(sql);
                LoadGridData();
            }
            else
            {
                int id = int.Parse(tbAccountID.Text);
                string sql = string.Format("UPDATE tblACCOUNT SET " +
                    "UserName=N'{0}', " +
                    "PassWord=N'{1}', " +
                    "TypeAccount={2}' WHERE AccountID={3} ", un, pw, ta, id);
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
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int id = int.Parse(tbAccountID.Text);
                string sql = string.Format("delete from tblACCOUNT where AccountID={0}", id);
                db.runQuery(sql);
                LoadGridData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setEnable(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
