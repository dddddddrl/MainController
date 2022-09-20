namespace MainController.FlowDesigner
{
    partial class Designer
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
            System.Windows.Forms.SplitContainer VertiSplit;
            this.PaintBox = new System.Windows.Forms.PictureBox();
            this.ElementPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AddOptBtn = new System.Windows.Forms.Button();
            this.AddConBtn = new System.Windows.Forms.Button();
            this.AddFlowCtlBtn = new System.Windows.Forms.Button();
            this.AddGroupBtn = new System.Windows.Forms.Button();
            this.AddCustBtn = new System.Windows.Forms.Button();
            this.HoriSplit = new System.Windows.Forms.SplitContainer();
            this.ToolPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.Delay = new System.Windows.Forms.Button();
            VertiSplit = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(VertiSplit)).BeginInit();
            VertiSplit.Panel1.SuspendLayout();
            VertiSplit.Panel2.SuspendLayout();
            VertiSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaintBox)).BeginInit();
            this.ElementPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HoriSplit)).BeginInit();
            this.HoriSplit.Panel1.SuspendLayout();
            this.HoriSplit.Panel2.SuspendLayout();
            this.HoriSplit.SuspendLayout();
            this.ToolPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // VertiSplit
            // 
            VertiSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            VertiSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            VertiSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            VertiSplit.IsSplitterFixed = true;
            VertiSplit.Location = new System.Drawing.Point(0, 0);
            VertiSplit.Name = "VertiSplit";
            // 
            // VertiSplit.Panel1
            // 
            VertiSplit.Panel1.Controls.Add(this.PaintBox);
            // 
            // VertiSplit.Panel2
            // 
            VertiSplit.Panel2.Controls.Add(this.ElementPanel);
            VertiSplit.Size = new System.Drawing.Size(859, 514);
            VertiSplit.SplitterDistance = 748;
            VertiSplit.TabIndex = 0;
            // 
            // PaintBox
            // 
            this.PaintBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaintBox.Location = new System.Drawing.Point(0, 0);
            this.PaintBox.Name = "PaintBox";
            this.PaintBox.Size = new System.Drawing.Size(746, 512);
            this.PaintBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaintBox.TabIndex = 0;
            this.PaintBox.TabStop = false;
            // 
            // ElementPanel
            // 
            this.ElementPanel.ColumnCount = 1;
            this.ElementPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.ElementPanel.Controls.Add(this.AddOptBtn, 0, 0);
            this.ElementPanel.Controls.Add(this.AddConBtn, 0, 2);
            this.ElementPanel.Controls.Add(this.AddFlowCtlBtn, 0, 3);
            this.ElementPanel.Controls.Add(this.AddGroupBtn, 0, 4);
            this.ElementPanel.Controls.Add(this.AddCustBtn, 0, 5);
            this.ElementPanel.Controls.Add(this.Delay, 0, 1);
            this.ElementPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ElementPanel.Location = new System.Drawing.Point(0, 0);
            this.ElementPanel.Name = "ElementPanel";
            this.ElementPanel.RowCount = 7;
            this.ElementPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ElementPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ElementPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ElementPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ElementPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ElementPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ElementPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ElementPanel.Size = new System.Drawing.Size(105, 512);
            this.ElementPanel.TabIndex = 0;
            // 
            // AddOptBtn
            // 
            this.AddOptBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddOptBtn.Location = new System.Drawing.Point(3, 3);
            this.AddOptBtn.Name = "AddOptBtn";
            this.AddOptBtn.Size = new System.Drawing.Size(99, 94);
            this.AddOptBtn.TabIndex = 0;
            this.AddOptBtn.Text = "Operation";
            this.AddOptBtn.UseVisualStyleBackColor = true;
            this.AddOptBtn.Click += new System.EventHandler(this.AddOptBtn_Click);
            // 
            // AddConBtn
            // 
            this.AddConBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddConBtn.Location = new System.Drawing.Point(3, 203);
            this.AddConBtn.Name = "AddConBtn";
            this.AddConBtn.Size = new System.Drawing.Size(99, 94);
            this.AddConBtn.TabIndex = 1;
            this.AddConBtn.Text = "Connector";
            this.AddConBtn.UseVisualStyleBackColor = true;
            this.AddConBtn.Click += new System.EventHandler(this.AddConBtn_Click);
            // 
            // AddFlowCtlBtn
            // 
            this.AddFlowCtlBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddFlowCtlBtn.Location = new System.Drawing.Point(3, 303);
            this.AddFlowCtlBtn.Name = "AddFlowCtlBtn";
            this.AddFlowCtlBtn.Size = new System.Drawing.Size(99, 94);
            this.AddFlowCtlBtn.TabIndex = 2;
            this.AddFlowCtlBtn.Text = "Flow Control";
            this.AddFlowCtlBtn.UseVisualStyleBackColor = true;
            this.AddFlowCtlBtn.Click += new System.EventHandler(this.AddFlowCtlBtn_Click);
            // 
            // AddGroupBtn
            // 
            this.AddGroupBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddGroupBtn.Location = new System.Drawing.Point(3, 403);
            this.AddGroupBtn.Name = "AddGroupBtn";
            this.AddGroupBtn.Size = new System.Drawing.Size(99, 94);
            this.AddGroupBtn.TabIndex = 3;
            this.AddGroupBtn.Text = "Group";
            this.AddGroupBtn.UseVisualStyleBackColor = true;
            this.AddGroupBtn.Click += new System.EventHandler(this.AddGroupBtn_Click);
            // 
            // AddCustBtn
            // 
            this.AddCustBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddCustBtn.Location = new System.Drawing.Point(3, 503);
            this.AddCustBtn.Name = "AddCustBtn";
            this.AddCustBtn.Size = new System.Drawing.Size(99, 94);
            this.AddCustBtn.TabIndex = 4;
            this.AddCustBtn.Text = "Custom";
            this.AddCustBtn.UseVisualStyleBackColor = true;
            this.AddCustBtn.Click += new System.EventHandler(this.AddCustBtn_Click);
            // 
            // HoriSplit
            // 
            this.HoriSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HoriSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HoriSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.HoriSplit.IsSplitterFixed = true;
            this.HoriSplit.Location = new System.Drawing.Point(0, 0);
            this.HoriSplit.Name = "HoriSplit";
            this.HoriSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // HoriSplit.Panel1
            // 
            this.HoriSplit.Panel1.Controls.Add(VertiSplit);
            // 
            // HoriSplit.Panel2
            // 
            this.HoriSplit.Panel2.Controls.Add(this.ToolPanel);
            this.HoriSplit.Size = new System.Drawing.Size(859, 582);
            this.HoriSplit.SplitterDistance = 514;
            this.HoriSplit.TabIndex = 1;
            // 
            // ToolPanel
            // 
            this.ToolPanel.ColumnCount = 7;
            this.ToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.ToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.ToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.ToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.ToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.ToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.ToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.ToolPanel.Controls.Add(this.ClearBtn, 6, 0);
            this.ToolPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.RowCount = 1;
            this.ToolPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolPanel.Size = new System.Drawing.Size(857, 62);
            this.ToolPanel.TabIndex = 1;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearBtn.Location = new System.Drawing.Point(735, 3);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(119, 56);
            this.ClearBtn.TabIndex = 0;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // Delay
            // 
            this.Delay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Delay.Location = new System.Drawing.Point(3, 103);
            this.Delay.Name = "Delay";
            this.Delay.Size = new System.Drawing.Size(99, 94);
            this.Delay.TabIndex = 5;
            this.Delay.Text = "Delay";
            this.Delay.UseVisualStyleBackColor = true;
            this.Delay.Click += new System.EventHandler(this.Delay_Click);
            // 
            // Designer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(859, 582);
            this.Controls.Add(this.HoriSplit);
            this.DoubleBuffered = true;
            this.Name = "Designer";
            this.Text = "Designer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Designer_FormClosed);
            this.Load += new System.EventHandler(this.Designer_Load);
            VertiSplit.Panel1.ResumeLayout(false);
            VertiSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(VertiSplit)).EndInit();
            VertiSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PaintBox)).EndInit();
            this.ElementPanel.ResumeLayout(false);
            this.HoriSplit.Panel1.ResumeLayout(false);
            this.HoriSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HoriSplit)).EndInit();
            this.HoriSplit.ResumeLayout(false);
            this.ToolPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer HoriSplit;
        private System.Windows.Forms.TableLayoutPanel ToolPanel;
        private System.Windows.Forms.TableLayoutPanel ElementPanel;
        private System.Windows.Forms.PictureBox PaintBox;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button AddOptBtn;
        private System.Windows.Forms.Button AddConBtn;
        private System.Windows.Forms.Button AddFlowCtlBtn;
        private System.Windows.Forms.Button AddGroupBtn;
        private System.Windows.Forms.Button AddCustBtn;
        private System.Windows.Forms.Button Delay;
    }
}