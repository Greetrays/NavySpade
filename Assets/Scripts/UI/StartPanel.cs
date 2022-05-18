using UnityEngine;
using UnityEngine.UI;

public class StartPanel : Window
{
    [SerializeField] private Text _score;

    public void ShowResult()
    {
        _score.text = ($"РЕКОРД: {PlayerPrefs.GetInt(PlayerPrefsData.ScoreRecord)}");
        Open();
    }
}