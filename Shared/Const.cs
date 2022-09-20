using System;

namespace MainController
{
    public static class Const
    {
        public static string BASE_DIR = AppDomain.CurrentDomain.BaseDirectory;
        public const string CONFIG_NAME = "config.xlsx";
        public const int VNA_MIN_FREQ = 10000000;
        public const int VNA_MAX_FREQ = 2147483647;
        public static TimeSpan CONTINUE_DELAY = new TimeSpan(0, 0, 1); //任务新起点延迟1s
        public const string READ_CONFIG = "读取配置参数";
        public const string SET_CONFIG = "设置配置参数";
        public const string START = "开始拉伸";
        public const string STOP = "停止拉伸";
        public const string PAUSE = "暂停";
        public const string FACTORY = "恢复出厂设置";
        public const int zeroOffset = 4;
    }
}
