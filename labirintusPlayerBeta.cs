using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static char[,] Betoltes(string palyaNeve = "teszt.txt")
        {
            string[] megnyitas = File.ReadAllLines(palyaNeve);
            char[,] labirintus = new char[megnyitas.Length, megnyitas[0].Length];
            for (int sorIndex = 0; sorIndex < labirintus.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < labirintus.GetLength(1); oszlopIndex++)
                {
                    labirintus[sorIndex, oszlopIndex] = megnyitas[sorIndex][oszlopIndex];

                }
            }

            for (int sorIndex = 0; sorIndex < labirintus.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < labirintus.GetLength(1); oszlopIndex++)
                {
                    Console.Write(labirintus[sorIndex, oszlopIndex]); 


                }
                Console.WriteLine();
            }

            return labirintus;
        }

        static void Main(string[] args)
        {
            Betoltes();
            Console.SetCursorPosition(1, 0);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(5, 23);
            char mozgas;
            
            do
            {
                Console.Clear();
                Betoltes();
                
                Console.Write("Északra(w)\nKeletre(d)\nDélre(s)\nNyugatra(a)\n(K)ilépés");
                mozgas = Console.ReadKey().KeyChar;
                switch (mozgas)
                {
                    case 'w':

                        break;
                    case 'd':
                        break;
                    case 's':
                        break;
                    case 'a':
                        break;
                    case 'k':
                        Environment.Exit(0);
                        break;
                }
            } while (true);
            

        }
        
    }
}
