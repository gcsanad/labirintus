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

			palyaKeszites(szam, szam2);

			Console.WriteLine("1. pálya szerkeztése");
			Console.WriteLine("2. pálya mentése");
			Console.WriteLine("3. pálya betöltése");
			Console.WriteLine();
			Console.WriteLine("Válasszon ki egy menü pontot");

			int bekeres = Convert.ToInt32(Console.ReadLine());



			if (bekeres == 1)
			{
				Console.Clear();
				szerkeztes(palyaKeszites(szam, szam2), falak);
			}
			
			else if (bekeres == 2)
			{
				mentes(palyaKeszites(szam,szam2));
			}
			
			else if (bekeres == 3)
			{
				Console.WriteLine("adja meg a mentett pálya nevét: ");
				string nev = Console.ReadLine();
				szerkeztes(betoltes(nev), falak);
			}
			
		}

		static char[,] palyaKeszites(int sorokSzama, int sozlopokSzama)
		{
			char[,] matrix = new char[sorokSzama, sozlopokSzama];

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
					Console.Write(matrix[sorIndex, oszlopIndex] + "");
				}
				Console.WriteLine();
			}
			

			return matrix;
		}

		static char[,] szerkeztes(char[,] palya, List<char> lista)
		{
			string bekeres = "";
			while (true)
			{
				Console.Clear();
				for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
				{
					for (int oszlopIndex = 0; oszlopIndex < palya.GetLength(1); oszlopIndex++)
					{
						Console.Write(palya[sorIndex, oszlopIndex]);
					}
					Console.WriteLine();
				}
				Console.ForegroundColor= ConsoleColor.DarkYellow;
				Console.WriteLine("Ha elszertné menteni a pályát akkor csak nyomjon egy ENTER-t!");
				Console.WriteLine("Ha minden objektumot ki szeretne törölni a pályáról, akkor írja be hogy 'ures'");
				Console.WriteLine("Ha karaktert szeretne törölin akkor a kordináták után rakjon egy 't betűt' kettős ponttal elválasztva (pl: 2:3:t)");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("Adjon meg egy kordinátát ahova a falakat, vagy egy szobát szeretné rakni (pl: 2:3): ");
				bekeres = Console.ReadLine();


				if (bekeres == "")
				{
					mentes(palya);
					break;
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

					for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
					{
						for (int oszlopIndex = 0; oszlopIndex < palya.GetLength(1); oszlopIndex++)
						{
							Console.Write(palya[sorIndex,oszlopIndex]);
						}
						Console.WriteLine();
					}
				}

				else if (bekeres.Contains(':'))
				{



					string[] valami = bekeres.Split(":");

					int xKord = Convert.ToInt32(valami[0]);
					int yKord = Convert.ToInt32(valami[1]);


					if (bekeres.Contains('t'))
					{
						palya[xKord - 1, yKord - 1] = JEL;
					}

					else
					{
						Console.WriteLine();
						Console.WriteLine("A melyik karaktert szeretné használni: (0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█'");
						int falSzam = Convert.ToInt32(Console.ReadLine());

						Console.Clear();


						if (falSzam < 0 || falSzam > 11)
						{
							Console.WriteLine("Nincs ilyen számú fal");
						}

						else if (falSzam >= 0 && falSzam <= 11)
						{
							palya[xKord - 1, yKord - 1] = lista[falSzam];
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

				
				}
				else if (bekeres != "ures" || bekeres != "" || bekeres.Contains(':') == false || bekeres.Contains('t') == false)
				{
					Console.WriteLine("Hiba");
					Console.ReadKey();
					Console.Clear();
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

			for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
			{
				for (int oszlopIndexe = 0; oszlopIndexe < palya.GetLength(1); oszlopIndexe++)
				{
					Console.Write(palya[sorIndex,oszlopIndexe]+"");
				}
				Console.WriteLine();
			}
			return palya;
		}


	}
}