using System.Drawing;

namespace MainController
{
    //Êó±ê¶¯×÷¿â
    public static class MouseAction
    {
        public static int SAVE_AS_EXCEL_X = 330;
        public static int SAVE_AS_EXCEL_Y = 70;
        public static int SINGLE_SCAN_X = 1800;
        public static int SINGLE_SCAN_Y = 950;
        public static int START_STRETCH_X = 555;
        public static int START_STRETCH_Y = 1000;
        public static int PAUSE_X = 1000;
        public static int PAUSE_Y = 1000;
        public static int YES_X = 950;
        public static int YES_Y = 580;
        public static int UNI_SAVE_X = 326;
        public static int UNI_SAVE_Y = 78;
        public static int UNI_SCAN_X = 729;
        public static int UNI_SCAN_Y = 949;
        public static int UNI_START_X = 1300;
        public static int UNI_START_Y = 428;
        public static int UNI_PAUSE_X = 1522;
        public static int UNI_PAUSE_Y = 428;
        public static int UNI_YES_X = 437;
        public static int UNI_YES_Y = 574;
        public static int SCREEN_CENTER_X = 1920 / 2;
        public static int SCREEN_CENTER_Y = 1080 / 2;

        public static void Save()
        {
            MouseFlag.LefClick(SAVE_AS_EXCEL_X, SAVE_AS_EXCEL_Y);
        }
        public static void Scan()
        {
            MouseFlag.LefClick(SINGLE_SCAN_X, SINGLE_SCAN_Y);
        }

        public static void Start()
        {
            MouseFlag.LefClick(SINGLE_SCAN_X, SINGLE_SCAN_Y);
        }
        public static void Pause()
        {
            MouseFlag.LefClick(PAUSE_X, PAUSE_Y);
        }
        public static void Yes()
        {
            MouseFlag.LefClick(YES_X, YES_Y);
        }
        public static void USave()
        {
            MouseFlag.LefClick(UNI_SAVE_X, UNI_SAVE_Y);
        }
        public static void USave_Re()
        {
            Point origin = MouseFlag.GetPos();
            MouseFlag.LefClick(UNI_SAVE_X, UNI_SAVE_Y);
            MouseFlag.SetPos(origin);
        }
        public static void UScan()
        {
            MouseFlag.LefClick(UNI_SCAN_X, UNI_SCAN_Y);
        }
        public static void UScan_Re()
        {
            Point origin = MouseFlag.GetPos();
            MouseFlag.LefClick(UNI_SCAN_X, UNI_SCAN_Y);
            MouseFlag.SetPos(origin);
        }
        public static void UStart()
        {
            MouseFlag.LefClick(UNI_START_X, UNI_START_Y);
        }
        public static void UStart_Re()
        {
            Point origin = MouseFlag.GetPos();
            MouseFlag.LefClick(UNI_START_X, UNI_START_Y);
            MouseFlag.SetPos(origin);
        }
        public static void UPause()
        {
            MouseFlag.LefClick(UNI_PAUSE_X, UNI_PAUSE_Y);
        }
        public static void UPause_Re()
        {
            Point origin = MouseFlag.GetPos();
            MouseFlag.LefClick(UNI_PAUSE_X, UNI_PAUSE_Y);
            MouseFlag.SetPos(origin);
        }
        public static void UYes()
        {
            MouseFlag.LefClick(UNI_YES_X, UNI_YES_Y);
        }
        public static void UYes_Re()
        {
            Point origin = MouseFlag.GetPos();
            MouseFlag.LefClick(UNI_YES_X, UNI_YES_Y);
            MouseFlag.SetPos(origin);
        }
        public static void Center()
        {
            MouseFlag.SetPos(SCREEN_CENTER_X, SCREEN_CENTER_Y);
        }
        public static void TaskBar()
        {
            MouseFlag.SetPos(0, 0);
        }
    }
}
