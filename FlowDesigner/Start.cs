using System.Drawing;

namespace MainController.FlowDesigner
{
    internal class Start : Node
    {
        Pen pen = new Pen(Palette.strawberry_red, 2);

 
        public Start(string name, Squre squre) : base(name)
        {
            this.type = typeof(Start);
            this.name = name;
            this.shape = squre.shape;
            CalcField();
     
          
        }

        private void CalcField()
        {
            this.left = new Point(shape.X, shape.Y);
            this.right = this.left + shape.Size;
            this.center = new Point((shape.Left + shape.Right) / 2, (shape.Top + shape.Bottom) / 2);
        }

        public override void SetLocation(Point p)
        {
    
            this.shape.X = p.X;
            this.shape.Y = p.Y;
            CalcField();
        }

        public override void Paint(ref Graphics g)
        {
            g.DrawEllipse(pen, shape);

        }
    }
}
