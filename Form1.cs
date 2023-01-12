using System.Threading;
using System.Diagnostics;

namespace SP_HW3
{
    public partial class Form1 : Form
    {
        List<int> fibNum = new List<int>();
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Maximum = Decimal.MaxValue;
            numericUpDown2.Maximum = Decimal.MaxValue;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread fibbNumbThrd = new(ShowFibonacciNum);
            (int, int) diapazone = new((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            fibNum.Clear();
            listBox1.Items.Clear();
            fibbNumbThrd.IsBackground = true;
            fibbNumbThrd.Start(diapazone);
        }

        private void ShowFibonacciNum(object obj)
        {
            (int min, int max) = ((int min, int max))obj;

            for (int i = min; i < max; i++)
            {
                if (IsFibonacci(i))
                {
                    fibNum.Add(i);
                }
            }
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action(() => RefreshListBox()));
            }
            else
            {
                foreach (int i in fibNum)
                {
                    listBox1.Items.Add(i.ToString());
                }
            }
        }

        static bool IsFibonacci(int num)
        {
            List<int> al = new List<int>();
            al.Add(0);
            al.Add(1);
            for (int i = 0; i < num; i++)
            {
                al.Add(al[al.Count - 1] + al[al.Count - 2]);
            }
            if (al.Contains(num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}