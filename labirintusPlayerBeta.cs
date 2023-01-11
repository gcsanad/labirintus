using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static char[,] labirintus;
        static int jatekosSor, jatekosOszlop;
        static void Main(string[] args)
        {
            string[] cim = File.ReadAllLines("cim.txt");
            foreach (string sor in cim)
            {
                Console.WriteLine(sor);

            }
            Console.WriteLine();
            Console.WriteLine("Nyomjon le egy billentyűt a folytatáshoz");
            Console.ReadKey();
            Console.Clear();
            // A fájl nevének a bekérése
            Console.Write("Írja ide a fájl nevét: ");
            string palyaNeve = Console.ReadLine();

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
        static void Betoltes(string palyaNeve)
        {
            // Ellenőrzi, hogy van e ilyen nevű fájl
            if (!File.Exists(palyaNeve))
            {
                Console.WriteLine("Nincs ilyen nevű  fájl!");
                return;
            }
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
                    Console.Write(labirintus[sorIndex, oszlopIndex]);

                }
                Console.WriteLine();
            }
        }
        static void JatekosMozgatasa(char irany)
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
                case 'k':
                    Console.WriteLine("\nKöszönjük, hogy játszott a játékkal!");
                    Environment.Exit(1);
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
        static void Megjelenit()
        {
            Console.Clear();
            for (int sorIndex = 0; sorIndex < labirintus.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < labirintus.GetLength(1); oszlopIndex++)
                {
                    if (sorIndex == jatekosSor && oszlopIndex == jatekosOszlop)
                    {
                        Console.Write('▒');
                    }
                    else
                    {
                        Console.Write(labirintus[sorIndex, oszlopIndex]);
                    }
                }
                Console.WriteLine();
            }
        }

        static void KezdopontKeresese()
        {
            //'╬','═','╦','╩','║','╣','╠','╗','╝','╚', '╔'
            for (int sorIndex = 0; sorIndex < labirintus.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < labirintus.GetLength(1); oszlopIndex++)
                {
                    if (labirintus[sorIndex, 0] == '═' || labirintus[sorIndex, 0] == '╬' || labirintus[sorIndex, 0] == '╦' || labirintus[sorIndex, 0] == '╩' ||
                        labirintus[sorIndex, 0] == '╣' || labirintus[sorIndex, 0] == '╗' || labirintus[sorIndex, 0] == '╝')
                    {
                        jatekosSor = sorIndex;
                        jatekosOszlop = 0;

                    }
                    else if (labirintus[sorIndex, labirintus.GetLength(1) - 1] == '═' || labirintus[sorIndex, labirintus.GetLength(1) - 1] == '╬' ||
                        labirintus[sorIndex, labirintus.GetLength(1) - 1] == '╦' || labirintus[sorIndex, labirintus.GetLength(1) - 1] == '╩' ||
                        labirintus[sorIndex, labirintus.GetLength(1) - 1] == '╠' || labirintus[sorIndex, labirintus.GetLength(1) - 1] == '╚' ||
                        labirintus[sorIndex, labirintus.GetLength(1) - 1] == '╔')
                    {
                        jatekosSor = sorIndex;
                        jatekosOszlop = labirintus.GetLength(1) - 1;
                    }
                    else if (labirintus[0, oszlopIndex] == '║' || labirintus[0, oszlopIndex] == '╬' || labirintus[0, oszlopIndex] == '╠' || labirintus[0, oszlopIndex] == '╩' ||
                        labirintus[0, oszlopIndex] == '╣' || labirintus[0, oszlopIndex] == '╚' || labirintus[0, oszlopIndex] == '╝')
                    {
                        jatekosSor = 0;
                        jatekosOszlop = oszlopIndex;

                    }
                    else if (labirintus[labirintus.GetLength(0) - 1, oszlopIndex] == '║' || labirintus[labirintus.GetLength(0) - 1, oszlopIndex] == '╬' ||
                        labirintus[labirintus.GetLength(0) - 1, oszlopIndex] == '╦' || labirintus[labirintus.GetLength(0) - 1, oszlopIndex] == '╠' ||
                        labirintus[labirintus.GetLength(0) - 1, oszlopIndex] == '╣' || labirintus[labirintus.GetLength(0) - 1, oszlopIndex] == '╗' ||
                        labirintus[labirintus.GetLength(0) - 1, oszlopIndex] == '╔')
                    {
                        jatekosSor = labirintus.GetLength(0)-1;
                        jatekosOszlop = oszlopIndex;

                    }
                }
            }

        }
    }
}
