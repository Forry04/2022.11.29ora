using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace _2022._11._29ora
{
    class Program
    {
        static List<int> tomb = new List<int>();
        static void Main(string[] args)
        {

            Console.WriteLine(
                "[1] Egyszerű cserés rendezés\n"+
                "[2] Buborék rendezés\n"+
                "[3] Fejlesztett buborék rendezés\n"+
                "[4] Beszúrásos rendezés\n"+
                "[5] Fejlesztett beszúrásos rendezés\n"+
                "[6] Minimum kereséses rendezés\n"+
                "[7] Maximum kereséses rendezés"
                );

            Console.Write("Választás: ");
            int valasz= Convert.ToInt32(Console.ReadLine());

            BeOlvasas();


            switch (valasz)
            {
                case 1:
                    EgyszeruCseresRendezes();
                    break;
                case 2:
                    BuborekRendezes();
                    break ;
                case 3:
                    TovabbFejlesztettBuborekRendezes();
                    break;

                case 4:
                    BeszuroRendezes();
                    break;

                case 5:
                    TovabbFejlesztettBeszuroRendezes();
                    break;

                case 6:
                    MinimumKivalasztasosRendezes();
                    break;
                case 7:
                    MaximumKivalasztasosRendezes();
                    break;

                default:
                    Console.WriteLine($"{valasz}: Nincs ilyen lehtőség");
                    break;
            }

            KiIras();


            Console.ReadKey();
        }
        static void EgyszeruCseresRendezes()
        { 
            for (int i = 0; i < tomb.Count - 1; i++)
            {
                for (int j = i+1; j < tomb.Count; j++)
                {
                    if (tomb[i]>tomb[j])
                    {
                        int temp = tomb[j];
                        tomb[j] = tomb[i];
                        tomb[i] = temp;
                    }
                }
            }
        }

        static void BuborekRendezes() 
        {
            for (int i = tomb.Count; i > 0 ; i--)
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
        }

        static void TovabbFejlesztettBuborekRendezes()
        {
            int i = tomb.Count-1;
            int csere;
            int temp;

            while (i>=1)
            {
                csere = -1;

                for (int j = 0; j <= i-1; j++)
                {
                    if (tomb[j] > tomb[j+1])
                    {
                        temp = tomb[j];
                        tomb[j] = tomb[j + 1];
                        tomb[j + 1] = temp;
                        csere = j;
                    }
                }
                i = csere;
            }
        }

        static void BeszuroRendezes()
        {
            for (int i = 1; i < tomb.Count; i++)
            {
                int j = i - 1;
                while (j>=0 && tomb[j] > tomb[j+1])
                {
                    int temp = tomb[j];
                    tomb[j] = tomb[j + 1];
                    tomb[j + 1] = temp;
                    j--;

                }
            }
        }

        static void TovabbFejlesztettBeszuroRendezes()
        {
            for (int i = 1; i < tomb.Count; i++)
            {
                int j = i - 1;
                int temp = tomb[i];

                while (j>=0 && tomb[j] > temp)
                {
                    tomb[j + 1] = tomb[j];
                    j--;

                }
                tomb[j + 1] = temp;
            }
        }

        static void MinimumKivalasztasosRendezes()
        {
            for (int i = 0; i < tomb.Count-1; i++)
            {
                int min = i;
                for (int j = i+1; j < tomb.Count; j++)
                {
                    if (tomb[min] > tomb[j])
                    {
                        min = j;
                    }
                }
                int temp= tomb[i];
                tomb[i] = tomb[min];
                tomb[min] = temp;
            }
        }

        static void MaximumKivalasztasosRendezes() { 
            for (int i = tomb.Count-1; i > 0; i--)
            {
                int max = 0;
                for (int j = 0; j < i; j++)
                {
                    if (tomb[max] < tomb[j])
                    {
                        max = j;
                    }
                }
                int temp = tomb[max];
                tomb[max] = tomb[i];
                tomb[i] = temp;
            }

        }

        static void KiIras()
        {
            foreach (var item in tomb)
            {
                Console.Write($"{item} ");
            }

        }
        
        static void BeOlvasas()
        {
            StreamReader be = new StreamReader("szamok.txt");

            while (!be.EndOfStream)
            {
                tomb.Add(Convert.ToInt32(be.ReadLine()));
                
            }
            be.Close();
        }  

    }
}
