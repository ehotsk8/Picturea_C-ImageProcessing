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
    public partial class HueSaturationForm : Form
    {
        private Form1 form;

        public HueSaturationForm(Form1 form)
        {
            InitializeComponent();
            this.form = form;

            trackBar1.ValueChanged += ValueChanged;
            trackBar2.ValueChanged += ValueChanged;
            trackBar3.ValueChanged += ValueChanged;

            trackBar2.Value = 50;
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            form.effects.RGB2HSV(trackBar1.Value, trackBar2.Value, trackBar3.Value);
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
