using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace HuaShiMicroApp.Util
{
    class LayoutUtil
    {
        // 得到控件的中间位置
        public static Point getCenterLocation(Form form, Control control) { 
         return new Point{
             X = form.Size.Width/2 - control.Width/2,
             Y = form.Size.Height / 2 - control.Height / 2 - 50
         };
        }

        // 得到控件的左边位置
       public static Point getLeftLocation(Form form, Control control)
        {
            return new Point
            {
                X = 0,
                Y = form.Size.Height / 2 - control.Height / 2 - 50 //Y要上偏移，显示的问题
            };
        }

        //得到控件的右边位置
        public static Point getRightLocation(Form form, Control control)
        {
            return new Point
            {
                X = form.Size.Width  - control.Width,
                Y = form.Size.Height / 2 - control.Height / 2 - 50
            };
        }

        //得到控件的上边位置
        public static Point getUpLocation(Form form, Control control)
        {
            return new Point
            {
                X = form.Size.Width / 2 - control.Width / 2,
                Y = 0
            };
        }

        //得到控件的下边位置
        public static Point getDownLocation(Form form, Control control)
        {
            return new Point
            {
                X = form.Size.Width / 2 - control.Width / 2,
                Y = form.Size.Height - control.Height - 50
            };
        }

    }
    
}
