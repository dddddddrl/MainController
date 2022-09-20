using System.Drawing;

namespace MainController
{
    internal class ImageMatch
    {
        //完全像素图像匹配，需要抛弃Bitmap
        public Rectangle FindLoction(Bitmap sub, Bitmap super)
        {
            int superH = super.Height;
            int superW = super.Width;
            int subH = sub.Height;
            int subW = sub.Width;
            Point start = new Point(0, 0);
            Size size = new Size(subW, subH);
            Rectangle area = new Rectangle(start, size);
            bool isMatch = false;

            for (int h = 0; h < superH && !isMatch; h++)
            {
                for (int w = 0; w < superW && !isMatch; w++)
                {
                    if ((w + subW) < superW && (h + subH) < superH && !isMatch)
                    {
                        bool isPair = true;
                        for (int y = 0; y < subH && !isMatch && isPair; y++)
                        {
                            for (int x = 0; x < subW && !isMatch && isPair; x++)
                            {
                                if (sub.GetPixel(x, y) != super.GetPixel(w + x, h + y))
                                {
                                    isPair = false;
                                }

                            }
                        }
                        if (isPair)
                        {
                            start = new Point(w, h);
                            size = new Size(subW, subH);
                            area = new Rectangle(start, size);
                            isMatch = true;
                        }
                    }
                }
            }

            return area;
        }
    }
}
