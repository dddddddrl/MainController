using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MainController
{
    public static class IO
    {
        //需根据机器自定义
        public static string saveDir = "C:\\Users\\ddddd\\vnaJ.3.2\\export";
        public static string processedDir = "C:\\Users\\ddddd\\vnaJ.3.2\\processed";
        public static string resultDir = "C:\\Users\\ddddd\\vnaJ.3.2\\result";
        public static string autoSaveDir = "C:\\Users\\ddddd\\vnaJ.3.2\\result\\autoSave";

   
        public static string newFilePath = "";
        public static int testFileNum = 2;
        public static void SetPath(string path)
        {
            saveDir = path;
        }
        public static void RenameNewFile(string name)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(saveDir);
                FileInfo[] arrFi = di.GetFiles("*.*");
                SortAsFileCreationTime(ref arrFi);

                FileInfo fi = new FileInfo(arrFi[arrFi.Length - 1].FullName);
                newFilePath = processedDir + "\\" + name + ".xls";
                fi.CopyTo(newFilePath);
            }
            catch (Exception)
            {
                throw new Exception("VNAFileNotFound");

            }

        }

        public static string GetNewFilePath()
        {
            return newFilePath;
        }
        private static void SortAsFileCreationTime(ref FileInfo[] arrFi)
        {
            Array.Sort(arrFi, delegate (FileInfo x, FileInfo y)
            {
                return x.CreationTime.CompareTo(y.CreationTime);
            });
        }

        public static void CsvPrint(List<Result> data)
        {
            string fileName = resultDir + "\\" + "Result_Of_Test" + ".csv";

            StreamWriter fileWriter = new StreamWriter(fileName, true, Encoding.UTF8);//TRUE 存在则添加，不存在则新建      
            fileWriter.Write("序列号,时间,毫秒,循环,点数,应变,频率,文件路径");
            fileWriter.Write("\r\n");
            for (int i = 0; i <= data.Count - 1; i++)//DAQData为要保存的float数组数据
            {
                fileWriter.Write(data[i].serialNum + ",");
                fileWriter.Write(data[i].time + ",");
                fileWriter.Write(data[i].time.Millisecond + ",");
                fileWriter.Write(data[i].cycle + ",");
                fileWriter.Write(data[i].point + ",");
                fileWriter.Write(data[i].strain + ",");
                fileWriter.Write(data[i].freq + ",");
                fileWriter.Write(data[i].path);
                fileWriter.Write("\r\n");
            }
            fileWriter.Flush();
            fileWriter.Close();
        }
        public static List<Result> CsvRead(string filePath)
        {
            List<Result> res = new List<Result>();
            try
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                    {
                        var result = reader.AsDataSet();
                        for (int i = 1; i < result.Tables[0].Rows.Count; i++)
                        {

                            Result data = new Result();
                            data.serialNum = int.Parse(result.Tables[0].Rows[i][0] + "");
                            data.time = DateTime.Parse(result.Tables[0].Rows[i][1] + "");
                            data.cycle = int.Parse(result.Tables[0].Rows[i][3] + "");
                            data.point = int.Parse(result.Tables[0].Rows[i][4] + "");
                            data.strain = double.Parse(result.Tables[0].Rows[i][5] + "");
                            data.freq = int.Parse(result.Tables[0].Rows[i][6] + "");
                            data.path = result.Tables[0].Rows[i][7] + "";
                            res.Add(data);


                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("读取错误！");
            }
            return res;


        }

        public static void AutoSave(Result data)
        {
            string fileName = autoSaveDir + "\\" + "AutoSave" + ".csv";
            StreamWriter fileWriter = new StreamWriter(fileName, true, Encoding.UTF8);//TRUE 存在则添加，不存在则新建 
            fileWriter.Write(data.serialNum + ",");
            fileWriter.Write(data.time + ",");
            fileWriter.Write(data.time.Millisecond + ",");
            fileWriter.Write(data.cycle + ",");
            fileWriter.Write(data.point + ",");
            fileWriter.Write(data.strain + ",");
            fileWriter.Write(data.freq + ",");
            fileWriter.Write(data.path);
            fileWriter.Write("\r\n");
            fileWriter.Flush();
            fileWriter.Close();
        }

        public static void GiveTestFile()//仅供测试使用！
        {
            string path = "D:\\测试";
            string newFilePath = "C:\\Users\\ddddd\\vnaJ.3.2\\export";
            if (testFileNum <= 58)
            {
                FileInfo fi = new FileInfo(path + "\\" + testFileNum + ".xls");
                fi.CopyTo(newFilePath + "\\" + testFileNum + ".xls");
                testFileNum++;
                testFileNum++;
            }

        }

        public static bool IsDirEmpty()
        {
            int exportStatus = Directory.GetFileSystemEntries(saveDir).Length;
            int processedStatus = Directory.GetFileSystemEntries(processedDir).Length;
            int autoSaveStatus = Directory.GetFileSystemEntries(autoSaveDir).Length;
            if (exportStatus == 0 && processedStatus == 0 && autoSaveStatus == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void DeleteFiles(string path)//删除某文件夹下所有文件和文件夹如D:\\
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (dir.Exists)
                {
                    DirectoryInfo[] childs = dir.GetDirectories();
                    foreach (DirectoryInfo child in childs)
                    {
                        child.Delete(true);
                    }
                    FileInfo[] fchilds = dir.GetFiles();
                    foreach (FileInfo child in fchilds)
                    {
                        child.Delete();
                    }
                }

            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("目录错误！");

            }


        }
    }
}
