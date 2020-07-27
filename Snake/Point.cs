using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point()
        {   
        }

        public Point (int xx, int yy, char ssym)
        {
            x = xx;
            y = yy;
            sym = ssym;
        }
        public Point (Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move (int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if (direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset;
            }
            else if (direction == Direction.DOWN)
            {
                y = y + offset;
            }
        }

        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }
        public void Draw()
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(sym);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.SetCursorPosition(40, 12);
                WriteGameOver();
            }
        }
        void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Автор:Непомнящих Александр", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }
        void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

        public void Clear()
        {
            sym = ' ';
            Draw();
        }
    }
}
