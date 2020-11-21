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
    public partial class SetForm : Form
    {
        public SetForm()
        {
            InitializeComponent();
        }

        private void SetForm_Load(object sender, EventArgs e)
        {
            loadFromAppSetting();
        }

        private void loadFromAppSetting() {
            int interval1;
            int.TryParse(ConfigAppSettings.GetValue("image1DisplayTime"), out interval1);
            int interval2;
            int.TryParse(ConfigAppSettings.GetValue("image1DisableTime"), out interval2);
            delay1.Value = interval1;
            delay2.Value = interval2;
            //读取信息
            informationInput.Text =  ConfigAppSettings.GetValue("information");
            group1Name.Text = ConfigAppSettings.GetValue("group1Name");
            group2Name.Text = ConfigAppSettings.GetValue("group2Name");
        }


        //将配置信息保存
        private void saveBtn_Click(object sender, EventArgs e)
        {
            ConfigAppSettings.SetValue("image1DisplayTime", delay1.Value.ToString());
            ConfigAppSettings.SetValue("image1DisableTime", delay2.Value.ToString());
            ConfigAppSettings.SetValue("group1Name", group1Name.Text);
            ConfigAppSettings.SetValue("group2Name", group2Name.Text);
            ConfigAppSettings.SetValue("information", informationInput.Text);
            //同时退出界面
            this.Close();
        }
    }
}
