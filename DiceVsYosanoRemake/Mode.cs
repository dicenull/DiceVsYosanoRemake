using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceVsYosanoRemake
{
    public enum Mode
    {
        Normal = 0,
        Yosano = 1
    }

    public static class ModeEntend
    {
        public static Mode NextMode(this Mode mode)
        {
            var count = Enum.GetNames(typeof(Mode)).Length;

            return (Mode)(((int)mode + 1) % count);
        }
    }
}
