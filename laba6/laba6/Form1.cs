using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace laba6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            Regex regex = new Regex(@"(\W|\d)");
            MatchCollection matches = regex.Matches(input);
            textBox2.Text = matches.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text.Replace(",", ";");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            Regex regex = new Regex(@"-?\d+(\.\d+)?");
            MatchCollection matches = regex.Matches(input);
            List<String> matchesInString = new List<String>();
            foreach (Match match in matches)
            {
                matchesInString.Add(match.Value);
            }
            textBox2.Text = String.Join(" + ", matchesInString.Select(x => (x[0] == '-') ? String.Format("({0})", x) : x)) + " = " + matchesInString.Select(x => double.Parse(x.Replace(".", ","))).Aggregate((a, b) => a + b).ToString().Replace(",", ".");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            List<int> bIndices = input.Select((x, ind) => (x == 'b') ? ind : -1).Where(x => x >= 0).ToList();
            var evenIndices = bIndices.Where((x, ind) => ind % 2 == 1);
            var total = input.Select((y, inx) => (Array.IndexOf(evenIndices.ToArray(), inx) >= 0) ? 'б' : y);
            textBox2.Text = String.Join("", total);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
