using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainController.FlowDesigner
{
    internal class Loop : Node
    {
        public Loop(string name) : base(name)
        {
            this.type=typeof(Loop); 
        }
        public override string Next()
        {
            return "";
        }
    }
}
