using DxLibUtilities;
using DxLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DiceVsYosanoRemake.Scenes
{
    class YosanoHpInput : SceneBase<MyData>
    {
        private Text text = new Text(18);
        private Text hpText = new Text(40);
        private int yosanoHp = 100;

        public override void Draw()
        {
            text.Draw("与謝野モード突入!! HPを入力!", new Vector2D(200, 140), Palette.White);
            text.Draw("簡単:～100, 普通:100～500, 難しい:500～", new Vector2D(100, 340), Palette.White);

            hpText.Draw($"{yosanoHp}", Window.Center, Palette.Yellowgreen);
        }

        public override SceneBase<MyData> Update()
        {
            if(Input.Key.IsDown(ConsoleKey.Enter))
            {
                return new VsYosanoGame(yosanoHp);
            }

            if(Input.Key.IsDown(ConsoleKey.UpArrow))
            {
                yosanoHp += 100;
            }

            if(Input.Key.IsDown(ConsoleKey.DownArrow))
            {
                yosanoHp -= 100;
            }

            yosanoHp = clamp(yosanoHp, 100, 1000);

            return this;
        }

        private int clamp(int value, int min, int max)
        {
            if(value < min)
            {
                return min;
            }

            if(value > max)
            {
                return max;
            }

            return value;
        }
    }
}
