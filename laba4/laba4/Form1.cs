using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4
{
    public partial class Form1 : Form
    {
        int[] staticArray = new int[10];
        int[] dinamicArray = { };

        int number = 0;
        int cxS = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out number))
            {
                int[] tempArray = new int[dinamicArray.Length + 1];
                dinamicArray.CopyTo(tempArray, 0); // Копируем старый массив в новый
                dinamicArray = tempArray;
                dinamicArray[dinamicArray.Length - 1] = number;
            }
            label2.Text = "Массив: " + string.Join(", ", dinamicArray);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out number))
            {
                if (cxS >= 10)
                {
                    staticArray.Select(x => 0);
                    cxS = 0;
                }
                else
                {
                    staticArray[cxS] = number;
                    cxS++;
                }
            }
            label1.Text = "Массив: " + string.Join(", ", staticArray);
        }
    }
}
