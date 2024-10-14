using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]

public class CubeCollision : MonoBehaviour
{
    private bool _isCollision;

    public event Action Collided;

    private void OnEnable()
    {
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
