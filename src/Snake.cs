namespace SnakeGame.src
{
    public class Snake
    {
        private readonly int borderWidth;
        private readonly int borderHeight;
        private readonly RenderBuffer renderBuffer;
        private readonly List<(int x, int y)> snake;
        public (int x, int y) Head => snake.First();
        private Direction currentDirection = Direction.Right;

        public Snake(int borderWidth, int borderHeight, RenderBuffer renderBuffer)
        {
            this.borderWidth = borderWidth;
            this.borderHeight = borderHeight;
            this.renderBuffer = renderBuffer;
            snake = new()
            {
                (borderWidth / 2, borderHeight / 2)
            };
        }

        public void DrawSnake()
        {
            // Clear previous snake parts
            foreach (var (x, y) in snake)
            {
                renderBuffer.DrawElement(x, y, ' ');
            }

            // Draw snake
            foreach (var (x, y) in snake)
            {
                renderBuffer.DrawElement(x, y, '■');
            }
        }
        enum Direction { Left, Right, Up, Down }
        public void UpdateDirection()
        {
            //which class should take care of this functionality?
            Console.CursorVisible = false;
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                switch (key)
                {
                    case ConsoleKey.W:
                        if (currentDirection != Direction.Down)
                            currentDirection = Direction.Up;
                        break;
                    case ConsoleKey.S:
                        if (currentDirection != Direction.Up)
                            currentDirection = Direction.Down;
                        break;
                    case ConsoleKey.A:
                        if (currentDirection != Direction.Right)
                            currentDirection = Direction.Left;
                        break;
                    case ConsoleKey.D:
                        if (currentDirection != Direction.Left)
                            currentDirection = Direction.Right;
                        break;
                }
            }
        }

        public void Move()
        {
            //move logic to get newHeadpossition
            var head = snake.First();
            (int x, int y) newHead;
            switch (currentDirection)
            {
                case Direction.Up:
                    newHead =  (head.x, head.y - 1);
                    break;
                case Direction.Down:
                    newHead =  (head.x, head.y + 1);
                    break;
                case Direction.Left:
                    newHead =  (head.x - 1, head.y);
                    break;
                case Direction.Right:
                    newHead =  (head.x + 1, head.y);
                    break;
                default:
                    newHead =  head;
                    break;

            }
            snake.Add(newHead);
            RemoveTail();
        }
        public void Grow()
        {
            var tail = snake.Last();
            snake.Add(tail);
        }
        public bool IsBorderHit()
        {
            return snake.First().x == 0 || snake.First().y == 0 || snake.First().x == borderWidth - 1 || snake.First().y == borderHeight - 1;
        }
        public bool IsSelfBite()
        {
            foreach (var segment in snake.Skip(1))
            {
                if (segment.x == snake.First().x && segment.y == snake.First().y)
                {
                    return true;
                }
            }
            return false;
        }
        private void RemoveTail()
        {
            if (snake.Count > 1)
            {
                (int x, int y) tail = snake.Last();
                renderBuffer.DrawElement(tail.x, tail.y, ' ');
                snake.RemoveAt(0);
            }
        }
    }
}
