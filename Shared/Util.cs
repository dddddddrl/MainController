using System.Diagnostics;
using System.Drawing;

namespace MainController
{
    public static class Util
    {

        public static string ToChinese(int action)
        {
            if (action == 0)
            {
                return "拉伸";
            }
            else if (action == 1)
            {
                return "暂停";
            }
            else if (action == 2)
            {
                return "扫描";
            }
            else if (action == 3)
            {
                return "保存";
            }
            else if (action == 4)
            {
                return "确认";
            }
            else
            {
                return "错误";
            }
        }

        public static string ToFileName(int serialNum, int cycle, int point, double strain)
        {
            return serialNum + "_" + cycle + "_" + point + "_" + strain;
        }

        public static double GetProcessUsedMemory()
        {

            return Process.GetCurrentProcess().WorkingSet64 / 1024.0 / 1024.0; ;
        }

        public static bool IsInArea(Point p, Point start, Point end)
        {
            int x1 = start.X;
            int x2 = end.X;
            int y1 = start.Y;
            int y2 = end.Y;
            int x = p.X;
            int y = p.Y;
            if (x >= x1 && x <= x2 && y >= y1 && y <= y2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
