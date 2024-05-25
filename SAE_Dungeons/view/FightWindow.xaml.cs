using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SAE_Dungeons.view
{
    /// <summary>
    /// Logique d'interaction pour FightWindow.xaml
    /// </summary>
    public partial class FightWindow : Window
    {
        #region Attributes
        private GameWindow gameWindow;
        private Monster monster;
        private Player player;
        private bool launched;
        private bool finishLegaly;
        private Stopwatch stopwatch;
        #endregion

        #region Constructor
        public FightWindow(GameWindow gameWindow, Monster monster)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            this.monster = monster;
            this.player = gameWindow.Player;
            this.launched = false;
            this.stopwatch = new Stopwatch();
            this.finishLegaly = false;

            gameWindow.Visibility = Visibility.Hidden;

            knightPV.Content = this.player.PV;

            this.Closed += MyWindow_Closed;
        }
        #endregion

        #region Operations
        /// <summary>
        /// Renvoie si le joueur est mort
        /// </summary>
        private void CheckPlayerDie()
        {
            if (player.isDead())
            {
                finishLegaly = true;
                Close();

                EndWindow endWindow = new EndWindow(this.gameWindow, this.player);
            }
        }

        /// <summary>
        /// Renvoie si le joueur ou le monstre est battue
        /// </summary>
        /// <returns></returns>
        private bool CheckEndBattle()
        {
            CheckPlayerDie();
            
            if (int.Parse(monsterPV.Content.ToString()) <= 0)
            {
                finishLegaly = true;
                Close();
                gameWindow.knightPV.Content = player.PV;
                player.OrkKill = player.OrkKill + 1;
                gameWindow.Visibility = Visibility.Visible;
                monster.SetActive(false);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gère le fonctionnement d'une bataille entre le joueur et le monstre
        /// </summary>
        private async void Battle()
        {
            Random random = new Random();
            double randomValue = random.NextDouble();
            float time = (float)(2.0 + randomValue * (5.0 - 2.0));

            await Task.Delay(TimeSpan.FromSeconds(time));
            orkState.Content = "Attaquer !";

            int randomRow = (random.Next(2) == 0) ? 5 : 7;
            int randomCol = (random.Next(2) == 0) ? 1 : 3;

            Grid.SetRow(attackButton, randomRow);
            Grid.SetColumn(attackButton, randomCol);
            attackButton.Visibility = Visibility.Visible;

            stopwatch.Restart();

            launched = true;
            while (launched)
            {
                if (stopwatch.Elapsed.Milliseconds / 100 > 5.0f)
                {
                    player.PV = int.Parse(knightPV.Content.ToString()) - 5;
                    knightPV.Content = player.PV.ToString();
                    ResetState();
                    return;
                }

                await Task.Delay(100);
            }

            return;
        }

        /// <summary>
        /// Gère la pré-bataille
        /// </summary>
        private void ResetState()
        {
            launched = false;
            attackButton.Visibility = Visibility.Hidden;
            orkState.Content = "Attendez...";

            if (CheckEndBattle() || !IsVisible) return;
            else Battle();
        }

        /// <summary>
        /// Lance une nouvelle bataille
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaunchBattle(object sender, RoutedEventArgs e)
        {
            launched = true;

            Button button = sender as Button;
            button.Visibility = Visibility.Hidden;

            orkState.Visibility = Visibility.Visible;

            Battle();
        }

        /// <summary>
        /// Lance une attaque sur le monstre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttackEnemy(object sender, RoutedEventArgs e)
        {
            monsterPV.Content = (int.Parse(monsterPV.Content.ToString()) - 5).ToString();
            ResetState();
        }
        
        /// <summary>
        /// Gère la fermeture brut de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyWindow_Closed(object sender, EventArgs e)
        {
            launched = false;

            gameWindow.Visibility = Visibility.Visible;

            if (!finishLegaly) // Si fermée de force
            {
                player.PV = Math.Max(int.Parse(knightPV.Content.ToString()) - 15, 0);
                gameWindow.knightPV.Content = player.PV;
                CheckPlayerDie();
            }
        }
        #endregion
    }
}
