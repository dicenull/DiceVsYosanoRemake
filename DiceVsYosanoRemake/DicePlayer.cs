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

        public List<Bullet> Bullets { get; private set; } = new List<Bullet>();

        public int Speed { get; set; } = 2;

        public int ShotSize { get; private set; } = 15;

        private int maxHp = 100;
        public int Hp { get; private set; }

        public Rectangle Area { get; set; }

        public void Move(Direction dir)
        {
            Area.TopLeft += dir.ToVector() * Speed;

            statusTexture = diceList[(int)dir + 1];
        }

        public void Hit(int damage)
        {
            Hp -= damage;

            if (Hp < 0) Hp = 0;
        }

        public void Draw()
        {
            statusTexture.Scaled(new Vector2D(Area.Size.w, Area.Size.h));

            statusTexture.Draw(Area.TopLeft);

            statusTexture = diceList[0];
        }

        public Color HpColor()
        {
            if(Hp > maxHp / 2)
            {
                return Palette.Blue;
            }

            if(Hp > maxHp / 4)
            {
                return Palette.Yellow;
            }

            return Palette.Red;
        }

        public void Shot()
        {
            if(Bullets.Count() != 0)
            {
                return;
            }

            // 四方向に弾を生成する
            foreach (Direction dir in Enum.GetValues(typeof(Direction)))
            {
                Bullets.Add(new Bullet(new Rectangle(Area.Center, (ShotSize, ShotSize), Location.Center), dir));
            }
        }
        
        public DicePlayer(Rectangle area, IEnumerable<Texture> diceList)
        {
            this.diceList = diceList.ToList();
            this.damagedDice = diceList.Last();

            this.diceList.Remove(damagedDice);

            Area = area;

            // 状態を初期化
            statusTexture = this.diceList[0];

            Hp = maxHp;
        }
    }
}
