namespace MainController
{
    partial class Analysis
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.FirstSplit = new System.Windows.Forms.SplitContainer();
            this.SecondLSplit = new System.Windows.Forms.SplitContainer();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PointCountTB = new System.Windows.Forms.TextBox();
            this.ChartSB = new System.Windows.Forms.HScrollBar();
            this.MaxXBtn = new System.Windows.Forms.Button();
            this.YAdaptorBtn = new System.Windows.Forms.Button();
            this.MaxXTB = new System.Windows.Forms.TextBox();
            this.MinXTB = new System.Windows.Forms.TextBox();
            this.MaxYTB = new System.Windows.Forms.TextBox();
            this.MinYTB = new System.Windows.Forms.TextBox();
            this.SecondRSplit = new System.Windows.Forms.SplitContainer();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.FileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FirstSplit)).BeginInit();
            this.FirstSplit.Panel1.SuspendLayout();
            this.FirstSplit.Panel2.SuspendLayout();
            this.FirstSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondLSplit)).BeginInit();
            this.SecondLSplit.Panel1.SuspendLayout();
            this.SecondLSplit.Panel2.SuspendLayout();
            this.SecondLSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondRSplit)).BeginInit();
            this.SecondRSplit.Panel2.SuspendLayout();
            this.SecondRSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // FirstSplit
            // 
            this.FirstSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FirstSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstSplit.Location = new System.Drawing.Point(0, 0);
            this.FirstSplit.Name = "FirstSplit";
            // 
            // FirstSplit.Panel1
            // 
            this.FirstSplit.Panel1.Controls.Add(this.SecondLSplit);
            // 
            // FirstSplit.Panel2
            // 
            this.FirstSplit.Panel2.AutoScroll = true;
            this.FirstSplit.Panel2.Controls.Add(this.SecondRSplit);
            this.FirstSplit.Size = new System.Drawing.Size(1784, 861);
            this.FirstSplit.SplitterDistance = 1602;
            this.FirstSplit.TabIndex = 1;
            this.FirstSplit.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.FirstSplit_SplitterMoving);
            this.FirstSplit.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.FirstSplit_SplitterMoved);
            // 
            // SecondLSplit
            // 
            this.SecondLSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SecondLSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondLSplit.Location = new System.Drawing.Point(0, 0);
            this.SecondLSplit.Name = "SecondLSplit";
            this.SecondLSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SecondLSplit.Panel1
            // 
            this.SecondLSplit.Panel1.Controls.Add(this.Chart);
            // 
            // SecondLSplit.Panel2
            // 
            this.SecondLSplit.Panel2.Controls.Add(this.PointCountTB);
            this.SecondLSplit.Panel2.Controls.Add(this.ChartSB);
            this.SecondLSplit.Panel2.Controls.Add(this.MaxXBtn);
            this.SecondLSplit.Panel2.Controls.Add(this.YAdaptorBtn);
            this.SecondLSplit.Panel2.Controls.Add(this.MaxXTB);
            this.SecondLSplit.Panel2.Controls.Add(this.MinXTB);
            this.SecondLSplit.Panel2.Controls.Add(this.MaxYTB);
            this.SecondLSplit.Panel2.Controls.Add(this.MinYTB);
            this.SecondLSplit.Size = new System.Drawing.Size(1602, 861);
            this.SecondLSplit.SplitterDistance = 749;
            this.SecondLSplit.TabIndex = 0;
            // 
            // Chart
            // 
            chartArea1.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea1);
            this.Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.Chart.Legends.Add(legend1);
            this.Chart.Location = new System.Drawing.Point(0, 0);
            this.Chart.Name = "Chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Chart.Series.Add(series1);
            this.Chart.Size = new System.Drawing.Size(1600, 747);
            this.Chart.TabIndex = 0;
            this.Chart.Text = "chart1";
            // 
            // PointCountTB
            // 
            this.PointCountTB.Location = new System.Drawing.Point(537, 74);
            this.PointCountTB.Name = "PointCountTB";
            this.PointCountTB.Size = new System.Drawing.Size(100, 21);
            this.PointCountTB.TabIndex = 8;
            this.PointCountTB.TextChanged += new System.EventHandler(this.PointCountTB_TextChanged);
            // 
            // ChartSB
            // 
            this.ChartSB.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChartSB.Location = new System.Drawing.Point(0, 0);
            this.ChartSB.Maximum = 1000;
            this.ChartSB.Minimum = 1;
            this.ChartSB.Name = "ChartSB";
            this.ChartSB.Size = new System.Drawing.Size(1600, 15);
            this.ChartSB.TabIndex = 1;
            this.ChartSB.Value = 1;
            this.ChartSB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ChartSB_Scroll);
            // 
            // MaxXBtn
            // 
            this.MaxXBtn.Location = new System.Drawing.Point(329, 76);
            this.MaxXBtn.Name = "MaxXBtn";
            this.MaxXBtn.Size = new System.Drawing.Size(37, 23);
            this.MaxXBtn.TabIndex = 7;
            this.MaxXBtn.Text = "Max";
            this.MaxXBtn.UseVisualStyleBackColor = true;
            this.MaxXBtn.Click += new System.EventHandler(this.MaxXBtn_Click);
            // 
            // YAdaptorBtn
            // 
            this.YAdaptorBtn.Location = new System.Drawing.Point(10, 74);
            this.YAdaptorBtn.Name = "YAdaptorBtn";
            this.YAdaptorBtn.Size = new System.Drawing.Size(100, 23);
            this.YAdaptorBtn.TabIndex = 6;
            this.YAdaptorBtn.Text = "Y Axis S-A";
            this.YAdaptorBtn.UseVisualStyleBackColor = true;
            this.YAdaptorBtn.Click += new System.EventHandler(this.YAdaptorBtn_Click);
            // 
            // MaxXTB
            // 
            this.MaxXTB.Location = new System.Drawing.Point(222, 76);
            this.MaxXTB.Name = "MaxXTB";
            this.MaxXTB.Size = new System.Drawing.Size(100, 21);
            this.MaxXTB.TabIndex = 5;
            this.MaxXTB.TextChanged += new System.EventHandler(this.MaxXTB_TextChanged);
            // 
            // MinXTB
            // 
            this.MinXTB.Location = new System.Drawing.Point(116, 76);
            this.MinXTB.Name = "MinXTB";
            this.MinXTB.Size = new System.Drawing.Size(100, 21);
            this.MinXTB.TabIndex = 4;
            this.MinXTB.TextChanged += new System.EventHandler(this.MinXTB_TextChanged);
            // 
            // MaxYTB
            // 
            this.MaxYTB.Location = new System.Drawing.Point(10, 18);
            this.MaxYTB.Name = "MaxYTB";
            this.MaxYTB.Size = new System.Drawing.Size(100, 21);
            this.MaxYTB.TabIndex = 3;
            this.MaxYTB.TextChanged += new System.EventHandler(this.MaxYTB_TextChanged);
            // 
            // MinYTB
            // 
            this.MinYTB.Location = new System.Drawing.Point(10, 47);
            this.MinYTB.Name = "MinYTB";
            this.MinYTB.Size = new System.Drawing.Size(100, 21);
            this.MinYTB.TabIndex = 2;
            this.MinYTB.TextChanged += new System.EventHandler(this.MinYTB_TextChanged);
            // 
            // SecondRSplit
            // 
            this.SecondRSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SecondRSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondRSplit.Location = new System.Drawing.Point(0, 0);
            this.SecondRSplit.Name = "SecondRSplit";
            this.SecondRSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SecondRSplit.Panel1
            // 
            this.SecondRSplit.Panel1.AutoScroll = true;
            // 
            // SecondRSplit.Panel2
            // 
            this.SecondRSplit.Panel2.Controls.Add(this.OpenBtn);
            this.SecondRSplit.Size = new System.Drawing.Size(178, 861);
            this.SecondRSplit.SplitterDistance = 747;
            this.SecondRSplit.TabIndex = 0;
            this.SecondRSplit.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.SecondRSplit_SplitterMoving);
            this.SecondRSplit.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SecondRSplit_SplitterMoved);
            // 
            // OpenBtn
            // 
            this.OpenBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OpenBtn.Location = new System.Drawing.Point(0, 0);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(176, 108);
            this.OpenBtn.TabIndex = 0;
            this.OpenBtn.Text = "Open";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // FileMenu
            // 
            this.FileMenu.Name = "contextMenuStrip1";
            this.FileMenu.ShowImageMargin = false;
            this.FileMenu.Size = new System.Drawing.Size(36, 4);
            this.FileMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.FileMenu_ItemClicked);
            // 
            // Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1784, 861);
            this.Controls.Add(this.FirstSplit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Analysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Analysis";
            this.Load += new System.EventHandler(this.Analysis_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Analysis_Paint);
            this.FirstSplit.Panel1.ResumeLayout(false);
            this.FirstSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FirstSplit)).EndInit();
            this.FirstSplit.ResumeLayout(false);
            this.SecondLSplit.Panel1.ResumeLayout(false);
            this.SecondLSplit.Panel2.ResumeLayout(false);
            this.SecondLSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondLSplit)).EndInit();
            this.SecondLSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.SecondRSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SecondRSplit)).EndInit();
            this.SecondRSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }





        #endregion

        private System.Windows.Forms.SplitContainer FirstSplit;
        private System.Windows.Forms.SplitContainer SecondLSplit;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.HScrollBar ChartSB;
        private System.Windows.Forms.ContextMenuStrip FileMenu;
        private System.Windows.Forms.SplitContainer SecondRSplit;
        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.TextBox MaxYTB;
        private System.Windows.Forms.TextBox MinYTB;
        private System.Windows.Forms.TextBox MaxXTB;
        private System.Windows.Forms.TextBox MinXTB;
        private System.Windows.Forms.Button YAdaptorBtn;
        private System.Windows.Forms.Button MaxXBtn;
        private System.Windows.Forms.TextBox PointCountTB;
    }
}