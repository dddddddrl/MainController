using System;
using System.Collections.Generic;
using System.Linq;

namespace MainController
{
    //任务脚本创建器-在此规划鼠标任务
    public class TaskManager
    {
        public List<TaskTree> task = new List<TaskTree>();
        public Queue<TaskTree> actionQueue = new Queue<TaskTree>();
        private DateTime iniTime = new DateTime();

        public void InitManager()
        {
            task.Clear();
            actionQueue.Clear();
        }
        public void GenTask(DateTime iniTime)
        {
            this.iniTime = iniTime;
            DateTime time = iniTime;
            double strain = TestEnv.dStrain;
            double real_strain = TestEnv.dStrain;
            InitManager();
            task.Add(new TaskTree());
            task[0].asRoot();
            for (int cycle = 1; cycle <= TestEnv.cycle; cycle++)
            {
                task.Add(new TaskTree());
                task.Last().asCycle(time, cycle);
                task[0].child.Add(task.Count - 1);
                int cycleNo = task.Count - 1;
                for (int point = 1; point <= TestEnv.pointNum; point++)
                {
                    task.Add(new TaskTree());
                    task.Last().asPoint(time, cycle, point, real_strain, cycleNo);
                    task[cycleNo].child.Add(task.Count - 1);
                    int pointNo = task.Count - 1;
                    for (int act = 0; act <= 4; act++)
                    {
                        task.Add(new TaskTree());
                        task.Last().asAction(time, cycle, point, act, pointNo);
                        actionQueue.Enqueue(task.Last());
                        task[pointNo].child.Add(task.Count - 1);
                        if (act == 0)
                        {
                            time = time.AddMilliseconds(TestEnv.strTime);
                        }
                        else if (act == 1)
                        {
                            time = time.AddMilliseconds(TestEnv.stableTime);
                        }
                        else if (act == 2)
                        {
                            time = time.AddMilliseconds(TestEnv.scanTime);
                        }
                        else if (act == 3)
                        {
                            time = time.AddMilliseconds(TestEnv.saveTime);
                        }
                        else if (act == 4)
                        {
                            time = time.AddMilliseconds(TestEnv.yesTime);
                        }

                    }
                    strain += TestEnv.dStrain;
                    real_strain = TestEnv.maxStrain - Math.Abs(strain - TestEnv.maxStrain);
                }
                strain = 0;
                real_strain = 0;
            }

        }

        public void GenVNATask(DateTime iniTime)
        {
            this.iniTime = iniTime;
            DateTime time = iniTime;
            InitManager();

            task.Add(new TaskTree());
            task.Last().asRoot();

            task.Add(new TaskTree());
            task.Last().asCycle(iniTime, 1);
            task[0].child.Add(task.Count - 1);
            int cycleNo = 1;

            for (int c = 0; c < 65000; c++)
            {
                task.Add(new TaskTree());
                task.Last().asVnaPoint(time, 1, c + 1, 1);
                task[1].child.Add(task.Count - 1);
                int pointNo = c + 2;

                task.Add(new TaskTree());
                task.Last().asVnaAction(time, c + 1, 2, c);
                actionQueue.Enqueue(task.Last());
                task[pointNo].child.Add(task.Count - 1);
                time = time.AddMilliseconds(TestEnv.scanTime);

                task.Add(new TaskTree());
                task.Last().asVnaAction(time, c + 1, 3, c);
                actionQueue.Enqueue(task.Last());
                task[pointNo].child.Add(task.Count - 1);
                time = time.AddMilliseconds(TestEnv.saveTime);

                task.Add(new TaskTree());
                task.Last().asVnaAction(time, c + 1, 4, c);
                actionQueue.Enqueue(task.Last());
                task[pointNo].child.Add(task.Count - 1);
                time = time.AddMilliseconds(TestEnv.yesTime);
            }
        }

        public void DelCycle(int cycleNo)
        {
            for (int i = 0; i <= task.Count - 1; i++)
            {
                if (task[i].cycle == cycleNo)
                {
                    task.RemoveAt(i);
                }
            }
        }

        public void TaskPlayer(TaskTree newTask)
        {
            switch (newTask.action)
            {
                case 0:
                    // Action.UStart_Re(); break;
                    MouseAction.UStart(); break;
                case 1:
                    // Action.UPause_Re(); break;
                    MouseAction.UPause(); break;
                case 2:
                    // Action.UScan_Re(); break;
                    MouseAction.UScan(); break;
                case 3:
                    // Action.USave_Re(); break;
                    MouseAction.USave();
                    if (AppEnv.isDevMode)
                    {
                        IO.GiveTestFile();//测试使用
                    }
                    break;
                case 4:
                    // Action.UYes_Re(); break;
                    MouseAction.UYes(); break;
            }
        }

        public TimeSpan TimeSpend()
        {
            return DateTime.Now - iniTime;
        }

        public TimeSpan TimeRest()
        {
            return task.Last().time - DateTime.Now;
        }

        public double ProgressPrecent()
        {
            double spendTime = TimeSpend().Ticks;
            double restTime = TimeRest().Ticks;
            double allTime = spendTime + restTime;
            double precent = spendTime * 100.0 / allTime;
            if (precent >= 100)
            {
                precent = 100.0;
            }
            return precent;
        }

        public void ActionQueueRenewTime()
        {
            TimeSpan dif = DateTime.Now - actionQueue.First().time + Const.CONTINUE_DELAY;
            TaskTree newTask = new TaskTree();
            long c = actionQueue.Count;
            for (int i = 0; i < c; i++)
            {
                newTask = actionQueue.Dequeue();
                newTask.time = newTask.time + dif;
                actionQueue.Enqueue(newTask);
            }

        }
    }
}
