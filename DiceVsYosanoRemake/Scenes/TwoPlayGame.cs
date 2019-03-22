using System;
using DxLogic;
using Graphics;
using System.Linq;
using DxLibUtilities;
using Utilities;

namespace DiceVsYosanoRemake.Scenes
{
    class TwoPlayGame : Game
    {
        public TwoPlayGame()
            : base(new Vector2D(600, 400), new Vector2D(100, 100))
        { }

        protected override void HitDecision()
        {
            for(int i = 0;i < 2;i++)
            {
                // 相手の弾にあたっていたらダメージ
                int flip = 1 - i;
                foreach (var bullet in players[flip].Bullets)
                {
                    if (players[i].Area.Intersects(bullet.Area))
                    {
                        players[i].Hit(damage: 1);
                    }
                }
            }
        }

        protected override bool IsGameOver()
        {
            for(int i = 0;i < 2;i++)
            {
                if (players[i].Hp <= 0)
                {
                    int other = 1 - i;
                    Data.Winner = other;

                    return true;
                }

            }

            return false;
        }
    }
}
