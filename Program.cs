using MainController.FlowDesigner;
using System;
using System.Windows.Forms;

namespace MainController
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Designer());
            Application.Run(new Main());
        }
    }
}
