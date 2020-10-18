using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuaShiMicroApp
{
    public partial class PassWordForm : Form
    {
        public PassWordForm()
        {
            InitializeComponent();
        }

        public bool login;

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            String password = now.ToString("MMdd");
            //响应事件
            if (passwordInput.Text == password)
            {
                login = true;
                this.Close();
            }
            else {
                login = false;
                MessageBox.Show("密码错误", "警告!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
