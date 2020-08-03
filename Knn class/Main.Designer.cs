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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.classes = new System.Windows.Forms.ComboBox();
            this.point_draw = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dots_list = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.Metrics = new System.Windows.Forms.ComboBox();
            this.button13 = new System.Windows.Forms.Button();
            this.Kls_Metrics = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtDot2 = new System.Windows.Forms.TextBox();
            this.txtDot1 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.chad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ribs = new System.Windows.Forms.CheckBox();
            this.button11 = new System.Windows.Forms.Button();
            this.graph_method = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Rbox = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.r_auto = new System.Windows.Forms.CheckBox();
            this.button14 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Cstep = new System.Windows.Forms.TextBox();
            this.chart_auto = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKlasters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numElements)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chad)).BeginInit();
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
            this.point_draw.BackColor = System.Drawing.Color.RosyBrown;
            this.point_draw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.point_draw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.point_draw.Location = new System.Drawing.Point(12, 10);
            this.point_draw.Name = "point_draw";
            this.point_draw.Size = new System.Drawing.Size(90, 25);
            this.point_draw.TabIndex = 3;
            this.point_draw.Text = "Point&&Click";
            this.point_draw.UseVisualStyleBackColor = false;
            this.point_draw.CheckedChanged += new System.EventHandler(this.Point_draw_CheckedChanged);
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
            this.button2.Location = new System.Drawing.Point(584, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 30);
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
            this.button3.Size = new System.Drawing.Size(137, 27);
            this.button3.TabIndex = 13;
            this.button3.Text = "Кластеризация";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // neighbours
            // 
            this.neighbours.Location = new System.Drawing.Point(549, 119);
            this.neighbours.Name = "neighbours";
            this.neighbours.Size = new System.Drawing.Size(81, 20);
            this.neighbours.TabIndex = 16;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(584, 76);
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
            this.w_knn.Location = new System.Drawing.Point(370, 152);
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
            this.c_knn.Location = new System.Drawing.Point(501, 152);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(461, 125);
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
            this.button5.Location = new System.Drawing.Point(671, 77);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 27);
            this.button5.TabIndex = 23;
            this.button5.Text = "Отмена";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // centers
            // 
            this.centers.Appearance = System.Windows.Forms.Appearance.Button;
            this.centers.AutoSize = true;
            this.centers.BackColor = System.Drawing.Color.RosyBrown;
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
            this.label2.Location = new System.Drawing.Point(318, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Число кластеров:";
            // 
            // klasters
            // 
            this.klasters.Location = new System.Drawing.Point(417, 227);
            this.klasters.Name = "klasters";
            this.klasters.Size = new System.Drawing.Size(108, 20);
            this.klasters.TabIndex = 28;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(321, 259);
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
            this.button9.Location = new System.Drawing.Point(402, 259);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(123, 28);
            this.button9.TabIndex = 34;
            this.button9.Text = "K means debug";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Metrics
            // 
            this.Metrics.BackColor = System.Drawing.Color.Black;
            this.Metrics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Metrics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Metrics.ForeColor = System.Drawing.Color.White;
            this.Metrics.FormattingEnabled = true;
            this.Metrics.Items.AddRange(new object[] {
            "Евклидово расстояние",
            "Квадрат Евклидова расстояния",
            "Манхэттенское расстояние",
            "Расстояние Чебышева",
            "Расстояние Хэмминга",
            "Расстояние Левинштейна"});
            this.Metrics.Location = new System.Drawing.Point(318, 198);
            this.Metrics.Name = "Metrics";
            this.Metrics.Size = new System.Drawing.Size(230, 23);
            this.Metrics.TabIndex = 41;
            this.Metrics.Text = "Метрика";
            this.Metrics.SelectedIndexChanged += new System.EventHandler(this.Metrics_SelectedIndexChanged);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button13.Location = new System.Drawing.Point(321, 293);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(204, 45);
            this.button13.TabIndex = 46;
            this.button13.Text = "Иерархическая кластеризация";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.Button13_Click);
            // 
            // Kls_Metrics
            // 
            this.Kls_Metrics.BackColor = System.Drawing.Color.Black;
            this.Kls_Metrics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Kls_Metrics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Kls_Metrics.ForeColor = System.Drawing.Color.White;
            this.Kls_Metrics.FormattingEnabled = true;
            this.Kls_Metrics.Items.AddRange(new object[] {
            "Метод ближайшего соседа",
            "Метод дальнего соседа",
            "UPGMA",
            "WPGMA"});
            this.Kls_Metrics.Location = new System.Drawing.Point(564, 198);
            this.Kls_Metrics.Name = "Kls_Metrics";
            this.Kls_Metrics.Size = new System.Drawing.Size(230, 23);
            this.Kls_Metrics.TabIndex = 47;
            this.Kls_Metrics.Text = "Критерий связи";
            this.Kls_Metrics.SelectedIndexChanged += new System.EventHandler(this.Kls_Metrics_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(546, 227);
            this.groupBox1.MinimumSize = new System.Drawing.Size(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 117);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.txtDot2);
            this.groupBox2.Controls.Add(this.txtDot1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(0, 2);
            this.groupBox2.MinimumSize = new System.Drawing.Size(0, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 113);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа со строками";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(48, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(149, 27);
            this.button4.TabIndex = 49;
            this.button4.Text = "Найти расстояние";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // txtDot2
            // 
            this.txtDot2.Location = new System.Drawing.Point(7, 56);
            this.txtDot2.Name = "txtDot2";
            this.txtDot2.Size = new System.Drawing.Size(232, 21);
            this.txtDot2.TabIndex = 1;
            // 
            // txtDot1
            // 
            this.txtDot1.Location = new System.Drawing.Point(7, 30);
            this.txtDot1.Name = "txtDot1";
            this.txtDot1.Size = new System.Drawing.Size(232, 21);
            this.txtDot1.TabIndex = 0;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10.Location = new System.Drawing.Point(694, 40);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 30);
            this.button10.TabIndex = 50;
            this.button10.Text = "1d=1k";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.Button10_Click_1);
            // 
            // chad
            // 
            this.chad.BackColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chad.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chad.Legends.Add(legend3);
            this.chad.Location = new System.Drawing.Point(12, 362);
            this.chad.Name = "chad";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.MarkerBorderWidth = 5;
            series3.Name = "График расстояний между точками";
            series3.YValuesPerPoint = 10;
            this.chad.Series.Add(series3);
            this.chad.Size = new System.Drawing.Size(502, 226);
            this.chad.TabIndex = 51;
            this.chad.Text = "chad";
            // 
            // ribs
            // 
            this.ribs.Appearance = System.Windows.Forms.Appearance.Button;
            this.ribs.AutoSize = true;
            this.ribs.BackColor = System.Drawing.Color.RosyBrown;
            this.ribs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ribs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ribs.Location = new System.Drawing.Point(510, 362);
            this.ribs.Name = "ribs";
            this.ribs.Size = new System.Drawing.Size(58, 25);
            this.ribs.TabIndex = 52;
            this.ribs.Text = "Рёбра";
            this.ribs.UseVisualStyleBackColor = false;
            this.ribs.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.Location = new System.Drawing.Point(574, 362);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(159, 25);
            this.button11.TabIndex = 53;
            this.button11.Text = "Построить дерево";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.Button11_Click_1);
            // 
            // graph_method
            // 
            this.graph_method.BackColor = System.Drawing.Color.Black;
            this.graph_method.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.graph_method.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.graph_method.ForeColor = System.Drawing.Color.White;
            this.graph_method.FormattingEnabled = true;
            this.graph_method.Items.AddRange(new object[] {
            "Выделение связных компонент",
            "Мин. остовное дерево (алгоритм Прима)"});
            this.graph_method.Location = new System.Drawing.Point(510, 404);
            this.graph_method.Name = "graph_method";
            this.graph_method.Size = new System.Drawing.Size(275, 23);
            this.graph_method.TabIndex = 54;
            this.graph_method.Text = "Графовый метод кластеризации";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(513, 439);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Параметр R:";
            // 
            // Rbox
            // 
            this.Rbox.Location = new System.Drawing.Point(591, 436);
            this.Rbox.Name = "Rbox";
            this.Rbox.Size = new System.Drawing.Size(108, 20);
            this.Rbox.TabIndex = 55;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12.Location = new System.Drawing.Point(510, 468);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(233, 25);
            this.button12.TabIndex = 57;
            this.button12.Text = "Графовая кластеризация";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.Button12_Click_1);
            // 
            // r_auto
            // 
            this.r_auto.AutoSize = true;
            this.r_auto.BackColor = System.Drawing.Color.Transparent;
            this.r_auto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.r_auto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.r_auto.Location = new System.Drawing.Point(714, 437);
            this.r_auto.Name = "r_auto";
            this.r_auto.Size = new System.Drawing.Size(55, 19);
            this.r_auto.TabIndex = 58;
            this.r_auto.Text = "авто";
            this.r_auto.UseVisualStyleBackColor = false;
            this.r_auto.CheckedChanged += new System.EventHandler(this.R_auto_CheckedChanged);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button14.Location = new System.Drawing.Point(510, 508);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(159, 25);
            this.button14.TabIndex = 59;
            this.button14.Text = "Обновить график";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.Button14_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(513, 542);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Шаг R:";
            // 
            // Cstep
            // 
            this.Cstep.Location = new System.Drawing.Point(557, 539);
            this.Cstep.Name = "Cstep";
            this.Cstep.Size = new System.Drawing.Size(49, 20);
            this.Cstep.TabIndex = 60;
            // 
            // chart_auto
            // 
            this.chart_auto.AutoSize = true;
            this.chart_auto.BackColor = System.Drawing.Color.Transparent;
            this.chart_auto.Checked = true;
            this.chart_auto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chart_auto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chart_auto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chart_auto.Location = new System.Drawing.Point(714, 514);
            this.chart_auto.Name = "chart_auto";
            this.chart_auto.Size = new System.Drawing.Size(55, 19);
            this.chart_auto.TabIndex = 62;
            this.chart_auto.Text = "авто";
            this.chart_auto.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(105, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(354, 15);
            this.label7.TabIndex = 63;
            this.label7.Text = "Гистограмма распределения попарных расстояний";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(803, 600);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chart_auto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Cstep);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.r_auto);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Rbox);
            this.Controls.Add(this.graph_method);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.ribs);
            this.Controls.Add(this.chad);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Kls_Metrics);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.Metrics);
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
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKlasters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numElements)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chad)).EndInit();
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
        private System.Windows.Forms.ComboBox Metrics;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ComboBox Kls_Metrics;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtDot2;
        private System.Windows.Forms.TextBox txtDot1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataVisualization.Charting.Chart chad;
        private System.Windows.Forms.CheckBox ribs;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox graph_method;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Rbox;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.CheckBox r_auto;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Cstep;
        private System.Windows.Forms.CheckBox chart_auto;
        private System.Windows.Forms.Label label7;
    }
}

