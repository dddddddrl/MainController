using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
//程序流程图设计器，施工中
namespace MainController.FlowDesigner
{
    public partial class Designer : Form
    {
        System.Threading.Timer mouseTimer;
        System.Threading.Timer graphicTimer;
        Thread gt ;
        List<Element> element = new List<Element>();
        int focusdElement = -1;//表示没有聚焦控件,所有控件采用整型编号
        bool focusLocked = false;
        int choosedTemplete = 0;//表示没有选择模板
        int choosedEle = -1;
        Graphics graphic;
        ContextMenuStrip contextMenuStrip;
        Size paintBoxSize;
        int debug = 0;
        Bitmap bki = (Bitmap)MainController.Properties.Resources.bki.Clone();
        enum Templete
        { 
            Null,
            Opt,
            Delay,
            Cnt,
            Flow,
            Group,
            Cust
        }

        public Designer()
        {
            InitializeComponent();

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            element.Clear();
        }

        private void Designer_Load(object sender, EventArgs e)
        {
            graphic = PaintBox.CreateGraphics();
            paintBoxSize = PaintBox.Size;
            PaintBox.MouseDown += new MouseEventHandler(OnMouseDown);
            PaintBox.MouseMove += new MouseEventHandler(OnMouseMove);
            PaintBox.MouseUp += new MouseEventHandler(OnMouseUp);
            this.MouseUp += new MouseEventHandler(OnMouseUp);
            //PaintBox.Image = MainController.Properties.Resources.sky;
            //PaintBox.MouseUp += new MouseEventHandler(t);
            gt = new Thread(new ThreadStart(() =>
            {
                OnRun();
            }));
            gt.Start();
        
        }

        private Point GetRML()//相对坐标，相对Form（除标题栏）
        {
            Point basePoint = new Point(0, 0); ;
            int windowBorder = (this.Width - this.ClientSize.Width) / 2;
            basePoint.X = this.Location.X + windowBorder;
            basePoint.Y = this.Location.Y + (this.Height - this.ClientSize.Height - windowBorder);
            Point absoluteLoc = MouseFlag.GetPos();
            Point relativeLoc = new Point(0, 0);
            relativeLoc.X = absoluteLoc.X - basePoint.X;
            relativeLoc.Y = absoluteLoc.Y - basePoint.Y;
            return relativeLoc;
        }



