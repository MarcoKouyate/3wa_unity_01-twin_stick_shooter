using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public float lifetime = 1f;

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
        _velocity = transform.forward * speed;
        Vector3 movementStep = _velocity * Time.fixedDeltaTime;
        Vector3 newPosition = transform.position + movementStep;
            
       _rigidbody.MovePosition(newPosition);
    }

    private void Update()
    {
        if(Time.time > _startTime + lifetime)
        {
            Destroy(gameObject);
        }
    }
}
