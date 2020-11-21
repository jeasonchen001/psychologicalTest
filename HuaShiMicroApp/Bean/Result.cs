using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuaShiMicroApp.Bean.Enum;

namespace HuaShiMicroApp
{
    public class Result: object
    {
        //index
        public int index;

        // startTime
        public DateTime startTime;
        // endTime
        public DateTime? endTime = null;
        //选择使用时间
        public int? usedTime = null;
        //是否选择正确
        public bool? chooseIfCorrent  = null;

        //类型
        private String type;

        public void setEndTime()
        {
            DateTime now = DateTime.Now;
            this.endTime = now;
            TimeSpan? period = this.endTime - this.startTime;
            usedTime = (int)period.Value.TotalMilliseconds;
            //usedTime = this.endTime.Millisecond - this.startTime.Millisecond;
        }

        public void setStartTime()
        {
            this.startTime = DateTime.Now;
        }

        public void setChooseIfCorrect(int randIndex, int chooseIndex)
        {
            if (randIndex == chooseIndex)
            {
                this.chooseIfCorrent = true;
            }
            else
            {
                this.chooseIfCorrent = false;
            }
        }

        // point 0左 1右 2上 3下
        public void setType(ShowType showType, DisappearType disappearType, String position) {
            String num1 = disappearType == DisappearType.DISAPPEAR_ORDER ? "0" : "1";
            String num2 = (showType == ShowType.PERSON_AND_PERSON || showType == ShowType.PERSON_AND_THING) ?  "1" : "0";
            String num3 = (showType == ShowType.THING_AND_PERSON || showType == ShowType.PERSON_AND_PERSON) ? "1" : "0";
            this.type = num1 + num2 + num3 + position;
        }

        public override string ToString()
        {
            return String.Format("index: {0}, useTime: {1}, type: {2}, correct: {3}", this.index, this.usedTime == null? "null": this.usedTime.ToString()
                , this.type, this.chooseIfCorrent==null?"null":this.chooseIfCorrent.ToString());
        }
    }
}
