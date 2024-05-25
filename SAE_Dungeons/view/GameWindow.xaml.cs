using SAE_Dungeons.utils;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SAE_Dungeons.view;
using System.Diagnostics;
using System.Xml.Linq;

namespace SAE_Dungeons
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        #region Attributes
        private List<Monster> monsters;
        private Player player;
        private int difficulty;
        private int taille;
        private static Graph graph;
        #endregion

        #region Properties
        public static Graph Graph => graph;
        public Grid Grid => MainGrid;
        public List<Monster> Monsters => monsters;
        public Player Player => player;
        #endregion

        #region Constructor
        public GameWindow(int taille, int difficulty)
        {
            this.taille = taille;
            this.difficulty = difficulty;
            InitializeComponent();
            SetPositionWindow(this, "left");

            graph = new Graph(this.taille);
            this.monsters = new List<Monster>();
            this.player = new Player(knightPV);

            if (difficulty == 3)
                graph.GeneratePerfectPath();
            else
                graph.GenerateImperfectPath(difficulty);

            InitializeGrid();
            InitializeWallImages();

            this.KeyDown += GameWindow_KeyDown;
        }
        #endregion

        #region Operations
        /// <summary>
        /// Initialise la partie "algo" de la grille
        /// </summary>
        private void InitializeGrid()
        {
            for (int i = 0; i < graph.Taille; i++)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(720 / graph.Taille) });
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(720 / graph.Taille) });
            }

            Grid.SetColumn(trapExit, graph.Taille - 1);
            Grid.SetRow(trapExit, graph.Taille - 1);

            MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(95) });

            SetChestAndMonsterCoords();
            SetGUIBandCoords();
        }

        /// <summary>
        /// Initialise le visuel des murs du donjon
        /// </summary>
        public void InitializeWallImages()
        {
            List<string> elementsToRemove = new List<string> { "wall", "wallVert", "tile_ground" };
            ClearGrid(elementsToRemove);

            // Parcour de la matrice
            for (int i = 0; i < graph.Taille; i++)
            {
                for (int j = 0; j < graph.Taille; j++)
                {
                    // Crée le fond d'une case
                    Image ground = CreateImage("../assets/background/tile_ground.png");
                    AddImageToGrid(ground, i, j, "");

                    // Crée une image pour chaque côté du mur, si nécessaire
                    if (graph.Matrice[i][j][0] == 1)  // Haut
                    {
                        Image image = CreateImage("../assets/background/wall.png");
                        Panel.SetZIndex(image, 3);
                        AddImageToGrid(image, i, j, "top");
                    }
                    if (graph.Matrice[i][j][1] == 1)  // Droite
                    {
                        Image image = CreateImage("../assets/background/wallVert.png");
                        Panel.SetZIndex(image, 3);
                        AddImageToGrid(image, i, j, "right");
                    }
                    if (graph.Matrice[i][j][2] == 1)  // Bas
                    {
                        Image image = CreateImage("../assets/background/wall.png");
                        Panel.SetZIndex(image, 3);
                        AddImageToGrid(image, i, j, "bottom");
                    }
                    if (graph.Matrice[i][j][3] == 1)  // Gauche
                    {
                        Image image = CreateImage("../assets/background/wallVert.png");
                        Panel.SetZIndex(image, 3);
                        AddImageToGrid(image, i, j, "left");
                    }
                }
            }
        }

        /// <summary>
        /// Crée une image
        /// </summary>
        /// <param name="imagePath">chemin de l'image</param>
        /// <returns></returns>
        private Image CreateImage(string imagePath)
        {
            Image image = new Image();

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(imagePath, UriKind.Relative);
            bi.EndInit();
            image.Source = bi;

            string[] segments = imagePath.Split('/');
            string nomFichier = segments.Last().Split('.').First();
            image.Name = nomFichier;

            return image;
        }

        /// <summary>
        /// Supprime de la grille les éléments d'une liste
        /// </summary>
        /// <param name="elementsToRemove">Les éléments de la liste à supprimer</param>
        private void ClearGrid(List<string> elementsToRemove)
        {
            // Parcours des enfants de MainGrid en sens inverse pour éviter les erreurs de modification pendant l'itération
            for (int i = MainGrid.Children.Count - 1; i >= 0; i--)
            {
                UIElement element = MainGrid.Children[i];
                string elementName = element.GetValue(NameProperty) as string;

                // Vérifie si le nom de l'élément fait partie de la liste des éléments à supprimer
                if (elementName != null && elementsToRemove.Contains(elementName))
                {
                    MainGrid.Children.Remove(element);
                }
            }
        }

        /// <summary>
        /// Ajoute une image à la grille
        /// </summary>
        /// <param name="image">L'image à ajouter</param>
        /// <param name="row">La ligne où placer l'image</param>
        /// <param name="column">La colonne où placer l'image</param>
        /// <param name="side">Le côté de la case où placer l'image</param>
        private void AddImageToGrid(Image image, int row, int column, string side)
        {
            switch (side)
            {
                case "top":
                    image.VerticalAlignment = VerticalAlignment.Top;
                    break;
                case "right":
                    image.HorizontalAlignment = HorizontalAlignment.Right;
                    break;
                case "bottom":
                    image.VerticalAlignment = VerticalAlignment.Bottom;
                    break;
                case "left":
                    image.HorizontalAlignment = HorizontalAlignment.Left;
                    break;
                default:
                    break;
            }

            Grid.SetRow(image, row);
            Grid.SetColumn(image, column);
            MainGrid.Children.Add(image);
        }

        /// <summary>
        /// Supprime l'affichage du chemin le plus court cf.DrawShortestPath
        /// </summary>
        public void CleanShortestPath()
        {
            // Efface tous les rectangles existants
            List<UIElement> rectanglesToRemove = new List<UIElement>();
            foreach (var child in MainGrid.Children)
            {
                if (child is Rectangle)
                {
                    rectanglesToRemove.Add(child as UIElement);
                }
            }
            foreach (var rect in rectanglesToRemove)
            {
                MainGrid.Children.Remove(rect);
            }
            MainGrid.Children.Remove(dijkstra);
        }

        /// <summary>
        /// Affiche le chemin le plus court du joueur à une destination
        /// </summary>
        /// <param name="xDest">L'abcisse de la destination</param>
        /// <param name="yDest">L'ordonnée de la destination</param>
        public void DrawShortestPath(int xDest, int yDest)
        {
            List<List<int>> shortestPath = graph.Dijkstra(Grid.GetRow(knight), Grid.GetColumn(knight), xDest, yDest);

            foreach (var position in shortestPath)
            {
                int x = position[0];
                int y = position[1];

                Rectangle rect = new Rectangle();
                rect.Name = "dijkstra";
                rect.Height = 100;
                rect.Width = 100;
                rect.Fill = Brushes.Red;
                rect.Opacity = 0.3;

                Grid.SetColumn(rect, y);
                Grid.SetRow(rect, x);
                MainGrid.Children.Add(rect);
            }
        }

        /// <summary>
        /// Gère les évènements clavier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Z:
                    MoveCharacter("top");
                    break;
                case Key.D:
                    MoveCharacter("right");
                    break;
                case Key.S:
                    MoveCharacter("bottom");
                    break;
                case Key.Q:
                    MoveCharacter("left");
                    break;
                case Key.P:
                    if (Inventory.Potion)
                    {
                        Inventory.UsePotion(this);
                    }
                    break;
                case Key.Up:
                    if (Inventory.Pickaxe && graph.CanBreakWall(0, Grid.GetRow(knight), Grid.GetColumn(knight)))
                    {
                        graph.DisableEdge(Grid.GetRow(knight), Grid.GetColumn(knight), 0);
                        Inventory.UsePickaxe(this);
                    }
                    break;
                case Key.Right:
                    if (Inventory.Pickaxe && graph.CanBreakWall(1, Grid.GetRow(knight), Grid.GetColumn(knight)))
                    {
                        graph.DisableEdge(Grid.GetRow(knight), Grid.GetColumn(knight), 1);
                        Inventory.UsePickaxe(this);
                    }
                    break;
                case Key.Down:
                    if (Inventory.Pickaxe && graph.CanBreakWall(2, Grid.GetRow(knight), Grid.GetColumn(knight)))
                    {
                        graph.DisableEdge(Grid.GetRow(knight), Grid.GetColumn(knight), 2);
                        Inventory.UsePickaxe(this);
                    }
                    break;
                case Key.Left:
                    if (Inventory.Pickaxe && graph.CanBreakWall(3, Grid.GetRow(knight), Grid.GetColumn(knight)))
                    {
                        graph.DisableEdge(Grid.GetRow(knight), Grid.GetColumn(knight), 3);
                        Inventory.UsePickaxe(this);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gère les mouvements du joueur
        /// </summary>
        /// <param name="direction">La direction effectué</param>
        private void MoveCharacter(string direction)
        {
            int currentRow = Grid.GetRow(knight);
            int currentColumn = Grid.GetColumn(knight);
            //Sounds.PlaySound("marche");

            switch (direction)
            {
                case "top":
                    if (currentRow > 0 && graph.CanSwitch(currentRow, currentColumn, "top"))
                    {
                        Grid.SetRow(knight, currentRow - 1);
                        VerifPlayerOnCase();
                    }
                    break;
                case "right":
                    if (currentColumn < MainGrid.ColumnDefinitions.Count - 1 && graph.CanSwitch(currentRow, currentColumn, "right"))
                    {
                        Grid.SetColumn(knight, currentColumn + 1);
                        VerifPlayerOnCase();
                    }
                    break;
                case "bottom":
                    if (currentRow < MainGrid.RowDefinitions.Count - 1 && graph.CanSwitch(currentRow, currentColumn, "bottom"))
                    {
                        Grid.SetRow(knight, currentRow + 1);
                        VerifPlayerOnCase();
                    }
                    break;
                case "left":
                    if (currentColumn > 0 && graph.CanSwitch(currentRow, currentColumn, "left"))
                    {
                        Grid.SetColumn(knight, currentColumn - 1);
                        VerifPlayerOnCase();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Verif si le joueur est sur une case spécial
        /// </summary>
        private void VerifPlayerOnCase()
        {
            int currentRow = Grid.GetRow(knight);
            int currentColumn = Grid.GetColumn(knight);

            if (currentRow == Grid.GetRow(chest) && currentColumn == Grid.GetColumn(chest) && Inventory.Treasure)
            {
                ClearGrid(new List<string> { "chest" });
                SetActive(contentGUITreasure, true);
                Player.TreasureRecup = Player.TreasureRecup + 1;
                Inventory.DisableObject(contentGUITreasure.Name);
                Sounds.PlaySound("treasure");
            }

            foreach (Monster monster in monsters)
            {
                if (currentRow == monster.OrkCoords[0] && currentColumn == monster.OrkCoords[1] && monster.OrkVisualVisibility == Visibility.Visible)
                {
                    view.FightWindow win = new view.FightWindow(this, monster);
                    SetPositionWindow(win, "center");
                    win.Show();
                }
            }

            if (currentRow == Grid.GetRow(trapExit) && currentColumn == Grid.GetColumn(trapExit))
            {
                EndWindow endWindow = new EndWindow(this, player);
            }
        }

        /// <summary>
        /// Set les coordonnées d'une fenêtre sur le bureau
        /// </summary>
        /// <param name="win">La fenêtre cible</param>
        /// <param name="side">La position souhaitée</param>
        public void SetPositionWindow(Window win, string side)
        {
            win.WindowStartupLocation = WindowStartupLocation.Manual;

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowHeight = win.Height;
            double windowWidth = win.Width;

            switch (side)
            {
                case "left":
                    win.Left = 100;
                    break;
                case "right":
                    win.Left = screenWidth - windowWidth - 100;
                    break;
                default:
                    win.Left = screenWidth * 0.5 - windowWidth * 0.5;
                    break;
            }
            win.Top = (screenHeight - windowHeight) / 2;
        }

        /// <summary>
        /// Set une valeur de visibilité à un objet
        /// </summary>
        /// <param name="objet">L'objet cible</param>
        /// <param name="value">La valeur de visibilité de l'objet</param>
        public void SetActive(Image objet, bool value)
        {
            switch (value)
            {
                case true:
                    objet.Visibility = Visibility.Visible;
                    break;
                case false:
                    objet.Visibility = Visibility.Hidden;
                    break;
            }
        }

        /// <summary>
        /// Ouvre la fenêtre de choix de chemin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OpenPathWindow(object sender, RoutedEventArgs e)
        {
            // ouvre la fenêtre path
            view.PathWindow win = new view.PathWindow(this);
            SetPositionWindow(win, "right");
            win.Show();
        }

        /// <summary>
        /// Détermine les coordonnées du coffre et des monstres
        /// </summary>
        private void SetChestAndMonsterCoords()
        {
            List<List<int>> chestAndOrkCoords = graph.FindChestAndOrkPos();
            Inventory.TreasureCoords = chestAndOrkCoords[0].ToArray();
            Grid.SetRow(chest, chestAndOrkCoords[0][0]);
            Grid.SetColumn(chest, chestAndOrkCoords[0][1]);

            switch (difficulty)
            {
                case 2:
                    Monster newMonster = new Monster(ork, chestAndOrkCoords[1].ToArray());
                    monsters.Add(newMonster);
                    Grid.SetRow(ork, chestAndOrkCoords[1][0]);
                    Grid.SetColumn(ork, chestAndOrkCoords[1][1]);
                    break;
                case 3:
                    Monster newMonsterD2 = new Monster(ork, chestAndOrkCoords[1].ToArray());
                    monsters.Add(newMonsterD2);
                    Grid.SetRow(ork, chestAndOrkCoords[1][0]);
                    Grid.SetColumn(ork, chestAndOrkCoords[1][1]);

                    List<List<int>> shortestPath = graph.Dijkstra(Grid.GetRow(knight), Grid.GetColumn(knight), graph.Taille - 1, graph.Taille - 1);
                    List<int> secondToLast = shortestPath[shortestPath.Count - 2];

                    Monster newMonsterD2T = new Monster(orkD2, [secondToLast[0], secondToLast[1]]);
                    monsters.Add(newMonsterD2T);
                    Grid.SetRow(orkD2, secondToLast[0]);
                    Grid.SetColumn(orkD2, secondToLast[1]);
                    break;
                case 1:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Set les coordonnées du bandeau GUI en bas de fenêtre
        /// </summary>
        public void SetGUIBandCoords()
        {
            List<Image> elementsToSet = new List<Image> { GUIPanel, GUISlot1, GUISlot2, GUISlot3,
                contentGUITreasure, contentGUIPickaxe, contentGUIPotion, GUIpv};

            foreach (Image image in elementsToSet)
            {
                Grid.SetRow(image, graph.Taille + 1);
            }

            Grid.SetRow(knightPV, graph.Taille + 1);
            Grid.SetRow(GUIButtonPath, graph.Taille + 1);
        }

        /// <summary>
        /// Set l'échelle de son appelant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetScale(object sender, RoutedEventArgs e)
        {
            Image GUIElm = sender as Image;
            int factor = ((int)GUIElm.Width == 0) ? 35 : (int)GUIElm.Width;

            if (factor > 0)
                GUIElm.Height = (factor * MainGrid.RowDefinitions[0].Height.Value) / 90;
            else
                GUIElm.Height = (35 * MainGrid.RowDefinitions[0].Height.Value) / 90;
        }

        /// <summary>
        /// Méthode pour relancer l'application
        /// </summary>
        public void RelaunchApplication()
        {
            System.Windows.Application.Current.Shutdown();
            string appPath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(appPath);
        }
    }
    #endregion
}
