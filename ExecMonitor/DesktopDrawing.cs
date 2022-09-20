using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MainController
{
    //屏幕GDI绘图
    internal class DesktopDrawing
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();//该函数返回桌面窗口的句柄。
        [DllImport("user32.dll", EntryPoint = "GetDCEx", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, int flags); //获取显示设备上下文环境的句柄

        IntPtr desk;
        IntPtr deskDC;
        Graphics g;


        public DesktopDrawing()
        {
            desk = GetDesktopWindow();
            deskDC = GetDCEx(desk, IntPtr.Zero, 0x403);
            g = Graphics.FromHdc(deskDC);
        }
        public void Refresh()
        {
            desk = GetDesktopWindow();
            deskDC = GetDCEx(desk, IntPtr.Zero, 0x403);
            g = Graphics.FromHdc(deskDC);

        }
        public void CircleIt(Rectangle area)
        {
            Refresh();
            g.DrawEllipse(new Pen(Palette.strawberry_red, 3), area);
        }

        public void Delete()
        {

            g.Dispose();

        }
    }
}
