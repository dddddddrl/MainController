using System.Collections.Generic;
using System.Drawing;


namespace MainController
{
    //曲线的缩略图
    internal static class Minimap
    {

        static Image m = new Bitmap(150, 100);
        static Graphics g = Graphics.FromImage(m);
        static int pointNum = 100;
        struct xy
        {
            public int x;
            public int y;
        }
        public static Image GetMinimap(List<Result> res)
        {
            //填充背景色
            Brush whiteB = new SolidBrush(Color.White);
            g.FillRectangle(whiteB, 0, 0, m.Width, m.Height);
            //确定y轴范围
            double minY = Const.VNA_MAX_FREQ;
            double maxY = Const.VNA_MIN_FREQ;
            //提取前50个数据
            xy xy = new xy();
            List<xy> XYs = new List<xy>();
            int dx = m.Width / pointNum;
            xy.x = 0;
            for (int i = 0; i < res.Count; i++)
            {
                if (i == pointNum)
                {
                    break;
                }
                double comparedData = res[i].freq;
                xy.y = (int)comparedData;
                XYs.Add(xy);
                if (comparedData >= maxY)
                {
                    maxY = comparedData;
                }
                if (comparedData <= minY)
                {
                    minY = comparedData;
                }
                xy.x += dx;
            }
            //坐标转换
            for (int i = 0; i < XYs.Count; i++)
            {
                xy newXY = new xy();
                newXY.x = XYs[i].x;
                newXY.y = (int)(m.Height - (XYs[i].y - minY) / (maxY - minY) * m.Height);
                XYs[i] = newXY;
            }
            //作图
            Pen pen = new Pen(Color.Red, 1);
            for (int i = 0; i < XYs.Count - 1; i++)
            {
                g.DrawLine(pen, XYs[i].x, XYs[i].y, XYs[i + 1].x, XYs[i + 1].y);
            }
            //输出
            return m;
        }

    }
}
