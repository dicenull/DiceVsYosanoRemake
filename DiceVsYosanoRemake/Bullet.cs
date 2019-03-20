using Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DiceVsYosanoRemake
{
    public class Bullet
    {
        private Direction moveDir;

        public Rectangle Area { get; }

        public int Speed { get; set; } = 4;

        public Vector2D Position { get { return Area.Center; } }

        public Color Color { get; }

        public void Draw()
        {
            Area.Draw(Color);
        }

        public void Move()
        {
            Area.MoveBy(moveDir.ToVector() * Speed);
        }

        public Bullet(Rectangle area, Direction moveDir, Color color)
        {
            Area = area;
            this.moveDir = moveDir;
            Color = color;
        }
    }
}
