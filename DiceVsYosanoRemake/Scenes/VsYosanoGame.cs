using DxLogic;
using Graphics;
using Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceVsYosanoRemake.Scenes
{
    class VsYosanoGame : Game
    {
        private YosanoEnemy yosano;
        private Texture yosanoImage = new Texture("Resource/Yosano.jpg");

        public VsYosanoGame(int yosanoHp)
            : base()
        {
            yosano = new YosanoEnemy(yosanoImage, yosanoHp, gameField);
        }

        public override void Draw()
        {
            base.Draw();

            yosano.Draw();

            foreach(var ball in yosano.Balls)
            {
                ball.Draw();
            }
        }

        public override SceneBase<MyData> Update()
        {
            base.Update();

            yosano.Update();

            for (int i = yosano.Balls.Count - 1; i >= 0; i--)
            {
                var ball = yosano.Balls[i];

                ball.Move();

                if (!gameField.Intersects(ball.Area))
                {
                    yosano.Balls.Remove(ball);
                }
            }

            return this;
        }

        protected override void HitDecision()
        {
            foreach(var ball in yosano.Balls)
            {
                foreach(var player in players)
                {
                    if(player.Area.Intersects(ball.Area))
                    {
                        player.Hit(damage: 1);
                    }
                }
            }
        }

        protected override bool IsGameOver()
        {
            for (int i = 0; i < 2; i++)
            {
                if (players[i].Hp <= 0)
                {
                    Data.Winner = 1;

                    return true;
                }

            }


            return false;
        }
    }
}
