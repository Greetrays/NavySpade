using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerScore))]

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private PlayerHealth _health;
    private PlayerScore _score;

    private void Awake()
    {
        _health = GetComponent<PlayerHealth>();
        _score = GetComponent<PlayerScore>();
        Restart();
    }
    public void Restart()
    {
        _health.Restart();
        _score.Restart();
        transform.position = _spawnPoint.position;
    }
}
