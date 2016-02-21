using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLL
{
    public interface ITransform
    {
        void Transform(int Width, int Height, int offsetX, int offsetY, int angle);
        void BilinearInterpolationTransform(int Width, int Height, int offsetX, int offsetY, int angle);
        void LinearInterpolationTransform(int Width, int Height, int offsetX, int offsetY, int angle);
    }
}
