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
        static List<Glass> gls = new List<Glass>();

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
            Glass temp = new Glass(name, col_name);
            gls.Add(temp);
            clr.Remove(col_name);
        } 
        public void generate_class(int count=1)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                string name = "Класс " + gls.Count;                
                string color = clr[rnd.Next(0, clr.Count - 1)];
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
            foreach (Glass g in gls)
            {
                g.RemoveAll();
                foreach (Dot d in Dots)
                {
                    if (d.class_name == g.name)
                    {
                        g.Add(d);
                        if (d.clr_name != g.clr_name)
                            d.clr_name = g.clr_name;
                    }
                        
                }
            }

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
                foreach(Dot d in Dots)
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
                    d.mean = d.Evklid(Dots[dots_list.SelectedIndex]);

                Dots = Dots.OrderBy(d => d.class_name == "none").ThenBy(d => d.mean).ToList();



                dots_list.DataSource = null;
                dots_list.Items.Clear();
                dots_list.DataSource = Dots;
            }
            catch { }            
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            CopyDots(Dots, old_Dots);
           
            int k=0;
            if (int.TryParse(neighbours.Text, out k)|| c_knn.Checked||cw_knn.Checked)
            {
                foreach (Dot d in Dots)
                    d.expectation = 0;
                if (def_knn.Checked) Dot.knn(Dots, k);
                else if (w_knn.Checked) Dot.knn(Dots, k, 1.0);
                else if (c_knn.Checked) Dot.knn(Dots, gls);
                else if (cw_knn.Checked) Dot.knn(Dots, gls, 1.0);
                 
                RefreshAll();
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            logBox.Clear();
            foreach (Dot d in Dots)
                AppendText(logBox, d.ToString(), Color.FromName(d.clr_name));
            string avg_prediction = "Средняя точность результатов классификации: "+Dot.average_predict(Dots)*100+"%";
            AppendText(logBox, avg_prediction, Color.FromName("White"));
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
            foreach (Glass g in gls)
            {
                g.RemoveAll();
            }
            RefreshAll();            
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            CopyDots(old_Dots, Dots);
            foreach (Glass g in gls)
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
        private void CopyDots(List<Dot> from, List<Dot> to)
        {
            to.Clear();
            foreach(Dot d in from)
            {
                Dot d2 = new Dot(d.prms);
                d2.name = d.name;
                d2.mean = d.mean;
                d2.class_name = d.class_name;
                d2.clr_name = d.clr_name;
                to.Add(d2);
            }
        }
        private void get_centers()
        {            
            class_centers.Clear();
            foreach (Glass dot_class in gls)
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
            CopyDots(Dots, old_Dots);
            Dot.Generate(Dots, 2, (int)numKlasters.Value, (int)numElements.Value, 300, gls[classes.SelectedIndex].name);
            
            RefreshAll();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                CopyDots(Dots, old_Dots);

                Fill_clr(clr);

                List<Dot> centers = new List<Dot>();

                Glass none = gls[0];
                gls.Clear();
                gls.Add(none);

                generate_class(Convert.ToInt32(klasters.Text));

                Dot.Generate(centers, 2, gls.Count - 1, 1, 300, "none", 0);
                for (int i = 0; i < gls.Count - 1; i++)
                {
                    centers[i].class_name = gls[i + 1].name;
                    centers[i].clr_name = gls[i + 1].clr_name;
                }

                Dot.kmeans(Dots, centers);
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
                CopyDots(Dots, old_Dots);
                
                Fill_clr(clr);

                List<Dot> centers = new List<Dot>();

                if (gls.Count()-1== Convert.ToInt32(klasters.Text)&&gls[0].Count()==0)
                {
                    centers.AddRange(class_centers);
                }
                else
                {
                    Glass none = gls[0];
                    gls.Clear();
                    gls.Add(none);

                    generate_class(Convert.ToInt32(klasters.Text));
                    
                    Dot.Generate(centers, 2, gls.Count - 1, 1, 300, "none", 0);
                    for (int i = 0; i < gls.Count - 1; i++)
                    {
                        centers[i].class_name = gls[i + 1].name;
                        centers[i].clr_name = gls[i + 1].clr_name;
                    }
                }
                
                Dot.kmeans_debug(Dots, centers);
                class_centers.Clear();
                class_centers.AddRange(centers);
                RefreshAll();
            }
            catch { }
        }

    }
}
