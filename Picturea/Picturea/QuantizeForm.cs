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
    public partial class QuantizeForm : Form
    {
        public QuantizeForm()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                new PLL.MedianCutQuantizer(Layers.CurrentLayer.Foreground).Quantize(int.Parse(quantSize_textBox.Text));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
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