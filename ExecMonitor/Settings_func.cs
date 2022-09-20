using System.Drawing;
using System.Windows.Forms;

namespace MainController
{
    public partial class Settings : Form
    {
        private void ReTextBox()
        {
            ScanTimeBox.Text = TestEnv.scanTime + "";
            SaveTimeBox.Text = TestEnv.saveTime + "";
            YesTimeBox.Text = TestEnv.yesTime + "";
            StableTimeBox.Text = TestEnv.stableTime + "";
            ScanPosBox.Text = MouseAction.UNI_SCAN_X + "," + MouseAction.UNI_SCAN_Y;
            SavePosBox.Text = MouseAction.UNI_SAVE_X + "," + MouseAction.UNI_SAVE_Y;
            YesPosBox.Text = MouseAction.UNI_YES_X + "," + MouseAction.UNI_YES_Y;
            StrPosBox.Text = MouseAction.UNI_START_X + "," + MouseAction.UNI_START_Y;
            PausePosBox.Text = MouseAction.UNI_PAUSE_X + "," + MouseAction.UNI_PAUSE_Y;
        }

        public void OnHotkey(int HotkeyID) //设置热键的行为
        {
            if (HotkeyID == Hotkey.Hotkey1 && hotKeyBindObj != -1)
            {
                Point p = MouseFlag.GetPos();
                switch (hotKeyBindObj)
                {
                    case 0:
                        MouseAction.UNI_SCAN_X = p.X;
                        MouseAction.UNI_SCAN_Y = p.Y;
                        break;
                    case 1:
                        MouseAction.UNI_SAVE_X = p.X;
                        MouseAction.UNI_SAVE_Y = p.Y;
                        break;
                    case 2:
                        MouseAction.UNI_YES_X = p.X;
                        MouseAction.UNI_YES_Y = p.Y;
                        break;
                    case 3:
                        MouseAction.UNI_START_X = p.X;
                        MouseAction.UNI_START_Y = p.Y;
                        break;
                    case 4:
                        MouseAction.UNI_PAUSE_X = p.X;
                        MouseAction.UNI_PAUSE_Y = p.Y;
                        break;
                    case 5:
                        ShotTimer.Enabled = false;
                        ScreenShot.SetCurtPoint(p);
                        break;
                }
                ReTextBox();


            }

        }




    }
}
