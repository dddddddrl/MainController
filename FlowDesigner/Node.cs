using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainController.FlowDesigner
{
    internal class Node:Element
    {
        public string nextName="";
        public Rectangle shape;
        public Node()
        {

        }
        public Node(string name):base(name)
        {
            this.type = typeof(Node);
            this.name= name;
        }

        public virtual string Next()
        {
            return nextName;
        }

        public virtual void SetLocation(Point p)
        {

        }
        
  


    }
}
