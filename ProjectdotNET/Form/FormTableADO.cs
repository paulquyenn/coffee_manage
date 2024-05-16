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
    public partial class FormTableADO : Form
    {
        DBServices db = new DBServices();
        bool AddNew = false;
        public FormTableADO()
        {
            InitializeComponent();
        }

        private void setEnable(bool check)
        {
            tbTableID.Enabled = check;
            cbStatus.Enabled = check;
            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnAdd.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnClose.Enabled = !check;
            dgvTableADO.Enabled = !check;
        }

        private void LoadGridData()
        {
            try
            {
                string sql = "SELECT * FROM tblTABLE";
                dgvTableADO.DataSource = db.getData(sql);
                setEnable(false);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FormTableADO_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void dgvTableADO_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                tbTableID.Text = dgvTableADO.Rows[i].Cells["TableID"].Value.ToString();
                cbStatus.Text = dgvTableADO.Rows[i].Cells["Status"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setEnable(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int tableID = int.Parse(tbTableID.Text);
            string status = cbStatus.Text;
            if (AddNew)
            {
                string sql = string.Format("INSERT INTO tblTABLE (TableID, Status) VALUES " +
                    "('{0}', N'{1}')", tableID, status);
                db.runQuery(sql);
                LoadGridData();
            }
            else
            {
                string sql = string.Format("UPDATE tblTABLE SET " +
                    "Status=N'{0}' WHERE TableID={1}", status, tableID);
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
                int id = int.Parse(tbTableID.Text);
                string sql = string.Format("delete from tblTABLE where TableID={0}", id);
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
