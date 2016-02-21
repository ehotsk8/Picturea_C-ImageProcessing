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
    public partial class BinarizationForm : Form
    {
        private Form1 form;
        private PLL.Effects effects;
        private Histogramm h;

        public BinarizationForm(Form1 form)
        {
            InitializeComponent();
            this.form = form;

            if (Layers.CurrentLayer != null)
            {
                effects = new PLL.Effects(Layers.CurrentLayer.Foreground);

                effects.Binarization(trackBar1.Value);
                form.pictureBox.Refresh();

                value_textBox.Text = trackBar1.Value.ToString();
                form.pictureBox.Refresh();

                h = new Histogramm(Layers.CurrentLayer.Foreground);
                chart_Histogram.Series[0].Points.DataBindY(h.GetHistogramm(HistogramType.Brightness));
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (Layers.CurrentLayer != null)
            {
                effects.Binarization(trackBar1.Value);
                form.pictureBox.Refresh();

                chart_Histogram.Series[0].Points.Clear();
                chart_Histogram.Series[0].Points.DataBindY(h.GetHistogramm(HistogramType.Brightness));
            }
            value_textBox.Text = trackBar1.Value.ToString();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
