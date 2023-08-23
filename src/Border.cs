namespace SnakeGame.src
{
    public class Border
    {
        private readonly int width;
        private readonly int height;
        private readonly RenderBuffer renderBuffer;

        public Border(int consoleWidth, int consoleHeight, RenderBuffer renderBuffer)
        {
            width = consoleWidth;
            height = consoleHeight;
            this.renderBuffer = renderBuffer;
        }

        public void DrawBorder()
        {
            for (int x = 0; x < width; x++)
            {
                renderBuffer.DrawElement(x, 0, '═');
                renderBuffer.DrawElement(x, height - 1, '═');
            }

            for (int y = 1; y < height - 1; y++)
            {
                renderBuffer.DrawElement(0, y, '║');
                renderBuffer.DrawElement(width - 1, y, '║');
            }

            renderBuffer.DrawElement(0, 0, '╔');
            renderBuffer.DrawElement(width - 1, 0, '╗');
            renderBuffer.DrawElement(0, height - 1, '╚');
            renderBuffer.DrawElement(width - 1, height - 1, '╝');
        }
    }
}
