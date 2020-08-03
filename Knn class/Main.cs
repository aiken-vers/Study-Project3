using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knn_class
{
    
    public partial class Main : Form
    {
        public static List<string> clr = new List<string>();
        List<Dot> Dots = new List<Dot>();
        List<Dot> old_Dots = new List<Dot>();
        List<Dot> class_centers = new List<Dot>();
        static List<Klass> gls = new List<Klass>();
        Dot.Metric metric = new Dot.Evklid();
        Klass.Metric kls_metric = new Klass.Nearest();

        public Main()
        {
            InitializeComponent();            
            this.classes.DrawItem +=
                new DrawItemEventHandler(classes_DrawItem);
            this.dots_list.DrawItem +=
               new DrawItemEventHandler(dotlist_DrawItem);
           
            Fill_clr(clr);
            add_class("none", "DimGray");           
            pictureBox1.Image = new Bitmap(pictureBox1.Height, pictureBox1.Width);            
            classes.DataSource = gls;
            dots_list.DataSource = Dots;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }        
        private void Fill_clr(List<string> list)
        {
            list.Clear();
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                    list.Add(prop.Name);                
            } 
            string[] bad_clr = new string[]{ "Black", "Transparent", "AliceBlue",
            "AntiqueWhite", "Azure", "Beige", "Bisque", "BlanchedAlmond", "Snow",
            "DarkGray", "FloralWhite", "ForestGreen", "Gainsboro", "GhostWhite",
            "Honeydew", "LavenderBlush", "LightYellow", "Linen", "MintCream", "Cornsilk",
            "NavajoWhite", "OldLace", "PapayaWhip", "SeaShell", "WhiteSmoke", };
            foreach(string b in bad_clr)
                list.Remove(b);

        }
        public static void add_class(string name, string col_name)
        {
            Klass temp = new Klass(name, col_name);
            gls.Add(temp);
            clr.Remove(col_name);
        } 
        public void generate_class(int count=1)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                string name = "Класс " + gls.Count;
                string color;
                try
                {
                    color = clr[rnd.Next(0, clr.Count - 1)];
                }
                catch
                {
                    color = "DimGray";
                }
                add_class(name, color);
            }            
        }
        private void classes_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox combo;
            try
            {
                e.DrawBackground();
                combo = (ComboBox)sender;
                if (e.Index >= 0)
                {                    
                    Brush brush = new SolidBrush(Color.FromName(gls[e.Index].clr_name));
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawString(gls[e.Index].ToString(), combo.Font, brush, e.Bounds.X, e.Bounds.Y);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        private void dotlist_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox combo;
            try
            {
                e.DrawBackground();
                combo = (ComboBox)sender;
                if (e.Index >= 0)
                {
                    Brush brush = new SolidBrush(Color.FromName(Dots[e.Index].clr_name));
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawString(Dots[e.Index].ToString(), combo.Font, brush, e.Bounds.X, e.Bounds.Y);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }               
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if(point_draw.Checked)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates = me.Location;
                List<double> tmp_list = new List<double>();
                tmp_list.Add(coordinates.X);
                tmp_list.Add(coordinates.Y);
                Dot temp = new Dot(tmp_list);
                Dots.Add(temp);
                temp.name = "P" + Dots.Count();
                temp.clr_name = gls[classes.SelectedIndex].clr_name;
                gls[classes.SelectedIndex].Add(temp);

                get_centers();
                RefreshAll();
            }           
        }
        private void RefreshAll()
        {
            Dots.Clear();
            Dots.AddRange(Klass.Kls_to_List(gls));
            Klass.RefreshAll(gls);

            //foreach (Klass g in gls)
            //{
            //    g.RemoveAll();
            //    foreach (Dot d in Dots)
            //    {
            //        if (d.class_name == g.name)
            //        {
            //            g.Add(d);
            //            if (d.clr_name != g.clr_name)
            //                d.clr_name = g.clr_name;
            //        }                        
            //    }
            //}

            RefreshScreen();
            dots_list.DataSource = null;
            dots_list.Items.Clear();
            dots_list.DataSource = Dots;

            classes.DataSource = null;
            classes.Items.Clear();
            classes.DataSource = gls;
        }
        private void RefreshScreen()
        {            
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
            Bitmap bmp = new Bitmap(300, 300);;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.Clear(Color.Black);
                //foreach(Dot d in Dots)
                foreach (Dot d in Klass.Kls_to_List(gls))
                {
                    SolidBrush b = new SolidBrush(Color.FromName(d.clr_name));
                    g.FillEllipse(b, new Rectangle((int)d.prms[0], (int)d.prms[1], 8, 8));
                }
                if (centers.Checked)
                {
                    foreach(Dot c in class_centers)
                    {
                        try
                        {
                            g.DrawLine(new Pen(Color.FromName(c.clr_name), 4),
                                         (float)c.prms[0] - 8,
                                         (float)c.prms[1] - 8,
                                         (float)c.prms[0] + 8,
                                         (float)c.prms[1] + 8);
                            g.DrawLine(new Pen(Color.FromName(c.clr_name), 4),
                                             (float)c.prms[0] + 8,
                                             (float)c.prms[1] - 8,
                                             (float)c.prms[0] - 8,
                                             (float)c.prms[1] + 8);
                        }
                        catch { }
                    }
                }
            }
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            add_class addclass = new add_class();
            if (addclass.ShowDialog() == DialogResult.OK)
            {
                classes.DataSource = null;
                classes.Items.Clear();
                classes.DataSource = gls;
            }
        }
        private void Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (Dot d in Dots)
                    d.mean = metric.Distance(d, Dots[dots_list.SelectedIndex]);

                Dots = Dots.OrderBy(d => d.class_name == "none").ThenBy(d => d.mean).ToList();

                dots_list.DataSource = null;
                dots_list.Items.Clear();
                dots_list.DataSource = Dots;
            }
            catch { }            
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            Klass.CopyDots(Klass.Kls_to_List(gls), old_Dots);
            //CopyDots(Dots, old_Dots);

            //CopyDots(Dots, old_Dots);

            int k = 0;
            if (int.TryParse(neighbours.Text, out k) || c_knn.Checked || cw_knn.Checked)
            {
                foreach (Dot d in Dots)
                    d.expectation = 0;
                if (def_knn.Checked) Klass.Knn(gls, k, metric);
                else if (w_knn.Checked) Klass.Knn(gls, k, 1.0, metric);
                else if (c_knn.Checked) Klass.Knn(gls, metric);
                else if (cw_knn.Checked) Klass.Knn(gls, metric, 1.0);

                RefreshAll();
            }
        }        
        public static void Prediction(RichTextBox box, List<Dot> Dots)
        {
            box.Clear();
            foreach (Dot d in Dots)
                AppendText(box, d.ToString(), Color.FromName(d.clr_name));
            string avg_prediction = "Средняя точность результатов классификации: " + Klass.average_predict(Dots) * 100 + "%";
            AppendText(box, avg_prediction, Color.FromName("White"));
        }
        public static void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text+'\n');
            box.SelectionColor = box.ForeColor;
        }
        private void Button6_Click(object sender, EventArgs e)
        {            
            Dots.Clear();
            class_centers.Clear();
            foreach (Klass g in gls)
            {
                g.RemoveAll();
            }
            RefreshAll();            
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            Klass.CopyDots(old_Dots, Dots);
            //CopyDots(old_Dots, Dots);
            foreach(Dot d in Dots)
            {
                if (!gls.Where(g => g.name == d.class_name).Any())
                {
                    Klass old = new Klass(d.class_name, d.clr_name);
                    gls.Add(old);
                }
            }
            foreach (Klass g in gls)
            {
                g.RemoveAll();
                foreach (Dot d in Dots)
                {
                    if (d.class_name == g.name)
                        g.Add(d);
                }
            }
            RefreshAll();
        }       
        
        private void get_centers()
        {            
            class_centers.Clear();
            foreach (Klass dot_class in gls)
                if(dot_class.name!="none")
                    class_centers.Add(dot_class.get_center());
        }
        private void Centers_CheckedChanged(object sender, EventArgs e)
        {
            get_centers();
            RefreshScreen();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Klass.CopyDots(Klass.Kls_to_List(gls), old_Dots);
            //CopyDots(Dots, old_Dots);
            
            Klass.Generate(gls[classes.SelectedIndex].Dots, 2, 300, (int)numKlasters.Value, (int)numElements.Value, metric, gls[classes.SelectedIndex].name);
            //Klass.Generate(Dots, 2, (int)numKlasters.Value, (int)numElements.Value, 300, gls[classes.SelectedIndex].name);
            
            RefreshAll();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Klass.CopyDots(Klass.Kls_to_List(gls), old_Dots);
                //CopyDots(Dots, old_Dots);

                Fill_clr(clr);

                List<Dot> centers = new List<Dot>();

                Klass none = gls[0];
                foreach (Klass k in gls)
                    if (k.name != "none")
                        Klass.AppendDots(k, gls[0]);
                gls.Clear();
                gls.Add(none);

                generate_class(Convert.ToInt32(klasters.Text));

                Klass.Generate(centers, 2, 300, gls.Count - 1, 1, metric, "none", 0);
                //Dot.Generate(centers, 2, gls.Count - 1, 1, 300, "none", 0);
                for (int i = 0; i < gls.Count - 1; i++)
                {
                    centers[i].class_name = gls[i + 1].name;
                    centers[i].clr_name = gls[i + 1].clr_name;
                }
                //Klass.Kmeans(Dots, centers, metric);
                Klass.Kmeans(gls[0].Dots, centers, metric);

                //Dot.kmeans(Dots, centers);
                class_centers.Clear();
                class_centers.AddRange(centers);
                RefreshAll();

            }
            catch { }            
        }
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                Klass.CopyDots(Klass.Kls_to_List(gls), old_Dots);

                Fill_clr(clr);

                List<Dot> centers = new List<Dot>();

                if (gls.Count()-1== Convert.ToInt32(klasters.Text)&&gls[0].Count()==0)
                {
                    centers.AddRange(class_centers);
                }
                else
                {
                    Klass none = gls[0];
                    gls.Clear();
                    gls.Add(none);

                    generate_class(Convert.ToInt32(klasters.Text));

                    Klass.Generate(centers, 2, 300, gls.Count - 1, 1, metric, "none", 0);
                    //Dot.Generate(centers, 2, gls.Count - 1, 1, 300, "none", 0);
                    for (int i = 0; i < gls.Count - 1; i++)
                    {
                        centers[i].class_name = gls[i + 1].name;
                        centers[i].clr_name = gls[i + 1].clr_name;
                    }
                }
                //Klass.Kmeans_debug(Dots, centers, metric);
                Klass.Kmeans_debug(Klass.Kls_to_List(gls), centers, metric);
                //Dot.kmeans_debug(Dots, centers);
                class_centers.Clear();
                class_centers.AddRange(centers);
                RefreshAll();
            }
            catch { }
        }

        private void Metrics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Metrics.SelectedItem.ToString() == "Евклидово расстояние")
                metric = new Dot.Evklid();
            else if (Metrics.SelectedItem.ToString() == "Квадрат Евклидова расстояния")
                metric = new Dot.Evklidx2();
            else if (Metrics.SelectedItem.ToString() == "Манхэттенское расстояние")
                metric = new Dot.Manhattan();
            else if (Metrics.SelectedItem.ToString() == "Расстояние Чебышева")
                metric = new Dot.Chebyshev();
            else if (Metrics.SelectedItem.ToString() == "Расстояние Хэмминга")
                metric = new Dot.Hamming();
            else if (Metrics.SelectedItem.ToString() == "Расстояние Левинштейна")
                metric = new Dot.Levenshtein();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //try
            //{
                Klass.Metric mk = new Klass.Nearest();
                Klass.CopyDots(Klass.Kls_to_List(gls), old_Dots);
                //CopyDots(Dots, old_Dots);
                Klass.lab3(gls, metric, Convert.ToInt32(klasters.Text), mk);              
               
                RefreshAll();
            //}
            //catch { }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Klass.Metric mk = new Klass.Furthest();
            Klass.CopyDots(Klass.Kls_to_List(gls), old_Dots);
            //CopyDots(Dots, old_Dots);
            Klass.lab3(gls, metric, Convert.ToInt32(klasters.Text), mk);

            RefreshAll();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Klass.Metric mk = new Klass.UPGMA();
            Klass.CopyDots(Klass.Kls_to_List(gls), old_Dots);
            //CopyDots(Dots, old_Dots);
            Klass.lab3(gls, metric, Convert.ToInt32(klasters.Text), mk);

            RefreshAll();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Klass.Metric mk = new Klass.WPGMA();
            Klass.CopyDots(Klass.Kls_to_List(gls), old_Dots);
            //CopyDots(Dots, old_Dots);
            Klass.lab3(gls, metric, Convert.ToInt32(klasters.Text), mk);

            RefreshAll();
        }

        private void Kls_Metrics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Kls_Metrics.SelectedItem.ToString() == "Метод ближайшего соседа")
                kls_metric = new Klass.Nearest();
            else if (Kls_Metrics.SelectedItem.ToString() == "Метод дальнего соседа")
                kls_metric = new Klass.Furthest();
            else if (Kls_Metrics.SelectedItem.ToString() == "UPGMA")
                kls_metric = new Klass.UPGMA();
            else if (Kls_Metrics.SelectedItem.ToString() == "WPGMA")
                kls_metric = new Klass.WPGMA();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            //try
            //{
                Klass.CopyDots(Klass.Kls_to_List(gls), old_Dots);
                Klass.lab3(gls, metric, Convert.ToInt32(klasters.Text), kls_metric);
                Check_colors();
                RefreshAll();
            //}
            //catch { }
        }

        private void Button10_Click_1(object sender, EventArgs e)
        {
            DtoK();
        }
        public void Check_colors()
        {
            Fill_clr(clr);
            Random rnd = new Random();
            foreach (Klass k in gls)
                if (k.name != "none")
                    if (!(k.clr_name == "DimGray"))
                        clr.Remove(k.clr_name);
                    else if (k.clr_name == "DimGray")
                        k.clr_name = clr[rnd.Next(0, clr.Count - 1)];

        }
        public void DtoK()
        {
            Klass.CopyDots(Klass.Kls_to_List(gls), old_Dots);
            Fill_clr(clr);
            Klass none = gls[0];
            foreach (Klass k in gls)
                if (k.name != "none")
                    Klass.AppendDots(k, gls[0]);
            gls.Clear();
            gls.Add(none);
            List<Dot> tempDots = new List<Dot>();
            tempDots.AddRange(Klass.Kls_to_List(gls));
            foreach(Dot d in tempDots)
            {
                generate_class();
                gls.Last().Add(d);
                gls.First().Remove(d);
            }
            RefreshAll();
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            double distance = 0;
            string txt1 = txtDot1.Text;
            string txt2 = txtDot2.Text;
            List<double> prms1 = new List<double>();
            List<double> prms2 = new List<double>();
            foreach(char c in txt1)
                prms1.Add(c);
            foreach (char c in txt2)
                prms2.Add(c);
            
            Dot d1 = new Dot(prms1);
            Dot d2 = new Dot(prms2);
            string sd1= d1.name + "{" + d1.prms_list(d1.prms.Count) + "} ";
            string sd2 = d2.name + "{" + d2.prms_list(d2.prms.Count) + "} ";
            try
            {
                double met = metric.Distance(d1, d2);
                string result = String.Format("{0}: {1}\n{2}: {3}\nРасстояние: {4}\n\nМетрика: {5}",
                    txt1, sd1, txt2, sd2, met, metric.type);
                MessageBox.Show(result, "Расстояние между строками");
            }
            catch
            {
                MessageBox.Show("Строки должны иметь одинаковую длину.", "Ошибка!");
            }
        }
    }
}
