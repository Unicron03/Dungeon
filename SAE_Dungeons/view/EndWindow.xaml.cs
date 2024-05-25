using System.Windows;

namespace SAE_Dungeons.view
{
    /// <summary>
    /// Logique d'interaction pour EndWindow.xaml
    /// </summary>
    public partial class EndWindow : Window
    {
        #region Attributes
        GameWindow gameWindow;
        Player player;
        #endregion

        #region Constructor
        public EndWindow(GameWindow gameWindow, Player player)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            this.player = player;

            SetObjects();

            gameWindow.Close();
            gameWindow.SetPositionWindow(this, "center");
            Show();

            if (player.isDead())
                Sounds.PlaySound("gameover");
            else
                Sounds.PlaySound("win");
        }
        #endregion

        #region Operations
        /// <summary>
        /// Initialise les variables des labels
        /// </summary>
        private void SetObjects()
        {
            resultGame.Content = player.isDead() ? "You die in the dungeon !" : "You beat the dungeon !";
            knightPV.Content = player.PV;
            orkKill.Content = player.OrkKill;
            treasure.Content = player.TreasureRecup;
        }

        /// <summary>
        /// Relance l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RelaunchApplication(object sender, RoutedEventArgs e)
        {
            gameWindow.RelaunchApplication();
        }

        /// <summary>
        /// Ferme l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion
    }
}
