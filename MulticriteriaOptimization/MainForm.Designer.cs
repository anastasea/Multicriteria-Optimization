namespace MulticriteriaOptimization
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxCountVar = new System.Windows.Forms.TextBox();
            this.textBoxCountConstraint = new System.Windows.Forms.TextBox();
            this.textBoxCountCriteria = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateEmptyProblem = new System.Windows.Forms.Button();
            this.buttonOpenFromFile = new System.Windows.Forms.Button();
            this.buttonCompute = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.textBoxCountVar);
            this.groupBox1.Controls.Add(this.textBoxCountConstraint);
            this.groupBox1.Controls.Add(this.textBoxCountCriteria);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonCreateEmptyProblem);
            this.groupBox1.Controls.Add(this.buttonOpenFromFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Постановка задачи";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MulticriteriaOptimization.Properties.Resources.rsz_help;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(146, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxCountVar
            // 
            this.textBoxCountVar.Location = new System.Drawing.Point(134, 115);
            this.textBoxCountVar.Name = "textBoxCountVar";
            this.textBoxCountVar.Size = new System.Drawing.Size(42, 20);
            this.textBoxCountVar.TabIndex = 7;
            // 
            // textBoxCountConstraint
            // 
            this.textBoxCountConstraint.Location = new System.Drawing.Point(134, 89);
            this.textBoxCountConstraint.Name = "textBoxCountConstraint";
            this.textBoxCountConstraint.Size = new System.Drawing.Size(42, 20);
            this.textBoxCountConstraint.TabIndex = 6;
            // 
            // textBoxCountCriteria
            // 
            this.textBoxCountCriteria.Location = new System.Drawing.Point(134, 63);
            this.textBoxCountCriteria.Name = "textBoxCountCriteria";
            this.textBoxCountCriteria.Size = new System.Drawing.Size(42, 20);
            this.textBoxCountCriteria.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Число критериев";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Число ограничений";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Число переменных";
            // 
            // buttonCreateEmptyProblem
            // 
            this.buttonCreateEmptyProblem.Location = new System.Drawing.Point(15, 151);
            this.buttonCreateEmptyProblem.Name = "buttonCreateEmptyProblem";
            this.buttonCreateEmptyProblem.Size = new System.Drawing.Size(125, 23);
            this.buttonCreateEmptyProblem.TabIndex = 1;
            this.buttonCreateEmptyProblem.Text = "Заполнить вручную";
            this.buttonCreateEmptyProblem.UseVisualStyleBackColor = true;
            this.buttonCreateEmptyProblem.Click += new System.EventHandler(this.buttonCreateEmptyProblem_Click);
            // 
            // buttonOpenFromFile
            // 
            this.buttonOpenFromFile.Location = new System.Drawing.Point(14, 30);
            this.buttonOpenFromFile.Name = "buttonOpenFromFile";
            this.buttonOpenFromFile.Size = new System.Drawing.Size(125, 23);
            this.buttonOpenFromFile.TabIndex = 0;
            this.buttonOpenFromFile.Text = "Открыть из файла";
            this.buttonOpenFromFile.UseVisualStyleBackColor = true;
            this.buttonOpenFromFile.Click += new System.EventHandler(this.buttonOpenFromFile_Click);
            // 
            // buttonCompute
            // 
            this.buttonCompute.Location = new System.Drawing.Point(27, 238);
            this.buttonCompute.Name = "buttonCompute";
            this.buttonCompute.Size = new System.Drawing.Size(125, 23);
            this.buttonCompute.TabIndex = 2;
            this.buttonCompute.Text = "Рассчитать";
            this.buttonCompute.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(318, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 398);
            this.panel1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCompute);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Решение задач многокритериальной оптимизации";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxCountVar;
        private System.Windows.Forms.TextBox textBoxCountConstraint;
        private System.Windows.Forms.TextBox textBoxCountCriteria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreateEmptyProblem;
        private System.Windows.Forms.Button buttonOpenFromFile;
        private System.Windows.Forms.Button buttonCompute;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

