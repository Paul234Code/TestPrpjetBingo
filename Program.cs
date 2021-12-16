using System;
using System.Collections.Generic;

namespace TestPrpjetBingo
{
    internal class Program
    {
         static void Main(string[] args)
        {
            //Dictionary<char, int[]> Boulier = new Dictionary<char, int[]>();
            var EnsembleCarteJoueur = new Dictionary<int, int[,]>();
            int[,] Carte1 = new int[15, 5];
            int[,] Carte2 = new int[5, 5];
            int[,] Carte3 = new int[5, 5];
            int[,] Carte4 = new int[5, 5];
            Program program = new Program();          
            Console.WriteLine("Carte de Annonceur:");
            Console.WriteLine();
            program.AfficheAnnonceur(Carte1);
            Console.WriteLine("==================================================================");
            Console.WriteLine("Carte2:");
            program.AfficheAnnonceur(Carte2);
            Console.WriteLine("==================================================================");
            Console.WriteLine("Carte3:");
            program.AfficheAnnonceur(Carte3);
            Console.WriteLine();
            Console.WriteLine("==================================================================");
            List<int> liste = new List<int>()
            { 12,13,24,10,30,49,56,67,90};
            List<int> liste1 = liste.GetRange(0, 5);
            liste1.Sort();
            int[] tab = liste1.ToArray();
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }

            // L'ensemble des carte du joeur
            EnsembleCarteJoueur.EnsureCapacity(1);
            EnsembleCarteJoueur.Add(1, Carte1);
            EnsembleCarteJoueur.Add(2, Carte2);
            EnsembleCarteJoueur.Add(3, Carte3);
            EnsembleCarteJoueur.Add(4, Carte4);
            int[,] carteJoueur = new int[5, 5];
            Console.WriteLine("======================================================================");
            Carte1[2, 1] = 23;
            program.AfficheAnnonceur(Carte1);
            Console.WriteLine("======================================================================");
            program.AfficheAnnonceur(carteJoueur);         
            Console.WriteLine("======================================================================");
            int[,] Tableau = new int[,]
            {
                {1,16,31,46,61 },
                {2,17,32,47,62},
                {3,18,33,48,63},
                {4,19,34,49,64 },
                {5,20,35,50,65 },
                {6,21,36,51,66 },
                {7,22,37,52,67 },
                {8,23,38,53,68 },
                {9,24,39,54,69 },
                {10,25,40,55,70 },
                {11,26,41,56,71 },
                {12,27,42,57,72 },
                {13,28,43,58,73 },
                {14,29,44,59,74 },
                {15,30,45,60,75 }
            };
            program.AfficheAnnonceur(Tableau);
            bool trouver = program.Verifier(Tableau, 3);
            Console.WriteLine("oui 65 est dans le tableau = "+trouver);              
        }

        // Fonction qui permet de verifier si un entier ou une boule dans le tableau
        // fonction a utilser dans pour verifier qu'une boole tirée est present dans la carte 
        public bool Verifier(int[,] Tableau, int numero)
        {
            bool trouve = false;
            int ligne = 0;
            while (ligne < Tableau.GetLength(0))
            {
                for (int colonne  = 0; colonne < Tableau.GetLength(1); colonne++)
                {
                    if (Tableau[ligne,colonne] == numero)
                    {
                        trouve = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }                   
                }
                ligne++;
            }
            return trouve;
        }
        // Fonction qui permet de construire une carte du joueur
        public int[,] CreerCarteJoueur(int[,] Tab,int numeroColonne)
        {
            int[,] Tableau = new int[5, 5];
            Random random = new Random();
            Tableau[2, 2] = 0;
            Tableau[2, 3] = 0;
            int ligne = random.Next(Tableau.GetLength(0));
            int colonne  = random.Next(Tableau.GetLength(1));
            int compteur = 0;
            int randomNumber = Tab[ligne,colonne];
            while (compteur < 100)
            {
                if(randomNumber <= 15)
                {


                }
            }
           return Tableau;
        }

        // Rechercher une carte dans le dictionnaire par son numero
        public int[,] RechercherCarte(Dictionary<int, int[,]> dictionnaire)
        {
            Console.WriteLine("Combien de carte voulez-vous afficher:(max 4)");
            string numero = Console.ReadLine();
            bool resultat = int.TryParse(numero, out int carte);
            int[,] tab = new int[5, 5];
            if (resultat)
            {
                if (carte > 0)
                {
                    bool result = dictionnaire.ContainsKey(carte);
                    if (result)
                    {
                        tab = dictionnaire[carte];
                    }
                    else
                    {
                        tab = null;
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter un numero de carte valide");
            }
            return tab;
        }
        public void afficherCarteJoueur(int[,] tab)
        {
            int i = 0;

            while (i < tab.GetLength(0))
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write("\t" + tab[i, j] + "\t");
                }
                i++;

            }
            Console.WriteLine();
        }
        // Fonction qui permet d'afficher la carte de l'annonceur
        public void AfficheAnnonceur(int[,] tab)
        {
            int i = 0;
            Console.WriteLine($"{'B'}\t{'I'}\t{'N'}\t{'G'}\t{'O'}");
            while (i < tab.GetLength(0))
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write($"{tab[i, j]}\t");

                }
                Console.WriteLine();
                i++;
            }
        }
        public void AfficherTableau(int[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write($"{tab[i]}\t");
            }
            Console.WriteLine();
        }


    }
    
}
