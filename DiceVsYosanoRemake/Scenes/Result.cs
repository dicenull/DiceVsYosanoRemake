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
        private Text resultText = new Text(18);

        public Result()
        {
            resultDices[Data.Winner].Scaled(3);

            Data.TitleMusic.Play(PlayType.Loop);
        }

        public override void Draw()
        {
            var names = new[] { "白", "緑" };
            resultText.Draw($"{names[Data.Winner]}DICEの勝ち！", new Vector2D(100, 100), Palette.White);
            resultText.Draw("スペースキー : 再開", new Vector2D(100, 125), Palette.White);
            resultText.Draw("エスケープキー : 終了", new Vector2D(100, 150), Palette.Lightgrey);

            resultDices[Data.Winner].DrawAt(new Vector2D(320, 240));
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
