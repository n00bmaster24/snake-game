using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGame
{
    public class Movement
    {
        public ConsoleKey UpdateDirection(ConsoleKey currentDirection)
        {
            Console.CursorVisible = false;
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                switch (key)
                {
                    case ConsoleKey.W:
                        if (currentDirection != ConsoleKey.DownArrow)
                            return ConsoleKey.UpArrow;
                        break;
                    case ConsoleKey.S:
                        if (currentDirection != ConsoleKey.UpArrow)
                            return ConsoleKey.DownArrow;
                        break;
                    case ConsoleKey.A:
                        if (currentDirection != ConsoleKey.RightArrow)
                            return ConsoleKey.LeftArrow;
                        break;
                    case ConsoleKey.D:
                        if (currentDirection != ConsoleKey.LeftArrow)
                            return ConsoleKey.RightArrow;
                        break;
                }
            }

            return currentDirection;
        }
        public (int x, int y) Move((int x, int y) head, ConsoleKey direction)
        {
            switch (direction)
            {
                case ConsoleKey.UpArrow:
                    return (head.x, head.y - 1);
                case ConsoleKey.DownArrow:
                    return (head.x, head.y + 1);
                case ConsoleKey.LeftArrow:
                    return (head.x - 1, head.y);
                case ConsoleKey.RightArrow:
                    return (head.x + 1, head.y);
                default:
                    return head;
            }
        }
        public void RemoveTail(List<(int x, int y)> currentPositions)
        {
            if (currentPositions.Count > 1)
            {
                (int x, int y) tail = currentPositions[0];
                Console.SetCursorPosition(tail.x, tail.y);
                Console.Write(" ");
                currentPositions.RemoveAt(0);
            }
        }
    }
}
