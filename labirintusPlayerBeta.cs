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
        private static char[,] labirintus;
        private static int jatekosSor, jatekosOszlop;
        static void Main(string[] args)
        {
            // A fájl nevének a bekérése
            //Console.Write("Írja ide a fájl nevét: ");
            string palyaNeve = "teszt.txt";

            // Pálya betöltése a fájlból
            Betoltes(palyaNeve);

            // Kezdési hely megkeresése
            KezdopontKeresese();

            // Pálya megjelenítése
            Megjelenit();

            // Folyamatosan kéri a felhasználótól a billentyűket és mozgatja a játékost
            while (true)
            {
                
                Console.Write("Merre mozog tovább (WASD): ");
                char irany = Console.ReadKey().KeyChar;

                // Játékos mozgatása
                JatekosMozgatasa(irany);

                // Pálya megjelenítése
                Megjelenit();

            }
        }
        private static void Betoltes(string palyaNeve = "teszt.txt")
        {
            // Beolvassa a fájl nevét és egy tömbben tárolja
            string[] lines = File.ReadAllLines(palyaNeve);
            labirintus = new char[lines.Length, lines[0].Length];

            for (int sorIndex = 0; sorIndex < lines.Length; sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < lines[sorIndex].Length; oszlopIndex++)
                {
                    labirintus[sorIndex, oszlopIndex] = lines[sorIndex][oszlopIndex];
                    
                }
            }
            for (int sorIndex = 0; sorIndex < lines.Length; sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < lines[sorIndex].Length; oszlopIndex++)
                {
                    Console.Write(labirintus[sorIndex,oszlopIndex]);

                }
                Console.WriteLine();
            }
        }
        private static void JatekosMozgatasa(char irany)
        {
            int ujSor = jatekosSor;
            int ujOszlop = jatekosOszlop;

            // A játékos pozíciójának frissítése
            switch (irany)
            {
                case 'W':
                case 'w':
                    ujSor--;
                    break;
                case 'A':
                case 'a':
                    ujOszlop--;
                    break;
                case 'S':
                case 's':
                    ujSor++;
                    break;
                case 'D':
                case 'd':
                    ujOszlop++;
                    break;
                default:
                    break;
            }

            // Ellenőrzi hogy a játékos pályán belül van e
            if (ujSor >= 0 && ujSor < labirintus.GetLength(0) && ujOszlop >= 0 && ujOszlop < labirintus.GetLength(1) && labirintus[ujSor, ujOszlop] != '.')
            {
                jatekosSor = ujSor;
                jatekosOszlop = ujOszlop;
            }
        }
        private static void Megjelenit()
        {
            Console.Clear();
            for (int sorIndex = 0; sorIndex < labirintus.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < labirintus.GetLength(1); oszlopIndex++)
                {
                    if (sorIndex == jatekosSor && oszlopIndex == jatekosOszlop)
                    {
                        Console.Write('P');
                    }
                    else
                    {
                        Console.Write(labirintus[sorIndex, oszlopIndex]);
                    }
                }
                Console.WriteLine();
            }
        }

        private static void KezdopontKeresese()
        {
            for (int sorIndex = 0; sorIndex < labirintus.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < labirintus.GetLength(1); oszlopIndex++)
                {
                    if (labirintus[sorIndex, oszlopIndex] == '═')
                    {
                        jatekosSor = 1;
                        jatekosOszlop = 0;
                        break;
                    }
                }
            }
        }
    }
}
