using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMover : MonoBehaviour
{
    private Camera _mainCamera;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private Vector3 _targetPosition = new Vector3();

    private void Start()
    {
        _mainCamera = Camera.main;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                _targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                _navMeshAgent.SetDestination(hit.point);
                _animator.SetBool(PlayerAnimatorContoller.Parameters.IsRun, true);
            }
        }

        if (transform.position == _targetPosition && _animator.GetBool(PlayerAnimatorContoller.Parameters.IsRun) == true)
        {
            _animator.SetBool(PlayerAnimatorContoller.Parameters.IsRun, false);
            
        }
    }
}
