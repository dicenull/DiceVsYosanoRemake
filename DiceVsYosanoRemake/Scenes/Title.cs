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
            new Texture("TitleDice.png"),
            new Texture("TitleYosano.jpg")
        };

        public Title()
            : base()
        {
            Data.GameMode = Mode.Normal;

            var defaultSize = new Vector2D(240, 240);
            foreach (var image in modeImages)
            {
                image.Scaled(defaultSize);
            }
        }

        public override SceneBase<MyData> Update()
        {
            if (Input.Key.IsDown(ConsoleKey.Enter))
            {
                return new Game();
            }

            if (Input.Key.IsDown(ConsoleKey.Spacebar))
            {
                Data.GameMode = Data.GameMode.NextMode();
            }

            return this;
        }

        public override void Draw()
        {
            modeImages[(int)Data.GameMode].DrawAt(Window.Center);
        }
    }
}
