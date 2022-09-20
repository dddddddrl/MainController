using System;
using System.Drawing;

namespace MainController.FlowDesigner
{
    internal class Element
    {
        public string name="";//控件名称
        public Point center=new Point(0,0);
        public Point left = new Point(0, 0);
        public Point right = new Point(0, 0);
        public Type type;

        public Element()
        {

        }
        public Element(string name)
        {
            this.name = name;
        }

        public virtual void Paint(ref Graphics g)
        {

        }
    }
}
