using UnityEngine;
using UnityEngine.UI;

public class SpawnObjectBar : Bar
{
    [SerializeField] private Pool _pool;

    private void OnEnable()
    {
        _pool.ChangeCountActiveObjects += OnChange;
    }

    private void OnDisable()
    {
        _pool.ChangeCountActiveObjects -= OnChange;
    }

    private void OnChange(int value)
    {
        ChangeValue(value);
    }
}
