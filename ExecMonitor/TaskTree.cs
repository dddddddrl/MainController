using System;
using System.Collections.Generic;

namespace MainController
{
    //任务树节点
    public class TaskTree
    {
        public DateTime time;

        public bool isRoot;
        public bool isCycle;
        public bool isPoint;

        //public long serialNum;
        public int cycle;

        public int point;

        public int action;
        public double strain;
        public double result;
        public int father;
        public List<int> child;

        public TaskTree()
        {
            time = DateTime.MinValue;
            isCycle = false;
            isRoot = false;
            isPoint = false;
            action = -1;
            child = new List<int>();
            result = 0;
            strain = 0;
            //serialNum = 0;
        }
        public void asRoot()
        {
            isRoot = true;
        }

        public void asCycle(DateTime iniTime, int cycle)
        {
            time = iniTime;
            this.cycle = cycle;
            isCycle = true;
            this.father = 0;
        }

        public void asPoint(DateTime iniTime, int cycle, int point, double strain, int father)
        {
            time = iniTime;
            this.cycle = cycle;
            this.point = point;
            this.strain = strain;
            isPoint = true;
            this.father = father;
        }

        public void asAction(DateTime actTime, int cycle, int point, int action, int father)
        {
            time = actTime;
            this.cycle = cycle;
            this.point = point;
            this.action = action;
            this.father = father;
        }

        public void asVnaAction(DateTime actTime, int point, int action, int father)
        {
            time = actTime;
            this.action = action;
            this.point = point;
            this.father = father;
        }

        public void asVnaPoint(DateTime iniTime, int cycle, int point, int father)
        {
            time = iniTime;
            this.cycle = cycle;
            this.point = point;
            isPoint = true;
            this.father = father;
        }
    }
}
