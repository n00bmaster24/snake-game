namespace SnakeGame
{
    public class RenderBuffer
    {
        private readonly char[,] buffer;

        public RenderBuffer(int width, int height)
        {
            buffer = new char[width, height];
        }

        public void ClearBuffer()
        {
            for (int x = 0; x < buffer.GetLength(0); x++)
            {
                for (int y = 0; y < buffer.GetLength(1); y++)
                {
                    buffer[x, y] = ' ';
                }
            }
        }

        public void DrawBuffer()
        {
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < buffer.GetLength(1); y++)
            {
                for (int x = 0; x < buffer.GetLength(0); x++)
                {
                    Console.Write(buffer[x, y]);
                }

                Console.WriteLine();
            }
        }

        public void DrawElement(int x, int y, char element)
        {
            if (x >= 0 && x < buffer.GetLength(0) && y >= 0 && y < buffer.GetLength(1))
            {
                buffer[x, y] = element;
            }
        }
    }
}
