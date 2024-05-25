using System.Windows;

namespace SAE_Dungeons.view
{
    /// <summary>
    /// Logique d'interaction pour StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        #region Constructors
        public StartWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Operations
        /// <summary>
        /// Gère le click du bouton appelant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaunchTaille(object sender, RoutedEventArgs e)
        {
            TailleWindow difficulteWindow = new TailleWindow();
            difficulteWindow.Show();
            Close();
        }
        #endregion
    }
}
