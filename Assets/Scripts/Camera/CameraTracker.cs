using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _speed;

    private float _oldPositionZ;

    private void Start()
    {
        _oldPositionZ = transform.position.z;
    }

    private void Update()
    {
        Vector3 newPosition = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z + _oldPositionZ);
        transform.position = Vector3.Lerp(transform.position, newPosition, _speed * Time.deltaTime);
    }
}
