using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace MulticriteriaOptimization
{
    public partial class ResultsForm : Form
    {
        PenaltyMethod penalty;
        double[] xOpt; 

        public ResultsForm(PenaltyMethod pm)
        {
            InitializeComponent();
            this.penalty = pm;
            Stopwatch sw = Stopwatch.StartNew();
            xOpt = pm.Calculate();
            sw.Stop();
            WriteResults();
        }

        private void WriteResults()
        {
            for (int i = 0; i < penalty.PenaltyIterations.Count; i++)
            {
                textBox1.Text += "Итерация " + (i + 1) + ": ";
                for (int j = 0; j < penalty.PenaltyIterations[i].Length; j++)
                {
                    textBox1.Text += Math.Round(penalty.PenaltyIterations[i][j], 4) + "   ";
                }
                textBox1.Text += "\r\n";
            }
            textBox1.Text += "Значение целевой функции: " + Math.Sqrt(penalty.GetFunctionValue(xOpt));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Текстовый документ(.txt)| *.txt";
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FilterIndex = 1;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog1.FileName;
                    string extension = Path.GetExtension(filename);
                    if (extension == ".txt")
                    {
                        using (StreamWriter sw = new StreamWriter(filename))
                        {
                            sw.Write(textBox1.Text);
                        }
                    }
                    else
                        throw new Exception("Неверное расширение файла!");
                }
                MessageBox.Show("Решение успешно сохранено!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
