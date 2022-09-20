using ExcelDataReader;
using System.Collections.Generic;
using System.IO;

namespace MainController
{
    //数据计算
    public class ResultManager
    {
        public double minRange = 1400000000;//Hz
        public double maxRange = 1600000000;
        List<SPara> list = new List<SPara>();
        List<SPara> fullList = new List<SPara>();
        public List<Result> resultList = new List<Result>();

        public void InitManager()
        {
            minRange = 1400000000;
            maxRange = 1600000000;
            list.Clear();
            fullList.Clear();
            resultList.Clear();
        }
        public double GetMinFreq(string path)
        {
            list.Clear();
            GetFullList(path);
            for (int i = 0; i <= fullList.Count - 1; i++)
            {
                double freq = fullList[i].freq;
                if (freq >= minRange && freq <= maxRange)//圈定比较数据
                {
                    list.Add(fullList[i]);
                }
                if (freq > maxRange)//节省性能
                {
                    break;
                }
            }
            list.Sort(new ParaCompare());//升序

            return list[0].freq;
        }

        private void GetFullList(string path)
        {
            fullList.Clear();
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    for (int i = 2; i <= result.Tables[0].Rows.Count - 1; i++)
                    {
                        SPara data = new SPara();
                        data.freq = (double)result.Tables[0].Rows[i][0];
                        data.s = (double)result.Tables[0].Rows[i][1];
                        fullList.Add(data);
                    }
                }
            }

        }

        public void SetMaxMin(double min, double max)
        {
            minRange = min;
            maxRange = max;
        }


    }
}
