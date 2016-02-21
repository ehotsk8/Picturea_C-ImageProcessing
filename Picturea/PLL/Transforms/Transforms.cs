using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLL
{
    public unsafe class Transforms : ITransform
    {
        private static int i, j, someIntValue, someIntValue2, someIntValue3, previousWidth, previousHeight, h, w;
        private static double someDoubleValue, cos, sin;

        private static int PixelsCount;
        private static int PixelsCountWithChannels;
        private static int Channels;
        private static int Stride;

        private static byte* Pixels;
        private static byte* PixelsBuffer;

        private Picture picture;

        /// <summary>
        /// Трансформации
        /// </summary>
        /// <param name="picture"></param>
        public Transforms(Picture picture)
        {
            this.picture = picture;

            Pixels = picture.Pixels;
            PixelsBuffer = picture.PixelsBuffer;

            Channels = picture.Channels;
            PixelsCountWithChannels = picture.PixelsCountWithChannels;
            PixelsCount = picture.PixelsCount;
            Stride = picture.Stride;

            previousWidth = picture.EditImage.Width;
            previousHeight = picture.EditImage.Height;
        }

        private void Scale(int Width, int Height, int angle)
        {
            int newAngle = angle;
            double cW = 0, cH = 0;

            h = Height;
            w = Width;
          
            var oc = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2)) / 2;

            cH = Math.Atan((double)Height / (double)Width);
            cW = Math.Atan((double)Width / (double)Height);
            if (newAngle > 90 && newAngle < 180)
            {
                newAngle -= 90;
                cW = Math.Atan((double)Height / (double)Width);
                cH = Math.Atan((double)Width / (double)Height);
            }
            else if (newAngle > 180 && newAngle < 270)
            {
                newAngle -= 180;
                cH = Math.Atan((double)Height / (double)Width);
                cW = Math.Atan((double)Width / (double)Height);
            }
            else if (newAngle > 270)
            {
                newAngle -= 270;
                cW = Math.Atan((double)Height / (double)Width);
                cH = Math.Atan((double)Width / (double)Height);
            }

            someDoubleValue = Math.PI / 180 * newAngle;

            h = (int)(2 * oc * Math.Sin(cH + someDoubleValue));
            w = (int)(2 * oc * Math.Sin(cW + someDoubleValue));
        }

        /// <summary>
        /// Изменение позиции, размера и поворот изображения
        /// </summary>
        public void Transform(int Width, int Height, int offsetX, int offsetY, int angle)
        {
            Scale(Width, Height, angle);

            byte[] TransformBuffer = new byte[w * h * Channels];

            int X, Y, X2, Y2;

            int pointX = Width / 2;
            int pointY = Height / 2;

            int currentOffsetX = offsetY + (previousWidth / 2 - Width / 2);
            int currentOffsetY = offsetX - (previousHeight / 2 - Height / 2);

            int x_ratio = (previousWidth << 16) / Width + 1;
            int y_ratio = (previousHeight << 16) / Height + 1;

            someDoubleValue = Math.PI / 180 * angle;
            cos = Math.Cos(someDoubleValue);
            sin = Math.Sin(someDoubleValue);

            currentOffsetX = offsetY + (previousWidth - Width) / 2 - (previousWidth - w) / 2;
            currentOffsetY = offsetX - (previousHeight - Height) / 2 + (previousHeight - h) / 2;

            x_ratio = (previousWidth << 16) / Width + 1;
            y_ratio = (previousHeight << 16) / Height + 1;

            for (i = 0; i < h; i++)
            {
                for (j = 0; j < w; j++)
                {
                    X = (int)(cos * (j - currentOffsetX - pointX) - sin * (i + currentOffsetY - pointY) + pointX);
                    Y = (int)(sin * (j - currentOffsetX - pointX) + cos * (i + currentOffsetY - pointY) + pointY);

                    X2 = (X * x_ratio) >> 16;
                    Y2 = (Y * y_ratio) >> 16;

                    someIntValue = i * (w * Channels) + j * 4;
                    someIntValue2 = Y2 * Stride + X2 * 4;

                    if (someIntValue >= 0 && someIntValue < TransformBuffer.Length &&
                        someIntValue2 >= 0 && someIntValue2 < PixelsCountWithChannels)
                    {
                        if (X2 >= 0 && X2 < previousWidth)
                        {
                            TransformBuffer[someIntValue] = PixelsBuffer[someIntValue2];
                            TransformBuffer[someIntValue + 1] = PixelsBuffer[someIntValue2 + 1];
                            TransformBuffer[someIntValue + 2] = PixelsBuffer[someIntValue2 + 2];
                            TransformBuffer[someIntValue + 3] = 255;
                        }
                        else TransformBuffer[someIntValue + 3] = 0;
                    }
                }
            }

            picture.TransformBuffer = TransformBuffer;
            picture.Width = Math.Abs(w);
            picture.Height = Math.Abs(h);
        }

        /// <summary>
        /// Изменение позиции, размера и поворот изображения, с линейной интерполяцией
        /// </summary>
        public void LinearInterpolationTransform(int Width, int Height, int offsetX, int offsetY, int angle)
        {
            Scale(Width, Height, angle);

            byte[] TransformBuffer = new byte[w * h * Channels];

            int X, Y, X2, Y2;

            RGB A = new RGB();
            RGB B = new RGB();

            byte r, g, b;

            int pointX = Width / 2;
            int pointY = Height / 2;

            int currentOffsetX = offsetY + (previousWidth - Width) / 2 - (previousWidth - w) / 2;
            int currentOffsetY = offsetX - (previousHeight - Height) / 2 + (previousHeight - h) / 2;

            int x_ratio = (previousWidth << 16) / Width + 1;
            int y_ratio = (previousHeight << 16) / Height + 1;

            someDoubleValue = Math.PI / 180 * angle;
            cos = Math.Cos(someDoubleValue);
            sin = Math.Sin(someDoubleValue);

            for (i = 0; i < h; i++)
            {
                for (j = 0; j < w; j++)
                {
                    X = (int)(cos * (j - currentOffsetX - pointX) - sin * (i + currentOffsetY - pointY) + pointX);
                    Y = (int)(sin * (j - currentOffsetX - pointX) + cos * (i + currentOffsetY - pointY) + pointY);

                    X2 = (X * x_ratio) >> 16;
                    Y2 = (Y * y_ratio) >> 16;

                    someIntValue = i * (w * Channels) + j * 4;
                    someIntValue2 = Y2 * Stride + X2 * 4;

                    if (someIntValue2 >= 0 && someIntValue2 < PixelsCountWithChannels)
                    {
                        A.B = PixelsBuffer[someIntValue2];
                        A.G = PixelsBuffer[someIntValue2 + 1];
                        A.R = PixelsBuffer[someIntValue2 + 2];
                    }

                    someIntValue3 = Y2 * Stride + (X2 + 1) * 4;

                    if (someIntValue3 >= 0 && someIntValue3 < PixelsCountWithChannels)
                    {
                        B.B = PixelsBuffer[someIntValue3];
                        B.G = PixelsBuffer[someIntValue3 + 1];
                        B.R = PixelsBuffer[someIntValue3 + 2];
                    }

                    r = A.R + (previousWidth * (B.R - A.R) / Width) < 0 ? r = 0 :
                        A.R + (previousWidth * (B.R - A.R) / Width) > 255 ? r = 255 : r = (byte)(A.R + (previousWidth * (B.R - A.R) / Width));
                    g = A.G + (previousWidth * (B.G - A.G) / Width) < 0 ? g = 0 :
                        A.G + (previousWidth * (B.G - A.G) / Width) > 255 ? g = 255 : g = (byte)(A.G + (previousWidth * (B.G - A.G) / Width));
                    b = A.B + (previousWidth * (B.B - A.B) / Width) < 0 ? b = 0 :
                        A.R + (previousWidth * (B.B - A.B) / Width) > 255 ? b = 255 : b = (byte)(A.B + (previousWidth * (B.B - A.B) / Width));

                    if (someIntValue >= 0 && someIntValue < TransformBuffer.Length &&
                        someIntValue2 >= 0 && someIntValue2 < PixelsCountWithChannels)
                    {
                        if (X2 >= 0 && X2 < previousWidth)
                        {
                            TransformBuffer[someIntValue] = b;
                            TransformBuffer[someIntValue + 1] = g;
                            TransformBuffer[someIntValue + 2] = r;
                            TransformBuffer[someIntValue + 3] = 255;
                        }
                        else TransformBuffer[someIntValue + 3] = 0;
                    }
                }
            }
            picture.TransformBuffer = TransformBuffer;
            picture.Width = Math.Abs(w);
            picture.Height = Math.Abs(h);
        }

        /// <summary>
        /// Изменение позиции, размера и поворот изображения, с биллинейной интерполяцией
        /// </summary>
        public void BilinearInterpolationTransform(int Width, int Height, int offsetX, int offsetY, int angle)
        {
            Scale(Width, Height, angle);

            byte[] TransformBuffer = new byte[w * h * Channels];

            int X, Y, X2, Y2;

            RGB A = new RGB();
            RGB B = new RGB();
            RGB C = new RGB();
            RGB D = new RGB();

            byte r, g, b;
            double W, H;

            int pointX = Width / 2;
            int pointY = Height / 2;

            int currentOffsetX = offsetY + (previousWidth - Width) / 2 - (previousWidth - w) / 2;
            int currentOffsetY = offsetX - (previousHeight - Height) / 2 + (previousHeight - h) / 2;

            double x_ratio = (double)(previousWidth - 1) / Width;
            double y_ratio = (double)(previousHeight - 1) / Height;

            someDoubleValue = Math.PI / 180 * angle;
            cos = Math.Cos(someDoubleValue);
            sin = Math.Sin(someDoubleValue);

            for (i = 0; i < h; i++)
            {
                for (j = 0; j < w; j++)
                {
                    X = (int)(cos * (j - currentOffsetX - pointX) - sin * (i + currentOffsetY - pointY) + pointX);
                    Y = (int)(sin * (j - currentOffsetX - pointX) + cos * (i + currentOffsetY - pointY) + pointY);

                    X2 = (int)(X * x_ratio);
                    Y2 = (int)(Y * y_ratio);

                    W = x_ratio * X - X2;
                    H = y_ratio * Y - Y2;

                    someIntValue = i * (w * Channels) + j * 4;
                    someIntValue2 = Y2 * Stride + X2 * 4;

                    if (someIntValue2 >= 0 && someIntValue2 < PixelsCountWithChannels)
                    {
                        A.B = PixelsBuffer[someIntValue2];
                        A.G = PixelsBuffer[someIntValue2 + 1];
                        A.R = PixelsBuffer[someIntValue2 + 2];
                    }
                    someIntValue3 = Y2 * Stride + (X2 + 1) * 4;
                    if (someIntValue3 >= 0 && someIntValue3 < PixelsCountWithChannels)
                    {
                        B.B = PixelsBuffer[someIntValue3];
                        B.G = PixelsBuffer[someIntValue3 + 1];
                        B.R = PixelsBuffer[someIntValue3 + 2];
                    }
                    someIntValue3 = (Y2 + 1) * Stride + X2 * 4;
                    if (someIntValue3 >= 0 && someIntValue3 < PixelsCountWithChannels)
                    {
                        C.B = PixelsBuffer[someIntValue3];
                        C.G = PixelsBuffer[someIntValue3 + 1];
                        C.R = PixelsBuffer[someIntValue3 + 2];
                    }
                    someIntValue3 = (Y2 + 1) * Stride + (X2 + 1) * 4;
                    if (someIntValue3 >= 0 && someIntValue3 < PixelsCountWithChannels)
                    {
                        D.B = PixelsBuffer[someIntValue3];
                        D.G = PixelsBuffer[someIntValue3 + 1];
                        D.R = PixelsBuffer[someIntValue3 + 2];
                    }

                    r = (byte)(A.R * (1 - W) * (1 - H) + B.R * (W) * (1 - H) + C.R * (H) * (1 - W) + D.R * (W * H));
                    g = (byte)(A.G * (1 - W) * (1 - H) + B.G * (W) * (1 - H) + C.G * (H) * (1 - W) + D.G * (W * H));
                    b = (byte)(A.B * (1 - W) * (1 - H) + B.B * (W) * (1 - H) + C.B * (H) * (1 - W) + D.B * (W * H));

                    if (someIntValue >= 0 && someIntValue < TransformBuffer.Length &&
                        someIntValue2 >= 0 && someIntValue2 < PixelsCountWithChannels)
                    {
                        if (X2 >= 0 && X2 < previousWidth)
                        {
                            TransformBuffer[someIntValue] = b;
                            TransformBuffer[someIntValue + 1] = g;
                            TransformBuffer[someIntValue + 2] = r;
                            TransformBuffer[someIntValue + 3] = 255;
                        }
                        else TransformBuffer[someIntValue + 3] = 0;
                    }
                }
            }
            picture.TransformBuffer = TransformBuffer;
            picture.Width = Math.Abs(w);
            picture.Height = Math.Abs(h);
        }
    }
}
