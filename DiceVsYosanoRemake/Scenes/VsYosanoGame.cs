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
        }

        public override SceneBase<MyData> Update()
        {
            base.Update();

            yosano.Update();

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
