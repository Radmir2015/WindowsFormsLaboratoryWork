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

        public string CheckIfNumbersOrBool(Tuple<double, double, int, int> arguments, string expected) // -1 - numbers; 0, 1 - bools
        {
            var args = arguments;
            if (args.Item3 == -1 && args.Item4 == -1)
                return "numbers";
            else if (args.Item3 >= 0 && args.Item4 >= 0)
                return "bools";
            else
                if (expected == "numbers")
                {
                    if (args.Item3 != -1) return "error in 1";
                    else if (args.Item4 != -1) return "error in 2";
                    else return "error";
                }
                else if (expected == "bools")
                {
                    if (args.Item3 < 0) return "error in 1";
                    else if (args.Item4 < 0) return "error in 2";
                    else return "error";
                }
                else return "error";
        }

        public Tuple<double, double, int, int> getArgs(int param = 2)
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
            else if (text2 == "ложь" || text2 == "false")
                argBool2 = 0;
            else
            {
                if (!double.TryParse(textBox2.Text.Replace(".", ","), out arg2))
                {
                    if (param == 2)
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

        private void button1_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            var type = CheckIfNumbersOrBool(args, "numbers");
            if (type == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " + " + args.Item2.ToString() + " = " + (args.Item1 + args.Item2).ToString());
            else if (type == "bools")
                MessageBox.Show("Необходим числовой тип, обнаружен логический");
            else if (type.StartsWith("error in"))
                MessageBox.Show("Нечисловое значение в аргументе " + (type == "error in 1" ? "1" : "2"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool(args, "numbers") == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " - " + args.Item2.ToString() + " = " + (args.Item1 - args.Item2).ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool(args, "numbers") == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " * " + args.Item2.ToString() + " = " + (args.Item1 * args.Item2).ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool(args, "numbers") == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " / " + args.Item2.ToString() + " = " + (args.Item1 / args.Item2).ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool(args, "numbers") == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " % " + args.Item2.ToString() + " = " + (args.Item1 % args.Item2).ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool(args, "numbers") == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " > " + args.Item2.ToString() + " = " + (args.Item1 > args.Item2).ToString());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool(args, "numbers") == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " < " + args.Item2.ToString() + " = " + (args.Item1 < args.Item2).ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool(args, "numbers") == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " >= " + args.Item2.ToString() + " = " + (args.Item1 >= args.Item2).ToString());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool(args, "numbers") == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " <= " + args.Item2.ToString() + " = " + (args.Item1 <= args.Item2).ToString());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool(args, "numbers") == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " == " + args.Item2.ToString() + " = " + (args.Item1 == args.Item2).ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool(args, "bools") == "bools")
            {
                var bool1 = true ? args.Item3 == 1 : false;
                var bool2 = true ? args.Item4 == 1 : false;
                listBox1.Items.Insert(0, bool1.ToString() + " && " + bool2.ToString() + " = " + ((bool1 && bool2).ToString()));
            }
            else if (CheckIfNumbersOrBool(args, "numbers") == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " & " + args.Item2.ToString() + " = " + ((int)args.Item1 & (int)args.Item2).ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool(args, "bools") == "bools")
            {
                var bool1 = true ? args.Item3 == 1 : false;
                var bool2 = true ? args.Item4 == 1 : false;
                listBox1.Items.Insert(0, bool1.ToString() + " || " + bool2.ToString() + " = " + (bool1 || bool2).ToString());
            }
            else if (CheckIfNumbersOrBool(args, "numbers") == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " | " + args.Item2.ToString() + " = " + ((int)args.Item1 | (int)args.Item2).ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var args = getArgs(1);
            if (args.Item3 >= 0)
            {
                var bool1 = true ? args.Item3 == 1 : false;
                listBox1.Items.Insert(0, "!" + bool1.ToString() + " = " + (!bool1).ToString());
            }
            else if (args.Item3 == -1)
                listBox1.Items.Insert(0, "~" + args.Item1.ToString() + " = " + (~(int)args.Item1).ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var args = getArgs();
            if (CheckIfNumbersOrBool(args, "bools") == "bools")
            {
                var bool1 = true ? args.Item3 == 1 : false;
                var bool2 = true ? args.Item4 == 1 : false;
                listBox1.Items.Insert(0, bool1.ToString() + " ^ " + bool2.ToString() + " = " + (bool1 ^ bool2).ToString());
            }
            else if (CheckIfNumbersOrBool(args, "numbers") == "numbers")
                listBox1.Items.Insert(0, args.Item1.ToString() + " ^ " + args.Item2.ToString() + " = " + ((int)args.Item1 ^ (int)args.Item2).ToString());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var args = getArgs(1);
            if (args.Item3 == -1)
            {
                listBox1.Items.Insert(0, "sin(" + args.Item1 + ") = " + Math.Sin(args.Item1).ToString());
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var args = getArgs(1);
            if (args.Item3 == -1)
            {
                listBox1.Items.Insert(0, "tan(" + args.Item1 + ") = " + Math.Tan(args.Item1).ToString());
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var args = getArgs(1);
            if (args.Item3 == -1)
            {
                listBox1.Items.Insert(0, "e ^ " + args.Item1 + " = " + Math.Exp(args.Item1).ToString());
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var args = getArgs(1);
            if (args.Item3 == -1)
            {
                var log2 = Math.Log(args.Item1) / Math.Log(2);
                if ((int)log2 == log2)
                    listBox1.Items.Insert(0, ((int)log2 == log2).ToString() + ": 2 ^ " + log2.ToString() + " = " + args.Item1.ToString());
                else
                    listBox1.Items.Insert(0, ((int)log2 == log2).ToString());
            }  
        }

        private void button15_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
