using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba3
{
    public partial class Form1 : Form
    {
        public double arg1, arg2;
        public int argBool1 = -1, argBool2 = -1;

        public string CheckIfNumbersOrBool() // -1 - numbers; 0, 1 - bools
        {
            var args = getArgs();
            if (args.Item3 == -1 && args.Item4 == -1)
                return "numbers";
            else if (args.Item3 >= 0 && args.Item4 >= 0)
                return "bools";
            else
                return "error";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool() == "numbers")
                listBox1.Items.Add((args.Item1 + args.Item2).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool() == "numbers")
                listBox1.Items.Add((args.Item1 - args.Item2).ToString());
        }

        public Tuple<double, double, int, int> getArgs()
        {
            string text1 = textBox1.Text.Trim().ToLower();
            string text2 = textBox2.Text.Trim().ToLower();
            if (text1 == "истина" || text1 == "true")
                argBool1 = 1;
            else if (text1 == "ложь" || text1 == "false")
                argBool1 = 0;
            else
            {
                if (!double.TryParse(textBox1.Text.Replace(".", ","), out arg1))
                {
                    MessageBox.Show("Неправильный тип в аргументе 1");
                    argBool1 = -2;
                }
                else
                    argBool1 = -1;
            }

            if (text2 == "истина" || text2 == "true")
                argBool2 = 1;
            else if (text1 == "ложь" || text1 == "false")
                argBool2 = 0;
            else
            {
                if (!double.TryParse(textBox2.Text.Replace(".", ","), out arg2))
                {
                    MessageBox.Show("Неправильный тип в аргументе 2");
                    argBool2 = -2;
                }
                else
                    argBool2 = -1;
            }

            return Tuple.Create(arg1, arg2, argBool1, argBool2);
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
