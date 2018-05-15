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

        public MainForm()
        {
            InitializeComponent();
            textBoxCountConstraint.Text = "4";
            textBoxCountCriteria.Text = "2";
            textBoxCountVar.Text = "5";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonCreateEmptyProblem_Click(object sender, EventArgs e)
        {
            int countCrit = Convert.ToInt32(textBoxCountCriteria.Text);
            int countVar = Convert.ToInt32(textBoxCountVar.Text);
            int countConstr = Convert.ToInt32(textBoxCountConstraint.Text);
            Label criteriaLabel = new Label();
            criteriaLabel.Location = new Point(0,0);
            criteriaLabel.Text = "Критерии";
            criteriaLabel.AutoSize = true;
            panel1.Controls.Add(criteriaLabel);

            DataGridView criteriaTable = new DataGridView();
            criteriaTable.Width = 60 * countVar;
            criteriaTable.RowHeadersVisible = false;
            criteriaTable.Location = new Point(criteriaLabel.Location.X + 60, groupBox1.Location.Y + 5);
            
            for(int i = 0; i < countVar; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "X" + (i + 1);
                col.Width = 60;
                criteriaTable.Columns.Add(col);
            }
            criteriaTable.RowCount = countCrit;

            int distance = 53;
            for(int i = 0; i < countCrit; i++)
            {
                ComboBox min = new ComboBox();
                min.Width = 50;
                min.Items.Add("MIN");
                min.Items.Add("MAX");
                min.SelectedIndex = 0;
                min.Location = new Point(criteriaLabel.Location.X, criteriaLabel.Location.Y + distance);
                distance += 22;
                panel1.Controls.Add(min);
            }

            int sum = criteriaTable.ColumnHeadersHeight;
            foreach (DataGridViewRow row in criteriaTable.Rows)
                sum += row.Height;
            criteriaTable.Height = sum;
            criteriaTable.ScrollBars = ScrollBars.None;
            foreach (DataGridViewRow row in criteriaTable.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = 0;
                }
            }
            panel1.Controls.Add(criteriaTable);

            Label coeffLabel = new Label();
            coeffLabel.Location = new Point(0,criteriaTable.Location.Y + criteriaTable.Height + 15);
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
            foreach (DataGridViewRow row in coeffTable.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = 0;
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
                lessThan.SelectedIndex = 0;
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
            foreach (DataGridViewRow row in constTable.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = 0;
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
                zero.Items.Add("<= 0");
                zero.Items.Add(" ");
                zero.SelectedIndex = 0;
                panel1.Controls.Add(zero);
                distance += 20;
            }
        }

        private void buttonOpenFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Текстовый документ (.txt)|*.txt|Excel-файл (.xlsx)|*.xlsx";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filename = dlg.FileName;
                string extension = Path.GetExtension(filename);
                try
                {
                    double[,] arr;
                    if (extension == ".txt")
                    {
                        string[] fileLines = File.ReadAllLines(filename);
                        if (fileLines.Length == 0)
                        {
                            throw new Exception("Пустой файл!");
                        }
                        string[] split = fileLines[0].Split(' ');
                        if (!Int32.TryParse(split[0], out countCrit))
                            throw new Exception("Неверный формат данных в файле! Проверьте файл на наличие букв и лишних пробелов.");
                        if (!Int32.TryParse(split[1], out countConstr))
                            throw new Exception("Неверный формат данных в файле! Проверьте файл на наличие букв и лишних пробелов.");
                        if (!Int32.TryParse(split[2], out countVar))
                            throw new Exception("Неверный формат данных в файле! Проверьте файл на наличие букв и лишних пробелов.");
                        

                        arr = new double[fileLines.Length, fileLines[0].Split(' ').Length];
                        for (int i = 0; i < fileLines.Length; i++)
                        {
                            for (int j = 0; j < arr.GetLength(1); j++)
                            {
                                string line = fileLines[i];
                                string[] split = line.Split(' ');
                                if (!Double.TryParse(split[j], out arr[i, j]))
                                    throw new Exception("Неверный формат данных в файле! Проверьте файл на наличие букв и лишних пробелов.");
                            }
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

                        arr = new double[rowCount, colCount];

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
                        arr = null;
                    }
                    try
                    {
                        assProb = new AssignmentProblem(arr); 
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (assProb.CostMatrix.GetLength(0) > 50)
            {
                buttonFillTable.Visible = true;
                dataGridViewMatrix.Columns.Clear();
            }
            else
            {
                FillGrid();
            }
        }
    }
}
