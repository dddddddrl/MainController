using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MainController
{
    //跨进程数据读取和控件控制
    internal static class FormBridge//未链接Buton
    {
        const string winFormButton = "WindowsForms10.BUTTON.app.0.34f5582_r7_ad1";
        const string winFormTextBox = "WindowsForms10.EDIT.app.0.34f5582_r7_ad1";
        const string winForm = "WindowsForms10.Window.8.app.0.34f5582_r7_ad1";
        const string strMachineName = "生物传感器拉伸测试仪-已连接";
        //测试target1代码
        //const string winFormButton = "WindowsForms10.BUTTON.app.0.141b42a_r8_ad1";
        //const string winFormTextBox = "WindowsForms10.EDIT.app.0.141b42a_r8_ad1";
        //const string winForm = "WindowsForms10.Window.8.app.0.141b42a_r8_ad1";
        //const string strMachineName = "Target1";

        const int WM_SETTEXT = 0x000C; //设置文本
        const int WM_LBUTTONDOWN = 0x0201; //按钮按下
        const int WM_LBUTTONUP = 0x0202;//按钮松开
        const int WM_CLOSE = 0x0010;//关闭
        const int WM_GETTEXT = 0x000D;//获取文本

        static IntPtr zeroPointTB = new IntPtr();
        static IntPtr rangeTB = new IntPtr();
        static IntPtr r_SpeedTB = new IntPtr();
        static IntPtr l_SpeedTB = new IntPtr();
        static IntPtr r_PauseTB = new IntPtr();
        static IntPtr l_PauseTB = new IntPtr();
        static IntPtr cycleNumTB = new IntPtr();
        static IntPtr readConfigBtn = new IntPtr();
        static IntPtr setConfigBtn = new IntPtr();
        static IntPtr startBtn = new IntPtr();
        static IntPtr stopBtn = new IntPtr();
        static IntPtr pauseBtn = new IntPtr();
        static IntPtr factoryBtn = new IntPtr();

        static IntPtr exe = new IntPtr();
        static IntPtr win = new IntPtr();

        struct matchParas
        {
            public string z;
            public string r;
            public string s2r;
            public string s2l;
            public string lp;
            public string rp;
            public string n;
        }

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr parent, IntPtr childe, string strclass, string FrmText);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int nMaxCount);
        private static void LinkWin()
        {
            exe = FindWindow(winForm, strMachineName);
            win = FindWindowEx(exe, IntPtr.Zero, winForm, "");
        }
        private static void LinkTextBoxPtr(ref IntPtr textBox, string name)
        {
            LinkWin();

            textBox = FindWindowEx(win, IntPtr.Zero, winFormTextBox, name);
        }
        private static void LinkButtonPtr(ref IntPtr button, string name)
        {
            LinkWin();
            button = FindWindowEx(win, IntPtr.Zero, winFormButton, name);
        }


        public static void LinkAllButton()
        {
            LinkButtonPtr(ref readConfigBtn, Const.READ_CONFIG);
            LinkButtonPtr(ref setConfigBtn, Const.SET_CONFIG);
            LinkButtonPtr(ref startBtn, Const.START);
            LinkButtonPtr(ref stopBtn, Const.STOP);
            LinkButtonPtr(ref pauseBtn, Const.PAUSE);
            LinkButtonPtr(ref factoryBtn, Const.FACTORY);
        }
        public static void ClickBtn(IntPtr btn)
        {
            SendMessage(btn, WM_LBUTTONDOWN, IntPtr.Zero, null);
            SendMessage(btn, WM_LBUTTONUP, IntPtr.Zero, null);
        }
        public static void SetText(IntPtr tb, string text)
        {
            SendMessage(tb, WM_SETTEXT, IntPtr.Zero, text);
        }
        public static void SetAllText(string z, string r, string s2r, string s2l, string n)
        {
            SetText(zeroPointTB, z);
            SetText(rangeTB, r);
            SetText(r_SpeedTB, s2r);
            SetText(l_SpeedTB, s2l);
            SetText(cycleNumTB, n);
        }
        public static string GetText(IntPtr tb)
        {
            StringBuilder text = new StringBuilder(99);
            GetWindowText(tb, text, 99);
            return text.ToString();
        }



        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = System.Runtime.InteropServices.CharSet.Auto)] // 
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpfn, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        public delegate bool CallBack(IntPtr hwnd, int lParam);
        public static void LinkAllTextBox(string z, string r, string s2r, string s2l, string lp, string rp, string n)//枚举句柄
        {
            matchParas m = new matchParas();
            m.z = z; m.r = r; m.s2r = s2r; m.s2l = s2l; m.lp = lp; m.rp = rp; m.n = n;
            LinkWin();
            List<IntPtr> listWnd = new List<IntPtr>();
            EnumChildWindows(win, new CallBack(delegate (IntPtr hwnd, int lParam)
            {
                listWnd.Add(hwnd);
                return true;
            }), 0);

            foreach (IntPtr hwnd in listWnd)
            {
                StringBuilder buffer = new StringBuilder(99);
                SendMessage(hwnd, WM_GETTEXT, 44, buffer);
                string c = buffer + "";
                if (c == m.z)
                {
                    zeroPointTB = hwnd;
                }
                else if (c == m.r)
                {
                    rangeTB = hwnd;
                }
                else if (c == m.s2r)
                {
                    r_SpeedTB = hwnd;
                }
                else if (c == m.s2l)
                {
                    l_SpeedTB = hwnd;
                }
                else if (c == m.lp)
                {
                    l_PauseTB = hwnd;
                }
                else if (c == m.rp)
                {
                    r_PauseTB = hwnd;
                }
                else if (c == m.n)
                {
                    cycleNumTB = hwnd;
                }
            }
        }

    }
}
