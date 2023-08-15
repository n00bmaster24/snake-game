namespace SnakeGame
{
    public class Snake
    {
        public List<(int x, int y)> InitializeSnake(int borderWidth, int borderHeight)
        {
            List<(int x, int y)> snake = new List<(int x, int y)>
            {
                (borderWidth / 2, borderHeight / 2)
            };
            return snake;
        }

        public (int x, int y) DrawSnake(List<(int x, int y)> snake)
        {
            (int x, int y) head = snake[^1]; // Using index to get the last element
            snake.Add(head);

            // Erase the tail
            if (snake.Count > 1)
            {
                (int x, int y) tail = snake[0]; // Using index to get the first element
                Console.SetCursorPosition(tail.x, tail.y);
                Console.Write(" ");
                snake.RemoveAt(0);
            }

            // Draw the snake
            Console.SetCursorPosition(head.x, head.y);
            Console.Write("■");

            return head;
        }
    }
}
