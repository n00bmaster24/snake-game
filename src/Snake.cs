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

        public void Move()
        {
            UpdateDirection();
            UpdateCoordinates();
        }

        enum Direction { Left, Right, Up, Down }
        private void UpdateDirection()
        {
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

        private void UpdateCoordinates()
        {
            (int x, int y) newHead;
            switch (currentDirection)
            {
                case Direction.Up:
                    newHead = (Head.x, Head.y - 1);
                    break;
                case Direction.Down:
                    newHead = (Head.x, Head.y + 1);
                    break;
                case Direction.Left:
                    newHead = (Head.x - 1, Head.y);
                    break;
                case Direction.Right:
                    newHead = (Head.x + 1, Head.y);
                    break;
                default:
                    newHead = Head;
                    break;
            }
            snake.Insert(0, newHead);
            RemoveTail();
        }

        public void Grow()
        {
            var tail = snake.Last();
            snake.Add(tail);
        }
        public bool IsBorderHit()
        {
            return Head.x == 0 || Head.y == 0 || Head.x == borderWidth - 1 || Head.y == borderHeight - 1;
        }
        public bool IsSelfBite()
        {
            return snake.Skip(1).Any(segment => segment.x == Head.x && segment.y == Head.y);
        }
        private void RemoveTail()
        {
            if (snake.Count > 1)
            {
                (int x, int y) tail = snake.Last();
                renderBuffer.DrawElement(tail.x, tail.y, ' ');
                snake.Remove(tail);
            }
        }
    }
}
