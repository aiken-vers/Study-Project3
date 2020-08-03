namespace Knn_class
{
    partial class Main
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.classes = new System.Windows.Forms.ComboBox();
            this.point_draw = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dots_list = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.neighbours = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.def_knn = new System.Windows.Forms.RadioButton();
            this.w_knn = new System.Windows.Forms.RadioButton();
            this.c_knn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.centers = new System.Windows.Forms.CheckBox();
            this.cw_knn = new System.Windows.Forms.RadioButton();
            this.button7 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.klasters = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.numKlasters = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numElements = new System.Windows.Forms.NumericUpDown();
            this.button9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKlasters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numElements)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // classes
            // 
            this.classes.BackColor = System.Drawing.Color.Black;
            this.classes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.classes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.classes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.classes.ForeColor = System.Drawing.Color.White;
            this.classes.FormattingEnabled = true;
            this.classes.Location = new System.Drawing.Point(348, 76);
            this.classes.Name = "classes";
            this.classes.Size = new System.Drawing.Size(166, 23);
            this.classes.TabIndex = 1;
            this.classes.Text = "Классы";
            // 
            // point_draw
            // 
            this.point_draw.Appearance = System.Windows.Forms.Appearance.Button;
            this.point_draw.AutoSize = true;
            this.point_draw.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.point_draw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.point_draw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.point_draw.Location = new System.Drawing.Point(12, 10);
            this.point_draw.Name = "point_draw";
            this.point_draw.Size = new System.Drawing.Size(90, 25);
            this.point_draw.TabIndex = 3;
            this.point_draw.Text = "Point&&Click";
            this.point_draw.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(318, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dots_list
            // 
            this.dots_list.BackColor = System.Drawing.Color.Black;
            this.dots_list.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dots_list.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dots_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dots_list.ForeColor = System.Drawing.Color.White;
            this.dots_list.FormattingEnabled = true;
            this.dots_list.Location = new System.Drawing.Point(318, 39);
            this.dots_list.Name = "dots_list";
            this.dots_list.Size = new System.Drawing.Size(230, 23);
            this.dots_list.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(584, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 30);
            this.button2.TabIndex = 11;
            this.button2.Text = "Сортировка";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(318, 111);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 27);
            this.button3.TabIndex = 13;
            this.button3.Text = "Knn";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.Color.Black;
            this.logBox.ForeColor = System.Drawing.Color.White;
            this.logBox.Location = new System.Drawing.Point(318, 249);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(319, 90);
            this.logBox.TabIndex = 14;
            this.logBox.Text = "";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(318, 346);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "append";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // neighbours
            // 
            this.neighbours.Location = new System.Drawing.Point(487, 118);
            this.neighbours.Name = "neighbours";
            this.neighbours.Size = new System.Drawing.Size(81, 20);
            this.neighbours.TabIndex = 16;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(584, 36);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(81, 28);
            this.button6.TabIndex = 18;
            this.button6.Text = "Очистить";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // def_knn
            // 
            this.def_knn.AutoSize = true;
            this.def_knn.BackColor = System.Drawing.Color.Transparent;
            this.def_knn.Checked = true;
            this.def_knn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.def_knn.Location = new System.Drawing.Point(318, 152);
            this.def_knn.Name = "def_knn";
            this.def_knn.Size = new System.Drawing.Size(51, 17);
            this.def_knn.TabIndex = 19;
            this.def_knn.TabStop = true;
            this.def_knn.Text = "KNN";
            this.def_knn.UseVisualStyleBackColor = false;
            // 
            // w_knn
            // 
            this.w_knn.AutoSize = true;
            this.w_knn.BackColor = System.Drawing.Color.Transparent;
            this.w_knn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.w_knn.Location = new System.Drawing.Point(375, 152);
            this.w_knn.Name = "w_knn";
            this.w_knn.Size = new System.Drawing.Size(130, 17);
            this.w_knn.TabIndex = 20;
            this.w_knn.Text = "Взвешенный KNN";
            this.w_knn.UseVisualStyleBackColor = false;
            // 
            // c_knn
            // 
            this.c_knn.AutoSize = true;
            this.c_knn.BackColor = System.Drawing.Color.Transparent;
            this.c_knn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.c_knn.Location = new System.Drawing.Point(511, 152);
            this.c_knn.Name = "c_knn";
            this.c_knn.Size = new System.Drawing.Size(126, 17);
            this.c_knn.TabIndex = 21;
            this.c_knn.Text = "Центрированный";
            this.c_knn.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(399, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Число соседей:";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button5.Location = new System.Drawing.Point(584, 110);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 27);
            this.button5.TabIndex = 23;
            this.button5.Text = "Revert";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // centers
            // 
            this.centers.Appearance = System.Windows.Forms.Appearance.Button;
            this.centers.AutoSize = true;
            this.centers.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.centers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.centers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.centers.Location = new System.Drawing.Point(108, 10);
            this.centers.Name = "centers";
            this.centers.Size = new System.Drawing.Size(69, 25);
            this.centers.TabIndex = 24;
            this.centers.Text = "Центры";
            this.centers.UseVisualStyleBackColor = false;
            this.centers.CheckedChanged += new System.EventHandler(this.Centers_CheckedChanged);
            // 
            // cw_knn
            // 
            this.cw_knn.AutoSize = true;
            this.cw_knn.BackColor = System.Drawing.Color.Transparent;
            this.cw_knn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cw_knn.Location = new System.Drawing.Point(318, 175);
            this.cw_knn.Name = "cw_knn";
            this.cw_knn.Size = new System.Drawing.Size(204, 17);
            this.cw_knn.TabIndex = 25;
            this.cw_knn.Text = "Центрированный взвешенный";
            this.cw_knn.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(222, 10);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 25);
            this.button7.TabIndex = 26;
            this.button7.Text = "Генерация";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(399, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Число кластеров:";
            // 
            // klasters
            // 
            this.klasters.Location = new System.Drawing.Point(503, 210);
            this.klasters.Name = "klasters";
            this.klasters.Size = new System.Drawing.Size(65, 20);
            this.klasters.TabIndex = 28;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(318, 203);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 27);
            this.button8.TabIndex = 27;
            this.button8.Text = "K means";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // numKlasters
            // 
            this.numKlasters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numKlasters.Location = new System.Drawing.Point(389, 13);
            this.numKlasters.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKlasters.Name = "numKlasters";
            this.numKlasters.ReadOnly = true;
            this.numKlasters.Size = new System.Drawing.Size(33, 20);
            this.numKlasters.TabIndex = 30;
            this.numKlasters.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(318, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "кластеры";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(427, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "элементы";
            // 
            // numElements
            // 
            this.numElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numElements.Location = new System.Drawing.Point(501, 13);
            this.numElements.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numElements.Name = "numElements";
            this.numElements.ReadOnly = true;
            this.numElements.Size = new System.Drawing.Size(47, 20);
            this.numElements.TabIndex = 32;
            this.numElements.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(399, 342);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(123, 28);
            this.button9.TabIndex = 34;
            this.button9.Text = "K means debug";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(700, 375);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numElements);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numKlasters);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.klasters);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.cw_knn);
            this.Controls.Add(this.centers);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_knn);
            this.Controls.Add(this.w_knn);
            this.Controls.Add(this.def_knn);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.neighbours);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dots_list);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.point_draw);
            this.Controls.Add(this.classes);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKlasters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numElements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox classes;
        private System.Windows.Forms.CheckBox point_draw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox dots_list;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox neighbours;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.RadioButton def_knn;
        private System.Windows.Forms.RadioButton w_knn;
        private System.Windows.Forms.RadioButton c_knn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox centers;
        private System.Windows.Forms.RadioButton cw_knn;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox klasters;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.NumericUpDown numKlasters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numElements;
        private System.Windows.Forms.Button button9;
    }
}

