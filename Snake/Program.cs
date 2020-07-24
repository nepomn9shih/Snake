using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numList = new List<int>();
            numList.Add(0);
            numList.Add(1);
            numList.Add(2);

            int x = numList[0];
            int y = numList[1];
            int z = numList[2];

            foreach(int i in numList)
            {
                Console.WriteLine(i); 
            }

            numList.RemoveAt(0);

            Point p1 = new Point(1, 3, '*');
            Point p2 = new Point(4, 5, '#');

            List<Point> pList = new List<Point>();
            pList.Add(p1);
            pList.Add(p2);

            foreach (Point j in pList)
            {
                j.Draw();
            }

            Console.ReadLine();
        }
    }
}
