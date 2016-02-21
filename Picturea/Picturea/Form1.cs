using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;

using PLL;

namespace Picturea
{
    public partial class Form1 : Form
    {
        public Effects effects { get; set; }
        public bool isBlack { get; set; }

        private RGB Black, White;
        private ColorChannelType selectedColor = ColorChannelType.RGB;

        private BlendModes modes;
        private History history;
        private Layers layers;

        private delegate void Filter();

        public Form1()
        {
            InitializeComponent();
            Open_toolStripButton.Click += open_MenuItem_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            blendModes_comboBox.SelectedIndex = 0;
        }

        private void open_MenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox.Visible = true;
            Bitmap image = null;

            string format = Path.GetExtension(openFileDialog.FileName);

            if (format == ".pll")
            {
                var file = PllFileFormat.Load(openFileDialog.FileName);
                image = new Bitmap(file.Image);
            }

            if (format != ".pll")
            {
                image = new Bitmap(openFileDialog.FileName);
            }

            var pic1 = new Picture(image);
            var transparentBitmap = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
            transparentBitmap.MakeTransparent();
            var pic2 = new Picture(transparentBitmap);

            Layer layer = new Layer("Слой 0", pic1, pic2);

            layers = new Layers(layer);
            layers.SomeEvent += SomeEvent;

            history = new History();
            history.SomeEvent += SomeEvent;
            history.Add("Открыть");
        }

        private void exit_MenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_toolStripButton_Click(object sender, EventArgs e)
        {
            save_MenuItem_Click(this, new EventArgs());
        }

        private void SaveAs_toolStripButton_Click(object sender, EventArgs e)
        {
            saveAs_MenuItem_Click(this, new EventArgs());
        }

        private void saveAs_MenuItem_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (Layers.CurrentLayer != null)
                {
                    Bitmap image = (Bitmap)Layers.CurrentLayer.Foreground.EditImage.Clone();

                    ImageFormat format = null;

                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            var pll = new PllFileFormat(Environment.UserName,
                                Layers.CurrentLayer.Foreground.EditImage);
                            PllFileFormat.Save(saveFileDialog.FileName, pll);
                            break;
                        case 2:
                            format = ImageFormat.Jpeg;
                            break;
                        case 3:
                            format = ImageFormat.Bmp;
                            break;
                        case 4:
                            format = ImageFormat.Tiff;
                            break;
                        default:
                            return;
                    }

