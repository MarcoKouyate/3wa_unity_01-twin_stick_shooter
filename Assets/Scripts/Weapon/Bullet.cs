using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    public float _speed = 1f;

    public float Damage {
        get => _damage;
    }


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
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

    private Rigidbody _rigidbody;
    private Vector3 _velocity;
}
