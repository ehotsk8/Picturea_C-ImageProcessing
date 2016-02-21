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
    public partial class CurveForm : Form
    {
        private Form1 form;

        private List<Point> points = new List<Point>();

        public CurveForm(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void whiteP_button_Click(object sender, EventArgs e)
        {
            form.isBlack = false;
        }

        private void blackP_button_Click(object sender, EventArgs e)
        {
            form.isBlack = true;
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void remove_button_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }


        private void apply_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                points.Add(new Point(int.Parse((string)dataGridView1.Rows[i].Cells[0].Value),
                    int.Parse((string)dataGridView1.Rows[i].Cells[1].Value)));
            }
            var c = new CurvesEdit(Layers.CurrentLayer.Foreground);
            c.setCorrect(points.ToArray());
            Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
