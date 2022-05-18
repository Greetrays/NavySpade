using UnityEngine;

public class ScoreBar : Bar
{
    [SerializeField] private PlayerScore _playerScore;

    private void OnEnable()
    {
        _playerScore.Changed += ChangeValue;
    }

    private void OnDisable()
    {
        _playerScore.Changed -= ChangeValue;
    }
}
