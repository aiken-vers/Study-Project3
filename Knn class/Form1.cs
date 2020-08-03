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
    public partial class Form1 : Form
    {
        Point lastPoint = Point.Empty;

        public Form1()
        {
            InitializeComponent();
            classes.Items.Clear();
            classes.Items.Add("зеленый");
           
            pictureBox1.Image = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            

        }



        //private void PictureBox1_Click(object sender, MouseEventArgs e)
        //{
        //    Dot.Dlist.Add(new Dot(e.X, e.Y));
        //    lastPoint = e.Location;
        //    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        //    pictureBox1.Image = bmp;
        //    using (Graphics g = Graphics.FromImage(pictureBox1.Image))

        //    {//we need to create a Graphics object to draw on the picture box, its our main tool

        //        //when making a Pen object, you can just give it color only or give it color and pen size

        //        g.Draw
        //        g.DrawLine(new Pen(Color.Black, 2), lastPoint, e.Location);

        //        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        //        //this is to give the drawing a more smoother, less sharper look

        //    }

        //    pictureBox1.Invalidate();//refreshes the picturebox
        //    pictureBox1.Paint
        //}

        MyPoints myPoints = new MyPoints();

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //Use default property values
            //myPoints.Add(new MyPoints.DrawingPoint(e.Location));

            MyPoints.DrawingPoint newPoint = new MyPoints.DrawingPoint();
            newPoint.Dot = new Rectangle(e.Location, new Size(4, 4));
            newPoint.DrawingPen = new Pen(Color.Red, 2);
            myPoints.DrawingPoints.Add(newPoint);
            ((Control)sender).Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (MyPoints.DrawingPoint mypoint in myPoints.DrawingPoints)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawEllipse(mypoint.DrawingPen, mypoint.Dot);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myPoints.Dispose();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                    ColorComboBox.Items.Add(prop.Name);
            }
        }

        private void ColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5,
                                rect.Width - 10, rect.Height - 10);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {            

            Bitmap b = (Bitmap)pictureBox1.Image;
            //if (b != null)
            //{
            for(int i=50;i<=70;i++)
                for(int j=50;j<=99; j++)
                    b.SetPixel(Convert.ToInt32(i), Convert.ToInt32(j), Color.Blue);

            pictureBox1.Refresh();
            //}
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            
            Image i = pictureBox1.Image;
            using (Graphics g = Graphics.FromImage(i))
            {
                SolidBrush b = new SolidBrush(Color.DarkOrange);
                g.FillEllipse(b, new Rectangle(coordinates.X, coordinates.Y, 10, 10));
            }

            pictureBox1.Refresh();
        }

        
    }
}
