using PLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picturea
{
    public partial class ColorOverlayForm : Form
    {
        private Form1 form;
        private RGB color;

        public ColorOverlayForm(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            color = new RGB(0, 0, 0);
            form.effects.ColorOverlay(color, Math.Abs(opacity_trackBar.Value) * 0.01);
            form.pictureBox.Refresh();
        }

        private void panelColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                color = new RGB(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                panelColor.BackColor = Color.FromArgb(color.R, color.G, color.B);
                form.effects.ColorOverlay(color, Math.Abs(opacity_trackBar.Value) * 0.01);
                form.pictureBox.Refresh();
            }
        }

        private void opacity_trackBar_ValueChanged(object sender, EventArgs e)
        {
            form.effects.ColorOverlay(color, Math.Abs(opacity_trackBar.Value) * 0.01);
            form.pictureBox.Refresh();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
