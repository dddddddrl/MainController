using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using MainController.NewIdea;

namespace MainController
{
    //测试新点子的场所
    public partial class test : Form
    {
        System.Threading.Timer t;
        int i = 0;
        List<Task<Rectangle>> list = new List<Task<Rectangle>>();
        Task<Rectangle> mread;
        Task<Rectangle> mstop;
        Task<Rectangle> mpause;
        Task<Rectangle> mstart;
        Task<Rectangle> scan;
        Task<Rectangle> excel;
        DesktopDrawing painter = new DesktopDrawing();
        Graphics g;
        Stopwatch sw = new Stopwatch();
        public test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            painter.Refresh();
            Bitmap super1 = ScreenShot.GetFullScreen();
            Bitmap super2 = new Bitmap(super1);
            Bitmap super3 = new Bitmap(super1);
            Bitmap super4 = new Bitmap(super1);

            Bitmap sub_read = MainController.Properties.Resources.read_paras;
            Bitmap sub_stop = MainController.Properties.Resources.stop_str;
            Bitmap sub_pause = MainController.Properties.Resources.pause;
            Bitmap sub_start = MainController.Properties.Resources.start_str;

            ImageMatch matcher1 = new ImageMatch();
            ImageMatch matcher2 = new ImageMatch();
            ImageMatch matcher3 = new ImageMatch();
            ImageMatch matcher4 = new ImageMatch();

            mread = Match(matcher1, sub_read, super1);
            mstop = Match(matcher2, sub_stop, super2);
            mpause = Match(matcher3, sub_pause, super3);
            mstart = Match(matcher4, sub_start, super4);

            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(draw);
            //到达时间的时候执行事件；   
            t.AutoReset = false;
            //设置是执行一次（false）还是一直执行(true)；   
            t.Enabled = true;
            //是否执行System.Timers.Timer.Elapsed事件；

        }

        private void button2_Click(object sender, EventArgs e)//move controls
        {
            t.Dispose();
        }

        private void draw(Object sender, System.Timers.ElapsedEventArgs e)
        {

            painter.CircleIt(mread.Result);
            painter.CircleIt(mstop.Result);
            painter.CircleIt(mpause.Result);
            painter.CircleIt(mstart.Result);
        }

        private void draw2(Object sender, System.Timers.ElapsedEventArgs e)
        {

            painter.CircleIt(scan.Result);
            painter.CircleIt(excel.Result);

        }

        private async Task<Rectangle> Match(ImageMatch matcher, Bitmap sub, Bitmap super)
        {
            Rectangle rec = await Task.Run(() => matcher.FindLoction(sub, super));
            return rec;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            painter.Refresh();
            Bitmap super1 = ScreenShot.GetFullScreen();
            Bitmap super2 = new Bitmap(super1);

            Bitmap scanimg = MainController.Properties.Resources.scan;
            Bitmap excelimg = MainController.Properties.Resources.target;

            ImageMatch matcher1 = new ImageMatch();
            ImageMatch matcher2 = new ImageMatch();

            scan = Match(matcher1, scanimg, super1);
            excel = Match(matcher2, excelimg, super2);

            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(draw2);
            //到达时间的时候执行事件；   
            t.AutoReset = false;
            //设置是执行一次（false）还是一直执行(true)；   
            t.Enabled = true;
            //是否执行System.Timers.Timer.Elapsed事件；
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

            t = new System.Threading.Timer(new TimerCallback(add), 20, 0, 16);

        }

