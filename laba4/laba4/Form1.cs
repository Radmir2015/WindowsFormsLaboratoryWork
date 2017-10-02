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

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Массив: пуст";
            staticArray = new int[10];
            cxS = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = "Массив: пуст";
            dinamicArray = new int[0];
            //Array.Clear(dinamicArray, 0, dinamicArray.Length);
        }

        public void showArrayInfo(int[] arr, string name)
        {
            MessageBox.Show(String.Format("Sum of all elems ({5}) = {0}\n3 Max elements = {1}\nSum of 3 max elems = {2}\nMultiply even idx = {3}\nSum elem > average = {4}",
                arr.Sum(),
                String.Join(", ", arr.OrderByDescending(x => x).Take(3)),
                arr.OrderByDescending(x => x).Take(3).Sum(),
                arr.Where((x, ind) => ind % 2 == 0).Aggregate(1, (acc, x) => acc * x),
                arr.Where(x => x > arr.Average()).Sum(),
                name), String.Format("Info for {0}", name));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showArrayInfo(staticArray, "staticArray");
            showArrayInfo(dinamicArray, "dinamicArray");
        }
    }
}
