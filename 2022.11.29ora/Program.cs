using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022._11._29ora
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tomb = new int[] { 4, 2, 9, 1, 7, 5, 1, 3};

            /*
            for (int i = 0; i < tomb.Length - 1; i++)
            {
                for (int j = i+1; j < tomb.Length; j++)
                {
                    if (tomb[i]>tomb[j])
                    {
                        int temp = tomb[j];
                        tomb[j] = tomb[i];
                        tomb[i] = temp;
                    }
                }
            }
            */

            //buborék rendezés

            for (int i = tomb.Length; i > 0 ; i--)
            {
                for (int j = 0; j < i-1; j++)
                {
                    if (tomb[j]>tomb[j+1])
                    {
                        int temp = tomb[j];
                        tomb[j] = tomb[j + 1];
                        tomb[j + 1] = temp;
                    }
                }
            }


            foreach (var item in tomb)
            {
                Console.Write($"{item} ");
            }

            Console.ReadKey();
        }
    }
}
