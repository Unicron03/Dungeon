using System.Windows;

namespace SAE_Dungeons.view
{
    /// <summary>
    /// Logique d'interaction pour SkinWindow.xaml
    /// </summary>
    public partial class TailleWindow : Window
    {
        #region Attributes
        private TailleWindow tailleWindow;
        private string taille;
        #endregion

        #region Constructor
        public TailleWindow()
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
        public void ClickValider(object sender, RoutedEventArgs e)
        {
            int n;
            taille = MainTextbox.Text;
            bool isNumeric = int.TryParse(taille, out n);
            if (isNumeric)
            {
                int valTaille = int.Parse(taille);
                DifficulteWindow difficulteWindow = new DifficulteWindow(valTaille);
                difficulteWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Seulement des chiffres !", MainTextbox.Text);
            }
        }
        #endregion
    }
}
