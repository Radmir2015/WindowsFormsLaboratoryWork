using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        unsafe struct SmallData
        {
            public fixed byte a[16];
        }

        unsafe struct LargeData
        {
            public fixed byte a[25600];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int msTest1, msTest2;
            Queue<SmallData> SmallQueue = new Queue<SmallData>();
            int time = Environment.TickCount;
            for (var i = 0; i < 25000; i++)
            {
                SmallData data = new SmallData();
                SmallQueue.Enqueue(data);
            }
            for (var i = 0; i < 25000; i++)
            {
                SmallQueue.Dequeue();
            }
            msTest1 = Environment.TickCount - time;
            //MessageBox.Show("Time = " + ((Environment.TickCount - time)).ToString());

            Queue<LargeData> LargeQueue = new Queue<LargeData>();
            time = Environment.TickCount;
            for (var i = 0; i < 25000; i++)
            {
                LargeData data = new LargeData();
                LargeQueue.Enqueue(data);
            }
            for (var i = 0; i < 25000; i++)
            {
                LargeQueue.Dequeue();
            }
            msTest2 = Environment.TickCount - time;
            MessageBox.Show(String.Format("Duraction of queue (16 bytes): {0} ms\nDuraction of queue (256 Kbytes): {1} ms", msTest1, msTest2));

            Stack<SmallData> SmallStack = new Stack<SmallData>();
            time = Environment.TickCount;
            for (var i = 0; i < 25000; i++)
            {
                SmallData data = new SmallData();
                SmallStack.Push(data);
                SmallStack.Pop();
            }
            msTest1 = Environment.TickCount - time;

            Stack<LargeData> LargeStack = new Stack<LargeData>();
            time = Environment.TickCount;
            for (var i = 0; i < 25000; i++)
            {
                LargeData data = new LargeData();
                LargeStack.Push(data);
                LargeStack.Pop();
            }
            msTest1 = Environment.TickCount - time;
            MessageBox.Show(String.Format("Duraction of stack (16 bytes): {0} ms\nDuraction of stack (256 Kbytes): {1} ms", msTest1, msTest2));

            LinkedList<SmallData> SmallList = new LinkedList<SmallData>();
            time = Environment.TickCount;
            for (var i = 0; i < 25000; i++)
            {
                SmallData data = new SmallData();
                SmallList.Find(data);
                SmallList.AddLast(data);
            }
            msTest1 = Environment.TickCount - time;

            LinkedList<LargeData> LargeList = new LinkedList<LargeData>();
            time = Environment.TickCount;
            for (var i = 0; i < 25000; i++)
            {
                LargeData data = new LargeData();
                LargeList.Find(data);
                LargeList.AddLast(data);
            }
            msTest2 = Environment.TickCount - time;
            MessageBox.Show(String.Format("Duraction of linkedList (16 bytes): {0} ms\nDuraction of linkedList (256 Kbytes): {1} ms", msTest1, msTest2));

        }
    }
}
