namespace SnakeGame.src
{
    public class Apple
    {
        private readonly RenderBuffer renderBuffer;
        private readonly int borderWidth;
        private readonly int borderHeight;
        private Random random;
        private (int x, int y) position;

        public Apple(int borderWidth, int borderHeight, RenderBuffer renderBuffer)
        {
            this.renderBuffer = renderBuffer;
            this.borderWidth = borderWidth;
            this.borderHeight = borderHeight;
            random = new Random();
            GenerateNewPosition();
        }

        public bool IsEaten((int x, int y) snakeHead)
        {
            return snakeHead.x == position.x && snakeHead.y == position.y;
        }

        private void GenerateNewPosition()
        {
            position = (random.Next(1, borderWidth - 1), random.Next(1, borderHeight - 1));
        }
        public void GenerateNewPosition((int x, int y) snakeHead)
        {
            do
            {
                GenerateNewPosition();
            } while (position.x == snakeHead.x && position.y == snakeHead.y);
        }

        public void DrawApple()
        {
            renderBuffer.DrawElement(position.x, position.y, '@');
        }
    }
}
