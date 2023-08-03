using SnakeGame;

int borderWidth = 40; 
int borderHeight = 20; 

var border = new DrawBorder(borderWidth, borderHeight);
border.Draw();
// Snake initialization
List<(int, int)> snake = new List<(int, int)>
        {
            (borderWidth / 2, borderHeight / 2) 
        };
ConsoleKey direction = ConsoleKey.RightArrow; // Initial direction

while (true)
{
    if (Console.KeyAvailable)
    {
        var key = Console.ReadKey(intercept: true).Key;
        switch (key)
        {
            case ConsoleKey.W:
                if (direction != ConsoleKey.DownArrow)
                    direction = ConsoleKey.UpArrow;
                break;
            case ConsoleKey.S:
                if (direction != ConsoleKey.UpArrow)
                    direction = ConsoleKey.DownArrow;
                break;
            case ConsoleKey.A:
                if (direction != ConsoleKey.RightArrow)
                    direction = ConsoleKey.LeftArrow;
                break;
            case ConsoleKey.D:
                if (direction != ConsoleKey.LeftArrow)
                    direction = ConsoleKey.RightArrow;
                break;
        }
    }

    // Move the snake
    (int x, int y) head = snake.Last();
    switch (direction)
    {
        case ConsoleKey.UpArrow:
            head = (head.x, head.y - 1);
            break;
        case ConsoleKey.DownArrow:
            head = (head.x, head.y + 1);
            break;
        case ConsoleKey.LeftArrow:
            head = (head.x - 1, head.y);
            break;
        case ConsoleKey.RightArrow:
            head = (head.x + 1, head.y);
            break;
    }

    // Check if the snake hits the border
    if (head.x == 0 || head.y == 0 || head.x == borderWidth - 1 || head.y == borderHeight - 1)
    {
        Console.Clear();
        Console.WriteLine("Game Over! Snake hit the border.");
        break;
    }

    snake.Add(head);

    // Erase the tail
    if (snake.Count > 1)
    {
        (int x, int y) tail = snake.First();
        Console.SetCursorPosition(tail.Item1, tail.Item2);
        Console.Write(" ");
        snake.RemoveAt(0);
    };

    Console.Write(" ");

    // Draw the snake
    Console.SetCursorPosition(head.x, head.y);
    Console.Write("S");

    Thread.Sleep(150);
}
