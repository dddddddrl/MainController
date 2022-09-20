using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainController
{
    internal class Squre
    {
        public Rectangle shape;
        public Squre(Point p,int len)//边长，左脚点
        {
            shape = new Rectangle(p,new Size(len,len));
        }
    }
}
