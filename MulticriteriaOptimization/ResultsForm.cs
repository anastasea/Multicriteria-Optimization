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
        Stopwatch sw;

        public ResultsForm(PenaltyMethod pm)
        {
            InitializeComponent();
            this.penalty = pm;
            sw = Stopwatch.StartNew();
            xOpt = pm.Calculate();
            sw.Stop();
            WriteResults();
            label1.Text = "Время работы программы: " + sw.Elapsed.ToString(@"m\:ss\.ff");
        }

        private void WriteResults()
        {
            for (int i = 0; i < penalty.PenaltyIterations.Count; i++)
            {
                textBox1.Text += "Итерация " + (i + 1) + ": ";
                for (int j = 0; j < penalty.PenaltyIterations[i].Length; j++)
                {
                    textBox1.Text += penalty.PenaltyIterations[i][j] + "   ";
                }
                // textBox1.Text += "f = " + Math.Round(Math.Sqrt(penalty.GetFunctionValue(penalty.PenaltyIterations[i])), 4);
                textBox1.Text += "\r\n";
            }
            textBox1.Text += "Расстояние до идеальной точки: " + (Math.Sqrt(penalty.GetFunctionValue(xOpt)))+ "\r\n";
            textBox1.Text += "Время работы программы: " + sw.Elapsed.ToString(@"m\:ss\.ff") + "\r\n"; ;
            double totalSum = 0;
            for (int i = 0; i < penalty.Prob.CountConstraint; i++)
            {
                double penForConstr = penalty.CountDifferenceForConstraints(xOpt,i);
                totalSum += penForConstr;
                textBox1.Text += (penForConstr!=0)? "Ограничение " + (i+1) + " нарушено на " + penForConstr + " единиц. \r\n":"Ограничение "+(i+1)+ " не нарушено. \r\n";
            }
            for (int i = 0; i < penalty.Prob.CountVariables; i++)
            {
                double penForNonNeg = penalty.CountDifferenceForNonNegativityConstraints(xOpt, i);
                totalSum += penForNonNeg;
                textBox1.Text += (penForNonNeg != 0) ? "Ограничение на неотрицательгость X" + (i + 1) + " нарушено на " + penForNonNeg + " единиц. \r\n" : "Ограничение на неотрицательность X" + (i + 1) + " не нарушено. \r\n";
            }
            textBox1.Text += "Штраф (сумма невязок): " + totalSum;
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
                //MessageBox.Show("Решение успешно сохранено!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
