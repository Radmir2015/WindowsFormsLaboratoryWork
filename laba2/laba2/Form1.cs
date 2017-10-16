using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba2
{
    public partial class Form1 : Form
    {
        enum Direction { Right, Left, Up, Down };

        Direction direction = Direction.Right; 

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Top < 0)
            {
                label1.Top = 0;
                direction = Direction.Right;
            }

            if (label1.Left > ClientRectangle.Width - label1.Width)
            {
                label1.Left = ClientRectangle.Width - label1.Width;
                direction = Direction.Down;
            }

            if (label1.Top > ClientRectangle.Height - label1.Height)
            {
                label1.Top = ClientRectangle.Height - label1.Height;
                direction = Direction.Left;
            }

            if (label1.Left < 0)
            {
                label1.Left = 0;
                direction = Direction.Up;
            }

            switch (direction)
            {
                case Direction.Right:
                    label1.ForeColor = Color.FromArgb(0, ((ClientRectangle.Width - label1.Width) - label1.Left) * 255 / (ClientRectangle.Width - label1.Width), (label1.Left) * 255 / (ClientRectangle.Width - label1.Width));
                    label1.Left += 10;
                    break;
                case Direction.Down:
                    label1.ForeColor = Color.FromArgb(label1.Top * 255 / (ClientRectangle.Height - label1.Height), 0, 255);
                    label1.Top += 10;
                    break;
                case Direction.Left:
                    label1.ForeColor = Color.FromArgb(255, ((ClientRectangle.Width - label1.Width) - label1.Left) * 255 / (ClientRectangle.Width - label1.Width), label1.Left * 255 / (ClientRectangle.Width - label1.Width));
                    label1.Left -= 10;
                    break;
                case Direction.Up:
                    label1.ForeColor = Color.FromArgb(label1.Top * 255 / (ClientRectangle.Height - label1.Height), 255, 0);
                    label1.Top -= 10;
                    break;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            newForm.form1 = this;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            switch (direction)
            {
                case Direction.Right:
                    label1.Top = 0;
                    break;
                case Direction.Down:
                    label1.Left = ClientRectangle.Width - label1.Width;
                    break;
                case Direction.Left:
                    label1.Top = ClientRectangle.Height - label1.Height;
                    break;
                case Direction.Up:
                    label1.Left = 0;
                    break;
            }
        }
    }
}
