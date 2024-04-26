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
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            FormEmployeeADO formEmployeeADO = new FormEmployeeADO();
            formEmployeeADO = new FormEmployeeADO();

            formEmployeeADO.TopLevel = false;
            formEmployeeADO.FormBorderStyle = FormBorderStyle.None;
            formEmployeeADO.Dock = DockStyle.Fill;

            pnlMain.Controls.Add( formEmployeeADO );

            formEmployeeADO.BringToFront();
            formEmployeeADO.Show();
        }

        private void pnlMain_Resize(object sender, EventArgs e)
        {
            foreach( Control item in pnlMain.Controls)
            {
                var frm = (Form)item;
                frm.Width = pnlMain.Width;
                frm.Height = pnlMain.Height;
            }
        }
    }
}
