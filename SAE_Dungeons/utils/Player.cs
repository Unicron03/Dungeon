using System.Windows.Controls;

public class Player
{
    #region Attributes
    private int pv;
    private Label GUILabel;
    private int orkKill = 0;
    private int treasureRecup = 0;
    #endregion

    #region Properties
    public int PV
    {
        get => pv;
        set => pv = value;
    }

    public int OrkKill
    {
        get => orkKill;
        set => orkKill = value;
    }

    public int TreasureRecup
    {
        get => treasureRecup;
        set => treasureRecup = value;
    }
    #endregion

    #region Constructor
    public Player(Label GUI)
    {
        this.GUILabel = GUI;
        this.pv = 20;
    }
    #endregion

    #region Operations
    /// <summary>
    /// Renvoie si le joueur est mort
    /// </summary>
    /// <returns></returns>
    public bool isDead()
    {
        return pv <= 0;
    }
    #endregion
}