using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;

namespace SAE_Dungeons.view
{
    /// <summary>
    /// Logique d'interaction pour DifficulteWindow.xaml
    /// </summary>
    public partial class DifficulteWindow : Window
    {
        #region Attributes
        private int taille;
        #endregion

        #region Constructor
        public DifficulteWindow(int taille)
        {
            InitializeComponent();
            this.taille = taille;
        }
        #endregion

        #region Operations
        /// <summary>
        /// Applique la difficulté du jeu selon le tag de son appelant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDifficulty(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            GameWindow gameWindow = new GameWindow(this.taille, int.Parse(button.Tag.ToString()));
            gameWindow.Show();
            Close();
        }
        #endregion
    }
}
