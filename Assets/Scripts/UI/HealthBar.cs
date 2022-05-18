using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnEnable()
    {
        _playerHealth.Changed += ChangeValue;
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= ChangeValue;
    }
}
