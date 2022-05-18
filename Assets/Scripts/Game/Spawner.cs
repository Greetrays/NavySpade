using UnityEngine;

public class Spawner : Pool
{
    [SerializeField] private SpawnObject _template;
    [SerializeField] private int _countObjects;
    [SerializeField] private int _startCountSpawnObjects;
    [SerializeField] private float _delayBetweenSpawn;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionZ;
    [SerializeField] private float _maxPositionZ;

    private float _elepsedTime;

    private void Start()
    {
        Init(_countObjects, _template);
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _delayBetweenSpawn)
        {
            TrySpawn();
            _elepsedTime = 0;
        }
    }

    public void Restart()
    {
        ResetGame();

        for (int i = 0; i < _startCountSpawnObjects; i++)
        {
            TrySpawn();
        }
    }

    private void TrySpawn()
    {
        if (TryGetRandomObject(out SpawnObject newObject))
        {
            Spawn(newObject);
        }
    }

    private void Spawn(SpawnObject newObject)
    {
        Vector3 randomPosition = GetRandomPosition();

        if (CheckFreePosition(randomPosition))
        {
            EnableObject(newObject);
            newObject.transform.position = randomPosition;
        }
    }

    private bool CheckFreePosition(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapBox(position, new Vector3(0.1f, 0.1f, 0.1f));

        if (colliders.Length > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(_minPositionX, _maxPositionX);
        float randomZ = Random.Range(_minPositionZ, _maxPositionZ);
        return new Vector3(randomX, transform.position.y, randomZ);
    }
}
