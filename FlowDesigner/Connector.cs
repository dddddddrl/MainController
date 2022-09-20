using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainController.FlowDesigner
{
    internal class Connector:Element
    {
        Pen pen = new Pen(Palette.pure_black, 2);
        List<Point> skeleton = new List<Point>();
        public Point fakeEndPoint = new Point();
        public bool hasEnd = false;
        
        public Connector(string name, Point startPoint):base(name)
        {
            this.type = typeof(Connector);
            this.name = name;
            skeleton.Clear();
            skeleton.Add(startPoint);
            CalcField();
        }
        public void ChangeShape(List<Point> newSkeleton)
        {
            this.skeleton = newSkeleton;
            CalcField();
        }

        private void CalcField()
        {
            this.center.X = (skeleton[0].X + skeleton[skeleton.Count - 1].X) / 2;
            this.center.Y = (skeleton[0].Y + skeleton[skeleton.Count - 1].Y) / 2;
            this.left = new Point(center.X-10,center.Y-10);
            this.right= new Point(center.X +10, center.Y +10);
        }

        public void AddPoint(Point newPoint)
        {
            skeleton.Add(newPoint);
        }

        public override void Paint(ref Graphics g)
        {
            int c=skeleton.Count;
            for(int i = 0; i < c-1; i++)
            {
                g.DrawLine(pen, skeleton[i], skeleton[i + 1]);
            }
            if (!hasEnd)
            {
                g.DrawLine(pen, skeleton[skeleton.Count - 1], fakeEndPoint);
            }

        }

    }
}
