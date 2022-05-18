using UnityEngine;

public class Enemy : SpawnObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth player))
        {
            if (player.IsInvulnerability == false)
            {
                Die();
            }
        }
    }
}
