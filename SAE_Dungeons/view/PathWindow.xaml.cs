using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SAE_Dungeons.view
{
    /// <summary>
    /// Logique d'interaction pour PathWindow.xaml
    /// </summary>
    public partial class PathWindow : Window
    {
        #region Attributes
        private GameWindow gameWindow;
        #endregion

        #region Constructors
        public PathWindow(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
        }
        #endregion

        #region Operations
        /// <summary>
        /// Empêche l'ajout d'un caractère non numérique dans son appelant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coord_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Vérifie si le texte entré est un chiffre
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Refocus du texte de son appelant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coord_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int value;
            if (!int.TryParse(textBox.Text, out value) || value < 0 || value > GameWindow.Graph.Taille - 1)
            {
                textBox.Text = "0";
            }
        }

        /// <summary>
        /// Affiche le plus court chemin vers une case
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawShortestPath(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            object parameter = button.CommandParameter;

            switch (parameter)
            {
                case "treasure":
                    if(Inventory.Treasure)
                    {
                        CleanShortestPath(this, e);
                        gameWindow.DrawShortestPath(Inventory.TreasureCoords[0], Inventory.TreasureCoords[1]);
                    }
                    break;
                case "ork":
                    CleanShortestPath(this, e);
                    foreach (Monster monster in gameWindow.Monsters)
                    {
                        if(monster.OrkVisualVisibility == Visibility.Visible)
                        {
                            gameWindow.DrawShortestPath(monster.OrkCoords[0], monster.OrkCoords[1]);
                        }
                    }
                    break;
                case "enter":
                    CleanShortestPath(this, e);
                    gameWindow.DrawShortestPath(0, 0);
                    break;
                case "exit":
                    CleanShortestPath(this, e);
                    gameWindow.DrawShortestPath(GameWindow.Graph.Taille - 1, GameWindow.Graph.Taille - 1);
                    break;
                default:
                    CleanShortestPath(this, e);
                    gameWindow.DrawShortestPath(int.Parse(Ycoord.Text), int.Parse(Xcoord.Text));
                    break;
            }

            Close();
        }

        /// <summary>
        /// Supprime l'affichage du chemin le plus court cf.DrawShortestPath
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CleanShortestPath(object sender, RoutedEventArgs e)
        {
            gameWindow.CleanShortestPath();
        }
        #endregion
    }
}
