using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLL
{
    public unsafe class BlendModes
    {
        private static int i, j, ForeStride,
            Value, ForeWidth, ForeHeight;

        private static byte* ForePixels;
        private static byte* ForePixelsBuffer;
        private static byte* ForeOriginalPixelsBuffer;

        private static byte* BackPixels;

        private Layer layer;

        public BlendModes(Layer layer)
        {
            this.layer = layer;

            BackPixels = layer.Background.Pixels;

            ForeStride = layer.Foreground.Stride;
            ForeWidth = layer.Foreground.EditImage.Width;
            ForeHeight = layer.Foreground.EditImage.Height;
            ForePixels = layer.Foreground.Pixels;
            ForePixelsBuffer = layer.Foreground.PixelsBuffer;
            ForeOriginalPixelsBuffer = layer.Foreground.PixelsSourceBuffer;
        }

        public void Transparence()
        {
            var alpha = layer.Transparence;
            for (i = 0; i < ForeHeight; i++)
            {
                for (j = 0; j < ForeWidth; j++)
                {
                    Value = i * ForeStride + j * 4;
                    ForePixels[Value] =
                        (byte)(BackPixels[Value] + (ForePixelsBuffer[Value] - BackPixels[Value]) * alpha);
                    ForePixels[Value + 1] =
                        (byte)(BackPixels[Value + 1] + (ForePixelsBuffer[Value + 1] - BackPixels[Value + 1]) * alpha);
                    ForePixels[Value + 2] =
                        (byte)(BackPixels[Value + 2] + (ForePixelsBuffer[Value + 2] - BackPixels[Value + 2]) * alpha);
                    ForePixels[Value + 3] =
                      (byte)(BackPixels[Value + 3] + (ForePixelsBuffer[Value + 3] - BackPixels[Value + 3]) * alpha);
                }
            }
        }

        public void Difference()
        {
            for (i = 0; i < ForeHeight; i++)
            {
                for (j = 0; j < ForeWidth; j++)
                {
                    Value = i * ForeStride + j * 4;
                    ForePixelsBuffer[Value] = (byte)Math.Abs((ForePixelsBuffer[Value] - BackPixels[Value]));
                    ForePixelsBuffer[Value + 1] = (byte)Math.Abs((ForePixelsBuffer[Value + 1] - BackPixels[Value + 1]));
                    ForePixelsBuffer[Value + 2] = (byte)Math.Abs((ForePixelsBuffer[Value + 2] - BackPixels[Value + 2]));
                }
            }
            Transparence();
            //Layers.CurrentLayer.Foreground.ApplyChanges();
        }

        public void Exclusion()
        {
            for (i = 0; i < ForeHeight; i++)
            {
                for (j = 0; j < ForeWidth; j++)
                {
                    Value = i * ForeStride + j * 4;
                    ForePixelsBuffer[Value] =
                         (byte)((ForePixelsBuffer[Value] + BackPixels[Value]) -
                         (2 * ForePixelsBuffer[Value] * BackPixels[Value] / 255));
                    ForePixelsBuffer[Value + 1] =
                        (byte)((ForePixelsBuffer[Value + 1] + BackPixels[Value + 1]) -
                        (2 * ForePixelsBuffer[Value + 1] * BackPixels[Value + 1] / 255));
                    ForePixelsBuffer[Value + 2] =
                        (byte)((ForePixelsBuffer[Value + 2] + BackPixels[Value + 2]) -
                        (2 * ForePixelsBuffer[Value + 2] * BackPixels[Value + 2] / 255));
                }
            }
            Transparence();
            //Layers.CurrentLayer.Foreground.ApplyChanges();
        }

        public void Normal()
        {
            for (i = 0; i < ForeHeight; i++)
            {
                for (j = 0; j < ForeWidth; j++)
                {
                    Value = i * ForeStride + j * 4;
                    ForePixelsBuffer[Value] = ForePixels[Value] = ForeOriginalPixelsBuffer[Value];
                    ForePixelsBuffer[Value + 1] = ForePixels[Value + 1] = ForeOriginalPixelsBuffer[Value + 1];
                    ForePixelsBuffer[Value + 2] = ForePixels[Value + 2] = ForeOriginalPixelsBuffer[Value + 2];
                }
            }
            Transparence();
            //Layers.CurrentLayer.Foreground.ApplyChanges();
        }
    }
}
