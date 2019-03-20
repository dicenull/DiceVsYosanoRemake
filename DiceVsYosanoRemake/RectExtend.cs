using Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceVsYosanoRemake
{
    public static class RectExtend
    {
        public static bool Contains(this Rectangle r1, Rectangle r2)
        {
            return r1.TopLeft.X <= r2.TopLeft.X
                && r1.TopLeft.Y <= r2.TopLeft.Y
                && r2.BottomRight.X <= r1.BottomRight.X
                && r2.BottomRight.Y <= r1.BottomRight.Y;
        }
    }
}
