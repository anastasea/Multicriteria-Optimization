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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace MulticriteriaOptimization
{
    public partial class MainForm : Form
    {
        int countCrit;
        int countConstr;
        int countVar;
        MultiCriteriaProblem prob;
        string wrongFormatMessage = "Неверный формат данных в файле! Проверьте файл на наличие букв и лишних пробелов.";

        public MainForm()
        {
            InitializeComponent();
            textBoxCountConstraint.Text = "5S";
            textBoxCountCriteria.Text = "2";
            textBoxCountVar.Text = "4";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonCreateEmptyProblem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            prob = null;
            int countCrit = Convert.ToInt32(textBoxCountCriteria.Text);
            int countVar = Convert.ToInt32(textBoxCountVar.Text);
            int countConstr = Convert.ToInt32(textBoxCountConstraint.Text);
            createUIProblem(countCrit, countVar, countConstr);
        }

        private void createUIProblem(int countCrit, int countVar, int countConstr)
        {
            Label criteriaLabel = new Label();
            criteriaLabel.Location = new Point(0, 0);
            criteriaLabel.Text = "Критерии";
            criteriaLabel.AutoSize = true;
            panel1.Controls.Add(criteriaLabel);

            DataGridView criteriaTable = new DataGridView();
            criteriaTable.Width = 60 * countVar;
            criteriaTable.RowHeadersVisible = false;
            criteriaTable.Location = new Point(criteriaLabel.Location.X + 60, groupBox1.Location.Y + 5);

            for (int i = 0; i < countVar; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "X" + (i + 1);
                col.Width = 60;
                criteriaTable.Columns.Add(col);
            }
            criteriaTable.RowCount = countCrit;

            int distance = 53;
            for (int i = 0; i < countCrit; i++)
            {
                ComboBox min = new ComboBox();
                min.Width = 50;
                min.Items.Add("MIN");
                min.Items.Add("MAX");
                if(prob != null)
                {
                    min.SelectedIndex = (prob.Minimize[i] == true) ? 0 : 1;
                }
                else
                {

                    min.SelectedIndex = 0;
                }
                min.Location = new Point(criteriaLabel.Location.X, criteriaLabel.Location.Y + distance);
                distance += 22;
                panel1.Controls.Add(min);
            }

            int sum = criteriaTable.ColumnHeadersHeight;
            foreach (DataGridViewRow row in criteriaTable.Rows)
                sum += row.Height;
            criteriaTable.Height = sum;
            criteriaTable.ScrollBars = ScrollBars.None;
            for(int i = 0; i < criteriaTable.RowCount; i++)
            {
                for (int j = 0; j < criteriaTable.ColumnCount; j++)
                {
                    if(prob != null)
                    {
                        criteriaTable[j, i].Value = prob.CriteriaCoefficients[i, j];
                    }
                    else
                    {
                        criteriaTable[j, i].Value = 0;
                    }
                }
            }
            panel1.Controls.Add(criteriaTable);

            Label coeffLabel = new Label();
            coeffLabel.Location = new Point(0, criteriaTable.Location.Y + criteriaTable.Height + 15);
            coeffLabel.Text = "Коэффициенты ограничений";
            coeffLabel.AutoSize = true;
            panel1.Controls.Add(coeffLabel);

            DataGridView coeffTable = new DataGridView();
            coeffTable.Width = 60 * countVar;
            coeffTable.RowHeadersVisible = false;
            coeffTable.Location = new Point(coeffLabel.Location.X + 60, coeffLabel.Location.Y + 20);
            for (int i = 0; i < countVar; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "X" + (i + 1);
                col.Width = 60;
                coeffTable.Columns.Add(col);
            }
            coeffTable.RowCount = countConstr;
            sum = coeffTable.ColumnHeadersHeight;
            foreach (DataGridViewRow row in coeffTable.Rows)
                sum += row.Height;
            coeffTable.Height = sum;
            coeffTable.ScrollBars = ScrollBars.None;
            for (int i = 0; i < coeffTable.RowCount; i++)
            {
                for (int j = 0; j < coeffTable.ColumnCount; j++)
                {
                    if (prob != null)
                    {
                        coeffTable[j, i].Value = prob.ConstraintCoefficients[i, j];
                    }
                    else
                    {
                        coeffTable[j, i].Value = 0;
                    }
                }
            }
            panel1.Controls.Add(coeffTable);

            distance = 24;
            ComboBox lessThan = new ComboBox();
            for (int i = 0; i < countConstr; i++)
            {
                lessThan = new ComboBox();
                lessThan.Width = 50;
                lessThan.Items.Add("<=");
                lessThan.Items.Add(">=");
                lessThan.Items.Add("=");
                if (prob != null)
                {
                    switch(prob.ConstraintSigns[i])
                    {
                        case MathSign.LessThan:
                            lessThan.SelectedIndex = 0; break;
                        case MathSign.GreaterThan:
                            lessThan.SelectedIndex = 1; break;
                        case MathSign.Equal:
                            lessThan.SelectedIndex = 2; break;
                    }
                }
                else
                {

                    lessThan.SelectedIndex = 0;
                }
                lessThan.Location = new Point(coeffTable.Location.X + coeffTable.Width + 15, coeffTable.Location.Y + distance);
                distance += 22;
                panel1.Controls.Add(lessThan);
            }

            Label constLabel = new Label();
            constLabel.Location = new Point(lessThan.Location.X + lessThan.Width + 15, criteriaTable.Location.Y + criteriaTable.Height + 15);
            constLabel.Text = "Свободные члены";
            constLabel.AutoSize = true;
            panel1.Controls.Add(constLabel);
            DataGridView constTable = new DataGridView();
            constTable.Width = 60;
            constTable.RowHeadersVisible = false;
            constTable.Location = new Point(constLabel.Location.X, coeffTable.Location.Y);
            constTable.ColumnCount = 1;
            constTable.Columns[0].Name = "B";
            constTable.RowCount = countConstr;
            sum = constTable.ColumnHeadersHeight;
            foreach (DataGridViewRow row in constTable.Rows)
                sum += row.Height;
            constTable.Height = sum;
            constTable.ScrollBars = ScrollBars.None;
            for (int i = 0; i < constTable.RowCount; i++)
            {
                if (prob != null)
                {
                    constTable[0, i].Value = prob.Constants[i];
                }
                else
                {
                    constTable[0, i].Value = 0;
                }
            }
            panel1.Controls.Add(constTable);

            distance = 15;
            for (int i = 0; i < countVar; i++)
            {
                Label X = new Label();
                X.Location = new Point(criteriaLabel.Location.X, coeffTable.Location.Y + coeffTable.Height + distance);
                X.Text = "X" + (i + 1);
                X.AutoSize = true;
                panel1.Controls.Add(X);
                ComboBox zero = new ComboBox();
                zero.Width = 50;
                zero.Location = new Point(X.Location.X + X.Width + 10, coeffTable.Location.Y + coeffTable.Height + distance);
                zero.Items.Add(">= 0");
                zero.Items.Add(" ");
                if (prob != null && prob.NotNonNegativeVarInd != null && prob.NotNonNegativeVarInd.Contains(i))
                {
                    zero.SelectedIndex = 1;
                }
                else
                {
                    zero.SelectedIndex = 0;
                }
                panel1.Controls.Add(zero);
                distance += 20;
            }
        }

        private void buttonOpenFromFile_Click(object sender, EventArgs e)
        {
            prob = null;
            panel1.Controls.Clear();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Текстовый документ (.txt)|*.txt|Excel-файл (.xlsx)|*.xlsx";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filename = dlg.FileName;
                string extension = Path.GetExtension(filename);
                //try
                //{
                    if (extension == ".txt")
                    {
                        string[] fileLines = File.ReadAllLines(filename);
                        if (fileLines.Length == 0)
                        {
                            throw new Exception("Пустой файл!");
                        }
                        string[] split = fileLines[0].Split(' ');
                        if (!Int32.TryParse(split[0], out countCrit))
                            throw new Exception(wrongFormatMessage);
                        if (!Int32.TryParse(split[1], out countConstr))
                            throw new Exception(wrongFormatMessage);
                        if (!Int32.TryParse(split[2], out countVar))
                            throw new Exception(wrongFormatMessage);

                        bool[] minimize = new bool[countCrit];
                        double[,] criteriaCoefficients = new double[countCrit,countVar];
                        double[,] constraintCoefficients = new double[countConstr, countVar];
                        double[] constants = new double[countConstr];
                        MathSign[] constraintSigns = new MathSign[countConstr];
                        int[] NotNonNegativeVarInd;
                        for (int i = 1; i <= countCrit; i++)
                        {
                            string line = fileLines[i];
                            string[] splitStr = line.Split(' ');
                            minimize[i - 1] = splitStr[0] == "1";
                            for (int j = 1; j <= countVar; j++)
                            {
                                if (!Double.TryParse(splitStr[j], out criteriaCoefficients[i - 1, j - 1]))
                                    throw new Exception(wrongFormatMessage);
                            }
                        }
                        for (int i = countCrit + 1; i < countConstr + countCrit + 1; i++)
                        {
                            string line = fileLines[i];
                            string[] splitStr = line.Split(' ');
                            for (int j = 0; j < countVar; j++)
                            {
                                if (!Double.TryParse(splitStr[j], out constraintCoefficients[i - countCrit - 1, j]))
                                    throw new Exception(wrongFormatMessage);
                            }
                            if (!Double.TryParse(splitStr[countVar + 1], out constants[i - countCrit - 1]))
                                throw new Exception(wrongFormatMessage);
                            switch(splitStr[countVar])
                            {
                                case "<=": constraintSigns[i - countCrit - 1] = MathSign.LessThan; break;
                                case ">=": constraintSigns[i - countCrit - 1] = MathSign.GreaterThan; break;
                                case "=": constraintSigns[i - countCrit - 1] = MathSign.Equal; break;
                                default: throw new Exception(wrongFormatMessage); 
                            }
                        }
                        if(fileLines.Length == countConstr + countCrit + 2)
                        {
                            string[] splitStr = fileLines[countConstr + countCrit + 1].Split(' ');
                            NotNonNegativeVarInd = new int[splitStr.Length];
                            for(int i = 0; i < splitStr.Length; i++)
                            {
                                if (!Int32.TryParse(splitStr[i], out NotNonNegativeVarInd[i]))
                                    throw new Exception(wrongFormatMessage);
                            } 
                        }
                        else
                        {
                            NotNonNegativeVarInd = null;
                        }
                        try
                        {
                            prob = new MultiCriteriaProblem(minimize, criteriaCoefficients, constraintCoefficients, constants, constraintSigns, NotNonNegativeVarInd);
                            createUIProblem(countCrit, countVar, countConstr);
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message);
                        }
                    }
                    else if (extension == ".xlsx")
                    {
                        Excel.Application xlApp = new Excel.Application();
                        xlApp.Visible = false;
                        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filename);
                        Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                        Excel.Range xlRange = xlWorksheet.UsedRange;

                        int rowCount = xlRange.Rows.Count;
                        int colCount = xlRange.Columns.Count;

                        double[,]arr = new double[rowCount, colCount];

                        Array values = (Array)xlRange.Cells.Value;

                        for (int i = 1; i <= rowCount; i++)
                        {
                            for (int j = 1; j <= colCount; j++)
                            {
                                if (!Double.TryParse(values.GetValue(i, j).ToString(), out arr[i - 1, j - 1]))
                                    throw new Exception("Неверный формат данных в файле!");
                            }
                        }
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Marshal.ReleaseComObject(xlRange);
                        Marshal.ReleaseComObject(xlWorksheet);
                        xlWorkbook.Close();
                        Marshal.ReleaseComObject(xlWorkbook);
                        xlApp.Quit();
                        Marshal.ReleaseComObject(xlApp);
                    }
                    else
                    {
                        
                    }
                //}
                //catch (Exception ex)
                //{
                    //MessageBox.Show(ex.Message);
                //}
            }
        }

        private void buttonCompute_Click(object sender, EventArgs e)
        {
            SimplexMethod sm;
            double[] solutions = new double[prob.Minimize.Length];
            for(int i = 0; i < prob.Minimize.Length; i++)
            {
                sm = new SimplexMethod(prob, i);
                solutions[i] = sm.Calculate();
            }
            int y = 0;
        }
    }
}
