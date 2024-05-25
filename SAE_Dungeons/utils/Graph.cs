using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SAE_Dungeons.utils
{
    public class Graph
    {
        #region Attributes
        private int cursorX;
        private int cursorY;
        private int taille;
        private int[][][] matrice;
        #endregion

        #region Properties
        public int Taille => taille;
        public int[][][] Matrice => matrice;
        #endregion

        #region Constructor
        public Graph(int t)
        {
            taille = t;
            cursorX = 0;
            cursorY = 0;

            matrice = new int[t][][];
            for (int i = 0; i < t; i++)
            {
                matrice[i] = new int[t][];
                for (int j = 0; j < t; j++)
                {
                    matrice[i][j] = new int[] { 1, 1, 1, 1 };
                }
            }
        }
        #endregion

        #region Operations
        /// <summary>
        /// Désactive une arrête
        /// </summary>
        /// <param name="x">L'abcisse de l'arête cible</param>
        /// <param name="y">L'ordonnée de l'arête cible</param>
        /// <param name="dir">La direction de l'arête cible</param>
        public void DisableEdge(int x, int y, int dir)
        {
            switch (dir)
            {
                case 0: // Haut
                    matrice[x][y][0] = 0;
                    matrice[x - 1][y][2] = 0;
                    break;
                case 1: // Droite
                    matrice[x][y][1] = 0;
                    matrice[x][y + 1][3] = 0;
                    break;
                case 2: // Bas
                    matrice[x][y][2] = 0;
                    matrice[x + 1][y][0] = 0;
                    break;
                case 3: // Gauche
                    matrice[x][y][3] = 0;
                    matrice[x][y - 1][1] = 0;
                    break;
            }
        }

        /// <summary>
        /// Renvoie si un côté d'une case est ouverte
        /// </summary>
        /// <param name="x">L'abcisse de la case cible</param>
        /// <param name="y">L'ordonnée de la case cible</param>
        /// <param name="dir">La direction de la case cible</param>
        /// <returns></returns>
        public bool CanSwitch(int x, int y, string dir)
        {
            switch (dir)
            {
                case "top":
                    if (matrice[x][y][0] == 0) return true;
                    return false;
                case "right":
                    if (matrice[x][y][1] == 0) return true;
                    return false;
                case "bottom":
                    if (matrice[x][y][2] == 0) return true;
                    return false;
                case "left":
                    if (matrice[x][y][3] == 0) return true;
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Génère un chemin parfait
        /// </summary>
        public void GeneratePerfectPath()
        {
            bool[][] visited = new bool[taille][];
            for (int i = 0; i < taille; i++)
            {
                visited[i] = new bool[taille];
                for (int j = 0; j < taille; j++)
                {
                    visited[i][j] = false;
                }
            }

            DFS(0, 0, visited);
        }

        /// <summary>
        /// Génère un chemin imparfait et retire x% de murs suivant la difficulté envoyé
        /// </summary>
        /// <param name="difficulty">La difficulté correspondante</param>
        public void GenerateImperfectPath(int difficulty)
        {
            List<List<int>> perfectPath = new List<List<int>>();

            bool[][] visited = new bool[taille][];
            for (int i = 0; i < taille; i++)
            {
                visited[i] = new bool[taille];
                for (int j = 0; j < taille; j++)
                {
                    visited[i][j] = false;
                }
            }

            DFS(0, 0, visited);

            int prc = difficulty == 1 ? 15 : 10;
            BreakSomeWall(prc);
        }

        /// <summary>
        /// Parcours en profondeur récursif
        /// </summary>
        /// <param name="x">L'abcisse de la case cible</param>
        /// <param name="y">L'ordonnée de la case cible</param>
        /// <param name="visited">La liste des cases visitées</param>
        private void DFS(int x, int y, bool[][] visited)
        {
            visited[x][y] = true;

            // Liste des déplacements possibles (haut, droite, bas, gauche)
            int[] dx = { -1, 0, 1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            // Mélange aléatoire des directions
            Random rand = new Random();
            int[] directionIndices = Enumerable.Range(0, 4).OrderBy(i => rand.Next()).ToArray();

            // Parcour des directions mélangées
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[directionIndices[i]];
                int newY = y + dy[directionIndices[i]];

                // Vérif si la nouvelle case est valide et non visitée
                if (newX >= 0 && newX < taille && newY >= 0 && newY < taille && !visited[newX][newY])
                {
                    DisableEdge(x, y, directionIndices[i]);

                    // Appel récursif pour la nouvelle case
                    DFS(newX, newY, visited);
                }
            }
        }

        /// <summary>
        /// Supprime x% de mur à la matrice
        /// </summary>
        /// <param name="prc">Le pourcentage correspondant</param>
        public void BreakSomeWall(int prc)
        {
            Random random = new Random();
            int totalWalls = taille * (taille - 1) * 2;
            int wallsToRemove = (int)Math.Ceiling(totalWalls * (prc / 100.0));
            List<Tuple<int, int, int>> availableWalls = new List<Tuple<int, int, int>>();

            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    if (i > 0)
                    {
                        availableWalls.Add(new Tuple<int, int, int>(i, j, 0));
                    }
                    if (j > 0)
                    {
                        availableWalls.Add(new Tuple<int, int, int>(i, j, 3));
                    }
                }
            }

            availableWalls = availableWalls.OrderBy(w => random.Next()).ToList();

            for (int i = 0; i < wallsToRemove && availableWalls.Count > 0; i++)
            {
                Tuple<int, int, int> wall = availableWalls[i];
                int x = wall.Item1;
                int y = wall.Item2;
                int dir = wall.Item3;
                DisableEdge(x, y, dir);
            }
        }

        /// <summary>
        /// Renvoie si un mur peut être cassé
        /// </summary>
        /// <param name="dir">La direction de la case cible</param>
        /// <param name="x">L'abcisse de la case cible</param>
        /// <param name="y">L'ordonnée de la case cible</param>
        /// <returns></returns>
        public bool CanBreakWall(int dir, int x, int y)
        {
            switch (dir)
            {
                case 0:
                    if (matrice[x][y][0] == 1 && x >= 1) return true;
                    break;
                case 1:
                    if (matrice[x][y][1] == 1 && y < taille - 1) return true;
                    break;
                case 2:
                    if (matrice[x][y][2] == 1 && x < taille - 1) return true;
                    break;
                case 3:
                    if (matrice[x][y][3] == 1 && y > 0) return true;
                    break;
                default:
                    return false;
            }

            return false;
        }

        /// <summary>
        /// Renvoie les coordonnées du voisin d'une case
        /// </summary>
        /// <param name="x">L'abcisse de la case source</param>
        /// <param name="y">L'ordonnée de la case cible</param>
        /// <returns></returns>
        public List<int> GetANeighboorNode(int x, int y)
        {
            int index = matrice[x][y].ToList().IndexOf(0);

            switch (index)
            {
                case 0:
                    return new List<int> { x - 1, y };
                case 1:
                    return new List<int> { x, y + 1 };
                case 2:
                    return new List<int> { x + 1, y };
                case 3:
                    return new List<int> { x, y - 1 };
                default:
                    return new List<int> { x, y };
            }
        }

        /// <summary>
        /// Récupère des coordonnées aléatoires où doivent être placer le coffre et le monstre
        /// </summary>
        /// <returns></returns>
        public List<List<int>> FindChestAndOrkPos()
        {
            Random random = new Random();

            List<int> deadEnds = FindDeadEnds()[random.Next(0, FindDeadEnds().Count)];
            List<List<int>> chestAndOrkPos = [deadEnds, GetANeighboorNode(deadEnds[0], deadEnds[1])];

            return chestAndOrkPos;
        }

        /// <summary>
        /// Renvoie la liste des cul-de-sac
        /// </summary>
        /// <returns></returns>
        public List<List<int>> FindDeadEnds()
        {
            List<List<int>> deadEnds = new List<List<int>>();

            // Parcourir chaque case du labyrinthe
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    // Vérifie si la case est un cul-de-sac
                    if (matrice[i][j].Count(wall => wall == 1) == 3 && (i != 0 && j != 0) && (i != taille - 1 && j != taille - 1))
                    {
                        // Enregistre les coordonnées du cul-de-sac
                        deadEnds.Add(new List<int> { i, j });
                    }
                }
            }

            return deadEnds;
        }

        /// <summary>
        /// Détermine et renvoie le chemin le plus court entre deux cases
        /// </summary>
        /// <param name="startX">L'abcisse de la case source</param>
        /// <param name="startY">L'ordonnée de la case source</param>
        /// <param name="endX">L'abcisse de la case cible</param>
        /// <param name="endY">L'ordonnée de la case cible</param>
        /// <returns></returns>
        public List<List<int>> Dijkstra(int startX, int startY, int endX, int endY)
        {
            int[][] distances = new int[taille][];
            bool[][] visited = new bool[taille][];

            for (int i = 0; i < taille; i++)
            {
                distances[i] = new int[taille];
                visited[i] = new bool[taille];
                for (int j = 0; j < taille; j++)
                {
                    distances[i][j] = int.MaxValue;
                    visited[i][j] = false;
                }
            }

            distances[startX][startY] = 0;

            while (true)
            {
                int minDistance = int.MaxValue;
                int currentX = -1, currentY = -1;

                // Recherche la case non visitée avec la distance minimale
                for (int i = 0; i < taille; i++)
                {
                    for (int j = 0; j < taille; j++)
                    {
                        if (!visited[i][j] && distances[i][j] < minDistance)
                        {
                            minDistance = distances[i][j];
                            currentX = i;
                            currentY = j;
                        }
                    }
                }

                if (currentX == -1 || currentY == -1) // Sortie si toutes les case accessibles ont été visitées
                    break;

                visited[currentX][currentY] = true;

                // Mets à jour les distances des cases voisines
                int[] dx = { -1, 0, 1, 0 };
                int[] dy = { 0, 1, 0, -1 };

                for (int i = 0; i < 4; i++)
                {
                    int newX = currentX + dx[i];
                    int newY = currentY + dy[i];

                    if (newX >= 0 && newX < taille && newY >= 0 && newY < taille && matrice[currentX][currentY][i] == 0)
                    {
                        int newDistance = distances[currentX][currentY] + 1;
                        if (newDistance < distances[newX][newY])
                        {
                            distances[newX][newY] = newDistance;
                        }
                    }
                }
            }

            // Retrace le chemin le plus court
            List<List<int>> shortestPath = new List<List<int>>();
            int x = endX, y = endY;

            while (x != startX || y != startY)
            {
                shortestPath.Add(new List<int> { x, y });
                int[] dx = { -1, 0, 1, 0 };
                int[] dy = { 0, 1, 0, -1 };
                for (int k = 0; k < 4; k++)
                {
                    int newX = x + dx[k];
                    int newY = y + dy[k];
                    if (newX >= 0 && newX < taille && newY >= 0 && newY < taille && matrice[x][y][k] == 0 && distances[newX][newY] == distances[x][y] - 1)
                    {
                        x = newX;
                        y = newY;
                        break;
                    }
                }
            }
            shortestPath.Add(new List<int> { startX, startY });

            // Inverse le chemin pour obtenir le bon ordre (entrée -> sortie)
            shortestPath.Reverse();
            return shortestPath;
        }
    }
    #endregion
}
