﻿
namespace SnakeGame
{
    public class Apple
    {
        private readonly int borderWidth;
        private readonly int borderHeight;
        private Random random;
        private (int x, int y) position;

        public Apple(int borderWidth, int borderHeight)
        {
            this.borderWidth = borderWidth;
            this.borderHeight = borderHeight;
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
            position = (random.Next(1, borderWidth - 1), random.Next(1, borderHeight - 1));
        }

        public void DrawApple(RenderBuffer renderBuffer)
        {
            renderBuffer.DrawElement(position.x, position.y, '@');
        }
    }
}
