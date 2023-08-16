﻿namespace SnakeGame.src
{
    public class CollisionDetector
    {
        private readonly int borderWidth;
        private readonly int borderHeight;

        public CollisionDetector(int borderWidth, int borderHeight)
        {
            this.borderWidth = borderWidth;
            this.borderHeight = borderHeight;
        }

        public bool IsCollision((int x, int y) position)
        {
            return position.x == 0 || position.y == 0 || position.x == borderWidth - 1 || position.y == borderHeight - 1;
        }
        public bool IsSelfBite((int x, int y) head, List<(int x, int y)> body)
        {
            foreach (var segment in body)
            {
                if (segment.x == head.x && segment.y == head.y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}