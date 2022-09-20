using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainController
{
    public partial class Analysis : Form
    {
        private void RefreshFilesList()//列表重排
        {
            int x = sp.X;
            int y = sp.Y;
            //this.SecondRSplit.Panel1.Controls.Clear();
            int c = files.Count;
            for (int i = 0; i < c; i++)
            {
                files[i].picLabel.Location = new Point(x, y);
                files[i].picBox.Location = new Point(x + 15, y);

                y += files[i].picBox.Height + distance;

                //this.SecondRSplit.Panel1.Controls.Add(files[i].picLabel);
                //this.SecondRSplit.Panel1.Controls.Add(files[i].picBox);
                //files[i].picBox.Image = files[i].picBox.Image;
            }
        }

        private void InitChart()
        {
            //定义图表区域
            Chart.ChartAreas.Clear();
            ChartArea mainArea = new ChartArea("Main Area");
            Chart.ChartAreas.Add(mainArea);
            //定义存储和显示点的容器
            Chart.Series.Clear();
            Series series1 = new Series("Freq");//文件名！
            series1.ChartArea = "Main Area";
            Chart.Series.Add(series1);
            //设置图表显示样式
            Chart.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            Chart.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            //设置标题
            //Monitor.Titles.Clear();
            //Monitor.Titles.Add("S01");
            //Monitor.Titles[0].Text = "XXX显示";
            //Monitor.Titles[0].ForeColor = Color.RoyalBlue;
            //Monitor.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            //Monitor.Titles[0].Text = string.Format("XXX {0} 显示", "sssss");
            //设置图表显示样式
            Chart.Series[0].Color = Color.Red;
            Chart.Series[0].ChartType = SeriesChartType.Line;
            Chart.Series[0].Points.Clear();
        }

        private void Chart_Update()
        {
            if (srcData.Count != 0)
            {
                //InitChart();
                Chart.Series[0].Points.Clear();
                AxisUpdate();
                if (maxX > srcData.Count)
                {
                    maxX = srcData.Count;
                }
                for (int i = minX - 1; i <= maxX - 1; i++)
                {
                    Chart.Series[0].Points.AddXY(i + 1, srcData.ElementAt<Result>(i).freq);
                }
                ChartSB.Maximum = srcData.Count;
              
            }
        }
        private void AxisTBChanged()
        {
            SetAxisPara();
            if (minX < maxX && minY < maxY)
            {
                Chart_Update();
            }
        }
        private void SetAxisPara()
        {
            try
            {
                if (MinYTB.Text != "" && MaxYTB.Text != "" && MinXTB.Text != "" && MaxXTB.Text != "" && srcData.Count != 0)
                {
                    minY = double.Parse(MinYTB.Text);
                    maxY = double.Parse(MaxYTB.Text);
                    minX = int.Parse(MinXTB.Text);
                    if (int.Parse(MaxXTB.Text) <= srcData.Count)
                    {
                        maxX = int.Parse(MaxXTB.Text);
                    }
                    else if (int.Parse(MaxXTB.Text) > srcData.Count)
                    {
                        maxX = srcData.Count;
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("数据错误！");
            }

        }
        private void AxisUpdate()
        {
            Chart.ChartAreas[0].AxisY.Minimum = minY;
            Chart.ChartAreas[0].AxisY.Maximum = maxY;
            Chart.ChartAreas[0].AxisX.Minimum = minX;
            Chart.ChartAreas[0].AxisX.Maximum = maxX;
        }

        private void YRangeAdaptor()//Y自适应调整
        {
            double min = Const.VNA_MAX_FREQ;
            double max = Const.VNA_MIN_FREQ;
            foreach (DataPoint p in Chart.Series[0].Points)
            {
                if (p.YValues[0] >= max)//一个X对应一个Y值
                {
                    max = p.YValues[0];
                }
                if (p.YValues[0] <= min)
                {
                    min = p.YValues[0];
                }
            }
            MaxYTB.Text = max + "";
            MinYTB.Text = min + "";

        }

        public void SetSrcData(List<Result> res)
        {
            srcData = res;
        }

        public void FastAnalysisUpdate()
        {
            InitChart();
            Chart_Update();
            OpenBtn.Enabled = false;
        }
    }
}
