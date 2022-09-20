using System.Drawing;

namespace MainController.FlowDesigner
{
    internal class Delay : Node
    {
        Pen pen = new Pen(Palette.ocean_blue, 2);
        public int delayTime=0;
        public int height;

        public Delay(string name, Rectangle shape, int delayTime) : base(name)
        {
            this.type=typeof(Delay);
            this.name = name;
            this.shape = shape;
            this.delayTime=delayTime;
            CalcField();
        }

        public override void SetLocation(Point p)
        {
            this.shape.X=p.X;
            this.shape.Y=p.Y;
            CalcField();
        }

        private void CalcField()
        {
            this.left = new Point(shape.X, shape.Y);
            this.right = this.left + shape.Size;
            this.center = new Point((shape.Left + shape.Right) / 2, (shape.Top + shape.Bottom) / 2);
            this.height = shape.Height;
        }
        public override void Paint(ref Graphics g)
        {
            Point p2 = new Point(this.left.X + height, this.left.Y);
            Point p3 = new Point(this.right.X, this.right.Y - height/ 2);
            Point p4= new Point(this.left.X + height, this.left.Y+height);
            Point p5 =new Point(this.left.X, this.left.Y+height);
            g.DrawLine(pen, this.left, p2);
            g.DrawLine(pen, p2, p3);
            g.DrawLine(pen, p3, p4);
            g.DrawLine(pen, p4, p5);
            g.DrawLine(pen, p5, this.left);

        }
    }
}
