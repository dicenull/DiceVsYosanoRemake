using System;

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

        public static string ToName(this Mode mode)
        {
            return mode switch
            {
                Mode.Normal => "ノーマルモード",
                Mode.Yosano => "与謝野モード",

                _ => throw new ArgumentException("存在しないモードです")
            };
        }
    }
}
