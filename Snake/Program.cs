using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;

            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();
            
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key); 
                }
                Thread.Sleep(100);
                snake.Move();
            }

            WriteGameOver();
            Console.ReadLine();

            void WriteGameOver()
            {
                int xOffset = 25;
                int yOffset = 8;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(xOffset, yOffset++);
                WriteText("============================", xOffset, yOffset++);
                WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
                yOffset++;
                WriteText("Автор: Непомнящих Александр", xOffset + 2, yOffset++);
                WriteText("============================", xOffset, yOffset++);
            }

            void WriteText(String text, int xOffset, int yOffset)
            {
                Console.SetCursorPosition(xOffset, yOffset);
                Console.WriteLine(text);
            }
        }
    }
}
