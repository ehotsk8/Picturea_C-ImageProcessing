using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLL
{
    public unsafe class Histogramm
    {
        private static int i, someIntValue;

        private static int PixelsCount;
        private static int PixelsCountWithChannels;
        private static int Channels;

        private static byte* Pixels;
        private static byte* PixelsBuffer;

        /// <summary>
        /// Гистограмма
        /// </summary>
        /// <param name="picture"></param>
        public Histogramm(Picture picture)
        {
            Pixels = picture.Pixels;
            PixelsBuffer = picture.PixelsBuffer;

            Channels = picture.Channels;
            PixelsCountWithChannels = picture.PixelsCountWithChannels;
            PixelsCount = picture.PixelsCount;
        }

        /// <summary>
        /// Массив значенией для построения гистограммы.
        /// </summary>
        /// <returns></returns>
        public int[] GetHistogramm(HistogramType type)
        {
            int[] result = new int[256];
            int max = 0;

            if (type != HistogramType.RGB)
            {
                for (i = 0; i < PixelsCount; i++)
                {
                    if (type == HistogramType.R) someIntValue = PixelsBuffer[2];
                    if (type == HistogramType.G) someIntValue = PixelsBuffer[1];
                    if (type == HistogramType.B) someIntValue = PixelsBuffer[0];
                    if (type == HistogramType.Brightness)
                        someIntValue = (PixelsBuffer[0] + PixelsBuffer[1] + PixelsBuffer[2]) / 3;

                    if (someIntValue > 255) someIntValue = 255;
                    if (max < ++result[someIntValue]) max = result[someIntValue];

                    PixelsBuffer += Channels;
                }
                PixelsBuffer -= PixelsCountWithChannels;
            }
            return result;
        }
    }
}
