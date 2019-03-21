using DxLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceVsYosanoRemake.Scenes
{
    class VsYosanoGame : Game
    {
        public VsYosanoGame(int yosanoHp)
            : base()
        {

        }

        public override void Draw()
        {
            
        }

        public override SceneBase<MyData> Update()
        {
            return this;
        }

        protected override void HitDecision()
        {
            
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
