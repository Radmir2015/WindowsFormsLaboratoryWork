using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba7_rightWay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Node
        {
            public Node next;
            public Node prev;
            public Object data;
        }

        public class DoubleLinkedList
        {
            private Node firstNode;
            private Node lastNode;

            public void AddAfter(Node node, Node newNode)
            {
                newNode.prev = node;
                if (node.next == null)
                {
                    newNode.next = null;
                    lastNode = newNode;
                }
                else
                {
                    newNode.next = node.next;
                    node.next.prev = newNode;
                }
                node.next = newNode;
            }

            public void AddBefore(Node node, Node newNode)
            {
                newNode.next = node;
                if (node.prev == null) {
                    newNode.prev = null;
                    firstNode = newNode;
                }
                else
                {
                    newNode.prev = node.prev;
                    node.prev.next = newNode;
                }
                node.prev = newNode;
            }

            public void AddFirst(Node newNode)
            {
                if (firstNode == null)
                {
                    firstNode = newNode;
                    lastNode = newNode;
                    newNode.prev = null;
                    newNode.next = null;
                }
                else
                    AddBefore(firstNode, newNode);
            }

            public void AddLast(Node newNode)
            {
                if (lastNode == null)
                    AddFirst(newNode);
                else
                    AddAfter(lastNode, newNode);
            }

            public void Remove(Node node)
            {
                if (node.prev == null)
                    firstNode = node.next;
                else
                    node.prev.next = node.next;
                if (node.next == null)
                    lastNode = node.prev;
                else
                    node.next.prev = node.prev;
            }

            public Node Find(Node node)
            {
                Node firstNodeCopy = firstNode;
                for (; firstNodeCopy != null && !firstNodeCopy.data.Equals(node.data); firstNodeCopy = firstNodeCopy.next) ;
                return firstNodeCopy;
            }

            public void Clear()
            {
                firstNode = null;
                lastNode = null;
            }

            public Node LastElement() => lastNode;

            public Node FirstElement() => firstNode;

            public int Count()
            {
                int count = 0;
                Node firstNodeCopy = firstNode;
                for (; firstNodeCopy != null; firstNodeCopy = firstNodeCopy.next, count++);
                return count;
            }

            public Node ElementAt(int index)
            {
                Node firstNodeCopy = firstNode;
                for (; firstNodeCopy != null && index > 0; firstNodeCopy = firstNodeCopy.next, index--);
                return firstNodeCopy;
            }

            public List<Object> ToList()
            {
                Node firstNodeCopy = firstNode;
                List<Object> result = new List<Object>();
                while (firstNodeCopy != null)
                {
                    result.Add(firstNodeCopy.data);
                    firstNodeCopy = firstNodeCopy.next;
                }
                return result;
            }
        }

        public class LinkedStack
        {
            private DoubleLinkedList stack = new DoubleLinkedList();

            public void Push(Object item)
            {
                stack.AddLast(new Node() { data = item });
            }

            public Object Pop()
            {
                Object item = Peek();
                if ((Node)item != null)
                {
                    stack.Remove((Node)item);
                    return item;
                }
                else
                    return null;
            }

            public void Clear() => stack.Clear();

            public Object Peek() => stack.LastElement();

            public List<Object> ToList() => stack.ToList();

            public int Count() => stack.Count();
        }

        public class LinkedQueue
        {
            private DoubleLinkedList list = new DoubleLinkedList();

            public void Enqueue(Object item)
            {
                list.AddLast(new Node() { data = item });
            }

            public Object Dequeue()
            {
                Object item = list.FirstElement();
                if ((Node)item != null)
                {
                    list.Remove((Node)item);
                    return item;
                }
                else
                    return null;
            }

            public void Clear() => list.Clear();

            public List<Object> ToList() => list.ToList();

            public int Count() => list.Count();
        }

        unsafe struct SmallData
        {
            public fixed byte a[16];
        }

        unsafe struct LargeData
        {
            public fixed byte a[25600];
        }

        

        public int Test(Action<int> func, int amountIter = 25000)
        {
            int time = Environment.TickCount;
            
            for (var i = 0; i < amountIter; i++)
            {
                func(0);
            }

            return Environment.TickCount - time;
        }

        DoubleLinkedList list = new DoubleLinkedList();
        LinkedStack stack = new LinkedStack();
        LinkedQueue queue = new LinkedQueue();

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Insert(0, String.Format("Enqueue: small data: {0} ms, big data: {1} ms",
                Test(x =>
                    {
                        SmallData data = new SmallData();
                        queue.Enqueue(data);
                    }).ToString(),
                Test(x =>
                    {
                        LargeData data = new LargeData();
                        queue.Enqueue(data);
                    }).ToString()
                ));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Insert(0, String.Format("Dequeue: {0} ms",
                Test(x =>
                {
                    queue.Dequeue();
                }).ToString()
                ));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Insert(0, String.Format("Push: small data: {0} ms, big data: {1} ms",
                Test(x =>
                {
                    SmallData data = new SmallData();
                    stack.Push(data);
                }).ToString(),
                Test(x =>
                {
                    LargeData data = new LargeData();
                    stack.Push(data);
                }).ToString()
                ));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Insert(0, String.Format("Pop: {0} ms",
                Test(x =>
                {
                    stack.Pop();
                }).ToString()
                ));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            list.Clear();
            Test(x =>
            {
                SmallData data = new SmallData();
                list.AddFirst(new Node() { data = data });
                LargeData data1 = new LargeData();
                list.AddLast(new Node() { data = data1 });
            });

            listBox1.Items.Insert(0, String.Format("Find: small data: {0} ms, big data (2500 iter): {1} ms",
                Test(x =>
                {
                    SmallData data = new SmallData();
                    list.Find(new Node() { data = data });
                }).ToString(),
                Test(x =>
                {
                    LargeData data = new LargeData();
                    list.Find(new Node() { data = data });
                }, 2500).ToString()
                ));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            list.Clear();
            listBox1.Items.Insert(0, String.Format("AddLast: small data: {0} ms, big data: {1} ms",
                Test(x =>
                {
                    SmallData data = new SmallData();
                    list.AddLast(new Node() { data = data });
                }).ToString(),
                Test(x =>
                {
                    LargeData data = new LargeData();
                    list.AddLast(new Node() { data = data });
                }).ToString()
                ));
        }
    }
}
