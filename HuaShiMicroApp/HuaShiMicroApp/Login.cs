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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private String userName;

        public void setUserName(String userName){
        this.userName = userName;
        }

        public String getUserName() {
            return this.userName;
        }

        public String age;

        public String number;

        private void 重置_Click(object sender, EventArgs e)
        {
            //将输入框中的数据清空
            学号.Text = "";
            年龄.Text = "";
            编号.Text = "";
            
        }

        private void 登录_Click(object sender, EventArgs e)
        {
            bool male = 男.Checked;
            bool female = 女.Checked;
            String studentNumber = 学号.Text;
            String age = 年龄.Text;
            String number = 编号.Text;
            //首先判断是否输入了学号和性别，如果没有弹出警告
            if (string.IsNullOrEmpty(studentNumber) || string.IsNullOrEmpty(age) || string.IsNullOrEmpty(number))
            {
                MessageBox.Show("学号或者年龄或者编号为空","提醒!!!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((!male & !female)) {
                MessageBox.Show("未选择性别，没有第三种选择", "提醒!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //将学号保存起来，然后跳转到程序开始界面
            //TODO
            this.setUserName(studentNumber);
            this.age = age;
            this.number = number;
            String rootPath = AppDomain.CurrentDomain.BaseDirectory;
            FileUtil.WriteToFile(String.Format("{0}result.txt", rootPath), String.Format("性别: {0}, 年龄: {1}, 编号: {2}, 学号: {3}", male ? "男" : "女", this.age, this.number, this.userName), false);
            this.DialogResult = DialogResult.OK;
        }

        //显示设置窗口
        private void setting_Click(object sender, EventArgs e)
        {
            // 密码窗口
            PassWordForm pasForm = new PassWordForm();
            pasForm.ShowDialog();
            if (pasForm.login) {
                //输入正确则打开设置窗口
                new SetForm().ShowDialog();
            }
        }
    }
}
