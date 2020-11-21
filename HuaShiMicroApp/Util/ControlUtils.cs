using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuaShiMicroApp.Util
{
    class ControlUtils
    {
        public static void closeButton(Button button)
        {
            button.Visible = false;
            button.Enabled = false;
        }

        public static void openButton(Button button)
        {
            button.Visible = true;
            button.Enabled = true;
        }

        public static void closeTextBox(TextBox textBox) {
            textBox.Visible = false;
            textBox.Enabled = false;
        }

        public static void openTextBox(TextBox textBox)
        {
            textBox.Visible = true;
            textBox.Enabled = true;
        }

        public static void closePictureBox(PictureBox picBox)
        {
            picBox.Visible = false;
            picBox.Enabled = false;
        }

        public static void showPictureBox(PictureBox picBox)
        {
            picBox.Visible = true;
            picBox.Enabled = false;
        }
    }
}
