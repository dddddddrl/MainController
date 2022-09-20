using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MainController
{
    //鼠标基本操作封装
    public class MouseFlag
    {
       
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);
        public static Point GetPos()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            // NOTE: If you need error handling
            // bool success = GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }
        public static void SetPos(int dx, int dy)
        {
            SetCursorPos(dx, dy);

        }
        public static void SetPos(Point pos)
        {
            SetCursorPos(pos.X, pos.Y);

        }
        public static void LefClick(int dx, int dy, uint data)
        {
            SetCursorPos(dx, dy);
            mouse_event(MouseEventFlag.LeftDown, dx, dy, data, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, dx, dy, data, UIntPtr.Zero);
        }
        public static void LefClick(int dx, int dy)
        {
            SetCursorPos(dx, dy);
            mouse_event(MouseEventFlag.LeftDown, dx, dy, 1, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, dx, dy, 1, UIntPtr.Zero);
        }

    }

}
