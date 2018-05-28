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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxCountVar = new System.Windows.Forms.TextBox();
            this.textBoxCountConstraint = new System.Windows.Forms.TextBox();
            this.textBoxCountCriteria = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateEmptyProblem = new System.Windows.Forms.Button();
            this.buttonOpenFromFile = new System.Windows.Forms.Button();
            this.buttonComputeF = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStep = new System.Windows.Forms.TextBox();
            this.textBoxAlpha = new System.Windows.Forms.TextBox();
            this.textBoxEps = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonComputePenalty = new System.Windows.Forms.Button();
            this.labelOptF = new System.Windows.Forms.Label();
            this.labelProblem = new System.Windows.Forms.Label();
            this.textBoxProb = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxEpsGrad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonSaveProb = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonGenerate);
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
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(146, 149);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(97, 23);
            this.buttonGenerate.TabIndex = 9;
            this.buttonGenerate.Text = "Сгенерировать";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
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
            this.toolTip1.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            // 
            // textBoxCountVar
            // 
            this.textBoxCountVar.Location = new System.Drawing.Point(133, 123);
            this.textBoxCountVar.Name = "textBoxCountVar";
            this.textBoxCountVar.Size = new System.Drawing.Size(42, 20);
            this.textBoxCountVar.TabIndex = 7;
            // 
            // textBoxCountConstraint
            // 
            this.textBoxCountConstraint.Location = new System.Drawing.Point(133, 97);
            this.textBoxCountConstraint.Name = "textBoxCountConstraint";
            this.textBoxCountConstraint.Size = new System.Drawing.Size(42, 20);
            this.textBoxCountConstraint.TabIndex = 6;
            // 
            // textBoxCountCriteria
            // 
            this.textBoxCountCriteria.Location = new System.Drawing.Point(133, 71);
            this.textBoxCountCriteria.Name = "textBoxCountCriteria";
            this.textBoxCountCriteria.Size = new System.Drawing.Size(42, 20);
            this.textBoxCountCriteria.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Число критериев";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Число ограничений";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Число переменных";
            // 
            // buttonCreateEmptyProblem
            // 
            this.buttonCreateEmptyProblem.Location = new System.Drawing.Point(14, 149);
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
            // buttonComputeF
            // 
            this.buttonComputeF.Location = new System.Drawing.Point(318, 436);
            this.buttonComputeF.Name = "buttonComputeF";
            this.buttonComputeF.Size = new System.Drawing.Size(125, 23);
            this.buttonComputeF.TabIndex = 2;
            this.buttonComputeF.Text = "Рассчитать вектор f*";
            this.buttonComputeF.UseVisualStyleBackColor = true;
            this.buttonComputeF.Visible = false;
            this.buttonComputeF.Click += new System.EventHandler(this.buttonCompute_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(318, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 398);
            this.panel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxStep);
            this.groupBox2.Controls.Add(this.textBoxAlpha);
            this.groupBox2.Controls.Add(this.textBoxEps);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 116);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Метод штрафных функций";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Шаг";
            // 
            // textBoxStep
            // 
            this.textBoxStep.Location = new System.Drawing.Point(100, 86);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(82, 20);
            this.textBoxStep.TabIndex = 10;
            // 
            // textBoxAlpha
            // 
            this.textBoxAlpha.Location = new System.Drawing.Point(100, 60);
            this.textBoxAlpha.Name = "textBoxAlpha";
            this.textBoxAlpha.Size = new System.Drawing.Size(82, 20);
            this.textBoxAlpha.TabIndex = 8;
            // 
            // textBoxEps
            // 
            this.textBoxEps.Location = new System.Drawing.Point(100, 34);
            this.textBoxEps.Name = "textBoxEps";
            this.textBoxEps.Size = new System.Drawing.Size(82, 20);
            this.textBoxEps.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Начальное aplha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Погрешность e";
            // 
            // buttonComputePenalty
            // 
            this.buttonComputePenalty.Location = new System.Drawing.Point(12, 431);
            this.buttonComputePenalty.Name = "buttonComputePenalty";
            this.buttonComputePenalty.Size = new System.Drawing.Size(75, 23);
            this.buttonComputePenalty.TabIndex = 9;
            this.buttonComputePenalty.Text = "Рассчитать";
            this.buttonComputePenalty.UseVisualStyleBackColor = true;
            this.buttonComputePenalty.Visible = false;
            this.buttonComputePenalty.Click += new System.EventHandler(this.buttonComputePenalty_Click);
            // 
            // labelOptF
            // 
            this.labelOptF.AutoSize = true;
            this.labelOptF.Location = new System.Drawing.Point(481, 441);
            this.labelOptF.Name = "labelOptF";
            this.labelOptF.Size = new System.Drawing.Size(35, 13);
            this.labelOptF.TabIndex = 5;
            this.labelOptF.Text = "label5";
            this.labelOptF.Visible = false;
            // 
            // labelProblem
            // 
            this.labelProblem.AutoSize = true;
            this.labelProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProblem.Location = new System.Drawing.Point(315, 465);
            this.labelProblem.Name = "labelProblem";
            this.labelProblem.Size = new System.Drawing.Size(81, 15);
            this.labelProblem.TabIndex = 6;
            this.labelProblem.Text = "labelProblem";
            this.labelProblem.Visible = false;
            // 
            // textBoxProb
            // 
            this.textBoxProb.Location = new System.Drawing.Point(318, 484);
            this.textBoxProb.Name = "textBoxProb";
            this.textBoxProb.Size = new System.Drawing.Size(549, 20);
            this.textBoxProb.TabIndex = 7;
            this.textBoxProb.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxEpsGrad);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(12, 343);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 72);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Метод наискорейшего спуска";
            // 
            // textBoxEpsGrad
            // 
            this.textBoxEpsGrad.Location = new System.Drawing.Point(100, 34);
            this.textBoxEpsGrad.Name = "textBoxEpsGrad";
            this.textBoxEpsGrad.Size = new System.Drawing.Size(82, 20);
            this.textBoxEpsGrad.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Погрешность e";
            // 
            // buttonSaveProb
            // 
            this.buttonSaveProb.Location = new System.Drawing.Point(751, 437);
            this.buttonSaveProb.Name = "buttonSaveProb";
            this.buttonSaveProb.Size = new System.Drawing.Size(115, 23);
            this.buttonSaveProb.TabIndex = 11;
            this.buttonSaveProb.Text = "Сохранить задачу";
            this.buttonSaveProb.UseVisualStyleBackColor = true;
            this.buttonSaveProb.Visible = false;
            this.buttonSaveProb.Click += new System.EventHandler(this.buttonSaveProb_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 518);
            this.Controls.Add(this.buttonSaveProb);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBoxProb);
            this.Controls.Add(this.labelProblem);
            this.Controls.Add(this.buttonComputePenalty);
            this.Controls.Add(this.labelOptF);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonComputeF);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Решение задач многокритериальной оптимизации";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button buttonComputeF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelOptF;
        private System.Windows.Forms.TextBox textBoxAlpha;
        private System.Windows.Forms.TextBox textBoxEps;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonComputePenalty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStep;
        private System.Windows.Forms.Label labelProblem;
        private System.Windows.Forms.TextBox textBoxProb;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxEpsGrad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonSaveProb;
    }
}

