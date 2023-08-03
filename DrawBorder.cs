using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class DrawBorder
    {
        private int Width;
        private int Height;
        
        public DrawBorder(int consoleWidth, int consoleHeight)
        {
            Width =  consoleWidth;
            Height =  consoleHeight;
        }

        public void Draw()
        {
            Console.SetWindowSize(Width, Height);

            Console.SetCursorPosition(0, 0);
            Console.Write("╔" + new string('═', Width - 2) + "╗");

            for (int i = 1; i < Height - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("║");
                Console.SetCursorPosition(Width - 1, i);
                Console.Write("║");
            }

            Console.SetCursorPosition(0, Height - 1);
            Console.Write("╚" + new string('═', Width - 2) + "╝");

            Console.SetCursorPosition(1, 1);
        }
    }
}
