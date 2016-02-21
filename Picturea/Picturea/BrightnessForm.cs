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
    public partial class BrightnessForm : Form
    {
        private Form1 form;
        private PLL.Effects effects;

        public BrightnessForm(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            trackBar_Brightness.ValueChanged += TrackBar_ValueChanged;
            trackBar_Contrast.ValueChanged += TrackBar_ValueChanged;

            effects = new PLL.Effects();
        }

        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            textBox_Brightness.Text = trackBar_Brightness.Value.ToString();
            textBox_Contrast.Text = trackBar_Contrast.Value.ToString();
            if (Layers.CurrentLayer != null)
            {
                effects.BrightnessNContrast(trackBar_Brightness.Value, trackBar_Contrast.Value);
                form.pictureBox.Refresh();
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
