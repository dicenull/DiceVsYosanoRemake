using DxLibUtilities;
using DxLogic;
using Graphics;
using System;
using Utilities;

namespace DiceVsYosanoRemake.Scenes
{
    class Result : SceneBase<MyData>
    {
        private Texture[] resultDices =
        {
            new Texture("Resource/ResultDice1.png"),
            new Texture("Resource/ResultDice2.png")
        };
        private Texture yosano = new Texture("Resource/Yosano.jpg");
        private Text resultText = new Text(18);

        public Result()
        {
            resultDices[Data.Winner].Scaled(3);

            yosano.Scaled(200, BasedOn.Height);

            Data.TitleMusic.Play(PlayType.Loop);
        }

        public override void Draw()
        {
            if(Data.GameMode == Mode.Normal)
            {
                var names = new[] { "白", "緑" };
                resultText.Draw($"{names[Data.Winner]}DICEの勝ち！", new Vector2D(100, 100), Palette.White);

                resultDices[Data.Winner].DrawAt(Window.Center);
            }
            else
            {
                string name;
                if(Data.Winner == 0)
                {
                    name = "DICEの勝ち！";

                    resultDices[0].DrawAt(Window.Center);
                }
                else
                {
                    name = "与謝野の勝ち！";

                    yosano.DrawAt(Window.Center + new Vector2D(0, 100));
                }

                resultText.Draw(name, new Vector2D(100, 100), Palette.White);
            }

            resultText.Draw("スペースキー : 再開", new Vector2D(100, 125), Palette.White);
            resultText.Draw("エスケープキー : 終了", new Vector2D(100, 150), Palette.Lightgrey);
        }

        public override SceneBase<MyData> Update()
        {
            if(Input.Key.IsDown(ConsoleKey.Spacebar))
            {
                Data.TitleMusic.Stop();
                return new Title();
            }

            if(Input.Key.IsDown(ConsoleKey.Escape))
            {
                DxSystem.Exit();
                return this;
            }

            return this;
        }
    }
}
