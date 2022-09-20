using System;

namespace MainController
{
    //通用实验数据格式
    public class Result
    {
        public DateTime time;
        public int serialNum;
        public int cycle;
        public int point;
        public double strain;
        public double freq;
        public string path;

        public Result()
        {
            time = DateTime.Now;
            serialNum = 0;
            cycle = 0;
            point = 0;
            strain = -1;
            freq = 0;
            path = "";

        }
        public Result(DateTime time, int serialNum, int cycle, int point, double strain, double freq, string path)
        {
            this.time = DateTime.Now;
            this.serialNum = serialNum;
            this.cycle = cycle;
            this.point = point;
            this.strain = strain;

            this.freq = freq;
            this.path = path;

        }

    }
}
