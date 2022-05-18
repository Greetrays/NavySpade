using UnityEngine;
using UnityEngine.Events;

public abstract class SpawnObject : MonoBehaviour
{
    public event UnityAction Dying;
    public event UnityAction<SpawnObject> Disable;

    protected virtual void Die()
    {
        Dying?.Invoke();
    }

    protected void DisableObject()
    {
        Disable?.Invoke(this);
    }
}
