using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;


namespace MyApp
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

			while (true)
			{
				string visszaAd = nyelvezet;
				string[] tomb = File.ReadAllLines($"{nyelvezet}.txt");
				Console.Clear();

				Kiirat(palya);


				Console.ForegroundColor = ConsoleColor.DarkYellow;
				for (int i = 0; i < 13; i++)
				{
					if (i > 6)
					{
						Console.WriteLine(tomb[i]);
					}
				}

				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine(tomb[14]);
				string bekeres = Console.ReadLine();


				if (bekeres == "")
				{
					Ellenoriz(palya,lista,nyelvezet);

					continue;
				}

				else if (bekeres == "menu")
				{
					Console.Clear();
					menu(visszaAd);
				}

				else if (bekeres == "nyelv")
				{
					Console.WriteLine(tomb[18]);
					string nyelvValt = Console.ReadLine();
					nyelvezet = nyelvValt;
					continue;
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
						Console.WriteLine(tomb[13]);
						int darab = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine(tomb[15] + " (0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█', (12)'▄',(13)'♣', (14)'♂', (15)'♀', (16)'♫', (17)'☼', (18)'↓', (19)'→', (20)'↑', (21)'▼'");
						int falszam1 = Convert.ToInt32(Console.ReadLine());

						for (int i = 0; i < darab; i++)
						{
							palya[xKord - 1, yKord - 1] = lista[falszam1];
							xKord--;
						}

					}

					else if (bekeres.Contains('e'))
					{
						Console.WriteLine(tomb[13]);
						int darab = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine(tomb[15] + " (0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█', (12)'▄',(13)'♣', (14)'♂', (15)'♀', (16)'♫', (17)'☼', (18)'↓', (19)'→', (20)'↑', (21)'▼'");
						int falszam1 = Convert.ToInt32(Console.ReadLine());

						for (int i = 0; i < darab; i++)
						{
							palya[xKord - 1, yKord - 1] = lista[falszam1];
							yKord++;
						}

					}

					else if (bekeres.Contains('w'))
					{
						Console.WriteLine(tomb[13]);
						int darab = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine(tomb[15] + " (0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█', (12)'▄',(13)'♣', (14)'♂', (15)'♀', (16)'♫', (17)'☼', (18)'↓', (19)'→', (20)'↑', (21)'▼'");
						int falszam1 = Convert.ToInt32(Console.ReadLine());

						for (int i = 0; i < darab; i++)
						{
							palya[xKord - 1, yKord - 1] = lista[falszam1];
							yKord--;
						}

					}

					else if (bekeres.Contains('s'))
					{
						Console.WriteLine(tomb[13]);
						int darab = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine(tomb[15] + " (0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█', (12)'▄',(13)'♣', (14)'♂', (15)'♀', (16)'♫', (17)'☼', (18)'↓', (19)'→', (20)'↑', (21)'▼'");
						int falszam1 = Convert.ToInt32(Console.ReadLine());

						for (int i = 0; i < darab; i++)
						{
							palya[xKord - 1, yKord - 1] = lista[falszam1];
							xKord++;
						}

					}


					else if (bekeres.Contains('w'))
					{
						Console.WriteLine(tomb[13]);
						int darab = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine(tomb[15] + " (0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█', (12)'▄',(13)'♣', (14)'♂', (15)'♀', (16)'♫', (17)'☼', (18)'↓', (19)'→', (20)'↑', (21)'▼'");
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
						Console.WriteLine(tomb[15] + "(0)'╬', (1)'═', (2)'╦', (3)'╩', (4)'║', (5)'╣', (6)'╠', (7)'╗', (8)'╝', (9)'╚', (10)'╔', (11)'█', (12)'▄',(13)'♣', (14)'♂', (15)'♀', (16)'♫', (17)'☼', (18)'↓', (19)'→', (20)'↑', (21)'▼'");
						int falSzam = Convert.ToInt32(Console.ReadLine());

						Console.Clear();


						if (falSzam < 0 || falSzam > lista.Count)
						{
							Console.WriteLine(tomb[16]);
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

		static void mentes(char[,] mentesPalya, string nyelvezet)
		{

			string[] tomb = File.ReadAllLines($"{nyelvezet}.txt");

			Console.WriteLine(tomb[17]);
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
			while (true)
			{
				Console.Clear();
				string[] tomb = File.ReadAllLines($"{nyelvezet}.txt");
				for (int i = 0; i < 5; i++)
				{
					Console.WriteLine(tomb[i]);
				}

				List<char> falak = new List<char>() { '╬', '═', '╦', '╩', '║', '╣', '╠', '╗', '╝', '╚', '╔', '█', '▄', '♣', '♂', '♀', '♫', '☼', '↓', '→', '↑', '▼' };

				Console.WriteLine();




				int bekeres = Convert.ToInt32(Console.ReadLine());
				if (bekeres == 1)
				{
					Console.WriteLine(tomb[5]);

					string kordinata = Console.ReadLine();
					string[] kordinataTomb = kordinata.Split(":");


					int szam = Convert.ToInt32(kordinataTomb[0]);
					int szam2 = Convert.ToInt32(kordinataTomb[1]);

					szerkeztes(palyaKeszites(szam, szam2), falak, nyelvezet);

				}


				else if (bekeres == 2)
				{
					Console.WriteLine(tomb[6]);
					string nev = Console.ReadLine();
					szerkeztes(betoltes(nev), falak, nyelvezet);
				}


				else if (bekeres == 3)
				{
					Console.WriteLine("Válasszon nyelvet: magyar vagy angol: ");
					string nyelvValtas = Console.ReadLine();
					nyelvezet = nyelvValtas;
					continue;
				}

				else if (bekeres == 4)
				{
					Environment.Exit(0);
				}
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

		static void Ellenoriz(char[,] palya, List<char> lista, string nyelvezet)
		{
			string[] tomb = File.ReadAllLines($"{nyelvezet}.txt");
			bool vanSzoba = false;
			bool elerhetetlenFal = false;
			int szobaSzamlalo = 0;

			bool[,] ellenorzo = new bool[palya.GetLength(0), palya.GetLength(1)];

			for (int i = 0; i < ellenorzo.GetLength(0); i++)
			{
				for (int j = 0; j < ellenorzo.GetLength(1); j++)
				{
					ellenorzo[i, j] = false;
				}
			}


			for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
			{
				for (int oszlopIndex = 0; oszlopIndex < palya.GetLength(1); oszlopIndex++)
				{
					if (palya[sorIndex,oszlopIndex] != JEL && sorIndex > 1 && sorIndex < palya.GetLength(0)-1 && oszlopIndex > 1 && oszlopIndex < palya.GetLength(1)-1 )
					{

						if (palya[sorIndex+1,oszlopIndex]== JEL && palya[sorIndex-1 , oszlopIndex] == JEL && palya[sorIndex, oszlopIndex+1] == JEL 
							&& palya[sorIndex, oszlopIndex-1] == JEL)
						{
							elerhetetlenFal = true;
							Console.WriteLine(tomb[25]);
						}

					}
					if (palya[sorIndex,oszlopIndex] == '█')
					{
						szobaSzamlalo++;
						vanSzoba = true;
					}
				}
			}

			bool vanKijaratBal= false;
			bool vanKijaratJobb = false;
			bool vanKijaratFent = false;
			bool vanKijaratAlul = false;
			for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
			{
				if (palya[sorIndex, 0] == lista[0] || palya[sorIndex, 0] == lista[1] || palya[sorIndex, 0] == lista[2] || palya[sorIndex, 0] == lista[3]
					|| palya[sorIndex, 0] == lista[5] || palya[sorIndex, 0] == lista[7] || palya[sorIndex, 0] == lista[8])
				{
					vanKijaratBal = true;
					Console.WriteLine(tomb[21]);
					
				}

				if (palya[sorIndex, palya.GetLength(1) - 1] == lista[0] || palya[sorIndex, palya.GetLength(1) - 1] == lista[1]
						|| palya[sorIndex, palya.GetLength(1) - 1] == lista[2] || palya[sorIndex, palya.GetLength(1) - 1] == lista[3]
						|| palya[sorIndex, palya.GetLength(1) - 1] == lista[6] || palya[sorIndex, palya.GetLength(1) - 1] == lista[9]
						|| palya[sorIndex, palya.GetLength(1) - 1] == lista[10])
				{
					vanKijaratJobb = true;
					Console.WriteLine(tomb[22]);

				}

			}
			for (int oszlopIndexe = 1; oszlopIndexe < palya.GetLength(1) - 1; oszlopIndexe++)
			{
				if (palya[0, oszlopIndexe] == lista[0] || palya[0, oszlopIndexe] == lista[3] || palya[0, oszlopIndexe] == lista[4]
					|| palya[0, oszlopIndexe] == lista[5] || palya[0, oszlopIndexe] == lista[6] || palya[0, oszlopIndexe] == lista[8] || palya[0, oszlopIndexe] == lista[9])
				{
					vanKijaratFent = true;
					Console.WriteLine(tomb[23]);
				}

				if (palya[palya.GetLength(0) - 1, oszlopIndexe] == lista[0] || palya[palya.GetLength(0) - 1, oszlopIndexe] == lista[2] 
					|| palya[palya.GetLength(0) - 1, oszlopIndexe] == lista[4] || palya[palya.GetLength(0) - 1, oszlopIndexe] == lista[5]
					|| palya[palya.GetLength(0) - 1, oszlopIndexe] == lista[6] || palya[palya.GetLength(0) - 1, oszlopIndexe] == lista[7] 
					|| palya[palya.GetLength(0) - 1, oszlopIndexe] == lista[10])
				{
					vanKijaratAlul = true;
					Console.WriteLine(tomb[24]);
				}

			}

			if (vanSzoba && vanKijaratAlul && elerhetetlenFal==false || vanSzoba && vanKijaratBal && elerhetetlenFal == false
				|| vanSzoba && vanKijaratJobb && elerhetetlenFal == false || vanSzoba && vanKijaratFent && elerhetetlenFal == false)
			{
				Console.WriteLine(tomb[20]+ " {0}db",szobaSzamlalo);
				mentes(palya, nyelvezet);
			}

			else
			{
				Console.WriteLine(tomb[19]);
				string valasz = Console.ReadLine();

				if (valasz == "igen")
				{
					mentes(palya, nyelvezet);
				}
			}
		}
	}
}