using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minStopingDistance;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionZ;
    [SerializeField] private float _maxPositionZ;

    private Vector3 _targetPosition = new Vector3();
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        SetRandomPosition(out _targetPosition);
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _speed;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(_targetPosition, transform.position) < _minStopingDistance)
        {
            SetRandomPosition(out _targetPosition);
        }
        else
        {
            _navMeshAgent.SetDestination(_targetPosition);
        }
    }

    private void SetRandomPosition(out Vector3 targetPosition)
    {
        float randomX = Random.Range(_minPositionX, _maxPositionX);
        float randomZ = Random.Range(_minPositionZ, _maxPositionZ);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }
}
