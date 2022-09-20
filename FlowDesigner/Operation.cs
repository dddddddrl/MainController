using System.Drawing;

namespace MainController.FlowDesigner
{
    internal class Operation :Node
    {
        Pen pen = new Pen(Palette.ocean_blue, 2);
        public string action;

        public Operation(string name, Rectangle shape, string action):base(name)
        {
            this.type = typeof(Operation);  
            this.name = name;
            this.shape = shape;
            this.action = action;
            CalcField();
        }

        public override void SetLocation(Point p)
        {
     
            this.shape.X = p.X;
            this.shape.Y = p.Y;
            CalcField();
        }

        private void CalcField()
        {
            this.left = new Point(shape.X, shape.Y);
            this.right = this.left + shape.Size;
            this.center = new Point((shape.Left + shape.Right) / 2, (shape.Top + shape.Bottom) / 2);
        }
        public override void Paint(ref Graphics g)
        {
            g.DrawRectangle(pen, shape);
     
        }

    }
}
