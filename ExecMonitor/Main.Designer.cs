namespace MainController
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.CycleListBox = new System.Windows.Forms.ListBox();
            this.PointListBox = new System.Windows.Forms.ListBox();
            this.ActionListBox = new System.Windows.Forms.ListBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.Monitor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TaskTimer = new System.Windows.Forms.Timer(this.components);
            this.IniLengthBox = new System.Windows.Forms.TextBox();
            this.StrRangeBox = new System.Windows.Forms.TextBox();
            this.StrSpeedBox = new System.Windows.Forms.TextBox();
            this.PointNumBox = new System.Windows.Forms.TextBox();
            this.HrBox = new System.Windows.Forms.NumericUpDown();
            this.MinBox = new System.Windows.Forms.NumericUpDown();
            this.SecBox = new System.Windows.Forms.NumericUpDown();
            this.StartBtn = new System.Windows.Forms.Button();
            this.TestTimer = new System.Windows.Forms.Timer(this.components);
            this.StopBtn = new System.Windows.Forms.Button();
            this.CycleNumBox = new System.Windows.Forms.TextBox();
            this.MinRangeBox = new System.Windows.Forms.TextBox();
            this.MaxRangeBox = new System.Windows.Forms.TextBox();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.ResultPathTB = new System.Windows.Forms.TextBox();
            this.ResultPathBtn = new System.Windows.Forms.Button();
            this.IniAllBtn = new System.Windows.Forms.Button();
            this.FoldMonitorBtn = new System.Windows.Forms.Button();
            this.RamTimer = new System.Windows.Forms.Timer(this.components);
            this.RamLabelCaption = new System.Windows.Forms.Label();
            this.RamLabelContent = new System.Windows.Forms.Label();
            this.OnlyVnaChecker = new System.Windows.Forms.CheckBox();
            this.DelBtn = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FirstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThirdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FirstSplit = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.flowDesignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Monitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HrBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecBox)).BeginInit();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstSplit)).BeginInit();
            this.FirstSplit.Panel1.SuspendLayout();
            this.FirstSplit.Panel2.SuspendLayout();
            this.FirstSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // CycleListBox
            // 
            this.CycleListBox.FormattingEnabled = true;
            this.CycleListBox.ItemHeight = 12;
            this.CycleListBox.Location = new System.Drawing.Point(11, 140);
            this.CycleListBox.Name = "CycleListBox";
            this.CycleListBox.Size = new System.Drawing.Size(49, 160);
            this.CycleListBox.TabIndex = 1;
            this.CycleListBox.SelectedIndexChanged += new System.EventHandler(this.CycleListBox_SelectedIndexChanged);
            // 
            // PointListBox
            // 
            this.PointListBox.FormattingEnabled = true;
            this.PointListBox.ItemHeight = 12;
            this.PointListBox.Location = new System.Drawing.Point(66, 140);
            this.PointListBox.Name = "PointListBox";
            this.PointListBox.Size = new System.Drawing.Size(45, 160);
            this.PointListBox.TabIndex = 2;
            this.PointListBox.SelectedIndexChanged += new System.EventHandler(this.PointListBox_SelectedIndexChanged);
            // 
            // ActionListBox
            // 
            this.ActionListBox.FormattingEnabled = true;
            this.ActionListBox.ItemHeight = 12;
            this.ActionListBox.Location = new System.Drawing.Point(117, 140);
            this.ActionListBox.Name = "ActionListBox";
            this.ActionListBox.Size = new System.Drawing.Size(53, 160);
            this.ActionListBox.TabIndex = 4;
            this.ActionListBox.SelectedIndexChanged += new System.EventHandler(this.ActionListBox_SelectedIndexChanged);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StatusLabel.Location = new System.Drawing.Point(186, 140);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(55, 16);
            this.StatusLabel.TabIndex = 5;
            this.StatusLabel.Text = "label1";
            this.StatusLabel.Click += new System.EventHandler(this.StatusLabel_Click);
            // 
            // Monitor
            // 
            chartArea1.Name = "ChartArea1";
            this.Monitor.ChartAreas.Add(chartArea1);
            this.Monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Monitor.Location = new System.Drawing.Point(0, 0);
            this.Monitor.Name = "Monitor";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.Monitor.Series.Add(series1);
            this.Monitor.Size = new System.Drawing.Size(691, 387);
            this.Monitor.TabIndex = 7;
            this.Monitor.Text = "chart1";
            // 
            // TaskTimer
            // 
            this.TaskTimer.Interval = 50;
            this.TaskTimer.Tick += new System.EventHandler(this.TaskTimer_Tick);
            // 
            // IniLengthBox
            // 
            this.IniLengthBox.Location = new System.Drawing.Point(11, 32);
            this.IniLengthBox.Name = "IniLengthBox";
            this.IniLengthBox.Size = new System.Drawing.Size(44, 21);
            this.IniLengthBox.TabIndex = 10;
            // 
            // StrRangeBox
            // 
            this.StrRangeBox.Location = new System.Drawing.Point(61, 32);
            this.StrRangeBox.Name = "StrRangeBox";
            this.StrRangeBox.Size = new System.Drawing.Size(44, 21);
            this.StrRangeBox.TabIndex = 11;
            // 
            // StrSpeedBox
            // 
            this.StrSpeedBox.Location = new System.Drawing.Point(111, 32);
            this.StrSpeedBox.Name = "StrSpeedBox";
            this.StrSpeedBox.Size = new System.Drawing.Size(44, 21);
            this.StrSpeedBox.TabIndex = 12;
            // 
            // PointNumBox
            // 
            this.PointNumBox.Location = new System.Drawing.Point(211, 32);
            this.PointNumBox.Name = "PointNumBox";
            this.PointNumBox.Size = new System.Drawing.Size(44, 21);
            this.PointNumBox.TabIndex = 13;
            // 
            // HrBox
            // 
            this.HrBox.Location = new System.Drawing.Point(11, 86);
            this.HrBox.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.HrBox.Name = "HrBox";
            this.HrBox.Size = new System.Drawing.Size(44, 21);
            this.HrBox.TabIndex = 14;
            this.HrBox.ValueChanged += new System.EventHandler(this.HrBox_ValueChanged);
            // 
            // MinBox
            // 
            this.MinBox.Location = new System.Drawing.Point(61, 86);
            this.MinBox.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MinBox.Name = "MinBox";
            this.MinBox.Size = new System.Drawing.Size(44, 21);
            this.MinBox.TabIndex = 15;
            this.MinBox.ValueChanged += new System.EventHandler(this.MinBox_ValueChanged);
            // 
            // SecBox
            // 
            this.SecBox.Location = new System.Drawing.Point(111, 86);
            this.SecBox.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.SecBox.Name = "SecBox";
            this.SecBox.Size = new System.Drawing.Size(44, 21);
            this.SecBox.TabIndex = 16;
            this.SecBox.ValueChanged += new System.EventHandler(this.SecBox_ValueChanged);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(174, 84);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(81, 23);
            this.StartBtn.TabIndex = 17;
            this.StartBtn.Text = "Start (F4)";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // TestTimer
            // 
            this.TestTimer.Interval = 50;
            this.TestTimer.Tick += new System.EventHandler(this.TestTimer_Tick);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(261, 84);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(81, 23);
            this.StopBtn.TabIndex = 18;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // CycleNumBox
            // 
            this.CycleNumBox.Location = new System.Drawing.Point(161, 32);
            this.CycleNumBox.Name = "CycleNumBox";
            this.CycleNumBox.Size = new System.Drawing.Size(44, 21);
            this.CycleNumBox.TabIndex = 20;
            // 
            // MinRangeBox
            // 
            this.MinRangeBox.Location = new System.Drawing.Point(11, 59);
            this.MinRangeBox.Name = "MinRangeBox";
            this.MinRangeBox.Size = new System.Drawing.Size(91, 21);
            this.MinRangeBox.TabIndex = 21;
            // 
            // MaxRangeBox
            // 
            this.MaxRangeBox.Location = new System.Drawing.Point(108, 59);
            this.MaxRangeBox.Name = "MaxRangeBox";
            this.MaxRangeBox.Size = new System.Drawing.Size(91, 21);
            this.MaxRangeBox.TabIndex = 22;
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(167, 338);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(75, 23);
            this.PrintBtn.TabIndex = 23;
            this.PrintBtn.Text = "Print";
            this.PrintBtn.UseVisualStyleBackColor = true;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(11, 306);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(271, 23);
            this.ProgressBar.Step = 1;
            this.ProgressBar.TabIndex = 24;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(290, 311);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(41, 12);
            this.ProgressLabel.TabIndex = 25;
            this.ProgressLabel.Text = "label1";
            // 
            // ResultPathTB
            // 
            this.ResultPathTB.Location = new System.Drawing.Point(11, 113);
            this.ResultPathTB.Name = "ResultPathTB";
            this.ResultPathTB.Size = new System.Drawing.Size(274, 21);
            this.ResultPathTB.TabIndex = 26;
            // 
            // ResultPathBtn
            // 
            this.ResultPathBtn.Location = new System.Drawing.Point(291, 111);
            this.ResultPathBtn.Name = "ResultPathBtn";
            this.ResultPathBtn.Size = new System.Drawing.Size(38, 23);
            this.ResultPathBtn.TabIndex = 27;
            this.ResultPathBtn.Text = "...";
            this.ResultPathBtn.UseVisualStyleBackColor = true;
            this.ResultPathBtn.Click += new System.EventHandler(this.ResultPathBtn_Click);
            // 
            // IniAllBtn
            // 
            this.IniAllBtn.Location = new System.Drawing.Point(11, 338);
            this.IniAllBtn.Name = "IniAllBtn";
            this.IniAllBtn.Size = new System.Drawing.Size(75, 23);
            this.IniAllBtn.TabIndex = 28;
            this.IniAllBtn.Text = "Ini All";
            this.IniAllBtn.UseVisualStyleBackColor = true;
            this.IniAllBtn.Click += new System.EventHandler(this.IniAllBtn_Click);
            // 
            // FoldMonitorBtn
            // 
            this.FoldMonitorBtn.Location = new System.Drawing.Point(248, 338);
            this.FoldMonitorBtn.Name = "FoldMonitorBtn";
            this.FoldMonitorBtn.Size = new System.Drawing.Size(94, 23);
            this.FoldMonitorBtn.TabIndex = 29;
            this.FoldMonitorBtn.Text = "Monitor (F3)";
            this.FoldMonitorBtn.UseVisualStyleBackColor = true;
            this.FoldMonitorBtn.Click += new System.EventHandler(this.FoldMonitorBtn_Click);
            // 
            // RamTimer
            // 
            this.RamTimer.Enabled = true;
            this.RamTimer.Interval = 1000;
            this.RamTimer.Tick += new System.EventHandler(this.RamTimer_Tick);
            // 
            // RamLabelCaption
            // 
            this.RamLabelCaption.AutoSize = true;
            this.RamLabelCaption.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RamLabelCaption.Location = new System.Drawing.Point(12, 364);
            this.RamLabelCaption.Name = "RamLabelCaption";
            this.RamLabelCaption.Size = new System.Drawing.Size(31, 16);
            this.RamLabelCaption.TabIndex = 30;
            this.RamLabelCaption.Text = "RAM";
            // 
            // RamLabelContent
            // 
            this.RamLabelContent.AutoSize = true;
            this.RamLabelContent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RamLabelContent.Location = new System.Drawing.Point(49, 364);
            this.RamLabelContent.Name = "RamLabelContent";
            this.RamLabelContent.Size = new System.Drawing.Size(31, 16);
            this.RamLabelContent.TabIndex = 31;
            this.RamLabelContent.Text = "...";
            // 
            // OnlyVnaChecker
            // 
            this.OnlyVnaChecker.AutoSize = true;
            this.OnlyVnaChecker.Checked = true;
            this.OnlyVnaChecker.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OnlyVnaChecker.Location = new System.Drawing.Point(205, 65);
            this.OnlyVnaChecker.Name = "OnlyVnaChecker";
            this.OnlyVnaChecker.Size = new System.Drawing.Size(54, 16);
            this.OnlyVnaChecker.TabIndex = 32;
            this.OnlyVnaChecker.Text = "仅VNA";
            this.OnlyVnaChecker.UseVisualStyleBackColor = true;
            // 
            // DelBtn
            // 
            this.DelBtn.BackColor = System.Drawing.Color.OrangeRed;
            this.DelBtn.Location = new System.Drawing.Point(89, 338);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(75, 23);
            this.DelBtn.TabIndex = 34;
            this.DelBtn.Text = "Delete";
            this.DelBtn.UseVisualStyleBackColor = false;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FirstToolStripMenuItem,
            this.SecondToolStripMenuItem,
            this.ThirdToolStripMenuItem,
            this.flowDesignerToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MainMenu.Size = new System.Drawing.Size(1044, 25);
            this.MainMenu.TabIndex = 35;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FirstToolStripMenuItem
            // 
            this.FirstToolStripMenuItem.Name = "FirstToolStripMenuItem";
            this.FirstToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.FirstToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.FirstToolStripMenuItem.Text = "Analysis (F2)";
            this.FirstToolStripMenuItem.Click += new System.EventHandler(this.FirstToolStripMenuItem_Click);
            // 
            // SecondToolStripMenuItem
            // 
            this.SecondToolStripMenuItem.Name = "SecondToolStripMenuItem";
            this.SecondToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
            this.SecondToolStripMenuItem.Text = "Settings";
            this.SecondToolStripMenuItem.Click += new System.EventHandler(this.SecondToolStripMenuItem_Click);
            // 
            // ThirdToolStripMenuItem
            // 
            this.ThirdToolStripMenuItem.Name = "ThirdToolStripMenuItem";
            this.ThirdToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.ThirdToolStripMenuItem.Text = "Sync/Link";
            this.ThirdToolStripMenuItem.Click += new System.EventHandler(this.ThirdToolStripMenuItem_Click);
            // 
            // FirstSplit
            // 
            this.FirstSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstSplit.Location = new System.Drawing.Point(0, 25);
            this.FirstSplit.Name = "FirstSplit";
            // 
            // FirstSplit.Panel1
            // 
            this.FirstSplit.Panel1.Controls.Add(this.label1);
            this.FirstSplit.Panel1.Controls.Add(this.DelBtn);
            this.FirstSplit.Panel1.Controls.Add(this.StrRangeBox);
            this.FirstSplit.Panel1.Controls.Add(this.RamLabelContent);
            this.FirstSplit.Panel1.Controls.Add(this.OnlyVnaChecker);
            this.FirstSplit.Panel1.Controls.Add(this.RamLabelCaption);
            this.FirstSplit.Panel1.Controls.Add(this.IniLengthBox);
            this.FirstSplit.Panel1.Controls.Add(this.FoldMonitorBtn);
            this.FirstSplit.Panel1.Controls.Add(this.StrSpeedBox);
            this.FirstSplit.Panel1.Controls.Add(this.IniAllBtn);
            this.FirstSplit.Panel1.Controls.Add(this.PointNumBox);
            this.FirstSplit.Panel1.Controls.Add(this.ResultPathBtn);
            this.FirstSplit.Panel1.Controls.Add(this.HrBox);
            this.FirstSplit.Panel1.Controls.Add(this.ResultPathTB);
            this.FirstSplit.Panel1.Controls.Add(this.ProgressLabel);
            this.FirstSplit.Panel1.Controls.Add(this.MinBox);
            this.FirstSplit.Panel1.Controls.Add(this.ProgressBar);
            this.FirstSplit.Panel1.Controls.Add(this.SecBox);
            this.FirstSplit.Panel1.Controls.Add(this.PrintBtn);
            this.FirstSplit.Panel1.Controls.Add(this.StartBtn);
            this.FirstSplit.Panel1.Controls.Add(this.StopBtn);
            this.FirstSplit.Panel1.Controls.Add(this.StatusLabel);
            this.FirstSplit.Panel1.Controls.Add(this.CycleNumBox);
            this.FirstSplit.Panel1.Controls.Add(this.ActionListBox);
            this.FirstSplit.Panel1.Controls.Add(this.MinRangeBox);
            this.FirstSplit.Panel1.Controls.Add(this.PointListBox);
            this.FirstSplit.Panel1.Controls.Add(this.MaxRangeBox);
            this.FirstSplit.Panel1.Controls.Add(this.CycleListBox);
            // 
            // FirstSplit.Panel2
            // 
            this.FirstSplit.Panel2.Controls.Add(this.Monitor);
            this.FirstSplit.Size = new System.Drawing.Size(1044, 387);
            this.FirstSplit.SplitterDistance = 349;
            this.FirstSplit.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "Press F2 Fast Analysis";
            // 
            // flowDesignerToolStripMenuItem
            // 
            this.flowDesignerToolStripMenuItem.Name = "flowDesignerToolStripMenuItem";
            this.flowDesignerToolStripMenuItem.Size = new System.Drawing.Size(98, 21);
            this.flowDesignerToolStripMenuItem.Text = "FlowDesigner";
            this.flowDesignerToolStripMenuItem.Click += new System.EventHandler(this.flowDesignerToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 412);
            this.Controls.Add(this.FirstSplit);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Monitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HrBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecBox)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.FirstSplit.Panel1.ResumeLayout(false);
            this.FirstSplit.Panel1.PerformLayout();
            this.FirstSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FirstSplit)).EndInit();
            this.FirstSplit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox CycleListBox;
        private System.Windows.Forms.ListBox PointListBox;
        private System.Windows.Forms.ListBox ActionListBox;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart Monitor;
        private System.Windows.Forms.Timer TaskTimer;
        private System.Windows.Forms.TextBox IniLengthBox;
        private System.Windows.Forms.TextBox StrRangeBox;
        private System.Windows.Forms.TextBox StrSpeedBox;
        private System.Windows.Forms.TextBox PointNumBox;
        private System.Windows.Forms.NumericUpDown HrBox;
        private System.Windows.Forms.NumericUpDown MinBox;
        private System.Windows.Forms.NumericUpDown SecBox;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Timer TestTimer;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.TextBox CycleNumBox;
        private System.Windows.Forms.TextBox MinRangeBox;
        private System.Windows.Forms.TextBox MaxRangeBox;
        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.TextBox ResultPathTB;
        private System.Windows.Forms.Button ResultPathBtn;
        private System.Windows.Forms.Button IniAllBtn;
        private System.Windows.Forms.Button FoldMonitorBtn;
        private System.Windows.Forms.Timer RamTimer;
        private System.Windows.Forms.Label RamLabelCaption;
        private System.Windows.Forms.Label RamLabelContent;
        private System.Windows.Forms.CheckBox OnlyVnaChecker;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FirstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SecondToolStripMenuItem;
        private System.Windows.Forms.SplitContainer FirstSplit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem ThirdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flowDesignerToolStripMenuItem;
    }
}