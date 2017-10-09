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

        public struct Student
        {
            public string cipher;
            public string name, lastName, parentsName;
            public string faculty;
            public string group;
            public string studyDirection;
        }

        List<Student> database = new List<Student>();

        public void ListViewShow(Student obj, bool needClear = false)
        {
            if (needClear)
                listView1.Items.Clear();

            ListViewItem listLastName = new ListViewItem();
            ListViewItem.ListViewSubItem subName = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem subParentsName = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem subCipher = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem subGroup = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem subFaculty = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem subStudyDirection = new ListViewItem.ListViewSubItem();

            listLastName.Text = obj.lastName;
            listLastName.Tag = obj;

            subName.Text = obj.name;
            subParentsName.Text = obj.parentsName;
            subCipher.Text = obj.cipher;
            subGroup.Text = obj.group;
            subFaculty.Text = obj.faculty;
            subStudyDirection.Text = obj.studyDirection;

            listLastName.SubItems.Add(subName);
            listLastName.SubItems.Add(subParentsName);
            listLastName.SubItems.Add(subCipher);
            listLastName.SubItems.Add(subGroup);
            listLastName.SubItems.Add(subFaculty);
            listLastName.SubItems.Add(subStudyDirection);

            listView1.Items.Add(listLastName);
        }

        public void ListViewShow(List<Student> database, bool needClear = false)
        {
            if (needClear)
                listView1.Items.Clear();
            foreach (var obj in database)
            {
                ListViewShow(obj);
            }
        }

        public Student CreateStudentStruct()
        {
            Student newStudent;
            newStudent.lastName = textBox1.Text;
            newStudent.name = textBox2.Text;
            newStudent.parentsName = textBox3.Text;
            newStudent.cipher = textBox4.Text;
            newStudent.group = textBox5.Text;
            newStudent.faculty = textBox6.Text;
            newStudent.studyDirection = textBox7.Text;
            database.Add(newStudent);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

            return newStudent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateStudentStruct();
            ListViewShow(database, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListViewShow(database.Where(x => x.lastName == textBox1.Text).ToList(), true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListViewShow(database.Where(x => x.faculty == textBox6.Text).ToList(), true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListViewShow(database.Where(x => x.group == textBox5.Text).ToList(), true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListViewShow(database.Where(x => x.studyDirection == textBox7.Text).Where(x => x.faculty != textBox6.Text).ToList(), true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ListViewShow(database.ToList(), true);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                database.Remove((Student)item.Tag);
            }
            ListViewShow(database, true);
        }
    }
}
