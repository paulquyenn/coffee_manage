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
    public partial class FormEmployeeADO : Form
    {
        DBServices db = new DBServices();
        bool AddNew = false;
        public FormEmployeeADO()
        {
            InitializeComponent();
        }

        private void setEnable( bool check)
        {
            tbEmployeeID.Enabled = false;
            tbEmployeeName.Enabled = check;
            tbGender.Enabled = check;
            dtpBirthDate.Enabled = check;
            tbPhone.Enabled = check;
            tbAddress.Enabled = check;
            tbPosition.Enabled = check;
            tbSalary.Enabled = check;
            rtbDescription.Enabled = check;
            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnAdd.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnClose.Enabled = !check;
            dgvEmployeeADO.Enabled = !check;
        }

        private void LoadGridData()
        {
            string sql = "SELECT * FROM tblEMPLOYEE";
            dgvEmployeeADO.DataSource = db.getData(sql);
            setEnable(false);
        }

        private void FormEmployeeADO_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void dgvEmployeeADO_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                tbEmployeeID.Text = dgvEmployeeADO.Rows[i].Cells["EmployeeID"].Value.ToString();
                tbEmployeeName.Text = dgvEmployeeADO.Rows[i].Cells["EmployeeName"].Value.ToString();
                tbGender.Text = dgvEmployeeADO.Rows[i].Cells["Gender"].Value.ToString();
                dtpBirthDate.Text = dgvEmployeeADO.Rows[i].Cells["BirthDate"].Value.ToString();
                tbPhone.Text = dgvEmployeeADO.Rows[i].Cells["Phone"].Value.ToString();
                tbAddress.Text = dgvEmployeeADO.Rows[i].Cells["Address"].Value.ToString();
                tbPosition.Text = dgvEmployeeADO.Rows[i].Cells["Position"].Value.ToString();
                tbSalary.Text = dgvEmployeeADO.Rows[i].Cells["Salary"].Value.ToString();
                rtbDescription.Text = dgvEmployeeADO.Rows[i].Cells["Description"].Value.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setEnable(true);
            tbEmployeeID.Clear();
            tbEmployeeName.Clear();
            tbGender.Clear();
            tbPhone.Clear();
            tbAddress.Clear();
            tbPosition.Clear();
            tbSalary.Clear();
            rtbDescription.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbEmployeeName.Text.Trim() == "")
            {
                MessageBox.Show("Thông tin nhân viên không được để trống!", "Thông báo");
                tbEmployeeName.Focus();
                return;
            }
            string en = tbEmployeeName.Text;
            string gd = tbGender.Text;
            string bd = dtpBirthDate.Text;
            string ph = tbPhone.Text;
            string ar = tbAddress.Text;
            string po = tbPosition.Text;
            decimal sa = decimal.Parse(tbSalary.Text);
            string de = rtbDescription.Text;
            if (AddNew)
            {
                string sql = string.Format("INSERT INTO tblEMPLOYEE (EmployeeName, Gender, BirthDate, Phone, Address, Position, Salary, Description) VALUES " +
                    "(N'{0}', N'{1}', '{2}', N'{3}', N'{4}', N'{5}', {6}, N'{7}')", en, gd, bd, ph, ar, po, sa, de);
                db.runQuery(sql);
                LoadGridData();
            }
            else
            {
                int id = int.Parse(tbEmployeeID.Text);
                string sql = string.Format("UPDATE tblEmployee SET " +
                    "EmployeeName=N'{0}', " +
                    "Gender=N'{1}', " +
                    "BirthDate='{2}', " +
                    "Phone=N'{3}', " +
                    "Address=N'{4}', " +
                    "Position=N'{5}', " +
                    "Salary=N'{6}', " +
                    "Description=N'{7}' WHERE EmployeeID={8} ", en, gd, bd, ph, ar, po, sa, de, id);
                db.runQuery(sql);
                LoadGridData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddNew = false;
            setEnable(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setEnable(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int id = int.Parse(tbEmployeeID.Text);
                string sql = string.Format("delete from tblEMPLOYEE where EmployeeID={0}", id);
                db.runQuery(sql);
                LoadGridData();
            }
        }
    }
}
