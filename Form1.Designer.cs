namespace DemoLab1._1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            this.gaussSelectDistGraph = new ZedGraph.ZedGraphControl();
            this.uniformSelectDistGraph = new ZedGraph.ZedGraphControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gaussAllDistGraph = new ZedGraph.ZedGraphControl();
            this.uniformAllDistGraph = new ZedGraph.ZedGraphControl();
            this.gaussRandGraph = new ZedGraph.ZedGraphControl();
            this.uniformRandGraph = new ZedGraph.ZedGraphControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 652);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Сгенерировать новые значения";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1024, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "СХЕМА МОДЕЛИРОВАНИЯ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.trackBar2);
            this.groupBox1.Location = new System.Drawing.Point(244, 652);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 66);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки отображения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(562, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Количество шагов гистограммы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Количество генерируемых значений";
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(122, 27);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(425, 33);
            this.trackBar1.TabIndex = 20;
            this.trackBar1.Value = 10;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(90, 17);
            this.radioButton2.TabIndex = 19;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "В виде точек";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(98, 17);
            this.radioButton1.TabIndex = 18;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "В виде кривой";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // trackBar2
            // 
            this.trackBar2.AutoSize = false;
            this.trackBar2.LargeChange = 1;
            this.trackBar2.Location = new System.Drawing.Point(553, 27);
            this.trackBar2.Maximum = 4;
            this.trackBar2.Minimum = 1;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(193, 33);
            this.trackBar2.TabIndex = 17;
            this.trackBar2.Value = 3;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 687);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(226, 33);
            this.button2.TabIndex = 18;
            this.button2.Text = "Выход из программы";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gaussSelectDistGraph
            // 
            this.gaussSelectDistGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gaussSelectDistGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gaussSelectDistGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gaussSelectDistGraph.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gaussSelectDistGraph.IsShowPointValues = false;
            this.gaussSelectDistGraph.Location = new System.Drawing.Point(538, 468);
            this.gaussSelectDistGraph.Name = "gaussSelectDistGraph";
            this.gaussSelectDistGraph.PointValueFormat = "G";
            this.gaussSelectDistGraph.Size = new System.Drawing.Size(226, 178);
            this.gaussSelectDistGraph.TabIndex = 10;
            // 
            // uniformSelectDistGraph
            // 
            this.uniformSelectDistGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uniformSelectDistGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uniformSelectDistGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uniformSelectDistGraph.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.uniformSelectDistGraph.IsShowPointValues = false;
            this.uniformSelectDistGraph.Location = new System.Drawing.Point(538, 272);
            this.uniformSelectDistGraph.Name = "uniformSelectDistGraph";
            this.uniformSelectDistGraph.PointValueFormat = "G";
            this.uniformSelectDistGraph.Size = new System.Drawing.Size(226, 190);
            this.uniformSelectDistGraph.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DemoLab1._1.Properties.Resources.schematicfull;
            this.pictureBox1.Location = new System.Drawing.Point(153, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // gaussAllDistGraph
            // 
            this.gaussAllDistGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gaussAllDistGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gaussAllDistGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gaussAllDistGraph.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gaussAllDistGraph.IsShowPointValues = false;
            this.gaussAllDistGraph.Location = new System.Drawing.Point(770, 468);
            this.gaussAllDistGraph.Name = "gaussAllDistGraph";
            this.gaussAllDistGraph.PointValueFormat = "G";
            this.gaussAllDistGraph.Size = new System.Drawing.Size(226, 178);
            this.gaussAllDistGraph.TabIndex = 3;
            // 
            // uniformAllDistGraph
            // 
            this.uniformAllDistGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uniformAllDistGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uniformAllDistGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uniformAllDistGraph.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.uniformAllDistGraph.IsShowPointValues = false;
            this.uniformAllDistGraph.Location = new System.Drawing.Point(770, 272);
            this.uniformAllDistGraph.Name = "uniformAllDistGraph";
            this.uniformAllDistGraph.PointValueFormat = "G";
            this.uniformAllDistGraph.Size = new System.Drawing.Size(226, 190);
            this.uniformAllDistGraph.TabIndex = 2;
            // 
            // gaussRandGraph
            // 
            this.gaussRandGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gaussRandGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gaussRandGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gaussRandGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gaussRandGraph.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gaussRandGraph.IsShowPointValues = false;
            this.gaussRandGraph.Location = new System.Drawing.Point(12, 468);
            this.gaussRandGraph.Name = "gaussRandGraph";
            this.gaussRandGraph.PointValueFormat = "G";
            this.gaussRandGraph.Size = new System.Drawing.Size(520, 178);
            this.gaussRandGraph.TabIndex = 1;
            // 
            // uniformRandGraph
            // 
            this.uniformRandGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uniformRandGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uniformRandGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uniformRandGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uniformRandGraph.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.uniformRandGraph.IsShowPointValues = false;
            this.uniformRandGraph.Location = new System.Drawing.Point(12, 272);
            this.uniformRandGraph.Name = "uniformRandGraph";
            this.uniformRandGraph.PointValueFormat = "G";
            this.uniformRandGraph.Size = new System.Drawing.Size(520, 190);
            this.uniformRandGraph.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(136, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Текущая реализация (100 отсчетов)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(715, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "Гистограммы:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(612, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 21;
            this.label6.Text = "Текущая";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(545, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 19);
            this.label7.TabIndex = 22;
            this.label7.Text = " (по последним 100 отсчетам)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(835, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 19);
            this.label8.TabIndex = 23;
            this.label8.Text = "Накопленная";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(816, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 19);
            this.label9.TabIndex = 24;
            this.label9.Text = "(для 100 отсчетов)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gaussSelectDistGraph);
            this.Controls.Add(this.uniformSelectDistGraph);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gaussAllDistGraph);
            this.Controls.Add(this.uniformAllDistGraph);
            this.Controls.Add(this.gaussRandGraph);
            this.Controls.Add(this.uniformRandGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1014, 758);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1014, 758);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Программа моделирования генератора сигнала с равномерным и нормальным распределен" +
                "ием величины ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl uniformRandGraph;
        private ZedGraph.ZedGraphControl gaussRandGraph;
        private ZedGraph.ZedGraphControl uniformAllDistGraph;
        private ZedGraph.ZedGraphControl gaussAllDistGraph;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ZedGraph.ZedGraphControl uniformSelectDistGraph;
        private ZedGraph.ZedGraphControl gaussSelectDistGraph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;

    }
}

