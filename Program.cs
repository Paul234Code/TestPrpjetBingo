
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
            int[,] Annonceur = new int[15, 5];
            int[,] Joueur1 = new int[5, 5];
            int[,] Joueur2 = new int[5, 5];
            int[,] Joueur3 = new int[5, 5];
            int[,] Joueur4 = new int[5, 5];
            Program program = new Program();
            Console.WriteLine("Carte Annonceur sans tirage de boule :");
            Console.WriteLine();
            program.AfficheAnnonceur(Annonceur);
            // L'ensemble des carte du joeur
            EnsembleCarteJoueur.EnsureCapacity(1);
            EnsembleCarteJoueur.Add(1, Joueur1);
            EnsembleCarteJoueur.Add(2, Joueur2);
            EnsembleCarteJoueur.Add(3, Joueur3);
            EnsembleCarteJoueur.Add(4, Joueur4);
            int[,] carteJoueur = new int[5, 5];
            Joueur1[2, 1] = 23;
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
            bool trouver = program.Verifier(Tableau, 60);
            Console.WriteLine("oui 65 est dans le tableau = " + trouver);
            //Console.WriteLine("=========================================");
            program.AfficheAnnonceur(Tableau);
            List<int> liste2 = new List<int>() {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,
                                                 16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,
                                                 31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,
                                                  46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,
                                                  61,62,63,64,65,66,67,68,69,70,71,72,73,74,75};

            int[,] carte1 = program.CreerCarteJoueur(liste2);
            int[,] carte2 = program.CreerCarteJoueur(liste2);
            int[,] carte3 = program.CreerCarteJoueur(liste2);
            program.AfficheAnnonceur(carte1);
            program.AfficheAnnonceur(carte2);
            program.AfficheAnnonceur(carte3);
            int compteur = 75;
           var myEnumerator =  liste2.GetEnumerator();
            while(compteur>50)
            {
                int valeur = program.RandomBall(liste2);
                program.Ajouter(Annonceur, valeur);
                compteur--;
            }          
            program.AfficheAnnonceur(Annonceur);
        }
        // Fonction qui permet de retirer une boule au hazard dans le boulier
        public int RandomBall(List<int> liste)
        {
            Random random = new Random();
            int index = random.Next(0, liste.Count);
            int valeur = liste[index];
            liste.RemoveAt(index);
            return valeur;
        }
        // Fonction qui permet de verifier si un entier ou une boule dans le tableau
        // fonction a utilser dans pour verifier qu'une boole tirée est present dans la carte  du joueur
        public bool Verifier(int[,] Tableau, int numero)
        {
            bool trouve = false;
            int ligne = 0;
            while (ligne < Tableau.GetLength(0))
            {
                for (int colonne = 0; colonne < Tableau.GetLength(1); colonne++)
                {
                    if (Tableau[ligne, colonne] == numero)
                    {
                        trouve = true;
                        Tableau[ligne, colonne] = 0;
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
        // Fonction qui ajoute une boule tirée au hasard dans la carte de l'annonceur
        public void Ajouter (int[,] Tab, int valeur)
        {
            if(valeur <= 15)
            {
                InsererNumber(Tab,valeur, 0);

            }else if(valeur <= 30)
            {
                InsererNumber(Tab,valeur, 1);

            }
            else if (valeur <= 45)
            {
                InsererNumber(Tab,valeur, 2);

            }
            else if(valeur <= 60)
            {
                InsererNumber(Tab,valeur, 3);

            }
            else
            {
                InsererNumber(Tab,valeur, 4);

            }
        }
        // Fonction qui permet d'inserer une boule dans une colonne de la carte de l'annonceur
        public void InsererNumber(int [,] Tab, int valeur,int colonne)
        {
            List<int> liste = new List<int>();
            //liste.Add(valeur);
            for(int ligne = 0; ligne < Tab.GetLength(0); ligne++)
            {
                if(Tab[ligne,colonne] == 0)
                {
                    Tab[ligne,colonne] = valeur;
                    break;
                }
            }
            liste.Sort();
            for (int i = 0; i < Tab.GetLength(0); i++)
            {
               liste.Add(Tab[i,colonne]);

            }
            liste.Sort();
            liste.Reverse();
            for(int i = 0;i < liste.Count; i++)
            {
                Tab[i,colonne] = liste[i];
            }


        }
        // Fonction qui permet de construire une carte du joueur
        public int[,] CreerCarteJoueur(List<int> liste)
        {
            int[,] Tableau = new int[5, 5];
            Tableau[2, 2] = 0;
            List<int> listeB = Construire(liste,1,15);
            List<int> listeI = Construire(liste,16,30);
            List<int> listeN = ConstruireMilieu(liste,31,45);
            List<int> listeG = Construire(liste,46,60);
            List<int> listeO = Construire(liste,61,75);           
            for(int i = 0; i < listeB.Count; i++)
            {
                Tableau[i,0] = listeB[i];
                Tableau[i,1] = listeI[i];
                Tableau[i,3] = listeG[i];
                Tableau[i,4] = listeO[i];
            }
            Tableau[0, 2] = listeN[0];
            Tableau[1, 2] = listeN[1];
            Tableau[3, 2] = listeN[2];
            Tableau[4, 2] = listeN[3];
            return Tableau;
        }
        // permet de construire les colonnes B,I,G,0
        public List<int>Construire(List<int> liste, int minimum,int maximum)
        {
            List<int> listeB = new List<int>();
            int indice;
            int randomNumber;
            //int compteur = 0;
            Random random = new Random();
            while (listeB.Count < 5)
            {
                indice = random.Next(0, liste.Count);
                randomNumber = liste[indice];
                if (minimum <= randomNumber && randomNumber <= maximum)
                {
                    if (!listeB.Contains(randomNumber))
                    {
                        listeB.Add(randomNumber);                       
                    }
                }               
            }
            return listeB;
        }
        // fonction qui construit la colonne du milieu N
        public List<int> ConstruireMilieu(List<int> liste, int minimum, int maximum)
        {
            List<int> listeB = new List<int>();
            int indice, randomNumber;
            Random random = new Random();
            while (listeB.Count < 5)
            {
                indice = random.Next(0, liste.Count);
                randomNumber = liste[indice];
                if (minimum <= randomNumber && randomNumber <= maximum)
                {
                    if (!listeB.Contains(randomNumber))
                    {
                        listeB.Add(randomNumber);                       
                    }
                }
            }
            return listeB;
        }
        // Rechercher une carte dans le dictionnaire par son numero pour ensuite l'afficher
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
        // Fonction qui permet d'afficher la carte de l'annonceur, le boulier, la carte du joueur
        public void AfficheAnnonceur(int[,] tab)
        {
            int i = 0;
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"{'B'}\t| {'I'}\t| {'N'}\t| {'G'}\t| {'O'}\t|");
            Console.WriteLine("-----------------------------------------");
            while (i < tab.GetLength(0))
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write($"{tab[i, j]}\t| ");
                }
                Console.WriteLine();
                i++;
            }            
            Console.WriteLine("-----------------------------------------");
        }
        // Fonction qui permet d'afficher une carte du joueur,le boulier, la carte de l'annonceur
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
