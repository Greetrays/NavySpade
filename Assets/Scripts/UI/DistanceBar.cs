using UnityEngine;
using UnityEngine.UI;

public class DistanceBar : Bar
{
    [SerializeField] private Pool _pool;

    private void OnEnable()
    {
        _pool.ChangeMinDistance += OnChange;
    }

    private void OnDisable()
    {
        _pool.ChangeMinDistance -= OnChange;
    }

    private void OnChange(float value)
    {
        ChangeValue(value);
    }
}