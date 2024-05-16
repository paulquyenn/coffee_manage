using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectdotNET
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            string passWord = tbPassword.Text;

            if (Login(userName, passWord))
            {
                fMain formMain = new fMain();
                this.Hide();
                formMain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }

        bool Login(string userName, string passWord)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] originalBytes = ASCIIEncoding.Default.GetBytes(passWord);
            byte[] encodedBytes = md5.ComputeHash(originalBytes);
            string hashedPassword = BitConverter.ToString(encodedBytes).Replace("-", "");

            return Account.Instance.Login(userName, hashedPassword);
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel)
                != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }
    }
}
