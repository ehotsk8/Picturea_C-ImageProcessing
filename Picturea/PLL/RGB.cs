using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLL
{
    public class RGB
    {
        /// <summary>
        /// Красный
        /// </summary>
        public byte R { get; set; }

        /// <summary>
        /// Зеленый
        /// </summary>
        public byte G { get; set; }

        /// <summary>
        /// Синий
        /// </summary>
        public byte B { get; set; }

        /// <summary>
        /// Прозрачность
        /// </summary>
        public byte A { get; set; }

        public RGB() { }

        /// <summary>
        /// Цвет в RGB
        /// </summary>
        /// <param name="R"></param>
        /// <param name="G"></param>
        /// <param name="B"></param>
        public RGB(byte R, byte G, byte B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }

        /// <summary>
        /// Цвет в RGBA
        /// </summary>
        /// <param name="R"></param>
        /// <param name="G"></param>
        /// <param name="B"></param>
        /// <param name="A"></param>
        public RGB(byte R, byte G, byte B, byte A)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = A;
        }

        public override string ToString()
        {
            return "R: " + R + " G: " + G + " B: " + B;
        }
    }
}
