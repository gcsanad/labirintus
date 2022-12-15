using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[,] tomb = new byte[10, 20];

            for (int sor = 0; sor < tomb.GetLength(0); sor++)
            {
                for (int oszlop = 0; oszlop < tomb.GetLength(0); oszlop++)
                {
                    tomb[sor, oszlop] = 0;
                }
            }

            char merre = Convert.ToChar(Console.ReadLine());
            string holVagyok = Console.ReadLine();


            do
            {
                merre = Convert.ToChar(Console.ReadLine());
                holVagyok = Console.ReadLine();
                Console.Clear();
                for (int sor = 0; sor < tomb.GetLength(0); sor++)
                {
                    for (int oszlop = 0; oszlop < tomb.GetLength(1); oszlop++)
                    {
                        if (oszlop== Convert.ToInt32(holVagyok.Split(',')[1])&& sor==Convert.ToInt32(holVagyok.Split(',')[0]))
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(tomb[sor, oszlop]);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.Write(tomb[sor, oszlop]);
                        }
                        
                    }
                    Console.WriteLine();
                }

                switch (merre)
                {
                    case 'f':
                        break;
                    case 'l':
                        holVagyok = holVagyok.Split(',')[0] + Convert.ToString(Convert.ToInt32(holVagyok.Split(',')[1]+1));
                        break;
                    default:
                        break;
                }
            } while (true);


        }
    }
}
