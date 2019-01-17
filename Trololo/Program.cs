using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trololo
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
            Application.Run(new Form1());
            DoOpenA();
        }
        private static void DoOpenA() {
            Task.Factory.StartNew(DoOpenB);
        }

        private static void DoOpenB()
        {
            for (int frmCount = 0; frmCount < 5; frmCount++)
            {
                Form1 frm = new Form1();
                frm.basicDelay = ((int)(int)frm.basicDelay * (int)1.34 / (int)new Random().Next(2));
                Application.Run(frm);
            }
        }
    }
}
