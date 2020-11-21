using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HuaShiMicroApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            
            //Application.Run(new LoginForm());
            // 制作登录界面跳转的功能
            LoginForm loginForm = new LoginForm();
            ImageForm imageForm = new ImageForm();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK) { 
            //登录成功
                loginForm.Dispose();
                Application.Run(imageForm);
            }
            

            //Application.Run(new SetForm());
            /*
            //测试代码
            ImageForm imageForm = new ImageForm();
            Application.Run(imageForm);
             */
        }
    }
}
