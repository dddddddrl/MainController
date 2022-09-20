namespace MainController
{
    //实验参数表
    public static class TestEnv
    {
        /*
        public static int scanTime = 1500;
        public static int saveTime = 250;
        public static int stableTime = 200;
        public static int yesTime = 200;
        */

        /*
        public static int scanTime = 1700;
        public static int saveTime = 500;
        public static int stableTime = 200;
        public static int yesTime = 200;
        */
        public static int scanTime = 1500;
        public static int saveTime = 250;
        public static int stableTime = 200;
        public static int yesTime = 200;

        public static double strRange = 10;
        public static double strSpeed = 0.08;
        public static double iniLength = 20;
        public static int pointNum = 20;
        public static int cycle = 2;
        public static int strTime = (int)((strRange * 2.0 / pointNum) / strSpeed * 1000);//ms
        public static double dStrain = (strRange * 2.0 / iniLength) / pointNum;
        public static double maxStrain = strRange / iniLength;

        public static void SetStrEnv(double iniLth, double strRge, double strSpd, int cycleNumber, int pointNumber)
        {
            iniLength = iniLth;
            strRange = strRge;
            strSpeed = strSpd;
            cycle = cycleNumber;
            pointNum = pointNumber;
            strTime = (int)((strRange * 2.0 / pointNum) / strSpeed * 1000);//ms
            dStrain = (strRange * 2.0 / iniLength) / pointNum;
            maxStrain = strRange / iniLength;
        }

        public static void SetSensorEnv(int timeOfScan, int timeOfSave, int timeOfStable, int timeOfYes)
        {
            scanTime = timeOfScan;
            saveTime = timeOfSave;
            stableTime = timeOfStable;
            yesTime = timeOfYes;
        }

    }
}