        private void OnRun()
        {
            while (true)
            {
                GetFocus(element);
                RePaint(element);
            
            }
 
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (focusdElement != -1)
                {
                    if (element[focusdElement].GetType().BaseType == typeof(Node))
                    {
                        int i = focusdElement;
                        ((Node)element[i]).SetLocation(GetRML());

                    }
                }
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            focusLocked = false;
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (focusdElement != -1)
                {
                    focusLocked = true;
                    if (element[focusdElement].GetType().BaseType == typeof(Node))
                    {
                        int i = focusdElement;
                        ((Node)element[i]).SetLocation(GetRML());
                    }

                }
                else
                {
                    if (focusdElement == -1 && choosedTemplete != -1)//未聚焦元素且使用模板
                    {
                        Element o;
                        //新增元素
                        switch (choosedTemplete) {
                            case 1:
                                o= new Operation("opt", new Rectangle(GetRML().X - 5, GetRML().Y - 5, 60, 20), "testAct");
                                break;
                            case 2:
                                o = new Delay("delay", new Rectangle(GetRML().X - 5, GetRML().Y - 5, 60, 30), 1000);
                                break;
                            case 3:
                                o = new Connector("cnt", GetRML());
                                break;
                            default:
                                o = new Operation("opt", new Rectangle(GetRML().X - 5, GetRML().Y - 5, 10, 10), "testAct");
                                break;
                        }                  
                        element.Add(o);
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (focusdElement != -1)
                {
                    choosedEle = focusdElement;
                    contextMenuStrip = new ContextMenuStrip();
                    contextMenuStrip.Items.Add("Copy");
                    contextMenuStrip.Items.Add("Delete");
                    contextMenuStrip.Show(MouseFlag.GetPos());
                    contextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(ProcessItem);
                }
            }

        }

        private void ProcessItem(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Copy")
            {
                Type t = element[choosedEle].type;
                
                if (t == typeof(Operation))
                {
                    Operation o = new Operation("copy",((Operation)element[choosedEle]).shape,"action");
                    element.Add(o);
                }else if (t == typeof(Delay))
                {
                    Delay o = new Delay("copy",((Delay)element[choosedEle]).shape, ((Delay)element[choosedEle]).delayTime);
                    element.Add(o);
                }
                else if (t == typeof(Start))
                {
                    Start o = new Start("copy",new Squre(GetRML(),20));
                    element.Add(o);
                }else if (t == typeof(Stop))
                {
                    Stop o = new Stop("copy", new Squre(GetRML(), 20));
                    element.Add(o);
                }


            }
            else if (e.ClickedItem.Text == "Delete")
            {
                element.RemoveAt(choosedEle);
            }
        }
        private void RePaint(List<Element> element)
        {
            List<Element> cache = element;
            int c = cache.Count;
            try
            {
                //Bitmap bitmap = new Bitmap(PaintBox.Width, PaintBox.Height);
                Bitmap bitmap = (Bitmap)bki.Clone();
                Graphics g;
                g = Graphics.FromImage(bitmap);
                //g.Clear(PaintBox.BackColor);
                for (int i = 0; i < c; i++)
                {
                    cache[i].Paint(ref g);
                    
                }
                this.Invoke(new Action(() =>
                {
                    MainThreadPaint((Bitmap)bitmap.Clone());
                }));
                g.Dispose();
                bitmap.Dispose();
                
            }
            catch (Exception ex)
            {

            }
        }

        private void GetFocus(List<Element> element)//焦点获取
        {
            if (!focusLocked)
            {
                Point p = GetRML();
                List<Element> cache = element;
                int c = cache.Count;
                for (int i = 0; i < c; i++)
                {
                    if (Util.IsInArea(p, cache[i].left, cache[i].right))
                    {
                        focusdElement = i;
                        break;
                    }
                    else
                    {
                        focusdElement = -1;
                    }
                }
                try
                {
                    this.Invoke(new Action(() =>
                    {
                        /*
                         * if (label1 != null)
                        {
                            label1.Text = focusdElement.ToString();
                        }*/
                    }));
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
        }

 

        private void MainThreadPaint(Bitmap b)
        {
            if (paintBoxSize != PaintBox.Size)
            {
                graphic = PaintBox.CreateGraphics();
            }
            graphic.DrawImage(b, new Point(0, 0));
            b.Dispose();
            paintBoxSize = PaintBox.Size;
        }
        private void Designer_FormClosed(object sender, FormClosedEventArgs e)
        {
            gt.Abort(); 
        }

        private void KeepPanelSize()
        {
          //  ((SplitContainer)HoriSplit.Panel1.Controls.Find("VertiSplit", false)[0]).Panel2.;
        }
        private void AddOptBtn_Click(object sender, EventArgs e)
        {

            choosedTemplete =(int) Templete.Opt;

        }
        private void Delay_Click(object sender, EventArgs e)
        {
            choosedTemplete = (int)Templete.Delay;
        }
        private void AddConBtn_Click(object sender, EventArgs e)
        {
            choosedTemplete = (int)Templete.Cnt;
        }

        private void AddFlowCtlBtn_Click(object sender, EventArgs e)
        {
            choosedTemplete = (int)Templete.Flow;
        }

        private void AddGroupBtn_Click(object sender, EventArgs e)
        {
            choosedTemplete = (int)Templete.Group;
        }

        private void AddCustBtn_Click(object sender, EventArgs e)
        {
            choosedTemplete=(int)Templete.Cust;
        }

      
    }
}
