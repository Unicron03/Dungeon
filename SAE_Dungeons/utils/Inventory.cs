using SAE_Dungeons;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public static class Inventory
{
    #region Attributes
    private static bool treasure = true;
    public static bool pickaxe = true;
    public static bool potion = true;
    private static int[] treasureCoords;
    #endregion

    #region Properties
    public static bool Treasure => treasure;

    public static bool Pickaxe => pickaxe;

    public static bool Potion => potion;

    public static int[] TreasureCoords
    {
        get => treasureCoords;
        set => treasureCoords = value;
    }
    #endregion

    #region Operations
    /// <summary>
    /// Active/Désactive le visuel d'un objet
    /// </summary>
    /// <param name="objet">L'objet cible</param>
    /// <param name="value">La valeur à appliquer</param>
    public static void SetActive(Image objet, bool value)
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
    /// Désactive un objet
    /// </summary>
    /// <param name="objet">L'objet cible</param>
    public static void DisableObject(string objet)
    {
        switch (objet)
        {
            case "contentGUITreasure":
                treasure = false;
                break;
            case "contentGUIPickaxe":
                pickaxe = false;
                break;
            case "contentGUIPotion":
                potion = false;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Gère l'utilisation de la potion
    /// </summary>
    /// <param name="gameWindow">La fenêtre où désactiver le visuel de la potion</param>
    public static void UsePotion(GameWindow gameWindow)
    {
        if (potion && gameWindow.Player.PV < 20)
        {
            gameWindow.Player.PV = Math.Min(gameWindow.Player.PV + 5, 20);
            Sounds.PlaySound("bottle");
            SetActive(gameWindow.contentGUIPotion, false);
            DisableObject(gameWindow.contentGUIPotion.Name);
            gameWindow.knightPV.Content = gameWindow.Player.PV;
        }
    }

    /// <summary>
    /// Gère l'utilisation de la pioche
    /// </summary>
    /// <param name="gameWindow">La fenêtre où désactiver le visuel de la pioche</param>
    public static void UsePickaxe(GameWindow gameWindow)
    {
        SetActive(gameWindow.contentGUIPickaxe, false);
        DisableObject(gameWindow.contentGUIPickaxe.Name);
        Sounds.PlaySound("pickaxe");
        gameWindow.InitializeWallImages();
    }
    #endregion
}