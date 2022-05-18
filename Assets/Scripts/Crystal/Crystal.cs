using UnityEngine;

public class Crystal : SpawnObject
{
    [SerializeField] private int _reward;

    public int Reward => _reward;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Die();
            DisableObject();
        }
        else if (other.TryGetComponent(out Enemy enemy))
        {
            DisableObject();
        }
    }
}
