using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proverka2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = textBox1.Text;

            byte[] symbols = Encoding.GetEncoding(1251).GetBytes(t);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "Perevod|*.txt";

            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
            {
                StreamWriter stream = new StreamWriter(saveFile.FileName, true);
                for (int i = 0; i < t.Length; i++)
                {
                    stream.WriteLine(t[i] + ": " + " (10): " + symbols[i] + " (2): " + Convert.ToString(symbols[i], 2));
                }
                stream.WriteLine("Если ты ввел числа то просто добавь в начало два нуля (Было 110010 -- Стало 00110010)");
                stream.Close();
            }
            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.DefaultExt = ".txt";
            openDialog.Filter = "(*.txt)|*.txt";
            if (openDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openDialog.FileName;
            var ARRAY = new List<string>();
            var PerArr = new List<string>();
            foreach (string line in File.ReadLines(filename))
            {
                ARRAY.Add(line);
            }
            for (int i = 0; i < ARRAY.Count; i++)
            {
                string suka = ARRAY[i];
                char[] pis = suka.ToCharArray();
                Array.Reverse(pis);
                double a, b = 0;
                for (int y = 0; y < pis.Length; y++)
                {
                    if (pis[y] == '1')
                    {
                        a = Math.Pow(2, Convert.ToDouble(y));
                        b = b + a;
                    }
                }
                byte c = Convert.ToByte(b);
                byte[] ss = new byte[] { c };
                string kak = Encoding.GetEncoding(1251).GetString(ss);
                PerArr.Add(kak);
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "Perevod|*.txt";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
            {
                StreamWriter stream = new StreamWriter(saveFile.FileName, true);
                for (int i = 0; i < PerArr.Count; i++)
                {
                    stream.Write(PerArr[i]);
                }
                stream.Close();

            }
            Close();

        }


    }
}
