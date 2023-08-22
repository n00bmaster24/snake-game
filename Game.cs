using System.Diagnostics;
using SnakeGame.src;

namespace SnakeGame
{
    public class Game
    {
        readonly int borderWidth;
        readonly int borderHeight;
        
        public Game(int borderWidth, int borderHeight)
        {
            this.borderWidth = borderWidth;
            this.borderHeight = borderHeight;
        }

        public void Run()
        {
            var border = new Border(borderWidth, borderHeight);
            var snake = new Snake();
            var apple = new Apple(borderWidth, borderHeight);
            var movement = new Movement();
            var collisionDetector = new CollisionDetector(borderWidth, borderHeight);
            var renderBuffer = new RenderBuffer(borderWidth, borderHeight);
            var gameOver = new GameOver();

            var currentPositions = new List<(int x, int y)> { snake.InitializeSnake(borderWidth, borderHeight)[0] };
            ConsoleKey initialDirection = ConsoleKey.RightArrow; 

            var frameInterval = TimeSpan.FromMilliseconds(180);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (true)
            {
                initialDirection = movement.UpdateDirection(initialDirection);

                var newHead = movement.Move(currentPositions[^1], initialDirection);

                if (collisionDetector.IsBorderHit(newHead) || collisionDetector.IsSelfBite(newHead, currentPositions))
                {
                    gameOver.PrintEndGameText();
                    break;
                }
             
                if (apple.IsEaten(newHead))
                {
                    apple.GenerateNewPosition(newHead);
                    snake.Grow(currentPositions, newHead);
                }
                else
                {
                    //only update the direction without growing
                    currentPositions.Add(newHead);
                    movement.RemoveTail(currentPositions, renderBuffer);
                }
                renderBuffer.ClearBuffer();
                
                border.DrawBorder(renderBuffer);

                snake.DrawSnake(currentPositions, renderBuffer);

                apple.DrawApple(renderBuffer);
                
                renderBuffer.DrawBuffer();
                
                stopwatch.Stop();
                var elapsed = stopwatch.Elapsed;
                stopwatch.Restart();

                // Delay if needed to maintain frame rate
                if (elapsed < frameInterval)
                {
                    Thread.Sleep(frameInterval - elapsed);
                }
            }
        }
    }
}
