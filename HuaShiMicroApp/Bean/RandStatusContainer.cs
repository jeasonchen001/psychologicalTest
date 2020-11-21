using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuaShiMicroApp.Bean.Enum;
using System.Drawing;
using HuaShiMicroApp.Util;
using System.Windows.Forms;

namespace HuaShiMicroApp.Bean
{
    // 存放随机状态的容器
    class RandStatusContainer
    {
        private List<ShowType> showTypeList = new List<ShowType>();

        private List<DisappearType> disappearTypeList = new List<DisappearType>();

        private List<Point> showPointList = new List<Point>();

        public String currentPosition;

        private Random random = new Random();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">总共多少组图片</param>
        public RandStatusContainer(int num, Form form, PictureBox pictureBox)
        {
            for (int i = 0; i < (int)num / 4; i++)
            {
                showTypeList.Add(ShowType.PERSON_AND_PERSON);
                showTypeList.Add(ShowType.PERSON_AND_THING);
                showTypeList.Add(ShowType.THING_AND_PERSON);
                showTypeList.Add(ShowType.THING_AND_THING);
            }
            for (int j = 0; j < (int)num / 2; j++)
            {
                disappearTypeList.Add(DisappearType.DISAPPEAR_ORDER);
                disappearTypeList.Add(DisappearType.DISAPPEAR_TOGETHER);
            }
            showPointList.Add(LayoutUtil.getUpLocation(form, pictureBox));
            showPointList.Add(LayoutUtil.getDownLocation(form, pictureBox));
            showPointList.Add(LayoutUtil.getLeftLocation(form, pictureBox));
            showPointList.Add(LayoutUtil.getRightLocation(form, pictureBox));
            showPointList.Add(LayoutUtil.getCenterLocation(form, pictureBox));
        }

        public ShowType getShowType()
        {
            if (showTypeList.Count != 0)
            {
                int randIndex = random.Next(0, showTypeList.Count);
                ShowType showType = showTypeList[randIndex];
                showTypeList.RemoveAt(randIndex);
                return showType;
            }
            return ShowType.PERSON_AND_THING;
        }

        public DisappearType getDisappearType()
        {
            if (disappearTypeList.Count != 0)
            {
                int randIndex = random.Next(0, disappearTypeList.Count);
                DisappearType disappearType = disappearTypeList[randIndex];
                disappearTypeList.RemoveAt(randIndex);
                return disappearType;
            }
            return DisappearType.DISAPPEAR_ORDER;
        }

        /// <summary>
        /// 获取第二张图片的位置
        /// </summary>
        /// <returns></returns>
        public Point getSecondImagePoint(DisappearType disappearType)
        {
            //if (disappearType == DisappearType.DISAPPEAR_ORDER)
            //{
            //可以随机获取位置
            int randIndex = random.Next(0, showPointList.Count - 1);
            this.setCurrentaPosition(randIndex + 1);
            return showPointList[randIndex];
            //}

            /*
            else
            {
                //只能获取上下左右
                int randIndex = random.Next(0, showPointList.Count - 1);
                return showPointList[randIndex];
            }
             */

        }

        public void setCurrentaPosition(int index)
        {
            this.currentPosition = index.ToString();
        }


    }
}
