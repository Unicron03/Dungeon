using System.Windows;
using System.Windows.Controls;

public class Monster
{
    #region Attributes
    private Image orkVisual;
    private int[] orkCoords;
    #endregion

    #region Properties
    public int[] OrkCoords => orkCoords;

    public Visibility OrkVisualVisibility => orkVisual.Visibility;
    #endregion

    #region Constructor
    public Monster(Image orkVisual, int[] coords)
    {
        this.orkVisual = orkVisual;
        this.orkCoords = coords;

        orkVisual.Visibility = Visibility.Visible;
    }
    #endregion

    #region Operation
    /// <summary>
    /// Applique une valeur de visibilité au visuel du monstre
    /// </summary>
    /// <param name="value">La valeur de visibilité à appliquer</param>
    public void SetActive(bool value)
    {
        if(value)
        {
            orkVisual.Visibility = Visibility.Visible;
        }
        else
        {
            orkVisual.Visibility = Visibility.Hidden;
        }
    }
    #endregion
}
