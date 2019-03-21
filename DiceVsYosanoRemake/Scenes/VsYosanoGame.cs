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
            return false;
        }
    }
}
