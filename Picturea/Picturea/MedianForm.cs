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
    public partial class MedianForm : Form
    {
        private Form1 form;

        public MedianForm(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (Layers.CurrentLayer != null)
            {
                form.effects.Medianer(trackBar1.Value);
                form.pictureBox.Refresh();
            }
            Close();
            Dispose();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {

            Close();
            Dispose();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                trackBar1.Value = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
