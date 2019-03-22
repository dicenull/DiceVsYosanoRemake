using System;
using DxLogic;
using Graphics;
using System.Linq;
using DxLibUtilities;
using Utilities;

using Rnd = DxLibUtilities.Random;

namespace DiceVsYosanoRemake
{
    class YosanoEnemy : CharacterBase<Circle>
    {
        private Texture yosanoImage;
        private Rectangle field;

        private Vector2D movement;
        private int rotation;

        public YosanoEnemy(Texture image, int hp, Rectangle gameField)
        {
            yosanoImage = image;
            Hp = hp;
            field = gameField;

            initStatus();
        }

        private void initStatus()
        {
            var pos = field.BottomRight + new Vector2D(Rnd.Next(100), Rnd.Next(100));
            var radius = Rnd.Next(40, 100);

            Area = new Circle(pos, radius);
            yosanoImage.Scaled(Area.Radius * 2, BasedOn.Width);


            movement = new Vector2D(Rnd.Next(1, 4), Rnd.Next(1, 4));
            rotation = Rnd.Next(-10, 10);
        }

        public void Update()
        {
            Area.Center -= movement;
            yosanoImage.Rotated(rotation);

            if(    Area.Center.X < field.TopLeft.X 
                || Area.Center.Y < field.TopLeft.Y)
            {
                initStatus();
            }
        }

        public override void Draw()
        {
            yosanoImage.DrawAt(Area.Center);

            Area.DrawFrame(Palette.White);
        }
    }
}
