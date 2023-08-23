using System.Diagnostics;
using SnakeGame.src;

namespace SnakeGame
{
    public class Game
    {
        readonly private int borderWidth;
        readonly private int borderHeight;
        
        public Game(int borderWidth, int borderHeight)
        {
            this.borderWidth = borderWidth;
            this.borderHeight = borderHeight;
        }

        public void Run()
        {
            var renderBuffer = new RenderBuffer(borderWidth, borderHeight);
            var border = new Border(borderWidth, borderHeight, renderBuffer);
            var snake = new Snake(borderWidth, borderHeight, renderBuffer);
            var apple = new Apple(borderWidth, borderHeight, renderBuffer);
            var gameOver = new GameOver();

            var frameInterval = TimeSpan.FromMilliseconds(200);
            var stopwatch = new Stopwatch();

            while (true)
            {
                stopwatch.Start();

                snake.UpdateDirection();

                snake.Move();

                if (snake.IsBorderHit() || snake.IsSelfBite())
                {
                    gameOver.PrintEndGameText();
                    break;
                }
             
                if (apple.IsEaten(snake.Head))
                {
                    apple.GenerateNewPosition(snake.Head);
                    snake.Grow();
                }

                renderBuffer.ClearBuffer();
                
                border.DrawBorder();

                snake.DrawSnake();

                apple.DrawApple();

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
