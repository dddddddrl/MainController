using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MainController
{
    //数据分析界面
    public partial class Analysis : Form
    {
        Point sp = new Point(5, 10);//列表起始点
        int distance = 5;//行距
        int chartDataNum = 50;//chart每页面点数
        List<Result> srcData = new List<Result>();//chart数据源
        double minY = Const.VNA_MIN_FREQ;
        double maxY = Const.VNA_MAX_FREQ;
        int minX = 1;
        int maxX = 10;
        public Point startPosition = new Point(0, 0);


        struct DataInfo
        {
            public string filePath;
            public PictureBox picBox;
            public Label picLabel;
            public string ctrlName;
        }
        int ctrlName = 1;
        List<DataInfo> files = new List<DataInfo>();
        Control focusedControl;
        public Analysis()
        {
            InitializeComponent();
        }

        private void Analysis_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.analysis;
            this.Location = startPosition;
            this.Text = "Analysis";
            FileMenu.Items.Clear();
            FileMenu.Items.Add("Delete");
            FileMenu.Items.Add("Open File in Explorer");
            InitChart();
            MinYTB.Text = minY + "";
            MaxYTB.Text = maxY + "";
            MinXTB.Text = minX + "";
            MaxXTB.Text = maxX + "";
        }


        private void OpenBtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files（*.csv）|*.csv";
            openFileDialog.Title = "Choose Data";
            openFileDialog.InitialDirectory = "d:\\测试\\Result_Of_Test.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataInfo info = new DataInfo();
                info.filePath = openFileDialog.FileName;
                Image map = Minimap.GetMinimap(IO.CsvRead(info.filePath));
                info.picBox = new PictureBox();
                info.picBox.Height = map.Height;
                info.picBox.Width = map.Width;
                info.picBox.Parent = this.SecondRSplit.Panel1;
                info.picBox.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
                //info.picBox.Location = new System.Drawing.Point(20, 10);
                info.picBox.BackColor = Color.White;
                info.picBox.Image = map;
                info.picBox.Name = ctrlName + "";

                info.ctrlName = info.picBox.Name;
                info.picBox.MouseDown += new MouseEventHandler(this.PicBox_Click);
                //info.picBox.Parent.Controls.Add(info.picBox);
                info.picLabel = new Label();
                info.picLabel.Name = ctrlName + "";
                info.picLabel.Height = 25;
                info.picLabel.Width = 10;
                //info.picLabel.Location = new System.Drawing.Point(5, 10);
                info.picLabel.Text = ctrlName + "";
                info.picLabel.Font = new Font("宋体", 12);
                info.picLabel.Parent = this.SecondRSplit.Panel1;
                //info.picLabel.Parent.Controls.Add(info.picLabel);
                ctrlName++;
                files.Add(info);
                RefreshFilesList();
            }

        }

        private void PicBox_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((PictureBox)sender).ContextMenuStrip = FileMenu;
                FileMenu.Show();
                focusedControl = (Control)sender;
            }
            else if (e.Button == MouseButtons.Left)
            {
                focusedControl = (Control)sender;
                int name = int.Parse(focusedControl.Name);
                for (int i = 0; ; i++)//遍历files记录,并读取数据
                {
                    if (i >= files.Count)
                    {
                        break;
                    }
                    if (files[i].ctrlName == name + "")
                    {
                        srcData = IO.CsvRead(files[i].filePath);
                    }
                }
                Chart_Update();
            }
        }

        private void FileMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == ((ContextMenuStrip)sender).Items[0].Text)//确认删除
            {
                Control[] c = this.SecondRSplit.Panel1.Controls.Find(focusedControl.Name, true);
                int name = int.Parse(focusedControl.Name);
                for (int i = 0; ; i++)//查找files记录
                {
                    if (i >= files.Count)
                    {
                        break;
                    }
                    if (files[i].ctrlName == name + "")
                    {
                        files.Remove(files[i]);
                    }

                }
                RefreshFilesList();
            }
            if (e.ClickedItem.Text == ((ContextMenuStrip)sender).Items[1].Text)//explorer打开文件
            {
                int name = int.Parse(focusedControl.Name);
                for (int i = 0; ; i++)//查找files记录
                {
                    if (i >= files.Count)
                    {
                        break;
                    }
                    if (files[i].ctrlName == name + "")
                    {
                        Process myProcess = new Process();
                        myProcess.StartInfo.FileName = files[i].filePath;
                        myProcess.StartInfo.Verb = "Open";
                        myProcess.StartInfo.CreateNoWindow = true;
                        myProcess.Start();
                    }

                }
            }
        }




        private void MinYTB_TextChanged(object sender, EventArgs e)
        {
            AxisTBChanged();
        }
        private void MaxYTB_TextChanged(object sender, EventArgs e)
        {
            AxisTBChanged();
        }
        private void MinXTB_TextChanged(object sender, EventArgs e)
        {
            AxisTBChanged();
        }
        private void MaxXTB_TextChanged(object sender, EventArgs e)
        {
            AxisTBChanged();
        }


        private void YAdaptorBtn_Click(object sender, EventArgs e)
        {
            YRangeAdaptor();
        }

        private void MaxXBtn_Click(object sender, EventArgs e)
        {
            if (srcData.Count != 0)
            {
                MaxXTB.Text = srcData.Count + "";
            }

        }

        private void ChartSB_Scroll(object sender, ScrollEventArgs e)
        {
            if (srcData.Count != 0)
            {

                MinXTB.Text = ChartSB.Value + "";
                MaxXTB.Text = ChartSB.Value + chartDataNum + "";
            }

        }

        private void PointCountTB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                chartDataNum = int.Parse(PointCountTB.Text);
            }
            catch (Exception)
            {

            }

        }

        private void SecondRSplit_SplitterMoved(object sender, SplitterEventArgs e)
        {
            int l = 0;
        }

        private void SecondRSplit_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            int l = 0;
        }

        private void FirstSplit_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void FirstSplit_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {

        }

        private void Analysis_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshFilesList();
        }

    
    }
}
