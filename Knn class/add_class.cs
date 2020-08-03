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
    public partial class add_class : Form
    {

        public add_class()
        {
            InitializeComponent();
            clr_Box.DrawItem+= new DrawItemEventHandler(ColorComboBox_DrawItem);
            clr_Box.DataSource = Main.clr;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cls_name.Text) && clr_Box.SelectedIndex > 0)
            {
                Main.add_class(cls_name.Text, clr_Box.SelectedItem.ToString());
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
            } 
        }
        private void ColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox combo;
            try
            {
                e.DrawBackground();
                combo = (ComboBox)sender;
                if (e.Index >= 0)
                {
                    Brush brush = new SolidBrush(Color.FromName(Main.clr[e.Index]));
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawString(Main.clr[e.Index], combo.Font, brush, e.Bounds.X, e.Bounds.Y);
                }
        }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
}
    }
}
