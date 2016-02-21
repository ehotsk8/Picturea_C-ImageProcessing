using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLL
{
    /// <summary>
    /// Класс эффектов
    /// </summary>
    public unsafe class Effects
    {
        private static int i, j, someIntValue, someIntValue2, someIntValue3, width, height, stride, mX, mY;
        private static double someDoubleValue, r, g, b;

        private static int PixelsCount;
        private static int PixelsCountWithChannels;
        private static int Channels;

        private static byte* Pixels;
        private static byte* PixelsBuffer;

        private Picture picture;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        public Effects(Picture picture)
        {
            this.picture = picture;
            width = picture.EditImage.Width;
            height = picture.EditImage.Height;
            stride = picture.Stride;

            Pixels = picture.Pixels;
            PixelsBuffer = picture.PixelsBuffer;

            Channels = picture.Channels;
            PixelsCountWithChannels = picture.PixelsCountWithChannels;
            PixelsCount = picture.PixelsCount;
        }

        public Effects()
        {
            if (Layers.CurrentLayer != null)
            {
                this.picture = Layers.CurrentLayer.Foreground;
                width = picture.EditImage.Width;
                height = picture.EditImage.Height;
                stride = picture.Stride;

                Pixels = picture.Pixels;
                PixelsBuffer = picture.PixelsBuffer;

                Channels = picture.Channels;
                PixelsCountWithChannels = picture.PixelsCountWithChannels;
                PixelsCount = picture.PixelsCount;
            }
        }

        /// <summary>
        /// Получение RGB по координатам.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public RGB GetPixel(int x, int y)
        {
            int i = y * stride + x * 4;
            return new RGB(PixelsBuffer[i + 2], PixelsBuffer[i + 1], PixelsBuffer[i]);
        }

        /// <summary>
        /// Точка белого и черного.
        /// </summary>
        public void PointBlackNWhite(RGB black, RGB white)
        {
            byte r2 = white.R, g2 = white.G, b2 = white.B;
            r = black.R; g = black.G; b = black.B;

            for (i = 0; i < PixelsCount; i++)
            {
                if (r > Pixels[2])
                    Pixels[2] = 0;
                if (g > Pixels[1])
                    Pixels[1] = 0;
                if (b > Pixels[0])
                    Pixels[0] = 0;

                if (Pixels[2] > r2)
                    Pixels[2] = 255;
                if (Pixels[1] > g2)
                    Pixels[1] = 255;
                if (Pixels[0] > b2)
                    Pixels[0] = 255;

                Pixels += Channels;
            }
            Pixels -= PixelsCountWithChannels;
        }

        /// <summary>
        /// S - коррекция.
        /// </summary>
        /// <param name="s"></param>
        public void SCorrection(double s)
        {
            s = 1 / s;

            someDoubleValue = (100 + 50) / 100.0;
            someDoubleValue *= someDoubleValue;

            for (i = 0; i < PixelsCount; i++)
            {
                someIntValue = (int)(someDoubleValue * (Pixels[0] - 128) + 128);
                if (someIntValue > 255) someIntValue = 255;
                if (someIntValue < 0) someIntValue = 0;

                Pixels[0] = (byte)(255 * (Math.Pow((double)someIntValue / (double)255, s)));
                someIntValue = (int)(someDoubleValue * (Pixels[1] - 128) + 128);
                if (someIntValue > 255) someIntValue = 255;
                if (someIntValue < 0) someIntValue = 0;

                Pixels[1] = (byte)(255 * (Math.Pow((double)someIntValue / (double)255, s)));
                someIntValue = (int)(someDoubleValue * (Pixels[2] - 128) + 128);
                if (someIntValue > 255) someIntValue = 255;
                if (someIntValue < 0) someIntValue = 0;

                Pixels[2] = (byte)(255 * (Math.Pow((double)someIntValue / (double)255, s)));
                Pixels += Channels;
            }
            Pixels -= PixelsCountWithChannels;
        }

        /// <summary>
        /// Гамма коррекция.
        /// </summary>
        /// <param name="gamma"></param>
        public void GammaCorrection(double gamma)
        {
            for (i = 0; i < PixelsCount; i++)
            {
                Pixels[0] = (byte)(255 * (Math.Pow((double)Pixels[0] / (double)255, gamma)));
                Pixels[1] = (byte)(255 * (Math.Pow((double)Pixels[1] / (double)255, gamma)));
                Pixels[2] = (byte)(255 * (Math.Pow((double)Pixels[2] / (double)255, gamma)));

                Pixels += Channels;
            }
            Pixels -= PixelsCountWithChannels;
        }

        /// <summary>
        /// По кривой.
        /// </summary>
        /// <param name="gamma"></param>
        public void CurveCorrection(RGB white)
        {
            r = white.R;
            g = white.G;
            b = white.B;
            for (i = 0; i < PixelsCount; i++)
            {
                //Pixels[0] = (byte)(255 * (Math.Pow((double)Pixels[0] / (double)255, 1 / gamma / (double)255)));
                //Pixels[1] = (byte)(255 * (Math.Pow((double)Pixels[1] / (double)255, 1 / gamma / (double)255)));
                //Pixels[2] = (byte)(255 * (Math.Pow((double)Pixels[2] / (double)255, 1 / gamma / (double)255)));
                someDoubleValue = (Math.Pow((double)PixelsBuffer[0], (double)255 / b));
                if (someDoubleValue > 255) someDoubleValue = 255;
                if (someDoubleValue < 0) someDoubleValue = 0;
                Pixels[0] = (byte)(someDoubleValue);
                someDoubleValue = (Math.Pow((double)PixelsBuffer[1], (double)255 / g));
                if (someDoubleValue > 255) someDoubleValue = 255;
                if (someDoubleValue < 0) someDoubleValue = 0;
                Pixels[1] = (byte)(someDoubleValue);
                someDoubleValue = (Math.Pow((double)PixelsBuffer[2], (double)255 / r));
                if (someDoubleValue > 255) someDoubleValue = 255;
                if (someDoubleValue < 0) someDoubleValue = 0;
                Pixels[2] = (byte)(someDoubleValue);
                Pixels += Channels;
                PixelsBuffer += Channels;
            }
            Pixels -= PixelsCountWithChannels;
            PixelsBuffer -= PixelsCountWithChannels;
        }

        public void CurveCorrection2(RGB black)
        {
            r = black.R;
            g = black.G;
            b = black.B;
            for (i = 0; i < PixelsCount; i++)
            {
                //Pixels[0] = (byte)(255 * (Math.Pow((double)Pixels[0] / (double)255, 1.0 / gamma / (double)255)));
                //Pixels[1] = (byte)(255 * (Math.Pow((double)Pixels[1] / (double)255, 1.0 / gamma / (double)255)));
                //Pixels[2] = (byte)(255 * (Math.Pow((double)Pixels[2] / (double)255, 1.0 / gamma / (double)255)));
                Pixels[0] = (byte)(255 * (Math.Pow((double)PixelsBuffer[0] / (double)255, (double)255 / b)));
                Pixels[1] = (byte)(255 * (Math.Pow((double)PixelsBuffer[1] / (double)255, (double)255 / g)));
                Pixels[2] = (byte)(255 * (Math.Pow((double)PixelsBuffer[2] / (double)255, (double)255 / r)));
                //someDoubleValue = (Math.Pow((double)Pixels[0], gamma / 255));
                //if (someDoubleValue > 255) someDoubleValue = 255;
                //if (someDoubleValue < 0) someDoubleValue = 0;
                //Pixels[0] = (byte)(someDoubleValue);
                //someDoubleValue = (Math.Pow((double)Pixels[1], gamma / 255));
                //if (someDoubleValue > 255) someDoubleValue = 255;
                //if (someDoubleValue < 0) someDoubleValue = 0;
                //Pixels[1] = (byte)(someDoubleValue);
                //someDoubleValue = (Math.Pow((double)Pixels[2], gamma / 255));
                //if (someDoubleValue > 255) someDoubleValue = 255;
                //if (someDoubleValue < 0) someDoubleValue = 0;
                //Pixels[2] = (byte)(someDoubleValue);
                Pixels += Channels;
                PixelsBuffer += Channels;
            }
            Pixels -= PixelsCountWithChannels;
            PixelsBuffer -= PixelsCountWithChannels;
        }

        /// <summary>
        /// Нормальное размытие.
        /// </summary>
        public void NormalBlur()
        {
            int sumR = 0, sumG = 0, sumB = 0;

            for (i = 0; i < PixelsCount; i++)
            {
                sumB += Pixels[0];
                sumG += Pixels[1];
                sumR += Pixels[2];

                Pixels += Channels;
            }
            Pixels -= PixelsCountWithChannels;

            sumB /= PixelsCount;
            sumG /= PixelsCount;
            sumR /= PixelsCount;

            for (i = 0; i < PixelsCount; i++)
            {
                Pixels[0] = (byte)sumB;
                Pixels[1] = (byte)sumG;
                Pixels[2] = (byte)sumR;

                Pixels += Channels;
            }
            Pixels -= PixelsCountWithChannels;
        }

        /// <summary>
        /// Медианер.
        /// </summary>
        public void Medianer(int radius)
        {
            int matrixSize = radius * 2 + 1;
            if ((double)radius % 2 == 0)
                matrixSize = radius * 2 + 1;
            radius *= radius;

            int center = matrixSize * matrixSize / 2 + 1;
            int MatrixOffset = (matrixSize - 1) / 2;

            byte[] R = new byte[matrixSize * matrixSize];
            byte[] G = new byte[matrixSize * matrixSize];
            byte[] B = new byte[matrixSize * matrixSize];

            for (i = 0; i < height; i++)
            {
                for (j = 0; j < width; j++)
                {
                    someIntValue3 = 0;
                    someIntValue = i * stride + j * 4;

                    for (mY = 0; mY < matrixSize; mY++)
                    {
                        for (mX = 0; mX < matrixSize; mX++)
                        {
                            someIntValue2 = someIntValue + (mX - MatrixOffset) * 4 + (mY - MatrixOffset) * stride;
                            if (someIntValue2 < PixelsCountWithChannels)
                            {
                                B[someIntValue3] = PixelsBuffer[someIntValue2];
                                G[someIntValue3] = PixelsBuffer[someIntValue2 + 1];
                                R[someIntValue3++] = PixelsBuffer[someIntValue2 + 2];
                            }
                        }
                    }

                    Array.Sort(B);
                    Pixels[someIntValue] = B[center];

                    Array.Sort(G);
                    Pixels[someIntValue + 1] = G[center];

                    Array.Sort(R);
                    Pixels[someIntValue + 2] = R[center];
                }
            }
        }

        /// <summary>
        /// Размытие по Гауссу.
        /// </summary>
        public void Gaussian(int radius)
        {
            int matrixSize = radius * 2 + 1;
            if ((double)radius % 2 == 0)
                matrixSize = radius * 2 + 1;
            radius *= radius;

            double[] matrix = new double[matrixSize * matrixSize];
            int MatrixOffset = (matrixSize - 1) / 2;
            someIntValue = 0;

            for (i = -MatrixOffset; i <= MatrixOffset; i++)
            {
                for (j = -MatrixOffset; j <= MatrixOffset; j++)
                {
                    matrix[someIntValue++] = 1 / (2 * 3.14 * radius * radius) * Math.Pow(Math.E, -((i * i + j * j) / (2 * radius * radius)));
                }
            }

            double sum = matrix.Sum();

            for (i = 0; i < matrixSize * matrixSize; i++)
            {
                matrix[i] /= sum;
            }

            ConvolutionXY(matrix, matrixSize);
        }

        private void ConvolutionXY(double[] Matrix, int matrixWidth)
        {
            double factor = 0;
            int MatrixOffset = (matrixWidth - 1) / 2;
            for (i = 0; i < Matrix.Length; i++)
                factor += Matrix[i];
            if (factor <= 0) factor = 1;

            for (i = 0; i < PixelsCount; i++)
            {
                r = 0; g = 0; b = 0;

                for (mX = -MatrixOffset; mX <= MatrixOffset; mX++)
                {
                    someIntValue2 = i * 4 + mX * 4;
                    b += PixelsBuffer[someIntValue2] * Matrix[mX + MatrixOffset];
                    g += PixelsBuffer[someIntValue2 + 1] * Matrix[mX + MatrixOffset];
                    r += PixelsBuffer[someIntValue2 + 2] * Matrix[mX + MatrixOffset];
                }

                Pixels[0] = (byte)(b / factor * matrixWidth);
                Pixels[1] = (byte)(g / factor * matrixWidth);
                Pixels[2] = (byte)(r / factor * matrixWidth);

                Pixels += Channels;
            }
            Pixels -= PixelsCountWithChannels;

            for (i = 0; i < PixelsCount; i++)
            {
                r = 0; g = 0; b = 0;

                for (mX = -MatrixOffset; mX <= MatrixOffset; mX++)
                {
                    someIntValue2 = mX * stride;
                    if (i * 4 + someIntValue2 > 0 && i * 4 + someIntValue2 < PixelsCountWithChannels)
                    {
                        b += Pixels[someIntValue2] * Matrix[mX + MatrixOffset];
                        g += Pixels[someIntValue2 + 1] * Matrix[mX + MatrixOffset];
                        r += Pixels[someIntValue2 + 2] * Matrix[mX + MatrixOffset];
                    }
                }

                Pixels[0] = (byte)(b / factor * matrixWidth);
                Pixels[1] = (byte)(g / factor * matrixWidth);
                Pixels[2] = (byte)(r / factor * matrixWidth);

                Pixels += Channels;
            }
            Pixels -= PixelsCountWithChannels;
        }

        /// <summary>
        /// Усиление границ по Лапласу.
        /// </summary>
        /// <param name="level"></param>
        public void Laplacian(int level)
        {
            int matrixSize = level * 2 + 1;
            if ((double)level % 2 == 0)
                matrixSize = level * 2 + 1;
            level *= level;

            double[] matrix = new double[matrixSize * matrixSize];
            int MatrixOffset = (matrixSize - 1) / 2;
            someIntValue = 0;

            for (i = -MatrixOffset; i <= MatrixOffset; i++)
            {
                for (j = -MatrixOffset; j <= MatrixOffset; j++)
                {
                    if (i == 0 && j == 0)
                        matrix[someIntValue++] = matrixSize * matrixSize - 1;
                    else
                        matrix[someIntValue++] = -1;
                }
            }

            Convolution(matrix, 0, matrixSize);
        }

        /// <summary>
        /// Цветовой тон/Насыщенность
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="v"></param>
        public void RGB2HSV(double h, double s, double v)
        {
            double max = 0, min = 256;
            int R, G, B;
            double H = 0, S = 0, V = 0;
            double Hi = 0, Vmin = 0, a = 0, Vinc = 0, Vdec = 0;

            for (i = 0; i < PixelsCount; i++)
            {
                max = 0;
                min = 256;

                B = PixelsBuffer[0];
                G = PixelsBuffer[1];
                R = PixelsBuffer[2];

                if (B > max)
                    max = B;
                if (B < min)
                    min = B;

                if (G > max)
                    max = G;
                if (G < min)
                    min = G;

                if (R > max)
                    max = R;
                if (R < min)
                    min = R;

                H = h;
                S = s;
                V = max + v;

                if (V > 255) V = 255;
                if (V < 0) V = 0;
                if (H < 0) H = 0;

                Hi = (H / 60) % 6;

                Vmin = ((100 - S) * V) / 100;

                a = (V - Vmin) * ((H % 60) / 60);

                Vinc = Vmin + a;

                Vdec = V - a;

                if (Hi >= 0 && Hi < 1) { Pixels[2] = (byte)V; Pixels[1] = (byte)Vinc; Pixels[0] = (byte)Vmin; }
                if (Hi >= 1 && Hi < 2) { Pixels[2] = (byte)Vdec; Pixels[1] = (byte)V; Pixels[0] = (byte)Vmin; }
                if (Hi >= 2 && Hi < 3) { Pixels[2] = (byte)Vmin; Pixels[1] = (byte)V; Pixels[0] = (byte)Vinc; }
                if (Hi >= 3 && Hi < 4) { Pixels[2] = (byte)Vmin; Pixels[1] = (byte)Vdec; Pixels[0] = (byte)V; }
                if (Hi >= 4 && Hi < 5) { Pixels[2] = (byte)Vinc; Pixels[1] = (byte)Vmin; Pixels[0] = (byte)V; }
                if (Hi >= 5) { Pixels[2] = (byte)V; Pixels[1] = (byte)Vmin; Pixels[0] = (byte)Vdec; }

                Pixels += Channels;
                PixelsBuffer += Channels;
            }
            Pixels -= PixelsCountWithChannels;
            PixelsBuffer -= PixelsCountWithChannels;
        }

        /// <summary>
        /// Матрица свертки.
        /// </summary>
        /// <param name="Matrix"></param>
        /// <param name="offset"></param>
        public void Convolution(double[] Matrix, int offset, int matrixWidth, double factor = 0)
        {
            int MatrixOffset = (matrixWidth - 1) / 2;
            if (factor == 0)
            {
                for (i = 0; i < Matrix.Length; i++)
                    factor += Matrix[i];
            }
            if (factor <= 0)
            {
                factor = 1;
                offset = 128;
            }

            for (i = MatrixOffset; i < height - MatrixOffset; i++)
            {
                for (j = 0; j < width; j++)
                {
                    r = 0; g = 0; b = 0;
                    someIntValue3 = 0;
                    someIntValue = i * stride + j * 4;
                    for (mY = 0; mY < matrixWidth; mY++)
                    {
                        for (mX = 0; mX < matrixWidth; mX++)
                        {
                            someIntValue2 = someIntValue + (mX - MatrixOffset) * 4 + (mY - MatrixOffset) * stride;
                            b += PixelsBuffer[someIntValue2] * Matrix[someIntValue3];
                            g += PixelsBuffer[someIntValue2 + 1] * Matrix[someIntValue3];
                            r += PixelsBuffer[someIntValue2 + 2] * Matrix[someIntValue3++];
                        }
                    }
                    r = r / factor + offset;
                    g = g / factor + offset;
                    b = b / factor + offset;

                    if (b > 255) b = 255;
                    if (g > 255) g = 255;
                    if (r > 255) r = 255;

                    if (b < 0) b = 0;
                    if (g < 0) g = 0;
                    if (r < 0) r = 0;

                    Pixels[someIntValue] = (byte)b;
                    Pixels[someIntValue + 1] = (byte)g;
                    Pixels[someIntValue + 2] = (byte)r;
                }
            }
        }

        /// <summary>
        /// Инверсия цвета.
        /// </summary>
        public void Invert()
        {
            for (i = 0; i < PixelsCount; i++)
            {
                Pixels[0] = (byte)(255 - Pixels[0]);
                Pixels[1] = (byte)(255 - Pixels[1]);
                Pixels[2] = (byte)(255 - Pixels[2]);
                Pixels += Channels;
            }
            Pixels -= PixelsCountWithChannels;
        }

        /// <summary>
        /// Изменение яркости и контрастности. 
        /// </summary>
        /// <param name="brightness"></param>
        /// <param name="contrast"></param>
        public void BrightnessNContrast(int brightness, int contrast)
        {
            someDoubleValue = (100 + contrast) / 100.0;
            someDoubleValue *= someDoubleValue;

            for (i = 0; i < PixelsCount; i++)
            {
                someIntValue = (int)(someDoubleValue * (PixelsBuffer[0] - 128) + 128) + brightness;
                Pixels[0] = (byte)(someIntValue | ((255 - someIntValue) >> 31));
                if (someIntValue < byte.MinValue) Pixels[0] = byte.MinValue;

                someIntValue = (int)(someDoubleValue * (PixelsBuffer[1] - 128) + 128) + brightness;
                Pixels[1] = (byte)(someIntValue | ((255 - someIntValue) >> 31));
                if (someIntValue < byte.MinValue) Pixels[1] = byte.MinValue;

                someIntValue = (int)(someDoubleValue * (PixelsBuffer[2] - 128) + 128) + brightness;
                Pixels[2] = (byte)(someIntValue | ((255 - someIntValue) >> 31));
                if (someIntValue < byte.MinValue) Pixels[2] = byte.MinValue;

                PixelsBuffer += Channels;
                Pixels += Channels;
            }
            Pixels -= PixelsCountWithChannels;
            PixelsBuffer -= PixelsCountWithChannels;
        }


        /// <summary>
        /// Градации серого.
        /// </summary>
        public void GrayScale()
        {
            for (i = 0; i < PixelsCount; i++)
            {
                someIntValue = (int)(PixelsBuffer[0] * 0.11f + PixelsBuffer[1] * 0.6f + PixelsBuffer[2] * 0.3f);

                if (someIntValue <= 255)
                {
                    Pixels[0] = (byte)someIntValue;
                    Pixels[1] = (byte)someIntValue;
                    Pixels[2] = (byte)someIntValue;
                }
                Pixels += Channels;
                PixelsBuffer += Channels;
            }
            Pixels -= PixelsCountWithChannels;
            PixelsBuffer -= PixelsCountWithChannels;
        }

        /// <summary>
        /// Бинаризация по порогу.
        /// </summary>
        /// <param name="threshold"></param>
        public void Binarization(int threshold)
        {
            for (i = 0; i < PixelsCount; i++)
            {
                someIntValue = (PixelsBuffer[0] + PixelsBuffer[1] + PixelsBuffer[2]) / 3;

                if (someIntValue < threshold)
                {
                    Pixels[0] = Pixels[1] = Pixels[2] = 0;
                }
                if (someIntValue > threshold)
                {
                    Pixels[0] = Pixels[1] = Pixels[2] = 255;
                }
                Pixels += Channels;
                PixelsBuffer += Channels;
            }
            Pixels -= PixelsCountWithChannels;
            PixelsBuffer -= PixelsCountWithChannels;
        }

        /// <summary>
        /// Наложение цвета, "opacity" от 0.0 до 1.0
        /// </summary>
        /// <param name="color"></param>
        public void ColorOverlay(RGB color, double opacity)
        {
            BlendModes modes = new BlendModes(Layers.CurrentLayer);
            byte* pixels = Layers.CurrentLayer.Background.Pixels;

            for (i = 0; i < PixelsCount; i++)
            {
                pixels[0] = color.B;
                pixels[1] = color.G;
                pixels[2] = color.R;
                pixels[3] = 255;

                pixels += Channels;
            }
            pixels -= PixelsCountWithChannels;

            Layers.CurrentLayer.Transparence = opacity;
            modes.Transparence();
        }

        /// <summary>
        /// Возвращает изображение по цветовым каналам.
        /// Параметр "color" - необходимый канал.
        /// </summary>
        /// <param name="color"></param>
        public void ChangeColorChannel(ColorChannelType color)
        {
            if (color == ColorChannelType.R || color == ColorChannelType.G || color == ColorChannelType.B)
            {
                for (i = 0; i < PixelsCount; i++)
                {
                    Pixels[0] = PixelsBuffer[(int)color];
                    Pixels[1] = PixelsBuffer[(int)color];
                    Pixels[2] = PixelsBuffer[(int)color];

                    Pixels += Channels;
                    PixelsBuffer += Channels;
                }
                Pixels -= PixelsCountWithChannels;
                PixelsBuffer -= PixelsCountWithChannels;
            }
            if (color == ColorChannelType.RGB)
            {
                for (i = 0; i < PixelsCount; i++)
                {
                    Pixels[0] = PixelsBuffer[0];
                    Pixels[1] = PixelsBuffer[1];
                    Pixels[2] = PixelsBuffer[2];

                    Pixels += Channels;
                    PixelsBuffer += Channels;
                }

                Pixels -= PixelsCountWithChannels;
                PixelsBuffer -= PixelsCountWithChannels;
            }
            Layers.CurrentLayer.Foreground.ApplyChanges();
        }

        /// <summary>
        /// Слияние редактируемого канала в RGB
        /// </summary>
        /// <param name="color"></param>
        public void MergeColorChannel(ColorChannelType color)
        {
            var pic = new Picture(Layers.CurrentLayer.Foreground.OriginalImage);
            byte* pixels = pic.Pixels;

            for (i = 0; i < PixelsCount; i++)
            {
                pixels[(int)color] = Pixels[(int)color];

                pixels += Channels;
                Pixels += Channels;
            }

            pixels -= PixelsCountWithChannels;
            Pixels -= PixelsCountWithChannels;

            Layers.CurrentLayer.Foreground = pic;
        }
    }
}