using System;
using System.IO;
using System.Collections.Generic;

namespace MyApp // Note: actual namespace depends on the project name.
{
	class Program
	{
		const char JEL = '.';


		static void Main(string[] args)
		{

			Random rnd = new Random();

			List<char> falak = new List<char>() { '╬', '═', '╦', '╩', '║', '╣', '╠', '╗', '╝', '╚', '╔', '█' };



			Console.WriteLine("Adjon meg a mátrix méretét (pl: '2:3'): ");
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

			
            for (int sorIndex = 0; sorIndex < matrix.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < matrix.GetLength(1); oszlopIndex++)
                {
                    Console.Write(matrix[sorIndex,oszlopIndex]+"");
                }
                Console.WriteLine();
            }

			
			Console.WriteLine("1. pálya szerkeztése");
			Console.WriteLine("2. pálya mentése");
			Console.WriteLine();
			Console.WriteLine("Válasszon ki egy menü pontot");
			int bekeres = Convert.ToInt32(Console.ReadLine());

			if (bekeres == 1)
			{
				szerkeztes(matrix, falak);
			}
			
			else if (bekeres == 2)
			{
				mentes(matrix);
			}

			

		}

		static char[,] szerkeztes(char[,] palya, List<char> lista)
		{
			string bekeres = "";
			while (true)
			{
				Console.ForegroundColor= ConsoleColor.DarkYellow;
				Console.WriteLine("Ha elszertné menteni a pályát akkor csak nyomjon ENTERT!");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("Adjon meg egy kordinátát ahova a falakat, vagy egy szobát szeretné rakni (pl: 2:3): ");
				bekeres = Console.ReadLine();
				if (bekeres == "")
				{
					Console.WriteLine("Adja mege a fájl mentési nevét: ");
					string nev = Console.ReadLine();

					string[] sorok = new string[palya.GetLength(0)];

					for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
					{
						for (int oszlopIndex = 0; oszlopIndex < palya.GetLength(1); oszlopIndex++)
						{
							sorok[sorIndex] += palya[sorIndex, oszlopIndex];
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
					palya[xKord-1, yKord-1] = lista[falSzam];
				}

				for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
				{
					for (int oszlopIndex = 0; oszlopIndex < palya.GetLength(1); oszlopIndex++)
					{
						Console.Write(palya[sorIndex, oszlopIndex] + "");
					}
					Console.WriteLine();
				}
				Console.ReadKey();
				Console.Clear();
				for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
				{
					for (int oszlopIndex = 0; oszlopIndex < palya.GetLength(1); oszlopIndex++)
					{
						Console.Write(palya[sorIndex, oszlopIndex] + "");
					}
					Console.WriteLine();
				}

			}
			return palya;
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




	}
}