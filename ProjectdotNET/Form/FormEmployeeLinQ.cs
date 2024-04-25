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
    public partial class FormEmployeeLinQ : Form
    {
        COFFEESTOREEntities myCoffee = new COFFEESTOREEntities();
        private bool AddNew = false;
        public FormEmployeeLinQ()
        {
            InitializeComponent();
        }

        private void LoadGridData()
        {
            var queryCoffee = from item in myCoffee.tblEMPLOYEE
                              select item;
            dgvEmployeeLinQ.DataSource = queryCoffee.ToList();
        }

        private void FormEmployeeLinQ_Load(object sender, EventArgs e)
        {
            LoadGridData();
            setEnable(false);
        }

        private void setEnable(bool check)
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
            dgvEmployeeLinQ.Enabled = !check;
        }

        private void dgvEmployeeLinQ_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                tbEmployeeID.Text = dgvEmployeeLinQ.Rows[i].Cells["EmployeeID"].Value.ToString();
                tbEmployeeName.Text = dgvEmployeeLinQ.Rows[i].Cells["EmployeeName"].Value.ToString();
                tbGender.Text = dgvEmployeeLinQ.Rows[i].Cells["Gender"].Value.ToString();
                dtpBirthDate.Text = dgvEmployeeLinQ.Rows[i].Cells["BirthDate"].Value.ToString();
                tbPhone.Text = dgvEmployeeLinQ.Rows[i].Cells["Phone"].Value.ToString();
                tbAddress.Text = dgvEmployeeLinQ.Rows[i].Cells["Address"].Value.ToString();
                tbPosition.Text = dgvEmployeeLinQ.Rows[i].Cells["Position"].Value.ToString();
                tbSalary.Text = dgvEmployeeLinQ.Rows[i].Cells["Salary"].Value.ToString();
                rtbDescription.Text = dgvEmployeeLinQ.Rows[i].Cells["Description"].Value.ToString();
            }
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
                MessageBox.Show("Thông tin không được để trống!", "Thông Báo");
                tbEmployeeName.Focus();
                return;
            }
            if (AddNew)
            {
                tblEMPLOYEE myEmployee = new tblEMPLOYEE();
                myEmployee.EmployeeName = tbEmployeeName.Text;
                myEmployee.Gender = tbGender.Text;
                myEmployee.BirthDate = Convert.ToDateTime(dtpBirthDate.Text);
                myEmployee.Phone = tbPhone.Text;
                myEmployee.Address = tbAddress.Text;
                myEmployee.Position = tbPosition.Text;
                myEmployee.Salary = Convert.ToDecimal(tbSalary.Text);
                myEmployee.Description = rtbDescription.Text;
                myCoffee.tblEMPLOYEE.Add(myEmployee);
                myCoffee.SaveChanges();
                LoadGridData();
            }
            else
            {
                int id = int.Parse(tbEmployeeID.Text);
                var queryCoffee = from item in myCoffee.tblEMPLOYEE
                                  where (item.EmployeeID == id)
                                  select item;
                tblEMPLOYEE itemUse = queryCoffee.First();
                itemUse.EmployeeName = tbEmployeeName.Text;
                itemUse.Gender = tbGender.Text;
                itemUse.BirthDate = Convert.ToDateTime(dtpBirthDate.Text);
                itemUse.Phone = tbPhone.Text;
                itemUse.Address = tbAddress.Text;
                itemUse.Position = tbPosition.Text;
                itemUse.Salary = Convert.ToDecimal(tbSalary.Text);
                itemUse.Description = rtbDescription.Text;
                myCoffee.SaveChanges();
                LoadGridData();
            }
            setEnable(false);
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
            try
            {
                int id = int.Parse(tbEmployeeID.Text);
                var queryDelete = from item in myCoffee.tblEMPLOYEE
                                  where (item.EmployeeID == id)
                                  select item;
                myCoffee.tblEMPLOYEE.Remove(queryDelete.First());
                myCoffee.SaveChanges();
                LoadGridData();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
