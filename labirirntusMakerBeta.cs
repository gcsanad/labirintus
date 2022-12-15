using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
	class Program
	{
		const char JEL = '.';

		


		static void Main(string[] args)
		{
			Console.WriteLine("Válasszon nyelvet: magyar vagy angol: ");
			string nyelv = Console.ReadLine();
			menu(nyelv);
		}

		static char[,] palyaKeszites(int sorokSzama, int oszlopokSzama)
		{
			char[,] matrix = new char[sorokSzama, oszlopokSzama];

			for (int sorIndex = 0; sorIndex < matrix.GetLength(0); sorIndex++)
			{
				for (int oszlopIndex = 0; oszlopIndex < matrix.GetLength(1); oszlopIndex++)
				{
					matrix[sorIndex, oszlopIndex] = JEL;
				}
			}

			Kiirat(matrix);
			return matrix;
		}

		static char[,] szerkeztes(char[,] palya, List<char> lista, string nyelvezet)
		{
			string visszaAd = "magyar";
			string szoveg = "Ha elszertné menteni a pályát akkor csak nyomjon egy ENTER-t!\n" +
					"Ha minden objektumot ki szeretne törölni a pályáról, akkor írja be hogy 'ures'\n" +
					"Ha karaktert szeretne törölin akkor a kordináták után rakjon egy 't betűt' kettős ponttal elválasztva (pl: 2:3:t)\n" +
					"Ha vissza szertene menni a menu akkro írja be hogy 'menu'\n" +
					"Ha többetakran lerakni az adott falból akkor a kordináta után írjon egy égtáj kezdőbetűjét (pl: 2:3:n, 2:3:e, 2:3:s, 2:3:w)";
			string lerakSzoveg = "Mennyit szeretne lerakni: ";

			string lerakSzoveg2 = "Adjon meg egy kordinátát ahova a falakat, vagy szobákat szeretné rakni (pl: 2:3): ";
			string kerdes = "Melyik karaktert szeretné használni:";


			if (nyelvezet == "angol")
            {
				visszaAd = "angol";
				szoveg = "If you want to save the track just press ENTER!\n" +
					"If you want to delete all objects from the track, just type 'ures'\n" +
					"If you want to delete a character, just put a 't' separated by a double dot after the coordinates (e.g.: 2:3:t)\n" +
					"If you want to go back to the menu, type 'menu'\n" +
					"If you want to unload more than one of the given wall, then after the cordinate, type the initial letter of a sky (e.g.: 2:3:n, 2:3:e, 2:3:s, 2:3:w)";
				lerakSzoveg = "How much do you want to unload: ";

				lerakSzoveg2 = "Give a cordon where you want to put the walls or rooms (e.g. 2:3):";
				kerdes = "Which character would you like to use:";
			}

			while (true)
			{
				Console.Clear();

				Kiirat(palya);


				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine(szoveg);
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine(lerakSzoveg2);
				string bekeres = Console.ReadLine();


				if (bekeres == "")
				{
					mentes(palya);

					continue;
				}

				else if (bekeres == "menu")
				{
					Console.Clear();
					menu(visszaAd);
				}

				else if (bekeres == "ures")
				{
					Console.Clear();
					for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
					{
						for (int oszlopIndex = 0; oszlopIndex < palya.GetLength(1); oszlopIndex++)
						{
							palya[sorIndex, oszlopIndex] = JEL;
						}
					}
					Kiirat(palya);
				}

				else if (bekeres.Contains(':'))
				{
					string[] valami = bekeres.Split(':');

					int xKord = Convert.ToInt32(valami[0]);
					int yKord = Convert.ToInt32(valami[1]);


					if (bekeres.Contains('t'))
					{
						palya[xKord - 1, yKord - 1] = JEL;
					}

					else if (bekeres.Contains('n'))
					{
						Console.WriteLine(lerakSzoveg);
						int darab = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine(kerdes+" (0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█', (12)'▄',(13)'♣', (14)'♂', (15)'♀', (16)'♫', (17)'☼', (18)'↓', (19)'→', (20)'↑', (21)'▼'");
						int falszam1 = Convert.ToInt32(Console.ReadLine());

						for (int i = 0; i < darab; i++)
						{
							palya[xKord - 1, yKord - 1] = lista[falszam1];
							xKord--;
						}

					}

					else if (bekeres.Contains('e'))
					{
						Console.WriteLine(lerakSzoveg);
						int darab = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine(kerdes+" (0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█', (12)'▄',(13)'♣', (14)'♂', (15)'♀', (16)'♫', (17)'☼', (18)'↓', (19)'→', (20)'↑', (21)'▼'");
						int falszam1 = Convert.ToInt32(Console.ReadLine());

						for (int i = 0; i < darab; i++)
						{
							palya[xKord - 1, yKord - 1] = lista[falszam1];
							yKord++;
						}

					}

					else if (bekeres.Contains('w'))
					{
						Console.WriteLine(lerakSzoveg);
						int darab = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine(kerdes+" (0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█', (12)'▄',(13)'♣', (14)'♂', (15)'♀', (16)'♫', (17)'☼', (18)'↓', (19)'→', (20)'↑', (21)'▼'");
						int falszam1 = Convert.ToInt32(Console.ReadLine());

						for (int i = 0; i < darab; i++)
						{
							palya[xKord - 1, yKord - 1] = lista[falszam1];
							yKord--;
						}

					}

					else if (bekeres.Contains('s'))
					{
						Console.WriteLine(lerakSzoveg);
						int darab = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine(kerdes+" (0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█', (12)'▄',(13)'♣', (14)'♂', (15)'♀', (16)'♫', (17)'☼', (18)'↓', (19)'→', (20)'↑', (21)'▼'");
						int falszam1 = Convert.ToInt32(Console.ReadLine());

						for (int i = 0; i < darab; i++)
						{
							palya[xKord - 1, yKord - 1] = lista[falszam1];
							xKord++;
						}

					}


					else if (bekeres.Contains('w'))
					{
						Console.WriteLine(lerakSzoveg);
						int darab = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine(kerdes+" (0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█', (12)'▄',(13)'♣', (14)'♂', (15)'♀', (16)'♫', (17)'☼', (18)'↓', (19)'→', (20)'↑', (21)'▼'");
						int falszam1 = Convert.ToInt32(Console.ReadLine());

						for (int i = 0; i < darab; i++)
						{
							palya[xKord - 1, yKord - 1] = lista[falszam1];
							xKord--;
						}

					}
					else
					{
						Console.WriteLine();
						Console.WriteLine(kerdes+"(0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█', (12)'▄',(13)'♣', (14)'♂', (15)'♀', (16)'♫', (17)'☼', (18)'↓', (19)'→', (20)'↑', (21)'▼'");
						int falSzam = Convert.ToInt32(Console.ReadLine());

						Console.Clear();


						if (falSzam < 0 || falSzam > lista.Count)
						{
							Console.WriteLine("Nincs ilyen számú fal");
						}

						else if (falSzam >= 0 && falSzam <= lista.Count)
						{
							palya[xKord - 1, yKord - 1] = lista[falSzam];
						}
					}

				}
				else if (bekeres != "ures" || bekeres != "" || bekeres.Contains(':') == false)
				{

					Console.WriteLine("Hiba");
					Console.ReadKey();
					Console.Clear();
				}
			}
			//return palya; 
		}

		static void mentes(char[,] mentesPalya)
		{
			Console.WriteLine("Adja mege a fájl mentési nevét: ");
			string nev = Console.ReadLine();

			string[] sorok = new string[mentesPalya.GetLength(0)];

			for (int sorIndex = 0; sorIndex < mentesPalya.GetLength(0); sorIndex++)
			{
				for (int oszlopIndex = 0; oszlopIndex < mentesPalya.GetLength(1); oszlopIndex++)
				{
					sorok[sorIndex] += mentesPalya[sorIndex, oszlopIndex];
				}
			}
			File.WriteAllLines(nev, sorok);
		}

		static char[,] betoltes(string palyaNeve)
		{
			string[] sorok = File.ReadAllLines(palyaNeve);
			char[,] palya = new char[sorok.Length, sorok[0].Length];
			for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
			{
				for (int oszlopIndexe = 0; oszlopIndexe < palya.GetLength(1); oszlopIndexe++)
				{
					palya[sorIndex, oszlopIndexe] = sorok[sorIndex][oszlopIndexe];
				}
			}

			Kiirat(palya);
			return palya;
		}

		static void menu(string nyelvezet = "magyar")
		{
			string menu = "1. pálya létrehozása\n" +
				"2. pálya betöltése\n" +
				"3. kilépés a programból\n" +
				"\n" +
				"Válasszon ki egy menü pontot";
			string menu2 = "Adja meg a mátrix méretét (pl: '2:3'): ";
			string menu3 = "Adja meg a mentett pálya nevét: ";


			if (nyelvezet == "angol")
            {
				menu = "1. Create map \n" +
				"2. Load map \n" +
				"3. Exit the program\n" +
				"\n" +
				"Select a menu item";
				menu2 = "Enter the size of the matrix (e.g. '2:3'): ";

				menu3 = "Enter the name of the saved map:";
			}

			Console.Clear();
			Console.WriteLine(menu);

			List<char> falak = new List<char>() { '╬', '═', '╦', '╩', '║', '╣', '╠', '╗', '╝', '╚', '╔', '█', '▄', '♣', '♂', '♀', '♫', '☼', '↓', '→', '↑', '▼' };

			Console.WriteLine();




			int bekeres = Convert.ToInt32(Console.ReadLine());



			if (bekeres == 1)
			{
				Console.WriteLine(menu2);

				string kordinata = Console.ReadLine();
				string[] ok = kordinata.Split(":");


				int szam = Convert.ToInt32(ok[0]);
				int szam2 = Convert.ToInt32(ok[1]);

				szerkeztes(palyaKeszites(szam, szam2), falak, nyelvezet);

			}


			else if (bekeres == 2)
			{
				Console.WriteLine(menu3);
				string nev = Console.ReadLine();
				szerkeztes(betoltes(nev), falak, nyelvezet);
			}

			else if (bekeres == 3)
			{
				Environment.Exit(0);
			}


		}

		static void Kiirat(char[,] palya)
		{
			for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
			{
				for (int oszlopIndex = 0; oszlopIndex < palya.GetLength(1); oszlopIndex++)
				{
					Console.Write(palya[sorIndex, oszlopIndex] + "");
				}
				Console.WriteLine();
			}
		}


	}
}
