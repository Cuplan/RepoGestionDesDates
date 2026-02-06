using System;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Calculateur d'Index de Jour (Format AAA/Logging) ===");
            bool continuer = true;

            while (continuer)
            {
                try
                {
                    // 1. Saisie des données
                    Console.WriteLine("\n--- Nouvelle saisie ---");
                    Console.Write("Entrez le mois (1-12) : ");
                    int mois = int.Parse(Console.ReadLine());

                    Console.Write("Entrez le jour (1-31) : ");
                    int jour = int.Parse(Console.ReadLine());

                    Console.Write("Entrez l'année : ");
                    int annee = int.Parse(Console.ReadLine());

                    // 2. Appel de ta méthode (Arrange & Act)
                    Console.WriteLine($"\n[LOG] Calcul pour le {jour}/{mois}/{annee}...");
                    int index = exo3_.Class1.CalculateDayIndexInYear(mois, jour, annee);

                    // 3. Résultat (Assert visuel)
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[SUCCÈS] L'index du jour est : {index}");
                    Console.ResetColor();
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERREUR] Bro, il faut entrer des chiffres, pas des lettres !");
                    Console.ResetColor();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[VALIDATION] {ex.Message}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[FATAL] Un truc bizarre est arrivé : {ex.Message}");
                }

                // 4. Option pour recommencer
                Console.Write("\nVoulez-vous tester une autre date ? (o/n) : ");
                continuer = Console.ReadLine()?.ToLower() == "o";
            }

            Console.WriteLine("\nBye ! Bonne chance pour ton DEC.");
            System.Threading.Thread.Sleep(1500); // Petite pause avant de fermer
        }
    }
}