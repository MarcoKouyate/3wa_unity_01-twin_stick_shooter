using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed = 1f;

    private Rigidbody _rigidbody;
    private Vector3 _velocity;
    private float _startTime;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startTime = Time.time;
    }

    private void FixedUpdate()
    {
        _velocity = transform.forward * _speed * Time.fixedDeltaTime;
        Vector3 newPosition = transform.position + _velocity;
        _rigidbody.MovePosition(newPosition);
    }

    public void ChangeSpeed(float speed)
    {
        _speed = speed;
    }

    public void DestroyWithDelay(float delay)
    {
         Destroy(gameObject, delay);
    }
}
