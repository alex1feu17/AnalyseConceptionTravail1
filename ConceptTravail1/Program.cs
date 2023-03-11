using System;
using System.Collections.Generic;

namespace ConceptTravail1
{
    class Program
    {
        static void Main(string[] args)
        {
            int col;
            int row;
            var beginPoint = new Dictionary<int, int>();
            var endPoint = new Dictionary<int, int>();
            beginPoint[0] = 0;
            beginPoint[1] = 0;

            Console.WriteLine("Comment de ligne que vous voulez ?");
            row = Convert.ToInt32(Console.ReadLine());
  
            Console.WriteLine("Comment de colonne que vous voulez ?");
            col = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Votre tableau va être de taille : "+row+","+col);

            int[,] mazePrim = new int[row, col];
            endPoint[0] = row;
            endPoint[1] = col;

            Random rnd = new Random();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    mazePrim[i,j] = rnd.Next(1, 20);
                   
                }
            }
            Console.WriteLine(beginPoint[0] + " " + beginPoint[1]);
            Console.WriteLine(endPoint[0] + " " + endPoint[1]);

        }
    }
}
