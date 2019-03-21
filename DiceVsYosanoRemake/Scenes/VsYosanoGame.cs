using DxLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceVsYosanoRemake.Scenes
{
    class VsYosanoGame : SceneBase<MyData>
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
    }
}
