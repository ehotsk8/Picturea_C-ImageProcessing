using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLL
{
    public unsafe class FreeTransform : ITransform
    {
        private static int i, j, someIntValue, someIntValue2, someIntValue3, previousWidth, previousHeight;
        private static double someDoubleValue, cos, sin;

        private static int PixelsCount;
        private static int PixelsCountWithChannels;
        private static int Channels;
        private static int Stride;

        private static byte* Pixels;
        private static byte* PixelsBuffer;

        private static byte* PixelsBufferBackground;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        public FreeTransform(Picture picture)
        {
            Pixels = picture.Pixels;
            PixelsBuffer = picture.PixelsBuffer;

            Channels = picture.Channels;
            PixelsCountWithChannels = picture.PixelsCountWithChannels;
            PixelsCount = picture.PixelsCount;
            Stride = picture.Stride;

            previousWidth = picture.EditImage.Width;
            previousHeight = picture.EditImage.Height;

            PixelsBufferBackground = Layers.CurrentLayer.Background.PixelsBuffer;
        }

        /// <summary>
        /// Изменение позиции, размера и поворот изображения
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        /// <param name="angle"></param>
        public void Transform(int Width, int Height, int offsetX, int offsetY, int angle)
        {
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

            for (i = 0; i < previousHeight; i++)
            {
                for (j = 0; j < previousWidth; j++)
                {
                    X = (int)(cos * (j - currentOffsetX - pointX) - sin * (i + currentOffsetY - pointY) + pointX);
                    Y = (int)(sin * (j - currentOffsetX - pointX) + cos * (i + currentOffsetY - pointY) + pointY);

                    X2 = (X * x_ratio) >> 16;
                    Y2 = (Y * y_ratio) >> 16;

                    someIntValue = i * Stride + j * 4;
                    someIntValue2 = Y2 * Stride + X2 * 4;

                    if (someIntValue >= 0 && someIntValue < PixelsCountWithChannels &&
                        someIntValue2 >= 0 && someIntValue2 < PixelsCountWithChannels)
                    {
                        if (X2 >= 0 && X2 < previousWidth)
                        {
                            Pixels[someIntValue] = PixelsBuffer[someIntValue2];
                            Pixels[someIntValue + 1] = PixelsBuffer[someIntValue2 + 1];
                            Pixels[someIntValue + 2] = PixelsBuffer[someIntValue2 + 2];
                            Pixels[someIntValue + 3] = 255;
                        }
                        else
                        {
                            Pixels[someIntValue] = PixelsBufferBackground[someIntValue];
                            Pixels[someIntValue + 1] = PixelsBufferBackground[someIntValue + 1];
                            Pixels[someIntValue + 2] = PixelsBufferBackground[someIntValue + 2];
                            Pixels[someIntValue + 3] = PixelsBufferBackground[someIntValue + 3];
                        }
                    }
                    else
                    {
                        Pixels[someIntValue] = PixelsBufferBackground[someIntValue];
                        Pixels[someIntValue + 1] = PixelsBufferBackground[someIntValue + 1];
                        Pixels[someIntValue + 2] = PixelsBufferBackground[someIntValue + 2];
                        Pixels[someIntValue + 3] = PixelsBufferBackground[someIntValue + 3];
                    }
                }
            }
        }

        /// <summary>
        /// Изменение позиции, размера и поворот изображения, с биллинейной интерполяцией
        /// </summary>
        public void BilinearInterpolationTransform(int Width, int Height, int offsetX, int offsetY, int angle)
        {
            int X, Y, X2, Y2;

            RGB A = new RGB();
            RGB B = new RGB();
            RGB C = new RGB();
            RGB D = new RGB();

            byte r, g, b;
            double w, h;

            int pointX = Width / 2;
            int pointY = Height / 2;

            int currentOffsetX = offsetY + (previousWidth / 2 - Width / 2);
            int currentOffsetY = offsetX - (previousHeight / 2 - Height / 2);

            double x_ratio = (double)(previousWidth - 1) / Width;
            double y_ratio = (double)(previousHeight - 1) / Height;

            someDoubleValue = Math.PI / 180 * angle;
            cos = Math.Cos(someDoubleValue);
            sin = Math.Sin(someDoubleValue);

            for (i = 0; i < previousHeight; i++)
            {
                for (j = 0; j < previousWidth; j++)
                {
                    X = (int)(cos * (j - currentOffsetX - pointX) - sin * (i + currentOffsetY - pointY) + pointX);
                    Y = (int)(sin * (j - currentOffsetX - pointX) + cos * (i + currentOffsetY - pointY) + pointY);

                    X2 = (int)(X * x_ratio);
                    Y2 = (int)(Y * y_ratio);

                    w = x_ratio * X - X2;
                    h = y_ratio * Y - Y2;

                    someIntValue = i * Stride + j * 4;
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

                    r = (byte)(A.R * (1 - w) * (1 - h) + B.R * (w) * (1 - h) + C.R * (h) * (1 - w) + D.R * (w * h));
                    g = (byte)(A.G * (1 - w) * (1 - h) + B.G * (w) * (1 - h) + C.G * (h) * (1 - w) + D.G * (w * h));
                    b = (byte)(A.B * (1 - w) * (1 - h) + B.B * (w) * (1 - h) + C.B * (h) * (1 - w) + D.B * (w * h));

                    if (someIntValue >= 0 && someIntValue < PixelsCountWithChannels &&
                        someIntValue2 >= 0 && someIntValue2 < PixelsCountWithChannels)
                    {
                        if (X2 >= 0 && X2 < previousWidth)
                        {
                            Pixels[someIntValue] = b;
                            Pixels[someIntValue + 1] = g;
                            Pixels[someIntValue + 2] = r;
                            Pixels[someIntValue + 3] = 255;
                        }
                        else
                        {
                            Pixels[someIntValue] = PixelsBufferBackground[someIntValue];
                            Pixels[someIntValue + 1] = PixelsBufferBackground[someIntValue + 1];
                            Pixels[someIntValue + 2] = PixelsBufferBackground[someIntValue + 2];
                            Pixels[someIntValue + 3] = PixelsBufferBackground[someIntValue + 3];
                        }
                    }
                    else
                    {
                        Pixels[someIntValue] = PixelsBufferBackground[someIntValue];
                        Pixels[someIntValue + 1] = PixelsBufferBackground[someIntValue + 1];
                        Pixels[someIntValue + 2] = PixelsBufferBackground[someIntValue + 2];
                        Pixels[someIntValue + 3] = PixelsBufferBackground[someIntValue + 3];
                    }
                }
            }
        }


        /// <summary>
        /// Изменение позиции, размера и поворот изображения, с линейной интерполяцией
        /// </summary>
        public void LinearInterpolationTransform(int Width, int Height, int offsetX, int offsetY, int angle)
        {
            int X, Y, X2, Y2;

            RGB A = new RGB();
            RGB B = new RGB();

            byte r, g, b;

            int pointX = Width / 2;
            int pointY = Height / 2;

            int currentOffsetX = offsetY + (previousWidth / 2 - Width / 2);
            int currentOffsetY = offsetX - (previousHeight / 2 - Height / 2);

            double x_ratio = (double)(previousWidth - 1) / Width;
            double y_ratio = (double)(previousHeight - 1) / Height;

            someDoubleValue = Math.PI / 180 * angle;
            cos = Math.Cos(someDoubleValue);
            sin = Math.Sin(someDoubleValue);

            for (i = 0; i < previousHeight; i++)
            {
                for (j = 0; j < previousWidth; j++)
                {
                    X = (int)(cos * (j - currentOffsetX - pointX) - sin * (i + currentOffsetY - pointY) + pointX);
                    Y = (int)(sin * (j - currentOffsetX - pointX) + cos * (i + currentOffsetY - pointY) + pointY);

                    X2 = (int)(X * x_ratio);
                    Y2 = (int)(Y * y_ratio);

                    someIntValue = i * Stride + j * 4;
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

                    if (someIntValue >= 0 && someIntValue < PixelsCountWithChannels &&
                        someIntValue2 >= 0 && someIntValue2 < PixelsCountWithChannels)
                    {
                        if (X2 >= 0 && X2 < previousWidth)
                        {
                            Pixels[someIntValue] = b;
                            Pixels[someIntValue + 1] = g;
                            Pixels[someIntValue + 2] = r;
                            Pixels[someIntValue + 3] = 255;
                        }
                        else
                        {
                            Pixels[someIntValue] = PixelsBufferBackground[someIntValue];
                            Pixels[someIntValue + 1] = PixelsBufferBackground[someIntValue + 1];
                            Pixels[someIntValue + 2] = PixelsBufferBackground[someIntValue + 2];
                            Pixels[someIntValue + 3] = PixelsBufferBackground[someIntValue + 3];
                        }
                    }
                    else
                    {
                        Pixels[someIntValue] = PixelsBufferBackground[someIntValue];
                        Pixels[someIntValue + 1] = PixelsBufferBackground[someIntValue + 1];
                        Pixels[someIntValue + 2] = PixelsBufferBackground[someIntValue + 2];
                        Pixels[someIntValue + 3] = PixelsBufferBackground[someIntValue + 3];
                    }
                }
            }
        }
    }
}
