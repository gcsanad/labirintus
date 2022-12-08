using System;
using System.IO;
using System.Collections.Generic;


namespace ConsoleApp6
{
    class Program
    {
        const char JEL = '.';
       

        static void Main(string[] args)
        {

            Random rnd = new Random();

            List<char> falak = new List<char>() { '╬', '═', '╦', '╩', '║', '╣', '╠', '╗', '╝', '╚', '╔', '█' };

            

            Console.WriteLine("Adjon meg egy kordinátát (pl: '2:3'): ");
            string kordinata = Console.ReadLine();

            string[] ok = kordinata.Split(":");


            int szam = Convert.ToInt32(ok[0]);
            int szam2 = Convert.ToInt32(ok[1]);

           

            char[,] matrix = new char[szam, szam2];

            for (int sorIndex = 0; sorIndex < matrix.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < matrix.GetLength(1); oszlopIndex++)
                {
                    matrix[sorIndex, oszlopIndex] = JEL;
                }
            }

            /*
            for (int sorIndex = 0; sorIndex < matrix.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < matrix.GetLength(1); oszlopIndex++)
                {
                    Console.Write(matrix[sorIndex,oszlopIndex]+"");
                }
                Console.WriteLine();
            }
            */

            string bekeres = "";

            while (true)
            {
                Console.WriteLine("Adjon meg egy kordinátát ahova a falakat, vagy egy szobát szeretné rakni (pl: 2:3): ");
                bekeres = Console.ReadLine();
                if (bekeres == "")
                {
                    Console.WriteLine("Adja mege a fájl mentési nevét: ");
                    string nev = Console.ReadLine();

                    string[] sorok = new string[matrix.GetLength(0)];

                    for (int sorIndex = 0; sorIndex < matrix.GetLength(0); sorIndex++)
                    {
                        for (int oszlopIndex = 0; oszlopIndex < matrix.GetLength(1); oszlopIndex++)
                        {
                            sorok[sorIndex] += matrix[sorIndex, oszlopIndex];
                        }
                    }
                    File.WriteAllLines(nev, sorok);
                    break;
                }
                string[] valami = bekeres.Split(":");
                int xKord = Convert.ToInt32(valami[0]);
                int yKord = Convert.ToInt32(valami[1]);
                Console.WriteLine();
                Console.WriteLine("A melyik karaktert szeretné használni: (0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█'");
                int falSzam = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                if (falSzam < 0 || falSzam > 11)
                {
                    Console.WriteLine("Nincs ilyen számú fal");
                }

                else
                {
                    matrix[xKord, yKord] = falak[falSzam];
                }
                
                for (int sorIndex = 0; sorIndex < matrix.GetLength(0); sorIndex++)
                {
                    for (int oszlopIndex = 0; oszlopIndex < matrix.GetLength(1); oszlopIndex++)
                    {
                        Console.Write(matrix[sorIndex, oszlopIndex] + "");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
                Console.Clear();
                for (int sorIndex = 0; sorIndex < matrix.GetLength(0); sorIndex++)
                {
                    for (int oszlopIndex = 0; oszlopIndex < matrix.GetLength(1); oszlopIndex++)
                    {
                        Console.Write(matrix[sorIndex, oszlopIndex] + "");
                    }
                    Console.WriteLine();
                }

            } 

        }
    }
}
