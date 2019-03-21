using DxLibUtilities;
using Graphics;
using Utilities;

namespace DiceVsYosanoRemake
{
    public class BulletItem
    {
        public bool Enabled { get; private set; } = true;

        public Circle Area { get; private set; }

        private Rectangle respawnField { get; }
        public BulletItem(Rectangle field)
        {
            respawnField = field;
            initPosition();
        }

        private void initPosition()
        {
            int size = 4;
            var randX = Random.Next(respawnField.TopLeft.X + size, respawnField.BottomRight.X - size);
            var randY = Random.Next(respawnField.TopLeft.Y + size, respawnField.BottomRight.Y - size);
            Area = new Circle(randX, randY, size);
        }

        public void Update()
        {
            if(Enabled)
            {
                return;
            }

            if(Random.Next(200) == 1)
            {
                initPosition();
                Enabled = true;
            }
        }

        public void Draw()
        {
            if(Enabled)
            {
                Area.Draw(Palette.Yellow);
            }
        }

        public void Collect()
        {
            Enabled = false;
        }
    }
}
