using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _durationInvulnerability;

    public event UnityAction<int> Changed;
    public event UnityAction Dying;
    public event UnityAction Died;

    private float _elepsedTimeInvulnerability;
    private int _currentHealth;
    private bool _isInvulnerability;

    public bool IsInvulnerability => _isInvulnerability;

    private void OnEnable()
    {
        if (_currentHealth <= 0)
        {
            _currentHealth = 1;
        }
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        Changed?.Invoke(_currentHealth);
    }

    private void Update()
    {
        if (_isInvulnerability)
        {
            _elepsedTimeInvulnerability += Time.deltaTime;

            if (_elepsedTimeInvulnerability >= _durationInvulnerability)
            {
                _elepsedTimeInvulnerability = 0;
                _isInvulnerability = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Crystal crystal))
        {
            if (_currentHealth < _maxHealth)
            {
                ChangeHealth(1);
            }
        }
        else if (other.TryGetComponent(out Enemy enemy))
        {
            if (_isInvulnerability == false)
            {
                ChangeHealth(-1);
                _isInvulnerability = true;
            }
        }
    }

    public void Restart()
    {
        _currentHealth = _maxHealth;
        Changed?.Invoke(_currentHealth);
    }

    private void ChangeHealth(int value)
    {
        _currentHealth += value;
        Changed?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            Dying?.Invoke();
            Died?.Invoke();
        }
    }
}
