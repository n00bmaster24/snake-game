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
        private int width;
        private int height;
        
        public DrawBorder(int consoleWidth, int consoleHeight)
        {
            width =  consoleWidth;
            height =  consoleHeight;
        }

        public void Draw()
        {
            Console.SetWindowSize(width, height);

            Console.SetCursorPosition(0, 0);
            Console.Write("╔" + new string('═', width - 2) + "╗");

            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("║");
                Console.SetCursorPosition(width - 1, i);
                Console.Write("║");
            }

            Console.SetCursorPosition(0, height - 1);
            Console.Write("╚" + new string('═', width - 2) + "╝");

            Console.SetCursorPosition(1, 1);
        }
    }
}
