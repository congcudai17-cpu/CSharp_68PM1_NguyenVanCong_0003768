using System;
using System.Windows.Forms;

namespace CSharp_68PM1_NguyenVanCong_0003768
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}