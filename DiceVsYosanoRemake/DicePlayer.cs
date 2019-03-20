using Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DiceVsYosanoRemake
{
    public class DicePlayer
    {
        private List<Texture> diceList;
        private Texture damagedDice;

        private Texture statusTexture;

        public int Speed { get; set; } = 2;

        public Rectangle Area { get; set; }

        public void Move(Direction dir)
        {
            Area.TopLeft += dir.ToVector() * Speed;

            statusTexture = diceList[(int)dir + 1];
        }

        public void Draw()
        {
            statusTexture.Scaled(new Vector2D(Area.Size.w, Area.Size.h));

            statusTexture.Draw(Area.TopLeft);

            statusTexture = diceList[0];
        }
        
        public DicePlayer(Rectangle area, IEnumerable<Texture> diceList)
        {
            this.diceList = diceList.ToList();
            this.damagedDice = diceList.Last();

            this.diceList.Remove(damagedDice);

            Area = area;

            // 状態を初期化
            statusTexture = this.diceList[0];
        }
    }
}
