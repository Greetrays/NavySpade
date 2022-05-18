using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerHealth))]

public class PlayerScore : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private int _countScore;

    public event UnityAction<int> Changed;

    private void OnEnable()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerHealth.Dying += OnDying;
    }

    private void OnDisable()
    {
        _playerHealth.Dying -= OnDying;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Crystal crystal))
        {
            ChangeScore(crystal.Reward);
        }
    }

    public void Restart()
    {
        _countScore = 0;
        Changed?.Invoke(_countScore);
    }

    private void ChangeScore(int value)
    {
        _countScore += value;
        Changed?.Invoke(_countScore);
    }

    private void OnDying()
    {
        if (PlayerPrefs.GetInt(PlayerPrefsData.ScoreRecord) < _countScore)
        {
            PlayerPrefs.SetInt(PlayerPrefsData.ScoreRecord, _countScore);
        }
    }
}