        private void add(object sender)
        {
            i += (int)sender;
            this.Invoke(new Action(() =>
            {
                materialLabel1.Text = i.ToString();
            }
            ));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filePath = "D:\\测试\\merge.xlsx";
            List<DateTime> lcrTime = new List<DateTime>() ;
            List<double> lcrValue = new List<double>();
            List<DateTime> tempTime=new List<DateTime>() ;
            List<double> tempValue=new List<double>();
         

        DateTime ini = new DateTime(2022,8,27,4,58,59);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    for (int r = 0; r < result.Tables[0].Rows.Count; r++)
                    {
                        for(int c = 0; c < 4; c++)
                        {
                            if (result.Tables[0].Rows[r][c] != null)
                            {
                                string s = result.Tables[0].Rows[r][c] + "";
                                if (!s.Equals(""))
                                {
                                    if (c == 0)
                                    {
                                        lcrTime.Add(DateTime.Parse(s));
                                    }
                                    else if (c == 1)
                                    {
                                        lcrValue.Add(double.Parse(s));
                                    }
                                    else if (c == 2)
                                    {
                                        ini = ini.AddSeconds(1);
                                        tempTime.Add(ini);
                                    }
                                    else if (c == 3)
                                    {
                                        tempValue.Add(double.Parse(s));
                                    }
                                }
                                
                            }
                        }
                    }
                }
            }

            List<TC> res=new List<TC>();
            for(int x = 0; x < lcrTime.Count; x++)
            {
                TC p = new TC();
                p.c = lcrValue[x];
                for(int y = 0; y < tempTime.Count; y++)
                {
                    if(lcrTime[x].Hour==tempTime[y].Hour&& lcrTime[x].Minute == tempTime[y].Minute && lcrTime[x].Second == tempTime[y].Second)
                    {
                        p.temp = tempValue[y];
                        break;
                    }
                }
                res.Add(p);
            }
            int sdqad = 0;//debug node

            List<TC> resAvg = new List<TC>();
            for(int x=0; x < res.Count;)
            {
                double cT = res[x].temp;
                for (int dx = 0; dx < 30; dx++)
                {
                    List<double> avg=new List<double>();
                    if (x + dx < res.Count)
                    {
                        if (cT == res[x + dx].temp)
                        {
                            avg.Add(res[x+dx].c);
                        }
                        else
                        {
                            x = x + dx;
                            double newC = 0;
                            foreach(double d in avg)
                            {
                                newC += d;
                            }
                            newC = newC / avg.Count;
                            TC r = new TC();
                            r.temp=cT; 
                            r.c=newC;
                            resAvg.Add(r);
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }





            string fileName = "D:\\测试\\MergeResult.csv";
            StreamWriter fileWriter = new StreamWriter(fileName, true, Encoding.UTF8);//TRUE 存在则添加，不存在则新建      
                for (int i = 0; i < resAvg.Count; i++)//DAQData为要保存的float数组数据
                {
                    fileWriter.Write(resAvg[i].temp + ",");
                    fileWriter.Write(resAvg[i].c + ",");
                    fileWriter.Write("\r\n");
                }
                fileWriter.Flush();
                fileWriter.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double d = 0.207638888888889;
            DateTime dt = DateTime.Parse(d + "");
            materialLabel1.Text = dt.ToString();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            DrawBinary(128);

        }
        private void DrawBinary(int thres)
        {
            

            Bitmap sImg = (Bitmap)MainController.Properties.Resources.t.Clone() ;
            int w=sImg.Width;
            int h=sImg.Height;
            Bitmap tImg = new Bitmap(w, h);
            
            BitmapData s = sImg.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, sImg.PixelFormat);
            BitmapData t = tImg.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, sImg.PixelFormat);
            
            // Get the address of the first line.
            IntPtr ptr = s.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(s.Stride) * h;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
            int l = rgbValues.Length;
            for (int i = 0; i < l; )
            {
                int gray = 0;
                //心理学方程
                gray = (int) (rgbValues[i] * 0.299 + rgbValues[i + 1] * 0.587 + rgbValues[i + 2] * 0.114);
       
                if (gray >= thres)
                {
                    rgbValues[i] =255;
                    rgbValues[i + 1] = 255;
                    rgbValues[i + 2] = 255;
                }
                else
                {
                    rgbValues[i] = 0;
                    rgbValues[i + 1] = 0;
                    rgbValues[i + 2] =0;
                }
      
               
                    //rgbValues[i] = (byte)gray;
                   // rgbValues[i + 1] = (byte)gray;
                   // rgbValues[i + 2] = (byte)gray;
                
                i += 3;
            }
            
            IntPtr ptr2 = t.Scan0;
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0,ptr2, bytes);
            tImg.UnlockBits(t);
            
            // Draw the modified image.
            g = pictureBox3.CreateGraphics();
            g.DrawImageUnscaled(tImg,new System.Drawing.Point(0,0));
            //g.DrawImage(tImg, new Point(0, 0));
            //pictureBox3.Image = (Bitmap)tImg.Clone();
            
            tImg.Dispose();
            sImg.Dispose();
            
           
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            sw.Restart();
            DrawBinary(trackBar1.Value);
            sw.Stop();
            label1.Text = 1000/sw.ElapsedMilliseconds+"";
        }

        private void label1_Click(object sender, EventArgs e)
        {
           

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
           
            Mat src = Cv2.ImRead("C:\\Users\\ddddd\\source\\repos\\MainController v4\\Resources\\testImg.bmp");
            Mat src_gray = new Mat();
            
            Cv2.CvtColor(src, src_gray, ColorConversionCodes.BGR2GRAY);

            
            MemoryStream s = new MemoryStream();
            sw.Restart();
            src_gray.ToMemoryStream().CopyTo(s);
            sw.Stop();
            Bitmap bmp = new Bitmap(s);
           
            //Cv2.ImShow("yy", src_gray);

            pictureBox3.Image = bmp;
            
            label1.Text =  sw.ElapsedMilliseconds + "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            O father = new O();
            OO son = new OO();
            father.go();
            son.go();
        }
    }
    
}
