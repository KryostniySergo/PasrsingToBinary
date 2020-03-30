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
    }
}
