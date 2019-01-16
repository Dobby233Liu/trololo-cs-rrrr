using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
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
            this.FormClosing += Form1_FormClosing;
            this.Visible = true;
            SoundPlayer player = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("trolo"));
            player.PlayLooping();
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
