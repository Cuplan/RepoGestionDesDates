using System;
using System.Windows;
using System.Windows.Media;

namespace test
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Petit feedback au démarrage
            LblResult.Text = "Prêt pour le calcul !";
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Reset du style pour chaque nouveau calcul
            ResetFeedback();

            try
            {
                // 1. Validation de la saisie numérique
                if (!int.TryParse(TxtDay.Text, out int d) ||
                    !int.TryParse(TxtMonth.Text, out int m) ||
                    !int.TryParse(TxtYear.Text, out int y))
                {
                    ShowFeedback("Erreur : Entre des nombres entiers, bro !", Brushes.Tomato);
                    return;
                }

                // 2. Appel de ta logique métier (exo3_)
                int result = exo3_.Class1.CalculateDayIndexInYear(m, d, y);

                // 3. Feedback de succès
                ShowFeedback($"Succès ! C'est le jour {result} de l'année.", Brushes.Cyan);

                // Optionnel : Un petit pop-up pour le "feeling"
                MessageBox.Show($"L'index calculé est : {result}", "Calcul terminé", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Feedback précis sur l'erreur de date (ex: 29 fév en 2023)
                // On récupère juste la première phrase de l'exception pour pas polluer l'UI
                string cleanMessage = ex.Message.Contains("\r\n") ? ex.Message.Substring(0, ex.Message.IndexOf("\r\n")) : ex.Message;
                ShowFeedback($"Oups : {cleanMessage}", Brushes.Yellow);
            }
            catch (Exception ex)
            {
                // Feedback pour tout autre problème imprévu
                ShowFeedback("Erreur inattendue... vérifie tes inputs.", Brushes.OrangeRed);
                Console.WriteLine($"[DEBUG] {ex.Message}");
            }
        }

        // Méthode helper pour centraliser le feedback visuel
        private void ShowFeedback(string message, Brush color)
        {
            LblResult.Foreground = color;
            LblResult.Text = message;
        }

        private void ResetFeedback()
        {
            LblResult.Foreground = Brushes.Gray;
            LblResult.Text = "Calcul en cours...";
        }
    }
}