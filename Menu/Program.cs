using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TabBtsVS
{
    class Program
    {
        public static void appeler_menu()
        {
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine(" Gestion des Notes de BTS");
            Console.WriteLine(" 1 - Remplir les tableaux MAT,ELEVE,NOTES");
            Console.WriteLine(" 2 - editer le tableau des matières ");
            Console.WriteLine(" 3 - editer la liste des eleves");
            Console.WriteLine(" 4 - editer le tableau des BTS");
            Console.WriteLine(" 5 - remplir un controle d'une matière dont on introduit le libellé");
            Console.WriteLine(" 6 - editer le détail d'un contrôle d'une matière dont on introduit le libellé ");
            Console.WriteLine(" 7 -éditer liste des eleves (avec leur moyenne) et la moyenne de la classe ");
            Console.WriteLine(" 10 - sortir");
        }

        public static void remplir(ref string[] tabMat, ref string[] tabEtud, ref double[,] tabNotes)
        {
            int i, j;
            tabMat[0] = "SI1"; tabMat[1] = "SI2"; tabMat[2] = "SI3"; tabMat[3] = "SI4"; tabMat[4] = "Maths";
            tabMat[5] = "Francais"; tabMat[6] = "Anglais"; tabMat[7] = "PPE"; tabMat[8] = "Edm";
            tabEtud[0] = "André"; tabEtud[1] = "Benard"; tabEtud[2] = "Bernier";
            tabEtud[3] = "Boulahbas"; tabEtud[4] = "Camier"; tabEtud[5] = "Chevreul";
            tabEtud[6] = "Debeauvais"; tabEtud[7] = "Demars"; tabEtud[8] = "Domart";
            tabEtud[9] = "Dubois";

            // tableau initialisé à 99 partout
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    tabNotes[i, j] = 99;
                }
            }
        }

        public static void editerMat(string[] mat)
        {
            int i;
            for (i = 0; i < mat.Length; i++)
            {
                Console.WriteLine(mat[i]);
            }
        }

        public static void editerEtud(string[] Etud)
        {
            int i;
            for (i = 0; i < Etud.Length; i++)
            {
                Console.WriteLine(Etud[i]);
            }
        }

        public static void editerBts(string[] mat, string[] etud, double[,] notes)
        {
            int i, l, c;

            Console.Write("\t");

            for (i = 0; i < 9; i++)
            {
                Console.Write(mat[i] + " ");
            }

            Console.WriteLine();

            for (l = 0; l < 10; l++)
            {
                Console.Write(etud[l] + " ");

                for (c = 0; c < 9; c++)
                {
                    Console.Write(notes[l, c] + " ");
                }

                Console.WriteLine();
            }
        }

        static void editerControleMatiere(string[] tabMatieres, double[,] tabNotes, string[] tabEleves)
        {
            string matiere;
            double note;
            int indexMatiere = 0;

            Console.WriteLine("Veuillez entrer une matière");
            matiere = Console.ReadLine();

            if(tabMatieres.Contains(matiere))
            {
                for(int i = 0; i < tabMatieres.Length; i++)
                {
                    if (matiere == tabMatieres[i])
                        indexMatiere = i;
                }

                for(int i = 0; i < tabEleves.Length; i++)
                {
                    Console.WriteLine("Veuillez entrer la note pour " + tabEleves[i]);
                    note = double.Parse(Console.ReadLine());

                    tabNotes[i, indexMatiere] = note;
                }
            }
            else
            {
                Console.WriteLine("Cette matière n'existe pas");
            }
        }

        static void afficherNotesMatiere(string[] tabMatiere, double[,] tabNotes, string[] tabEleves)
        {
            string matiere;
            int indexMatiere = 0;

            Console.WriteLine("Veuillez inscrire la matière à afficher");
            matiere = Console.ReadLine();

            if(tabMatiere.Contains(matiere))
            {
                for(int i = 0; i < tabMatiere.Length; i++)
                {
                    if (tabMatiere[i] == matiere)
                        indexMatiere = i;                    
                }

                for(int i = 0; i < tabEleves.Length; i++)
                {
                    Console.WriteLine(tabEleves[i] + "\t" + tabNotes[i, indexMatiere]);
                }
            }
            else
            {
                Console.WriteLine("Cette matière n'existe pas");
            }
        }

        static void afficherMoyenne(string[] tabEleves, string[] tabMatieres, double[,] tabNotes)
        {
            double moyenneEleve = 0, moyenneClasse;
            int compteur = 0;

            // moyenne de l'eleve sera le ses notes * le nombre de matieres
            // moyenne de classe sera la moyenne entre une matiere et plusieurs eleves

            //      Matiere Matiere Matiere

            //nom   note    note    note        Moyenne eleve
            //nom   note    note    note        Moyenne eleve
            //nom   note    note    note        Moyenne eleve

            //      classe  classe  classe


            // Pour les élèves 2 boucles une de première de longueur élève dedans  
            // fais une boucle de longueur matière et dans le for de matière tu vérifies 
            // si la note est différente de 99 et si c’est le cas tu rentre la valeur dans une variable 
            // et faut que tu compte de nombre de note aussi et une fois la boucle matière est fini 
            // (j’ai créé une nouvelle liste pour la moyenne élève ) et tu rentres la variable avec la 
            // somme des notes que tu as compter dans la boucles matière / par nombre des notes et après 
            // ça va recommencer pour le deuxième élève
            for (int i = 0; i < tabEleves.Length; i++)
            {
                for(int j = 0; j < tabMatieres.Length; j++)
                {
                    moyenneEleve = 0;
                    if(tabNotes[i, j] != 99)
                    {
                        moyenneEleve += tabNotes[i, j];
                        Console.WriteLine(tabNotes[i, j]);
                        compteur += 1;
                    }
                }
                moyenneEleve = moyenneEleve / compteur;
                Console.WriteLine(moyenneEleve);
                   
            }
        }

        static void Main(string[] args)
        {
            string[] tabMat = new string[9];
            string[] tabEtud = new string[10];
            double[,] tabNotes = new double[10, 9];
            int choix = 0;

            while (choix != 10)
            {
                appeler_menu();

                Console.WriteLine("Entrez votre choix?");
                choix = Int16.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        remplir(ref tabMat, ref tabEtud, ref tabNotes);
                        break;
                    case 2:
                        editerMat(tabMat);
                        Console.ReadLine();
                        break;
                    case 3:
                        editerEtud(tabEtud);
                        Console.ReadLine();
                        break;
                    case 4:
                        editerBts(tabMat, tabEtud, tabNotes);
                        Console.ReadLine();
                        break;
                    case 5:
                        editerControleMatiere(tabMat, tabNotes, tabEtud);
                        Console.ReadLine();
                        break;
                    case 6:
                        afficherNotesMatiere(tabMat, tabNotes, tabEtud);
                        Console.ReadLine();
                        break;
                    case 7:
                        afficherMoyenne(tabEtud, tabMat, tabNotes);
                        Console.ReadLine();
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
