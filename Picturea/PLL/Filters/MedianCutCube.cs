using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PLL
{
    internal class MedianCutCube
    {
        private byte redLowBound;
        private byte redHighBound;

        private byte greenLowBound;
        private byte greenHighBound;

        private byte blueLowBound;
        private byte blueHighBound;

        private RGB[] colorList;

        public int PaletteIndex { get; private set; }

        public MedianCutCube(RGB[] colors)
        {
            colorList = colors;
            Shrink();
        }

        public int RedSize
        {
            get { return redHighBound - redLowBound; }
        }

        public int GreenSize
        {
            get { return greenHighBound - greenLowBound; }
        }

        public int BlueSize
        {
            get { return blueHighBound - blueLowBound; }
        }

        public RGB RGB
        {
            get
            {
                int countColorList = colorList.Length;
                int red = 0, green = 0, blue = 0;
                for (int i = 0; i < countColorList; i++)
                {
                    red += colorList[i].R;
                    green += colorList[i].G;
                    blue += colorList[i].B;
                }

                red = countColorList == 0 ? 0 : red / countColorList;
                green = countColorList == 0 ? 0 : green / countColorList;
                blue = countColorList == 0 ? 0 : blue / countColorList;

                return new RGB((byte)red, (byte)green, (byte)blue);
            }
        }

        private void Shrink()
        {
            redLowBound = greenLowBound = blueLowBound = 255;
            redHighBound = greenHighBound = blueHighBound = 0;
            int countColorList = colorList.Length;
            for (int i = 0; i < countColorList; i++)
            {
                if (colorList[i].R < redLowBound) redLowBound = colorList[i].R;
                if (colorList[i].R > redHighBound) redHighBound = colorList[i].R;
                if (colorList[i].G < greenLowBound) greenLowBound = colorList[i].G;
                if (colorList[i].G > greenHighBound) greenHighBound = colorList[i].G;
                if (colorList[i].B < blueLowBound) blueLowBound = colorList[i].B;
                if (colorList[i].B > blueHighBound) blueHighBound = colorList[i].B;
            }

        }

        public void SplitAtMedian(byte componentIndex, out MedianCutCube firstMedianCutCube, out MedianCutCube secondMedianCutCube)
        {
            List<RGB> colors;

            switch (componentIndex)
            {
                case 0:
                    colors = colorList.OrderBy(color => color.R).ToList();
                    break;

                case 1:
                    colors = colorList.OrderBy(color => color.G).ToList();
                    break;

                case 2:
                    colors = colorList.OrderBy(color => color.B).ToList();
                    break;

                default:
                    throw new NotSupportedException("Не RGB");
            }

            int medianIndex = colorList.Length >> 1;

            firstMedianCutCube = new MedianCutCube(colors.GetRange(0, medianIndex).ToArray());
            secondMedianCutCube = new MedianCutCube(colors.GetRange(medianIndex, colors.Count - medianIndex).ToArray());
        }

        public void SetPaletteIndex(int newPaletteIndex)
        {
            PaletteIndex = newPaletteIndex;
        }

        public bool IsColorIn(RGB color)
        {
            return (color.R >= redLowBound && color.R <= redHighBound) &&
                   (color.G >= greenLowBound && color.G <= greenHighBound) &&
                   (color.B >= blueLowBound && color.B <= blueHighBound);
        }
    }
}
