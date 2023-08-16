
namespace SnakeGame
{
    public class Apple
    {
        private readonly int BorderWidth;
        private readonly int BorderHeight;
        private Random random;
        private (int x, int y) position;

        public Apple(int borderWidth, int borderHeight)
        {
            BorderWidth = borderWidth;
            BorderHeight = borderHeight;
            random = new Random();
            GenerateNewPosition();
        }

        public (int x, int y) GetPosition()
        {
            return position;
        }

        public bool IsEaten((int x, int y) snakeHead)
        {
            return snakeHead.x == position.x && snakeHead.y == position.y;
        }

        public void GenerateNewPosition()
        {
            position = (random.Next(1, BorderWidth - 1), random.Next(1, BorderHeight - 1));
        }

        public void DrawApple(RenderBuffer renderBuffer)
        {
            renderBuffer.DrawElement(position.x, position.y, '@');
        }
    }
}
