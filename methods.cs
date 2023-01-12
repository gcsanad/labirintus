using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        ///'╬','═','╦','╩','║','╣','╠','╗','╝','╚', '╔' ’█’’.’

        /// <summary>
        /// Megadja, hogy hány termet tartamaz a térkép
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>Termek száma</returns>
        static int GetRoomNumber(char[,] map)
        {
            int szobakSzama = 0;
            int sorokSzama = map.GetLength(0);
            int oszlopokSzama = map.GetLength(1);

            for (int sorok = 0; sorok < sorokSzama; sorok++)
            {
                for (int oszlopok = 0; oszlopok < oszlopokSzama; oszlopok++)
                {
                    if (map[sorok, oszlopok] == '█')
                    {
                        szobakSzama++;
                    }
                }
            }
            if (szobakSzama != 0)
            {
                return szobakSzama;
            }
            else;
            {
                return -1;
            }

        }
        /// <summary>
        /// A kapott térkép széleit végignézve megállapítja, hogy hány kijárat van.
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>Az alkalmas kijáratok száma</returns>
        static int GetSuitableEntrance(char[,] map)
        {
            int bejaratokSzama = 0;
            int osszesSorokSzama = map.GetLength(0);
            int osszesOszlopokSzama = map.GetLength(1);
            char[] balBejaratok = {'╬', '═', '╦', '╩', '╣', '╗', '╝'};
            char[] jobbBejaratok = { '╬', '═', '╦', '╩', '╠', '╚', '╔'};
            char[] alsoBejaratok = { '╬', '╦', '║', '╣', '╠', '╗', '╔'};
            char[] felsoBejaratok = { '╬', '╩', '║', '╣', '╠', '╝', '╚',};


            for (int sorokSzama = 0; sorokSzama < osszesSorokSzama; sorokSzama++)
            {
                if (balBejaratok.Contains(map[sorokSzama, 0]))
                {
                    bejaratokSzama++;
                }
                if (jobbBejaratok.Contains(map[sorokSzama, osszesOszlopokSzama]))
                {
                    bejaratokSzama++;
                }
            }

            for (int oszlopok = 0; oszlopok < osszesOszlopokSzama; oszlopok++)
            {
                if (felsoBejaratok.Contains(map[0, oszlopok]))
                {
                    bejaratokSzama++;
                }
                if (alsoBejaratok.Contains(map[osszesSorokSzama, oszlopok]))
                {
                    bejaratokSzama++;
                }
            }



            if (bejaratokSzama != 0)
            {
                return bejaratokSzama;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// Megnézi, hogy van-e a térképen meg nem engedett karakter?
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>true - A térkép tartalmaz szabálytalan karaktert, false - nincs benne ilyen</returns>
        static bool IsInvalidElement(char[,] map)
        {
            bool vanSzabalytalan = false;
            int osszesSorokSzama = map.GetLength(0);
            int osszesOszlopokSzama = map.GetLength(1);
            char[] validCharacters = { '╬', '═', '╦', '╩', '║', '╣', '╠', '╗', '╝', '╚', '╔', '█', '.'};

            while (!vanSzabalytalan)
            {
                for (int sor = 0; sor < osszesSorokSzama; sor++)
                {
                    for (int oszlop = 0; oszlop < osszesOszlopokSzama; oszlop++)
                    {
                        if (!validCharacters.Contains(map[sor, oszlop]))
                        {
                            vanSzabalytalan=true;
                        }
                    }
                }
            }


            return vanSzabalytalan;
        }
        /// <summary>
        /// Visszaadja azoknak a járatkaraktereknek a pozícióját, amelyekhez egyetlen szomszéd pozícióból sem lehet eljutni.
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>A pozíciók "sor_index:oszlop_index" formátumban szerepelnek a lista elemeiként
        static List<string> GetUnavailableElements(char[,] map)
        {
            List<string> unavailables = new List<string>();
            // ?
            // pld: string poz = "4:12"; 
            int osszesSorokSzama = map.GetLength(0);
            int osszesOszlopokSzama = map.GetLength(1);
            char[] balBejaratok = { '╬', '═', '╦', '╩', '╣', '╗', '╝' };
            char[] jobbBejaratok = { '╬', '═', '╦', '╩', '╠', '╚', '╔' };
            char[] alsoBejaratok = { '╬', '╦', '║', '╣', '╠', '╗', '╔' };
            char[] felsoBejaratok = { '╬', '╩', '║', '╣', '╠', '╝', '╚', };


            for (int sorok = 0; sorok < osszesSorokSzama; sorok++)
            {
                for (int oszlop = 0; oszlop < osszesOszlopokSzama; oszlop++)
                {
                    if (sorok == osszesSorokSzama && oszlop == osszesOszlopokSzama)
                    {
                        if (!(alsoBejaratok.Contains(map[sorok-1, oszlop]) || jobbBejaratok.Contains(map[sorok, oszlop-1])))
                        {
                            unavailables.Add($"{sorok}:{oszlop}");
                        }
                    }
                    else if (sorok == osszesSorokSzama && oszlop == 0)
                    {
                        if (!(alsoBejaratok.Contains(map[sorok - 1, oszlop]) || balBejaratok.Contains(map[sorok, oszlop + 1])))
                        {
                            unavailables.Add($"{sorok}:{oszlop}");
                        }
                    }
                    else if (sorok == 0 && oszlop == osszesOszlopokSzama)
                    {
                        if (!(felsoBejaratok.Contains(map[sorok + 1, oszlop]) || jobbBejaratok.Contains(map[sorok, oszlop - 1])))
                        {
                            unavailables.Add($"{sorok}:{oszlop}");
                        }
                    }
                    else if (sorok == 0 && oszlop == 0)
                    {
                        if (!(felsoBejaratok.Contains(map[sorok + 1, oszlop]) || balBejaratok.Contains(map[sorok, oszlop + 1])))
                        {
                            unavailables.Add($"{sorok}:{oszlop}");
                        }
                    }
                    else if (sorok == 0)
                    {
                        if (!(jobbBejaratok.Contains(map[sorok, oszlop - 1]) || felsoBejaratok.Contains(map[sorok + 1, oszlop]) || balBejaratok.Contains(map[sorok, oszlop + 1])))
                        {
                            unavailables.Add($"{sorok}:{oszlop}");
                        }
                    }
                    else if (sorok == osszesSorokSzama)
                    {
                        if (!(jobbBejaratok.Contains(map[sorok, oszlop - 1]) || alsoBejaratok.Contains(map[sorok - 1, oszlop]) || balBejaratok.Contains(map[sorok, oszlop + 1])))
                        {
                            unavailables.Add($"{sorok}:{oszlop}");
                        }
                    }
                    else if (oszlop == 0)
                    {
                        if (!(alsoBejaratok.Contains(map[sorok - 1, oszlop]) || felsoBejaratok.Contains(map[sorok + 1, oszlop]) || balBejaratok.Contains(map[sorok, oszlop + 1])))
                        {
                            unavailables.Add($"{sorok}:{oszlop}");
                        }
                    }
                    else if (oszlop == osszesOszlopokSzama)
                    {
                        if (!(alsoBejaratok.Contains(map[sorok - 1, oszlop]) || felsoBejaratok.Contains(map[sorok + 1, oszlop]) || jobbBejaratok.Contains(map[sorok, oszlop - 1])))
                        {
                            unavailables.Add($"{sorok}:{oszlop}");
                        }
                    }
                }
            }
            return unavailables;
        }
        /// <summary>
        /// Labiritust generál a kapott pozíciókat tartalmazó lista alapján. A lista elemei egymáshoz kapcsolódó járatok pozíciói.
        /// </summary>
        /// <param name="positionsList">"sor_index:oszlop_index" formátumban az egymáshoz kapcsolódó járatok pozícióit tartalmazó lista </param>
        /// <returns>A létrehozott labirintus térképe</returns>
        static char[,] GenerateLabyrinth(List<string> positionsList)
        {
            return null;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}