namespace SnakeGame.src
{
    public class Snake
    {
        public List<(int x, int y)> InitializeSnake(int borderWidth, int borderHeight)
        {
            List<(int x, int y)> snake = new()
            {
                (borderWidth / 2, borderHeight / 2)
            };
            return snake;
        }

        public void DrawSnake(List<(int x, int y)> snake, RenderBuffer renderBuffer)
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

        public void Grow(List<(int x, int y)> snake, (int x, int y) newHead)
        {
            snake.Insert(1, newHead);
        }
    }
}
