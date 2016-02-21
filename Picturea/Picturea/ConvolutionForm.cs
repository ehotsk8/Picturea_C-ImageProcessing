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
    public partial class ConvolutionForm : Form
    {
        private Form1 form;
        private static double[] Matrix = { 0,0,0,0,0,
                             0,0,0,0,0,
                             0,0,1,0,0,
                             0,0,0,0,0,
                             0,0,0,0,0, };

        public ConvolutionForm(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            button_OK.DialogResult = DialogResult.OK;
            button_Cancel.DialogResult = DialogResult.Cancel;
            pictureBox1.Image = Layers.CurrentLayer.Foreground.EditImage;

            foreach (var control in groupBox1.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).TextChanged += Changed;
                }
            }
            view_checkBox.CheckedChanged += Changed;
            checkBox1.CheckedChanged += Changed;
            massh_textBox.TextChanged += Changed;
            offset_textBox.TextChanged += Changed;
        }

        private void Changed(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (var control in this.groupBox1.Controls)
                {
                    if (control is TextBox)
                    {
                        Matrix[i++] = double.Parse((control as TextBox).Text);
                    }
                }
                if (checkBox1.Checked)
                    form.effects.Convolution(Matrix, int.Parse(offset_textBox.Text), 5);
                else
                    form.effects.Convolution(Matrix, int.Parse(offset_textBox.Text), 5, int.Parse(massh_textBox.Text));

                if (view_checkBox.Checked)
                    pictureBox1.Refresh();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
