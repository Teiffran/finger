using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finger
{
    public partial class Form1 : Form
    {
        PictureBox[] pictureBoxes;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            last.Location = MousePosition;
            int x = (this.Width - first.Width) / 2;
            int y = (this.Height - first.Height) / 2;
            first.Location = new Point(x, y);
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Capture = true;
            Point clientPoint = PointToClient(MousePosition);
            last.Location = new Point(clientPoint.X - last.Width / 2, clientPoint.Y - last.Height / 2);
            int p2x = (Convert.ToInt32(clientPoint.X - last.Width / 2) + Convert.ToInt32(first.Location.X)) / 2;
            int p2y = (Convert.ToInt32(clientPoint.Y - last.Height / 2) + Convert.ToInt32(first.Location.Y)) / 2;
            int p1x = (p2x + Convert.ToInt32(first.Location.X)) / 2;
            int p1y = (p2y + Convert.ToInt32(first.Location.Y)) / 2;
            int p3x = (Convert.ToInt32(clientPoint.X - last.Width / 2) + p2x) / 2;
            int p3y = (Convert.ToInt32(clientPoint.Y - last.Height / 2) + p2y) / 2;
            p1.Location = new Point(p1x, p1y);
            p2.Location = new Point(p2x, p2y);
            p3.Location = new Point(p3x, p3y);
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Capture = false;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int x = (this.Width - first.Width) / 2;
            int y = (this.Height - first.Height) / 2;
            first.Location = new Point(x, y);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is PictureBox && control.Name != "first" && control.Name != "last")
                {
                    Controls.Remove(control);
                    control.Dispose();
                }
            }
            foreach (Control control in Controls)
            {
                if (control is PictureBox && control.Name != "first" && control.Name != "last")
                {
                    Controls.Remove(control);
                    control.Dispose();
                }
            }


        }
    }
}
