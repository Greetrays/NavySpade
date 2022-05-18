using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.AI;

public abstract class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private Spawner _targetPool;
    [SerializeField] NavMeshAgent _player;

    public event UnityAction<int> ChangeCountActiveObjects;
    public event UnityAction<float> ChangeMinDistance;

    private List<SpawnObject> _pool = new List<SpawnObject>();

    public int CountActiveObjects
    {
        get
        {
            return _pool.Where(item => item.gameObject.activeSelf == true).ToList().Count;
        }
    }


    private void OnDisable()
    {
        foreach (var item in _pool)
        {
            item.Dying -= OnDyingObject;
            item.Disable -= OnDisableObject;
        }
    }

    private void FixedUpdate()
    {
        float minDistance = float.MaxValue;
        List<SpawnObject> activeObjects = _pool.Where(item => item.gameObject.activeSelf == true).ToList();

        foreach (var item in activeObjects)
        {
            float currentDistance = Vector3.Distance(_player.gameObject.transform.position, item.gameObject.transform.position);

            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
                ChangeMinDistance?.Invoke(minDistance);
            }
        }
    }
    public void ResetGame()
    {
        foreach (var item in _pool)
            OnDisableObject(item);
    }

    public void DestroyRandomObject()
    {
        List<SpawnObject> activeObjects = _pool.Where(item => item.gameObject.activeSelf == true).ToList();

        if (activeObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, activeObjects.Count);
            OnDisableObject(activeObjects[randomIndex]);
        }
    }

    protected void Init(int size, SpawnObject tepmplate)
    {
        for (int i = 0; i < size; i++)
        {
            SpawnObject newObject = Instantiate(tepmplate, _container.transform);
            newObject.gameObject.SetActive(false);
            _pool.Add(newObject);
            newObject.Dying += OnDyingObject;
            newObject.Disable += OnDisableObject;
        }
    }

    protected bool TryGetRandomObject(out SpawnObject obj)
    {
        List<SpawnObject> activeObjects = _pool.Where(item => item.gameObject.activeSelf == false).ToList();
        obj = null;

        if (activeObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, activeObjects.Count);
            obj = activeObjects[randomIndex];
        }

        return obj != null;
    }

    protected void EnableObject(SpawnObject spawnObject)
    {
        spawnObject.gameObject.SetActive(true);
        ChangeCountActiveObjects?.Invoke(CountActiveObjects);
    }

    private void OnDisableObject(SpawnObject spawnObject)
    {
        spawnObject.gameObject.SetActive(false);
        ChangeCountActiveObjects?.Invoke(CountActiveObjects);
    }

    private void OnDyingObject()
    {
        _targetPool.DestroyRandomObject();
    }
}
