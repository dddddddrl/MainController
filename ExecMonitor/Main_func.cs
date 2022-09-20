using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainController
{
    public partial class Main
    {

        public void OnHotkey(int HotkeyID) //设置热键的行为
        {
            StartBtn_Click(0, System.EventArgs.Empty);
        }
        public void OnHotkeyForMonitor(int HotkeyID)
        {
            FoldMonitorBtn_Click(0, System.EventArgs.Empty);
        }

        public void OnHotkeyForAnalysis(int HotkeyID)
        {
            if (resultMan.resultList.Count != 0)
            {
                //状态置0
                TaskTimer.Enabled = false;
                StartBtn.Text = "Continue (F4)";
                StopBtn.Enabled = true;
                testStatus = 0;

                Analysis analysisForm = new Analysis();
                analysisForm.SetSrcData(resultMan.resultList);
                analysisForm.Show();
                analysisForm.Text += "Fast Analysis Mode";
                analysisForm.FastAnalysisUpdate();
            }
            else
            {
                MessageBox.Show("无可用数据！");
            }
        }
        private void ReCurtInfo(int cycle, int point, double strain)
        {
            curtCycle = cycle;
            curtPoint = point;
            curtStrain = strain;

        }

        private void ReCycleList()
        {
            cycleItemPair.Clear();
            CycleListBox.Items.Clear();
            for (int i = 0; i <= manager.task.Count - 1; i++)
            {
                if (manager.task[i].isCycle)
                {
                    cycleItemPair.Add(i);
                    String name = manager.task[i].cycle + "";
                    CycleListBox.Items.Add(name);
                }
            }
        }

        private void RePointList(int leafNo)
        {
            pointItemPair.Clear();
            PointListBox.Items.Clear();
            for (int i = 0; i <= manager.task[leafNo].child.Count - 1; i++)
            {
                int pointIndex = manager.task[leafNo].child[i];
                pointItemPair.Add(pointIndex);
                String name = manager.task[pointIndex].point + "";
                PointListBox.Items.Add(name);
            }

        }

        private void ReActionList(int leafNo)
        {
            actionItemPair.Clear();
            ActionListBox.Items.Clear();
            for (int i = 0; i <= manager.task[leafNo].child.Count - 1; i++)
            {
                int actionIndex = manager.task[leafNo].child[i];
                actionItemPair.Add(actionIndex);
                int name = manager.task[actionIndex].action;
                ActionListBox.Items.Add(Util.ToChinese(name));
            }

        }

        private void ReTimeLabel(int leafNo)
        {
            int mili = manager.task[leafNo].time.Millisecond;
            StatusLabel.Text = manager.task[leafNo].time.ToString() + "-" + mili + "";
        }

        private void InitChart()
        {
            //定义图表区域
            Monitor.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            Monitor.ChartAreas.Add(chartArea1);
            //定义存储和显示点的容器
            Monitor.Series.Clear();
            Series series1 = new Series("Freq");

            series1.ChartArea = "C1";
            Monitor.Series.Add(series1);
            //设置图表显示样式
            Monitor.ChartAreas[0].AxisY.Minimum = resultMan.minRange / 1000000.0;
            Monitor.ChartAreas[0].AxisY.Maximum = resultMan.maxRange / 1000000.0;
            Monitor.ChartAreas[0].AxisX.Interval = 10;
            Monitor.ChartAreas[0].AxisY.Interval = 10;
            Monitor.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            Monitor.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            //设置标题
            //Monitor.Titles.Clear();
            //Monitor.Titles.Add("S01");
            //Monitor.Titles[0].Text = "XXX显示";
            //Monitor.Titles[0].ForeColor = Color.RoyalBlue;
            //Monitor.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            //Monitor.Titles[0].Text = string.Format("XXX {0} 显示", "sssss");
            //设置图表显示样式
            Monitor.Series[0].Color = Color.Red;
            Monitor.Series[0].ChartType = SeriesChartType.Line;
            Monitor.Series[0].Points.Clear();
        }
        private void UpdateQueueValue()
        {

            if (dataQueue.Count > 100) //先出列
            {

                for (int i = 0; i < num; i++)
                {
                    dataQueue.Dequeue();
                }
            }
            for (int i = 0; i < num; i++) //入列
            {
                dataQueue.Enqueue(resultMan.resultList.Last().freq / 1000000.0);
            }
        }
        private void Monitor_Update()
        {
            UpdateQueueValue();
            Monitor.Series[0].Points.Clear();
            MonitorRangeAdaptor();
            for (int i = 0; i < dataQueue.Count; i++)
            {
                Monitor.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));
            }
        }

        private void SetTestPara()
        {
            TestEnv.SetStrEnv(double.Parse(IniLengthBox.Text), double.Parse(StrRangeBox.Text), double.Parse(StrSpeedBox.Text), int.Parse(CycleNumBox.Text), int.Parse(PointNumBox.Text));
            resultMan.SetMaxMin(double.Parse(MinRangeBox.Text), double.Parse(MaxRangeBox.Text));
        }

        private void MonitorRangeAdaptor()
        {
            /*double sumOfFreq = 0;
            for(int i=0;i<=dataQueue.Count-1;i++)
            {
                sumOfFreq += dataQueue.ElementAt(i);

            }
            double avg = sumOfFreq / dataQueue.Count;
            Monitor.ChartAreas[0].AxisY.Minimum = avg -20;
            Monitor.ChartAreas[0].AxisY.Maximum = avg + 20;*/
            Monitor.ChartAreas[0].AxisY.Minimum = (int)(dataQueue.Min() - 1.0);
            Monitor.ChartAreas[0].AxisY.Maximum = (int)(dataQueue.Max() + 1.0);
            Monitor.ChartAreas[0].AxisX.Interval = (int)((dataQueue.Count + 10.0) / 10.0);
            Monitor.ChartAreas[0].AxisY.Interval = 2;
        }


    }
}
