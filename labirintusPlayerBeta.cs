using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp4
{
    class Program
    {
        static char[,] labirintus;
        static int jatekosSor, jatekosOszlop;
        static int megtalaltSzobakSzama = 0;
        static char[,] mentesLabirintus;
        static string[] nyelvvalasztas;
        static int megtalalhatoSzobakSzama;


        static void Main(string[] args)
        {
            string[] cim = File.ReadAllLines("cim.txt");
            foreach (string sor in cim)
            {
                Console.WriteLine(sor);
            }
            Console.WriteLine();
            Console.WriteLine("Nyomjon le egy billentyűt a folytatáshoz");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Pálya betöltése (l)");
            Console.WriteLine("Válassza ki a nyelvet: Magyar vagy Angol");
            Console.WriteLine("Kilépés (k)");
            switch (Console.ReadLine())
            {
                case "l":
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
                    break;
                case "Magyar":
                case "magyar":
                case "Hungarian":
                case "hungarian":
                    nyelvvalasztas = File.ReadAllLines("magyarJatek.txt");
                    break;
                case "Angol":
                case "angol":
                case "English":
                case "english":
                    nyelvvalasztas = File.ReadAllLines("angolJatek.txt");
                    break;
                case "k":
                case "e":
                    Console.WriteLine("Köszönjük, hogy játszott a játékkal!");
                    Console.ReadKey();
                    Environment.Exit(1);
                    break;
                default:
                    break;
            }

            bool[,] megtalaltSzobak = new bool[labirintus.GetLength(0), labirintus.GetLength(1)];
            for (int sorIndex = 0; sorIndex < megtalaltSzobak.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < megtalaltSzobak.GetLength(1); oszlopIndex++)
                {
                    megtalaltSzobak[sorIndex, oszlopIndex] = false;
                }
            }
            // Folyamatosan kéri a felhasználótól a billentyűket és mozgatja a játékost
            while (true)
            {
                Console.WriteLine("Eddig talált szobák száma:"+megtalaltSzobakSzama);
                Console.Write("Merre mozog tovább (WASD): ");
                char irany = Console.ReadKey().KeyChar;

                // Játékos mozgatása
                JatekosMozgatasa(irany, megtalaltSzobak);

                // Pálya megjelenítése
                Megjelenit();

            }
        }
        static void Betoltes(string palyaNeve)
        {
            // Ellenőrzi, hogy van e ilyen nevű fájl
            if (!File.Exists(palyaNeve))
            {
                Console.WriteLine("Nincs ilyen nevű fájl!");
                Console.ReadKey();
                Environment.Exit(1);
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
                    if (labirintus[sorIndex,oszlopIndex]=='█')
                    {
                        megtalalhatoSzobakSzama++;
                    }

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
        static void JatekosMozgatasa(char irany, bool[,] matrix)
        {
            mentesLabirintus = new char[labirintus.GetLength(0), labirintus.GetLength(1)];
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
                case 'm':
                    Console.Write("\nMilyen néven mentené el a fájlt?");
                    string mentesNeve = Console.ReadLine();
                    Mentes(mentesLabirintus, mentesNeve);
                    break;
                default:
                    break;
            }
            for (int sorIndex = 0; sorIndex < mentesLabirintus.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < mentesLabirintus.GetLength(1); oszlopIndex++)
                {
                    mentesLabirintus[sorIndex, oszlopIndex] = labirintus[sorIndex, oszlopIndex];
                }
            }
            mentesLabirintus[jatekosSor, jatekosOszlop] = '▒';
            // Ellenőrzi hogy a játékos pályán belül van e
            if (ujSor >= 0 && ujSor < labirintus.GetLength(0) && ujOszlop >= 0 && ujOszlop < labirintus.GetLength(1) && labirintus[ujSor, ujOszlop] != '.')
            {
                jatekosSor = ujSor;
                jatekosOszlop = ujOszlop;
            }
            /*
            if (labirintus[jatekosSor,jatekosOszlop]== '═' && labirintus[jatekosSor+1,jatekosOszlop]== '╬' || labirintus[jatekosSor + 1, jatekosOszlop] == '╦' || labirintus[jatekosSor + 1, jatekosOszlop] == '╩' ||labirintus[jatekosSor + 1, jatekosOszlop] == '╣' || labirintus[jatekosSor + 1, jatekosOszlop] == '╝' || labirintus[jatekosSor + 1, jatekosOszlop] == '╗')
            {
                jatekosSor = ujSor;
                jatekosOszlop = ujOszlop;
            }
            */
            if (labirintus[jatekosSor, jatekosOszlop] == '█' && matrix[jatekosSor,jatekosOszlop] == false)
            {
                matrix[jatekosSor, jatekosOszlop] = true;
                Console.WriteLine("\nTaláltál egy szobát!");
                megtalaltSzobakSzama++;
                Console.ReadKey();
            }
            if (megtalalhatoSzobakSzama == megtalaltSzobakSzama)
            {
                Console.WriteLine("\nGratulálok, megtaláltad az összes szobát!");
                Console.WriteLine($"\n{megtalaltSzobakSzama} szobát találtál");
                Console.ReadKey();
                Console.WriteLine("\nKöszönjük, hogy játszott a játékkal!");
                Console.ReadKey();
                Environment.Exit(1);

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
                        jatekosSor = labirintus.GetLength(0) - 1;
                        jatekosOszlop = oszlopIndex;

                    }
                }
            }

        }

        static void Mentes(char[,] palya, string palyaNeve)
        {
            
                string[] sorok = new string[palya.GetLength(0)];

                string sor = "";
                string mentJatekSor = jatekosSor.ToString();
                string mentJatekOszlop = jatekosOszlop.ToString();
                string mentesJatekosAdatok = mentJatekSor + ":" + mentJatekOszlop;

                for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
                {
                    for (int oszlopIndexe = 0; oszlopIndexe < palya.GetLength(1); oszlopIndexe++)
                    {
                        sor += palya[sorIndex, oszlopIndexe];
                    }
                    sorok[sorIndex] = sor;
                    sor = "";
                }
                File.WriteAllLines(palyaNeve, sorok);
            
                
        }

        


        //Nem működik
        /*
        static void Mentes(char[,] palya, string mentesNeve)
        {
            using (StreamWriter ment = new StreamWriter(mentesNeve))
            {   
                
                string[] sorok = new string[palya.GetLength(0)];
                
                for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
                {
                    for (int oszlopIndex = 0; oszlopIndex < palya.GetLength(1); oszlopIndex++)
                    {
                        ment.Write(palya[sorIndex,oszlopIndex]);
                    }
                    Console.WriteLine();
                }
               
                ment.WriteLine(jatekosSor + " " + jatekosOszlop + " " + megtalaltSzobakSzama);
            }
        */
    }
}

