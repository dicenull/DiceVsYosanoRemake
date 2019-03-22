using System;
using DxLogic;
using Graphics;
using System.Linq;
using DxLibUtilities;
using System.Collections.Generic;
using Utilities;

using Rnd = DxLibUtilities.Random;

namespace DiceVsYosanoRemake
{
    class YosanoEnemy : CharacterBase<Circle>
    {
        private Texture drawImage;

        private Texture yosanoImage;
        private Texture damageImage;
        private Texture hojoImage = new Texture("Resource/Hojo.jpg");
        private Rectangle field;

        private bool canShot;
        private Vector2D movement;
        private int rotation;

        public List<HojoBall> Balls { get; private set; } = new List<HojoBall>();

        public YosanoEnemy(Texture image, Texture damage, int hp, Rectangle gameField)
        {
            yosanoImage = image;
            damageImage = damage;
            drawImage = yosanoImage;

            Hp = hp;
            field = gameField;

            initStatus();
        }

        private void initStatus()
        {
            var pos = field.BottomRight + new Vector2D(Rnd.Next(100), Rnd.Next(100));
            var radius = Rnd.Next(40, 100);

            Area = new Circle(pos, radius);
            yosanoImage.Scaled(Area.Radius * 2 + 10, BasedOn.Width);
            damageImage.Scaled(Area.Radius * 2 + 10, BasedOn.Width);


            movement = new Vector2D(Rnd.Next(1, 4), Rnd.Next(1, 4));
            rotation = Rnd.Next(-10, 10);

            canShot = true;
        }

        public void Hit(int damage)
        {
            Hp -= damage;

            if (Hp < 0) Hp = 0;

            drawImage = damageImage;
        }

        public void Update()
        {
            Area.Center -= movement;
            yosanoImage.Rotated(rotation);
            damageImage.Rotated(rotation);
            
            // 画面外に行ったら再配置
            if(    Area.Center.X < field.TopLeft.X 
                || Area.Center.Y < field.TopLeft.Y)
            {
                initStatus();
            }

            // 画面の中心付近で弾を発射
            if(    Area.Center.X < field.Center.X
                || Area.Center.Y < field.Center.Y)
            {
                Shot();    
            }
        }

        public void Shot()
        {
            if(Balls.Count != 0 || !canShot)
            {
                return;
            }
            canShot = false;

            var moves = new[]
            {
                new Vector2D(-1, 0), new Vector2D(-1, -1), new Vector2D(0, -1), new Vector2D(1, -1),
                new Vector2D(1, 0), new Vector2D(1, 1), new Vector2D(0, 1), new Vector2D(-1, 1)
            };
            foreach(var move in moves)
            {
                Balls.Add(new HojoBall(hojoImage, Area.Center, move));
            }
        }

        public override void Draw()
        {
            drawImage.DrawAt(Area.Center);
            drawImage = yosanoImage;

            Area.DrawFrame(Palette.White);
        }
    }
}
