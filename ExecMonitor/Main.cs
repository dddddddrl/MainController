using MainController.FlowDesigner;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MainController
{
    //主界面
    public partial class Main : Form
    {

        enum action { start, pause, scan, save, yes };//{0,1,2,3,4}

        List<int> cycleItemPair = new List<int>();
        List<int> pointItemPair = new List<int>();
        List<int> actionItemPair = new List<int>();
        TaskManager manager = new TaskManager();
        ResultManager resultMan = new ResultManager();
        private Queue<double> dataQueue = new Queue<double>(100);
        private int num = 1;//每次删除增加几个点
        private int testDelay = 5;//指任务规划起始点相较预约时间延迟的秒数
        private int curtCycle = 0;
        private int curtPoint = 0;
        private double curtStrain = 0;
        private int curtSerialNum = 1;
        private DateTime curtTestBookTime;
        private int testStatus = -1;//-1==stop 0==pause 1==running 
        private bool isLinked = false;

        Hotkey hotkey;
        Hotkey monitorKey;
        Hotkey analysisKey;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.main;
            DateTime iniTime = new DateTime();
            iniTime = DateTime.Now;
            HrBox.Value = iniTime.Hour;
            MinBox.Value = iniTime.Minute;
            SecBox.Value = iniTime.Second;

            StopBtn.Enabled = false;

            IniLengthBox.Text = TestEnv.iniLength + "";
            StrRangeBox.Text = TestEnv.strRange + "";
            StrSpeedBox.Text = TestEnv.strSpeed + "";
            CycleNumBox.Text = TestEnv.cycle + "";
            PointNumBox.Text = TestEnv.pointNum + "";

            MinRangeBox.Text = resultMan.minRange + "";
            MaxRangeBox.Text = resultMan.maxRange + "";

            ResultPathTB.Text = IO.resultDir;

            FirstSplit.Panel2Collapsed = true;
            this.Width = 362;
            hotkey = new Hotkey(this.Handle);
            monitorKey = new Hotkey(this.Handle);
            analysisKey = new Hotkey(this.Handle);
            Hotkey.Hotkey1 = hotkey.RegisterHotkey(System.Windows.Forms.Keys.F4, Hotkey.KeyFlags.MOD_NONE);
            hotkey.OnHotkey += new HotkeyEventHandler(OnHotkey);
            Hotkey.Hotkey2 = monitorKey.RegisterHotkey(System.Windows.Forms.Keys.F3, Hotkey.KeyFlags.MOD_NONE);
            monitorKey.OnHotkey += new HotkeyEventHandler(OnHotkeyForMonitor);
            Hotkey.Hotkey3 = analysisKey.RegisterHotkey(System.Windows.Forms.Keys.F2, Hotkey.KeyFlags.MOD_NONE);
            analysisKey.OnHotkey += new HotkeyEventHandler(OnHotkeyForAnalysis);

        }




        private void CycleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex = CycleListBox.SelectedIndex;
            if (selectIndex != -1)
            {
                int leafNo = cycleItemPair[selectIndex];
                RePointList(leafNo);
            }


        }

        private void PointListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex = PointListBox.SelectedIndex;
            if (selectIndex != -1)
            {
                int leafNo = pointItemPair[selectIndex];
                ReActionList(leafNo);
            }
        }

        private void ActionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex = ActionListBox.SelectedIndex;
            if (selectIndex != -1)
            {
                int leafNo = actionItemPair[selectIndex];
                ReTimeLabel(leafNo);
            }
        }



        private void TaskTimer_Tick(object sender, EventArgs e)
        {
            TaskTree nextTask = new TaskTree();
            if (manager.actionQueue.Count >= 1)
            {
                nextTask = manager.actionQueue.First();
                if (DateTime.Now >= nextTask.time)
                {
                    Console.WriteLine(nextTask.time.ToString() + "_" + nextTask.time.Millisecond + "");
                    manager.TaskPlayer(nextTask);
                    ReCurtInfo(nextTask.cycle, nextTask.point, nextTask.strain);
                    StatusLabel.Text = "循环：" + nextTask.cycle + "\n点数：" + nextTask.point + "\n应变：" + nextTask.strain + "%";
                    ProgressBar.Value = (int)manager.ProgressPrecent();
                    ProgressLabel.Text = ProgressBar.Value + "%";
                    if (nextTask.action == 4)
                    {
                        try
                        {
                            IO.RenameNewFile(Util.ToFileName(curtSerialNum, curtCycle, curtPoint, curtStrain));

                            Result newResult = new Result(DateTime.Now, curtSerialNum, curtCycle, curtPoint, curtStrain, resultMan.GetMinFreq(IO.newFilePath), IO.newFilePath);
                            resultMan.resultList.Add(newResult);
                            IO.AutoSave(newResult);
                            curtSerialNum++;
                            Monitor_Update();
                        }
                        catch (Exception)
                        {
                            //状态置0
                            TaskTimer.Enabled = false;
                            StartBtn.Text = "Continue (F4)";
                            StopBtn.Enabled = true;
                            testStatus = 0;
                            MessageBox.Show("VNA数据读取错误");

                        }

                    }
                    manager.actionQueue.Dequeue();
                }
            }
            else
            {
                TaskTimer.Stop();
                StartBtn.Enabled = true;
                StopBtn.Enabled = false;
            }
        }



        private void SecBox_ValueChanged(object sender, EventArgs e)
        {
            if (SecBox.Value == 60)
            {
                SecBox.Value = 0;
                MinBox.Value++;
            }
        }
        private void MinBox_ValueChanged(object sender, EventArgs e)
        {
            if (MinBox.Value == 60)
            {
                MinBox.Value = 0;
                HrBox.Value++;
            }
        }
        private void HrBox_ValueChanged(object sender, EventArgs e)
        {
            if (HrBox.Value == 24)
            {
                HrBox.Value = 0;
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (testStatus == -1)
            {
                if (IO.IsDirEmpty())
                {
                    SetTestPara();
                    InitChart();
                    curtTestBookTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (int)HrBox.Value, (int)MinBox.Value, (int)SecBox.Value);
                    TestTimer.Enabled = true;
                    //DateTime taskStartTime = curtTestBookTime.AddSeconds(testDelay);
                    if (OnlyVnaChecker.Checked == false)
                    {
                        manager.GenTask(curtTestBookTime);

                    }
                    else
                    {
                        manager.GenVNATask(curtTestBookTime);
                    }
                    ReCycleList();
                    StartBtn.Text = "Pause (F4)";
                    StopBtn.Enabled = true;
                    testStatus = 1;
                }
                else
                {
                    MessageBox.Show("数据文件夹非空！");
                }

            }
            else if (testStatus == 0)
            {
                manager.ActionQueueRenewTime();
                TaskTimer.Enabled = true;
                StartBtn.Text = "Pause (F4)";
                StopBtn.Enabled = true;
                testStatus = 1;
            }
            else if (testStatus == 1)
            {
                TaskTimer.Enabled = false;
                StartBtn.Text = "Continue (F4)";
                StopBtn.Enabled = true;
                testStatus = 0;
            }


        }

        private void TestTimer_Tick(object sender, EventArgs e)
        {
            StartBtn.Enabled = false;
            if (DateTime.Now >= curtTestBookTime)
            {
                if (OnlyVnaChecker.Checked == true)
                {
                    MouseAction.UStart();
                }
                TaskTimer.Enabled = true;
                TestTimer.Enabled = false;
                StartBtn.Enabled = true;
            }

        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = true;
            StopBtn.Enabled = false;
            TaskTimer.Enabled = false;
            TestTimer.Enabled = false;
            StartBtn.Text = "Start";
            testStatus = -1;
        }


        private void PrintBtn_Click(object sender, EventArgs e)
        {
            IO.CsvPrint(resultMan.resultList);
        }



        private void ResultPathBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveDirDialog = new FolderBrowserDialog();
            if (saveDirDialog.ShowDialog() == DialogResult.OK)
            {
                IO.resultDir = saveDirDialog.SelectedPath;
                ResultPathTB.Text = IO.resultDir;
            }
        }

        private void IniAllBtn_Click(object sender, EventArgs e)
        {
            cycleItemPair.Clear();
            pointItemPair.Clear();
            actionItemPair.Clear();
            manager.InitManager();
            resultMan.InitManager();
            dataQueue.Clear();
            curtCycle = 0;
            curtPoint = 0;
            curtStrain = 0;
            curtSerialNum = 0;
            curtTestBookTime = DateTime.Now;
        }

        private void FoldMonitorBtn_Click(object sender, EventArgs e)
        {
            if (this.Width > 362)
            {
                this.Width = 362;
                FirstSplit.Panel2Collapsed = true;
            }
            else
            {
                this.Width = 1060;
                FirstSplit.Panel2Collapsed = false;
            }

        }

        private void RamTimer_Tick(object sender, EventArgs e)
        {
            RamLabelContent.Text = Util.GetProcessUsedMemory() + "MB";
        }

        private void DelBtn_Click(object sender, EventArgs e)//删除操作！
        {
            DialogResult isDel = MessageBox.Show("Delete all files?", "Confirm Message", MessageBoxButtons.OKCancel);
            if (isDel == DialogResult.OK)
            {
                IO.DeleteFiles(IO.saveDir);
                IO.DeleteFiles(IO.processedDir);
                IO.DeleteFiles(IO.autoSaveDir);
            }
        }

        private void FirstToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Analysis analysis = new Analysis();
            analysis.StartPosition = FormStartPosition.Manual;
            analysis.startPosition = new Point(this.Location.X, this.Location.Y);
            analysis.Show();



        }

        private void SecondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.StartPosition = FormStartPosition.Manual;
            settings.startPosition = new Point(this.Location.X, this.Location.Y);
            settings.Show();
        }

        private void ThirdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int zeroPoint = 10;

            try
            {
                zeroPoint = int.Parse(IniLengthBox.Text) + Const.zeroOffset;
                if (isLinked)
                {
                    FormBridge.SetAllText(zeroPoint + "", StrRangeBox.Text, StrSpeedBox.Text, StrSpeedBox.Text, CycleNumBox.Text);
                    MessageBox.Show("同步成功");
                }
                else
                {

                    FormBridge.LinkAllTextBox(zeroPoint + "", StrRangeBox.Text, StrSpeedBox.Text, "0.016", "0", "1", CycleNumBox.Text);
                    isLinked = true;
                    MessageBox.Show("链接成功");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("参数无效");
            }
        }
        private void flowDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Designer ds = new Designer();
            ds.StartPosition = FormStartPosition.Manual;
            //ds.startPosition = new Point(this.Location.X, this.Location.Y);
            ds.Show();
        }
        private void StatusLabel_Click(object sender, EventArgs e)
        {
          
        }

     
    }
}
