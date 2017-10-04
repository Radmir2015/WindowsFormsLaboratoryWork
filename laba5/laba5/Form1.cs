using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        struct Student
        {
            public string cipher;
            public string name, lastName, parentsName;
            public string faculty;
            public string group;
            public string study_direction;
        }

        List<Student> database = new List<Student>();

        private void button1_Click(object sender, EventArgs e)
        {
            Student newStudent;
            newStudent.lastName = textBox1.Text;
            newStudent.name = textBox2.Text;
            newStudent.parentsName = textBox3.Text;
            newStudent.cipher = textBox4.Text;
            newStudent.group = textBox5.Text;
            newStudent.faculty = textBox6.Text;
            newStudent.study_direction = textBox7.Text;
            database.Add(newStudent);
            ListViewItem a = new ListViewItem();
            a.Text = newStudent.lastName;
            ListViewItem.ListViewSubItem b = new ListViewItem.ListViewSubItem();
            b.Text = newStudent.name;
            ListViewItem.ListViewSubItem c = new ListViewItem.ListViewSubItem();
            c.Text = newStudent.parentsName;
            a.SubItems.Add(b);
            a.SubItems.Add(c);
            listView1.Items.Add(a);
        }
    }
}
