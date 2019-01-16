using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            this.Visible = true;
            Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));
            Random rd = new Random();
            while (true)
            {
                int picXPoint = rd.Next(0, bounds.Right - this.Width);
                int picYPoint = rd.Next(0, bounds.Height - this.Height);
                Point ulCorner = new Point(picXPoint, picYPoint);
                this.Location = ulCorner;
                Delay(100);
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
