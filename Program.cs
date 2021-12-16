using System;
using System.Collections.Generic;
using System.Linq;

namespace TestPrpjetBingo
{
    internal class Program
    {
        public static void Main()
        {
            Dictionary<char, int[]> Boulier = new Dictionary<char, int[]>();
            var EnsembleCarteJoueur = new Dictionary<int, int[,]>();
            int[,] Carte1 = new int[15,5];
            int[,] Carte2 = new int[5, 5];
            int[,] Carte3 = new int[5, 5];
            int[,] Carte4 = new int[5, 5];
            Console.WriteLine("Carte de Annonceur:");
            Console.WriteLine();
            new Program().AfficheAnnonceur(Carte1);
            Console.WriteLine("==================================================================");
            Console.WriteLine("Carte2:");
            new Program().AfficheAnnonceur(Carte2);
            Console.WriteLine("==================================================================");
            Console.WriteLine("Carte3:");
            new Program().AfficheAnnonceur(Carte3);
            Console.WriteLine();
            Console.WriteLine("==================================================================");
            List<int> liste = new List<int>()
            { 12,13,24,10,30,49,56,67,90};
            List<int> liste1 =  liste.GetRange(0,5);
            liste1.Sort();
            int[] tab = liste1.ToArray();
            for(int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }

            // L'ensemble des carte du joeur
            EnsembleCarteJoueur.EnsureCapacity(1);
            EnsembleCarteJoueur.Add(1, Carte1);
            EnsembleCarteJoueur.Add(2, Carte2);
            EnsembleCarteJoueur.Add(3,Carte3);
            EnsembleCarteJoueur.Add(4, Carte4);
            Boulier['B'] = new int[] {1,2,3,4,5 };
            Boulier['I'] = new int[] { 6, 7, 8, 9, 10 };
            Boulier['N'] = new int[] { 11, 12, 0, 13, 15 };
            Boulier['G'] = new int[] { 16, 17, 18, 19, 20 };
            Boulier['O'] = new int[] { 21, 22, 23, 24, 25 };
            






            int[,] carteJoueur = new int[5, 5];
           

            Console.WriteLine("======================================================================");
            Carte1[2, 1] = 23;
            new Program().AfficheAnnonceur(Carte1);
            Console.WriteLine("======================================================================");
            new Program().AfficheAnnonceur(carteJoueur);
            var Boulier1 =  new Dictionary<char, int[]>();
            Boulier1['B'] = new int[] { 1, 2, 3, 4, 5 ,6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Boulier1['I'] = new int[] { 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            Boulier1['N'] = new int[] { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
            Boulier1['G'] = new int[] { 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 };
            Boulier1['O'] = new int[] { 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75 };
            Console.WriteLine("======================================================================");
            foreach(var keys in Boulier1.Keys)
            {
                Console.Write($"{keys}\t");
                new Program().AfficherTableau(Boulier1[keys]);
            }
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
            //new Program().AfficheAnnonceur(Tableau);
            Random random = new Random();
            int ligne = random.Next(0, 15);
            int colonne = random.Next(0, 5);
            Console.WriteLine("Boule Tire au hasard = "+ Tableau[ligne,colonne]);
            bool trouver = new Program().Verifier(Tableau, 60);
            Console.WriteLine("Bienvenue dans C#" );


        }
        // Fonction qui permet de verifier si un entier ou une boule dans le tableau
        public bool Verifier( int[,] Tableau ,int numero)
        {
             bool trouve = false;
            int ligne= 0;
            int colonne = 0;
            while(ligne < Tableau.GetLength(0))
            {
                while(colonne < Tableau.GetLength(1))
                {
                    if(Tableau[ligne, colonne] == numero)
                    {
                        trouve = true;
                    }
                    else
                    {
                        trouve=false;
                    }
                }
            }
            return trouve;

        }
        

        // Rechercher une carte dans le dictionnaire par son numero
        public int[,] RechercherCarte(Dictionary<int,int[,]> dictionnaire)
        {
            Console.WriteLine("Combien de carte voulez-vous afficher:(max 4)");
            string numero = Console.ReadLine();
            bool resultat = int.TryParse(numero, out int carte);
            int[,] tab = new int[5,5];
            if (resultat)
            {
                if(carte > 0)
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

            while ( i < tab.GetLength(0))
            {
                for(int j = 0; j < tab.GetLength(1); j++)
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
                for(int j = 0; j< tab.GetLength(1); j++)
                {
                    Console.Write($"{tab[i,j]}\t");

                }
                Console.WriteLine();
                i++;
            }
        }
        public void AfficherTableau(int[] tab)
        {
            for(int i = 0; i < tab.Length; i++)
            {
                Console.Write($"{tab[i]}\t");
            }
            Console.WriteLine();
        }


}
    public class HowToDictionaryInitializer
    {
        class StudentName
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
        }

        
        
        
    }
}
