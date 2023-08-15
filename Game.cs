namespace SnakeGame
{
    public class Game
    {
        int borderWidth;
        int borderHeight;
        public Game(int borderWidth, int borderHeight)
        {
            this.borderWidth = borderWidth;
            this.borderHeight = borderHeight;
        }

        public void Run()
        {
            var border = new DrawBorder(borderWidth, borderHeight);
            var snake = new Snake();
            var apple = new Apple(borderWidth, borderHeight);
            var movement = new Movement();
            var collisionDetector = new CollisionDetector(borderWidth, borderHeight);

            var currentPositions = new List<(int x, int y)> { snake.InitializeSnake(borderWidth, borderHeight)[0] };
            ConsoleKey direction = ConsoleKey.RightArrow; // Initial direction

            while (true)
            {
                direction = movement.UpdateDirection(direction);

                // Move the snake
                var newHead = movement.Move(currentPositions[^1], direction);

                // Check if the snake hits the border
                if (collisionDetector.IsCollision(newHead))
                {
                    Console.Clear();
                    Console.WriteLine("Game Over! Snake hit the border.");
                    break;
                }
                // Check if the snake bites its own tail
                if (collisionDetector.IsSelfBite(newHead, currentPositions))
                {
                    Console.Clear();
                    Console.WriteLine("Game Over! Snake bit its own tail.");
                    break;
                }

                // Check if the snake eats the apple
                if (apple.IsEaten(newHead))
                {
                    apple.GenerateNewPosition();
                    // Grow the snake
                    currentPositions.Insert(1, newHead);
                }
                else
                {
                    // Remove the tail
                    movement.RemoveTail(currentPositions);
                }
                 border.Draw();
                // Draw the snake
                snake.DrawSnake(currentPositions);

                // Add the new head position
                currentPositions.Add(newHead);

                // Draw the apple
                apple.DrawApple();

                Thread.Sleep(180);
            }
        }
    }
}
