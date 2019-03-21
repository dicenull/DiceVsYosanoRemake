using System;
using DxLogic;
using DxLibUtilities;
using Utilities;
using Graphics;

namespace DiceVsYosanoRemake.Scenes
{
    class Title : SceneBase<MyData>
    {
        private Texture[] modeImages =
        {
            new Texture("Resource/TitleDice.png"),
            new Texture("Resource/TitleYosano.jpg")
        };

        private Text titleText = new Text(25);

        public Title()
            : base()
        {
            Data.GameMode = Mode.Normal;

            var defaultSize = new Vector2D(240, 240);
            foreach (var image in modeImages)
            {
                image.Scaled(defaultSize);
            }

            Data.TitleMusic = new Audio("Resource/title.mp3");
            Data.MainMusic = new Audio("Resource/main.mp3");

            Data.TitleMusic.Play(PlayType.Loop);
        }

        public override SceneBase<MyData> Update()
        {
            if (Input.Key.IsDown(ConsoleKey.Enter))
            {
                Data.TitleMusic.Stop();
                return new TwoPlayGame();
            }

            if (Input.Key.IsDown(ConsoleKey.Spacebar))
            {
                Data.GameMode = Data.GameMode.NextMode();
            }

            if (Input.Key.IsDown(ConsoleKey.Escape))
            {
                DxSystem.Exit();
                return this;
            }

            return this;
        }

        public override void Draw()
        {
            titleText.Draw("ゲームモードを選んでください", new Vector2D(120, 50), Palette.White);
            titleText.Draw("モード変更 [Space] , 開始 [Enter]", new Vector2D(100, 380), Palette.Gray);
            titleText.Draw("二人用", new Vector2D(280, 420), Palette.White);

            titleText.Draw(Data.GameMode.ToName(), new Vector2D(200, 80), Palette.White);

            modeImages[(int)Data.GameMode].DrawAt(Window.Center);
        }
    }
}
