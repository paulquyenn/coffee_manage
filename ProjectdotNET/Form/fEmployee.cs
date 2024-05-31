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
    public partial class fEmployee : Form
    {
        COFFEESTOREEntities myCoffee = new COFFEESTOREEntities();
        private bool AddNew = false;
        public fEmployee()
        {
            InitializeComponent();
        }

        private void setEnable(bool check)
        {
            tbEmployeeId.Enabled = false;
            tbEmployeeName.Enabled = check;
            cbGender.Enabled = check;
            dtpBirthDate.Enabled = check;
            tbPhone.Enabled = check;
            tbAddress.Enabled = check;
            tbPosition.Enabled = check;
            cbShift.Enabled = check;
            tbSalary.Enabled = check;
            tbDescription.Enabled = check;
            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnAdd.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnClose.Enabled = !check;
            dgvEmployee.Enabled = !check;
        }

        private void LoadGridData()
        {
            var query = from item in myCoffee.tblEMPLOYEE
                        select new
                        {
                            EmployeeID = item.EmployeeID,
                            EmployeeName = item.EmployeeName,
                            Gender = item.Gender,
                            BirthDate = item.BirthDate,
                            Phone = item.Phone,
                            Address = item.Address,
                            Position = item.Position,
                            Shift = item.Shift,
                            Salary = item.Salary,
                            Description = item.Description,
                        };
            dgvEmployee.DataSource = query.ToList();
        }

        private void dgvEmployee_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                tbEmployeeId.Text = dgvEmployee.Rows[i].Cells["EmployeeID"].Value.ToString();
                tbEmployeeName.Text = dgvEmployee.Rows[i].Cells["EmployeeName"].Value.ToString();
                cbGender.Text = dgvEmployee.Rows[i].Cells["Gender"].Value.ToString();
                dtpBirthDate.Text = dgvEmployee.Rows[i].Cells["BirthDate"].Value.ToString();
                tbPhone.Text = dgvEmployee.Rows[i].Cells["Phone"].Value.ToString();
                tbAddress.Text = dgvEmployee.Rows[i].Cells["Address"].Value.ToString();
                tbPosition.Text = dgvEmployee.Rows[i].Cells["Position"].Value.ToString();
                cbShift.Text = dgvEmployee.Rows[i].Cells["Shift"].Value.ToString();
                tbSalary.Text = dgvEmployee.Rows[i].Cells["Salary"].Value.ToString();
                tbDescription.Text = dgvEmployee.Rows[i].Cells["Description"].Value.ToString();
            }
        }

        private void fEmployee_Load(object sender, EventArgs e)
        {
            LoadGridData();
            setEnable(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setEnable(true);
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
                myEmployee.Gender = cbGender.Text;
                myEmployee.BirthDate = Convert.ToDateTime(dtpBirthDate.Text);
                myEmployee.Phone = tbPhone.Text;
                myEmployee.Address = tbAddress.Text;
                myEmployee.Position = tbPosition.Text;
                myEmployee.Shift = cbShift.Text;
                myEmployee.Salary = Convert.ToDecimal(tbSalary.Text);
                myEmployee.Description = tbDescription.Text;
                myCoffee.tblEMPLOYEE.Add(myEmployee);
                myCoffee.SaveChanges();
                LoadGridData();
            }
            else
            {
                int id = int.Parse(tbEmployeeId.Text);
                var queryCoffee = from item in myCoffee.tblEMPLOYEE
                                  where (item.EmployeeID == id)
                                  select item;
                tblEMPLOYEE itemUse = queryCoffee.First();
                itemUse.EmployeeName = tbEmployeeName.Text;
                itemUse.Gender = cbGender.Text;
                itemUse.BirthDate = Convert.ToDateTime(dtpBirthDate.Text);
                itemUse.Phone = tbPhone.Text;
                itemUse.Address = tbAddress.Text;
                itemUse.Position = tbPosition.Text;
                itemUse.Shift = cbShift.Text;
                itemUse.Salary = Convert.ToDecimal(tbSalary.Text);
                itemUse.Description = tbDescription.Text;
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
                int id = int.Parse(tbEmployeeId.Text);
                var queryDelete = from item in myCoffee.tblEMPLOYEE
                                  where (item.EmployeeID == id)
                                  select item;
                myCoffee.tblEMPLOYEE.Remove(queryDelete.First());
                myCoffee.SaveChanges();
                LoadGridData();
            }
            catch (Exception ex)
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
