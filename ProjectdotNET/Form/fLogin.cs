﻿using System;
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

        int Login(string userName, string passWord)
        {
            return Account.Instance.Login(userName, passWord);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            string passWord = tbPassword.Text;

            if (Login(userName, passWord) == 0)
            {
                fMain formMain = new fMain(0, userName);
                this.Hide();
                formMain.ShowDialog();
                this.Show();
            }
            else if(Login(userName, passWord) == 1)
            {
                fMain formMain = new fMain(1, userName);
                this.Hide();
                formMain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không đúng!", "Thông báo");
            }
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát phần mềm?", "Thông báo", MessageBoxButtons.OKCancel)
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
