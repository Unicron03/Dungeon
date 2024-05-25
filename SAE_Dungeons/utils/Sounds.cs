using System.Media;
using System.Windows;

public static class Sounds
{
    #region Operations
    /// <summary>
    /// Charge un son et le joue
    /// </summary>
    /// <param name="name">Le nom du son à jouer</param>
    public static void PlaySound(string name)
    {
        string path = "pack://application:,,,/SAE_Dungeons;component/assets/sounds/" + name + ".wav";
        SoundPlayer sounds = new SoundPlayer(Application.GetResourceStream(new Uri(path)).Stream);
        sounds.Load();
        sounds.Play();
    }
    #endregion
}
