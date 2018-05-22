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
    }
}
