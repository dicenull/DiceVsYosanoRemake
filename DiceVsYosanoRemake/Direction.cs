using Utilities;

namespace DiceVsYosanoRemake
{
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

    public static class DirectionExtend
    {
        public static Vector2D ToVector(this Direction dir)
        {
            return dir switch
            {
                Direction.Up => new Vector2D(0, -1),
                Direction.Right => new Vector2D(1, 0),
                Direction.Down => new Vector2D(0, 1),
                Direction.Left => new Vector2D(-1, 0)
            };
        }
    }
}
