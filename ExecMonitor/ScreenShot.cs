using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MainController
{
    //常用截屏方法
    public static class ScreenShot
    {
        private static Color curtColor;
        private static Point curtPoint = new Point(0, 0);

        const int OBJ_BITMAP = 7;


        private static Rectangle ScreenArea = new Rectangle(0, 0, 1920, 1080);
        private static Image bmp = new Bitmap(1920, 1080);
        private static Bitmap fullShot = new Bitmap(1920, 1080);


        private static Bitmap targetImage = MainController.Properties.Resources.target;
        private static int targetH = targetImage.Height;
        private static int targetW = targetImage.Width;
        private static Color targetColor = targetImage.GetPixel(targetW - 1, targetH - 1);

        [DllImport("user32.dll")]
        private extern static IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private extern static IntPtr GetDC(IntPtr windowHandle);

        [DllImport("gdi32.dll")]
        private extern static IntPtr GetCurrentObject(IntPtr hdc, ushort objectType);

        [DllImport("user32.dll")]
        private extern static void ReleaseDC(IntPtr hdc);


        /*private static Bitmap CaptureFullScreen()
        {
            IntPtr desktopWindow;
            IntPtr desktopDC;
            IntPtr desktopBitmap;
            desktopWindow = GetDesktopWindow();
            desktopDC = GetDC(desktopWindow);
            desktopBitmap = GetCurrentObject(desktopDC, OBJ_BITMAP);
            Bitmap fullShot = Image.FromHbitmap(desktopBitmap);
            //ReleaseDC(desktopDC);
           
            return fullShot;
        }*/
        private static void CaptureFullScreen()
        {
            //获取整个屏幕图像,不包括任务栏
            bmp = new Bitmap(1920, 1080);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(ScreenArea.Width, ScreenArea.Height));
            }
            fullShot = (Bitmap)bmp;

        }
        public static Bitmap GetFullScreen()
        {
            CaptureFullScreen();
            return fullShot;
        }

        public static Bitmap Cropping(ref Bitmap src, Point leftUp, Point rightDown)
        {
            Bitmap output = new Bitmap(rightDown.X - leftUp.X, rightDown.Y - leftUp.Y);
            int w = output.Width;
            int h = output.Height;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Color color = src.GetPixel(leftUp.X + x, leftUp.Y + y);
                    output.SetPixel(x, y, color);
                }
            }
            src.Dispose();
            return output;
        }
        private static Bitmap Enlarge(ref Bitmap src, int mag)
        {
            Bitmap output = new Bitmap(src.Width * mag, src.Height * mag);
            for (int y = 0; y < output.Height; y++)
            {
                for (int x = 0; x < output.Width; x++)
                {
                    Color c = src.GetPixel(x / mag, y / mag);
                    output.SetPixel(x, y, c);
                }
            }
            src.Dispose();
            return output;
        }

        public static Bitmap GetPartScreen(Point leftUp, Point rightDown)
        {
            CaptureFullScreen();
            Bitmap temp = Cropping(ref fullShot, leftUp, rightDown);
            return Enlarge(ref temp, 8);
        }

        public static bool IsBtnEnabled()
        {
            curtColor = GetFullScreen().GetPixel(curtPoint.X, curtPoint.Y);
            if (curtColor == targetColor)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void SetCurtPoint(Point p)
        {
            curtPoint = p;
        }
    }
}
