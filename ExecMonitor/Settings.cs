using ExcelDataReader;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MainController
{
    //设置界面
    public partial class Settings : Form
    {
        Hotkey hotkey;
        int hotKeyBindObj = -1;
        Point p = MouseFlag.GetPos();
        Point leftUp = new Point(0, 0);
        Point rightDown = new Point(50, 50);
        public Point startPosition = new Point(0, 0);

        public Settings()
        {
            InitializeComponent();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.settings;
            this.Location = startPosition;
            hotkey = new Hotkey(this.Handle);
            Hotkey.Hotkey1 = hotkey.RegisterHotkey(System.Windows.Forms.Keys.F5, Hotkey.KeyFlags.MOD_NONE);
            hotkey.OnHotkey += new HotkeyEventHandler(OnHotkey);
            ReTextBox();


        }


        private void EnterBtn_Click(object sender, EventArgs e)
        {
            TestEnv.SetSensorEnv(int.Parse(ScanTimeBox.Text), int.Parse(SaveTimeBox.Text), int.Parse(StableTimeBox.Text), int.Parse(YesTimeBox.Text));

        }

        private void ScanPosBtn_Click(object sender, EventArgs e)
        {
            hotKeyBindObj = 0;
        }

        private void SavePosBtn_Click(object sender, EventArgs e)
        {
            hotKeyBindObj = 1;
        }

        private void YesPosBtn_Click(object sender, EventArgs e)
        {
            hotKeyBindObj = 2;
        }

        private void StrPosBtn_Click(object sender, EventArgs e)
        {
            hotKeyBindObj = 3;
        }

        private void PausePosBtn_Click(object sender, EventArgs e)
        {
            hotKeyBindObj = 4;
        }



        private void ChooseSaveImage_Click(object sender, EventArgs e)
        {
            ShotTimer.Enabled = true;
            hotKeyBindObj = 5;

        }

        private void ShotTimer_Tick(object sender, EventArgs e)
        {
            p = MouseFlag.GetPos();
            if (p.X >= 50 && p.Y >= 50)
            {
                leftUp.X = p.X - 50;
                leftUp.Y = p.Y - 50;
                rightDown.X = p.X;
                rightDown.Y = p.Y;
                BrowseBox.Image = ScreenShot.GetPartScreen(leftUp, rightDown);
            }

        }

        private void ReadConfigBtn_Click(object sender, EventArgs e)
        {
            string path = Const.BASE_DIR + Const.CONFIG_NAME;
            try
            {
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();

                        TestEnv.scanTime = int.Parse(result.Tables[0].Rows[1][1] + "");
                        TestEnv.saveTime = int.Parse(result.Tables[0].Rows[2][1] + "");
                        TestEnv.yesTime = int.Parse(result.Tables[0].Rows[3][1] + "");
                        TestEnv.stableTime = int.Parse(result.Tables[0].Rows[4][1] + "");
                        MouseAction.UNI_SCAN_X = int.Parse(result.Tables[0].Rows[5][1] + "");
                        MouseAction.UNI_SCAN_Y = int.Parse(result.Tables[0].Rows[6][1] + "");
                        MouseAction.UNI_SAVE_X = int.Parse(result.Tables[0].Rows[7][1] + "");
                        MouseAction.UNI_SAVE_Y = int.Parse(result.Tables[0].Rows[8][1] + "");
                        MouseAction.UNI_YES_X = int.Parse(result.Tables[0].Rows[9][1] + "");
                        MouseAction.UNI_YES_Y = int.Parse(result.Tables[0].Rows[10][1] + "");
                        MouseAction.UNI_START_X = int.Parse(result.Tables[0].Rows[11][1] + "");
                        MouseAction.UNI_START_Y = int.Parse(result.Tables[0].Rows[12][1] + "");
                        MouseAction.UNI_PAUSE_X = int.Parse(result.Tables[0].Rows[13][1] + "");
                        MouseAction.UNI_PAUSE_Y = int.Parse(result.Tables[0].Rows[14][1] + "");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Config文件不存在");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("目录错误");
            }
            //catch (Exception)
            //{
            //   MessageBox.Show("Error");
            //}
            ReTextBox();
        }

        private void DevModeSwitch_CheckedChanged(object sender, EventArgs e)
        {
            AppEnv.isDevMode = DevModeSwitch.Checked;
        }
    }
}