                    try
                    {
                        if (saveFileDialog.FilterIndex != 1)
                            image.Save(saveFileDialog.FileName, format);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Изображение без изменений нельзя сохранить");
                    }
                }
            }
        }

        private void save_MenuItem_Click(object sender, EventArgs e)
        {
            string format = Path.GetExtension(openFileDialog.FileName);

            if (format != ".pll")
            {
                if (Layers.CurrentLayer != null)
                    Layers.CurrentLayer.Foreground.EditImage.Save(openFileDialog.FileName);
            }
            else
            {
                var pll = new PllFileFormat(Environment.UserName,
                                   Layers.CurrentLayer.Foreground.EditImage);
                PllFileFormat.Save(openFileDialog.FileName, pll);
            }
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            rgb_StatusLabel1.Text = "Пиксель:";
        }

        private void button_ScrollMinus_Click(object sender, EventArgs e)
        {
            size_numericUpDown.Value -= 10;
            PreviewSizeChange();
        }

        private void button_ScrollPlus_Click(object sender, EventArgs e)
        {
            size_numericUpDown.Value += 10;
            PreviewSizeChange();
        }

        private void size_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            PreviewSizeChange();
        }

        public void PreviewSizeChange()
        {
            if (pictureBox != null)
            {
                int PreviewSize = (int)size_numericUpDown.Value;
                pictureBox.Width = (int)(pictureBox.Image.Width * PreviewSize / 100);
                pictureBox.Height = (int)(pictureBox.Image.Height * PreviewSize / 100);
                pictureBox.Location = new Point(viewportPanel.Width / 2 - pictureBox.Width / 2,
                        viewportPanel.Height / 2 - pictureBox.Height / 2);
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Layers.CurrentLayer != null)
            {
                double w = (double)pictureBox.Width / (double)Layers.CurrentLayer.Foreground.EditImage.Width;
                double h = (double)pictureBox.Height / (double)Layers.CurrentLayer.Foreground.EditImage.Height;
                rgb_StatusLabel1.Text = String.Format("Пиксель: {0}, {1}; {2}",
                    (int)(e.X / w), (int)(e.Y / h), effects.GetPixel((int)(e.X / w), (int)(e.Y / h)));
            }
        }

        private void history_listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (history_listView.SelectedIndices.Count > 0)
            {
                History.CurrentId = history_listView.SelectedIndices[0];
                Layers.CurrentLayer = new Layer("Слой 0",
                    new Picture(History.HistoryList[History.CurrentId].Picture.EditImage), Layers.CurrentLayer.Background);

                Histogramm h = new Histogramm(Layers.CurrentLayer.Foreground);
                histogramm_chart.Series[0].Points.DataBindY(h.GetHistogramm(HistogramType.Brightness));
                RefreshColorChanelsView();

                effects = new Effects(Layers.CurrentLayer.Foreground);
                pictureBox.Image = Layers.CurrentLayer.Foreground.EditImage;
                PreviewSizeChange();
            }
        }

        public void SomeEvent()
        {
            effects = new Effects();
            modes = new BlendModes(Layers.CurrentLayer);
            pictureBox.Image = Layers.CurrentLayer.Foreground.EditImage;
            PreviewSizeChange();

            layers_imageList.Images.Clear();
            layers_listView.Items.Clear();

            for (int i = 0; i < layers.LayersArray.Length; i++)
            {
                layers_imageList.Images.Add(layers.LayersArray[i].Foreground.EditImage);
                layers_listView.Items.Add(layers.LayersArray[i].Name);
                layers_listView.Items[i].ImageIndex = i;
            }

            history_imageList.Images.Clear();
            history_listView.Items.Clear();
            for (int i = 0; i < History.HistoryList.Count; i++)
            {
                history_imageList.Images.Add(History.HistoryList[i].Picture.EditImage);
                history_listView.Items.Add(History.HistoryList[i].Action);
                history_listView.Items[i].ImageIndex = i;
            }

            Histogramm h = new Histogramm(Layers.CurrentLayer.Foreground);
            histogramm_chart.Series[0].Points.DataBindY(h.GetHistogramm(HistogramType.Brightness));

            RefreshColorChanelsView();
        }

        public void ChangeCurrentPicture()
        {
            if (History.HistoryList.Count > 1)
            {
                Layers.CurrentLayer = new Layer("Слой 0",
                    new Picture(History.HistoryList[History.CurrentId - 1].Picture.EditImage), Layers.CurrentLayer.Background);

                Histogramm h = new Histogramm(Layers.CurrentLayer.Foreground);
                histogramm_chart.Series[0].Points.DataBindY(h.GetHistogramm(HistogramType.Brightness));
                RefreshColorChanelsView();

                effects = new Effects(Layers.CurrentLayer.Foreground);
                pictureBox.Image = Layers.CurrentLayer.Foreground.EditImage;
                PreviewSizeChange();
            }
        }

        private void undo_MenuItem_Click(object sender, EventArgs e)
        {
            history.Undo();
            ChangeCurrentPicture();
        }

        private void redo_MenuItem_Click(object sender, EventArgs e)
        {
            history.Redo();
            ChangeCurrentPicture();
        }

        private void addLayer_toolStripButton_Click(object sender, EventArgs e)
        {
            importFileDialog1.ShowDialog();
        }

        private void importFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var loadImage = new Bitmap(importFileDialog1.FileName);
            PLL.Layer layer = new Layer("Слой " + layers.LayersArray.Length,
                new Picture(new Bitmap(loadImage,
                Layers.CurrentLayer.Foreground.EditImage.Width, Layers.CurrentLayer.Foreground.EditImage.Height)),
              layers.LayersArray[layers.LayersArray.Length - 1].Foreground);

            layers.AddLayer(layer);
        }

        private void layers_listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (layers_listView.SelectedItems.Count > 0)
            {
                Layers.CurrentLayer = layers.GetLayerByName(layers_listView.SelectedItems[0].Text);

                alpha_numericUpDown.ValueChanged -= alpha_numericUpDown_ValueChanged;
                alpha_numericUpDown.Value = (int)(Layers.CurrentLayer.Transparence * 100);
                alpha_numericUpDown.ValueChanged += alpha_numericUpDown_ValueChanged;

                effects = new PLL.Effects(Layers.CurrentLayer.Foreground);
                modes = new BlendModes(Layers.CurrentLayer);

                pictureBox.Image = layers.LayersArray[layers.LayersArray.Length - 1].Foreground.EditImage;
                PreviewSizeChange();
            }
        }

        private void RefreshColorChanelsView()
        {
            if (layers != null)
            {
                ColorChannelChange();

                colors_imageList.Images.Clear();

                for (int i = 0; i < 4; i++)
                {
                    Layers.CurrentLayer.Foreground = new Picture(Layers.CurrentLayer.Foreground.OriginalImage);
                    effects = new Effects();
                    effects.ChangeColorChannel((ColorChannelType)i);
                    colors_imageList.Images.Add(Layers.CurrentLayer.Foreground.EditImage);
                }

                for (int i = 3; i >= 0; i--)
                    colors_listView.Items[i].ImageIndex = Math.Abs(i - 3);

                Layers.CurrentLayer.Foreground = new Picture(Layers.CurrentLayer.Foreground.OriginalImage);
                effects = new Effects();

                colors_listView.Refresh();

                pictureBox.Image = Layers.CurrentLayer.Foreground.EditImage;
            }
        }

        private void colors_listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Layers.CurrentLayer != null)
            {
                if (colors_listView.SelectedItems.Count != 0)
                {
                    Layers.CurrentLayer.Foreground = new Picture(Layers.CurrentLayer.Foreground.OriginalImage);
                    effects = new Effects();

                    switch (colors_listView.SelectedIndices[0])
                    {
                        case 0:
                            selectedColor = ColorChannelType.RGB;
                            break;
                        case 1:
                            selectedColor = ColorChannelType.R;
                            break;
                        case 2:
                            selectedColor = ColorChannelType.G;
                            break;
                        case 3:
                            selectedColor = ColorChannelType.B;
                            break;
                    }
                    effects.ChangeColorChannel(selectedColor);

                    effects = new Effects();
                    pictureBox.Image = Layers.CurrentLayer.Foreground.EditImage;
                }
            }
        }

        private void blendModes_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (modes != null)
            {
                switch ((string)blendModes_comboBox.SelectedItem)
                {
                    case "Обычный":
                        modes.Normal();
                        break;
                    case "Разница":
                        modes.Difference();
                        break;
                    case "Исключение":
                        modes.Exclusion();
                        break;
                }
                pictureBox.Refresh();
            }
        }

        private void alpha_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Layers.CurrentLayer.Transparence = (double)alpha_numericUpDown.Value * 0.01;
            modes.Transparence();
            pictureBox.Refresh();
        }

        private void ColorChannelChange()
        {
            if (selectedColor != ColorChannelType.RGB)
            {
                effects.MergeColorChannel(selectedColor);
                selectedColor = ColorChannelType.RGB;
            }
            effects = new Effects();
            Layers.CurrentLayer.Foreground = new Picture(Layers.CurrentLayer.Foreground.EditImage);
            pictureBox.Image = Layers.CurrentLayer.Foreground.EditImage;
            pictureBox.Refresh();
        }

        private void ApplyFormResult(string ActionName, DialogResult Result)
        {
            if (Result == DialogResult.OK)
            {
                ColorChannelChange();
                history.Add(ActionName);
            }
            else if (Result == DialogResult.Cancel)
                Layers.CurrentLayer = new Layer("Слой 0",
                       new Picture(History.HistoryList[History.HistoryList.Count - 1].Picture.EditImage), Layers.CurrentLayer.Background);
            SomeEvent();
        }

        private void ApplyFilterResult(string ActionName, Filter filter)
        {
            filter();
            ColorChannelChange();
            history.Add(ActionName);
        }

        private void transform_MenuItem_Click(object sender, EventArgs e)
        {
            ApplyFormResult("Трансформация", new TransformationForm(this).ShowDialog());
        }

        private void brightnessNContrast_MenuItem_Click(object sender, EventArgs e)
        {
            ApplyFormResult("Яркость/Контрастность", new BrightnessForm(this).ShowDialog());
        }

        private void binarize_MenuItem_Click(object sender, EventArgs e)
        {
            ApplyFormResult("Бинаризация", new BinarizationForm(this).ShowDialog());
        }

        private void grayScale_MenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilterResult("Черно белый", effects.GrayScale);
        }

        private void invert_MenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilterResult("Инверсия", effects.Invert);
        }

        private void quantize_MenuItem_Click(object sender, EventArgs e)
        {
            ApplyFormResult("Палитра", new QuantizeForm().ShowDialog());
        }

        private void convolution_MenuItem_Click(object sender, EventArgs e)
        {
            ApplyFormResult("Матрица свертки", new ConvolutionForm(this).ShowDialog());
        }

        private void curve_MenuItem_Click(object sender, EventArgs e)
        {
            new CurveForm(this).Show();
            //var r = new CurveForm(this).ShowDialog();

            //if (r == DialogResult.OK)
            //{
            //    ColorChannelChange();
            //    history.Add("Кривая");
            //}
            //else if (r == DialogResult.Cancel)
            //    Layers.CurrentLayer = new Layer("Слой 0",
            //           new Picture(History.HistoryList[History.HistoryList.Count - 1].Picture.EditImage), Layers.CurrentLayer.Background);
            //SomeEvent();
        }

        private void hueSaturation_MenuItem_Click(object sender, EventArgs e)
        {
            ApplyFormResult("HSV", new HueSaturationForm(this).ShowDialog());
        }

        private void Medianer_MenuItem_Click(object sender, EventArgs e)
        {
            ApplyFormResult("Медианер", new MedianForm(this).ShowDialog());
        }

        private void ColorOverlay_MenuItem_Click(object sender, EventArgs e)
        {
            ApplyFormResult("Наложение цвета", new ColorOverlayForm(this).ShowDialog());
        }

        private void normalBlur_MenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilterResult("Нормальное размытие", effects.NormalBlur);
        }

        private void gaussian_MenuItem_Click(object sender, EventArgs e)
        {
            ApplyFormResult("Размытие по Гауссу", new GaussianForm(this).ShowDialog());
        }

        private void gamma_MenuItem_Click(object sender, EventArgs e)
        {
            effects.GammaCorrection(2);
            Layers.CurrentLayer.Foreground.ApplyChanges();
            pictureBox.Refresh();
            history.Add("Гамма коррекция");
        }

        private void sCorrect_MenuItem_Click(object sender, EventArgs e)
        {
            effects.SCorrection(2);
            Layers.CurrentLayer.Foreground.ApplyChanges();
            pictureBox.Refresh();
            history.Add("S коррекция");
        }

        private void laplasian_MenuItem_Click(object sender, EventArgs e)
        {
            effects.Laplacian(1);
            Layers.CurrentLayer.Foreground.ApplyChanges();
            pictureBox.Refresh();
            history.Add("Усиление границ по Лапласу");
        }

        private void laplasianOfGaussianMenuItem_Click(object sender, EventArgs e)
        {
            effects.Gaussian(1);
            Layers.CurrentLayer.Foreground.ApplyChanges();
            effects = new Effects();
            effects.Laplacian(1);
            Layers.CurrentLayer.Foreground.ApplyChanges();
            pictureBox.Refresh();
            history.Add("Усиление границ по Гаусу с Лапласом");
        }

        private void transforms_toolStripButton_Click(object sender, EventArgs e)
        {
            ApplyFormResult("Трансформация", new TransformationForm(this).ShowDialog());
        }

        private void curv_toolStripButton_Click(object sender, EventArgs e)
        {
            curve_MenuItem_Click(sender, e);
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Layers.CurrentLayer != null)
            {
                double w = (double)pictureBox.Width / (double)Layers.CurrentLayer.Foreground.EditImage.Width;
                double h = (double)pictureBox.Height / (double)Layers.CurrentLayer.Foreground.EditImage.Height;

                if (isBlack)
                    Black = effects.GetPixel((int)(e.X / w), (int)(e.Y / h));
                else
                    White = effects.GetPixel((int)(e.X / w), (int)(e.Y / h));

                if (White != null && Black != null)
                {
                    effects.PointBlackNWhite(Black, White);

                    Layers.CurrentLayer.Foreground.ApplyChanges();
                    pictureBox.Refresh();
                    Black = White = null;
                    history.Add("Точка черного и белого");
                }
            }
        }
    }
}
