using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]

public class CubeDetector : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool _isCollision;

    public event Action Collided;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rigidbody.velocity = Vector3.zero;
        _isCollision = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out _))
        {
            if (_isCollision == false)
            {
                Collided?.Invoke();
                _isCollision = true;
            }
        }
    }
}
