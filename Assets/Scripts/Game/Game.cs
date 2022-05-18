using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameplayPanel _gameplayPanel;
    [SerializeField] private StartPanel _startPanel;
    [SerializeField] private Spawner _enemyPool;
    [SerializeField] private Spawner _crystalPool;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _playerHealth.Died += OnDied;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= OnDied;
    }

    private void Start()
    {
        OnDied();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        _gameplayPanel.Open();
        _startPanel.ShowResult();
        _startPanel.Close();
        _player.Restart();
        _enemyPool.Restart();
        _crystalPool.Restart();
    }

    private void OnDied()
    {
        _startPanel.ShowResult();
        Time.timeScale = 0;
        _gameplayPanel.Close();
        _startPanel.Open();
    }
}
