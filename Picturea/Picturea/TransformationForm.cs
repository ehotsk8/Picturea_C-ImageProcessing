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
    public partial class TransformationForm : Form
    {
        private Form1 form;
        private PLL.ITransform transforms;

        private delegate void TransformMethod(int Width, int Height, int offsetX, int offsetY, int angle);

        public TransformationForm(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            rotate_trackBar.Scroll += trackBar_ValueChanged;
            trackBar_W.Scroll += trackBar_ValueChanged;
            trackBar_H.Scroll += trackBar_ValueChanged;
            trackBar_Y.Scroll += trackBar_ValueChanged;
            trackBar_X.Scroll += trackBar_ValueChanged;

            trackBar_W.Maximum = form.pictureBox.Width * 2;
            trackBar_W.Value = form.pictureBox.Width;
            trackBar_X.Maximum = form.pictureBox.Width;
            trackBar_X.Minimum = -form.pictureBox.Width;

            trackBar_H.Maximum = form.pictureBox.Height * 2;
            trackBar_H.Value = form.pictureBox.Height;
            trackBar_Y.Maximum = form.pictureBox.Height;
            trackBar_Y.Minimum = -form.pictureBox.Height;

            transforms = new PLL.FreeTransform(Layers.CurrentLayer.Foreground);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            value_textBox.Text = rotate_trackBar.Value.ToString();

            if (radioButton1.Checked)
            {
                Changes(transforms.Transform);
            }
            if (radioButton2.Checked)
            {
                Changes(transforms.LinearInterpolationTransform);
            }
            if (radioButton3.Checked)
            {
                Changes(transforms.BilinearInterpolationTransform);
            }
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

        private void Changes(TransformMethod transform)
        {
            transform(trackBar_W.Value, trackBar_H.Value, trackBar_Y.Value, trackBar_X.Value, rotate_trackBar.Value);

            form.pictureBox.Refresh();

            if (!changes_checkBox.Checked)
            {
                Layers.CurrentLayer.Foreground.ApplyChangesTransform();
                form.pictureBox.Image = Layers.CurrentLayer.Foreground.EditImage;
                form.PreviewSizeChange();
            }
        }

        private void changes_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (changes_checkBox.Checked)
            {
                Layers.CurrentLayer.Foreground = new Picture(History.HistoryList[History.HistoryList.Count - 1].Picture.OriginalImage);
                form.SomeEvent();
                transforms = new PLL.FreeTransform(Layers.CurrentLayer.Foreground);
                Changes(transforms.Transform);
            }
            if (!changes_checkBox.Checked)
            {
                Layers.CurrentLayer.Foreground = new Picture(History.HistoryList[History.HistoryList.Count - 1].Picture.OriginalImage);
                transforms = new PLL.Transforms(Layers.CurrentLayer.Foreground);
                Changes(transforms.Transform);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Changes(transforms.Transform);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Changes(transforms.LinearInterpolationTransform);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Changes(transforms.BilinearInterpolationTransform);
        }
    }
}
