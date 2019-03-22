using Graphics;
using Utilities;

namespace DiceVsYosanoRemake
{
    class HojoBall
    {
        private Texture hojoImage;
        private Vector2D movement;

        public Circle Area { get; }

        public HojoBall(Texture image, Vector2D origin, Vector2D movement)
        {
            hojoImage = image;
            this.movement = movement;

            image.Scaled(50, BasedOn.Width);

            Area = new Circle(origin, image.ScaledSize.X / 2);

            // 原点から少し離す
            Area.Center += movement * 50;
        }

        public void Draw()
        {
            hojoImage.DrawAt(Area.Center);

            Area.DrawFrame(Palette.White);
        }

        public void Move()
        {
            Area.Center += movement * 5;

            hojoImage.Rotated(1);
        }
    }
}
