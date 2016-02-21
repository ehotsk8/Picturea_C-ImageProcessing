using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace PLL
{
    unsafe public class MedianCutQuantizer
    {
        private static int i, j, width, height, stride;

        private static int PixelsCount;
        private static int PixelsCountWithChannels;
        private static int Channels;

        private static byte* Pixels;

        private RGB[] colorList;
        private readonly List<MedianCutCube> cubeList;
        private readonly Dictionary<RGB, int> cache;

        public MedianCutQuantizer(Picture picture)
        {
            cache = new Dictionary<RGB, int>();
            cubeList = new List<MedianCutCube>();

            width = picture.EditImage.Width;
            height = picture.EditImage.Height;
            stride = picture.Stride;

            Pixels = picture.Pixels;

            Channels = picture.Channels;
            PixelsCountWithChannels = picture.PixelsCountWithChannels;
            PixelsCount = picture.PixelsCount;
        }

        public void Quantize(int colorCount)
        {
            Clear();
            colorList = new RGB[PixelsCount];

            int index = 0;
            for (i = 0; i < PixelsCountWithChannels; i += Channels)
            {
                colorList[index++] = new RGB(Pixels[i + 2], Pixels[i + 1], Pixels[i]);
            }

            int b;
            RGB[] palette = GetPalette(colorCount);

            for (i = 0; i < PixelsCountWithChannels; i += Channels)
            {
                RGB color = new RGB(Pixels[i + 2], Pixels[i + 1], Pixels[i]);
                if (!cache.TryGetValue(color, out b))
                {
                    for (j = 0; j < cubeList.Count; j++)
                    {
                        if (cubeList[j].IsColorIn(color))
                        {
                            b = cubeList[j].PaletteIndex;
                            break;
                        }
                    }
                }

                Pixels[i + 2] = palette[b].R;
                Pixels[i + 1] = palette[b].G;
                Pixels[i] = palette[b].B;
            }
        }

        private void SplitCubes(int colorCount)
        {
            List<MedianCutCube> newCubes = new List<MedianCutCube>();

            for (int i = 0; i < cubeList.Count; i++)
            {
                MedianCutCube newMedianCutCubeA, newMedianCutCubeB;

                if (cubeList[i].RedSize >= cubeList[i].GreenSize && cubeList[i].RedSize >= cubeList[i].BlueSize)
                {
                    cubeList[i].SplitAtMedian(0, out newMedianCutCubeA, out newMedianCutCubeB);
                }
                else if (cubeList[i].GreenSize >= cubeList[i].BlueSize)
                {
                    cubeList[i].SplitAtMedian(1, out newMedianCutCubeA, out newMedianCutCubeB);
                }
                else
                {
                    cubeList[i].SplitAtMedian(2, out newMedianCutCubeA, out newMedianCutCubeB);
                }

                newCubes.Add(newMedianCutCubeA);
                newCubes.Add(newMedianCutCubeB);
            }


            cubeList.Clear();
            cubeList.AddRange(newCubes);
        }

        public RGB[] GetPalette(int colorCount)
        {
            cubeList.Add(new MedianCutCube(colorList));

            int iterationCount = 1;
            while ((1 << iterationCount) < colorCount) { iterationCount++; }

            for (i = 0; i < iterationCount; i++)
            {
                SplitCubes(colorCount);
            }

            RGB[] result = new RGB[cubeList.Count];

            for (i = 0; i < cubeList.Count; i++)
            {
                result[i] = cubeList[i].RGB;
                cubeList[i].SetPaletteIndex(i);
            }

            return result;
        }

        public void Clear()
        {
            cache.Clear();
            cubeList.Clear();
        }
    }
}
