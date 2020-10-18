using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuaShiMicroApp.Bean.State
{
    // 保存状态信息
    class StateInfo
    {
        public static bool started = false;

        public static bool done = false;

        public static void StartShowImage() {
            started = true;
        }

        // 判断是否开始
        public static bool ifStart() {
            return started;
        }

        public static void finish() {
            done = true;
        }

        // 判断是否完成
        public static bool ifFinished() {
            return done;
        }
    }
}
