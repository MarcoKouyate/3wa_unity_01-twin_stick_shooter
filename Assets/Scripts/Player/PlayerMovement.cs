using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = transform;
        _moveInput = Vector3.zero;
    }


    public void Move(Vector2 direction)
    {
        _moveInput = new Vector3(direction.x, 0, direction.y);
    }

    public void Rotate(Quaternion rotation)
    {
        _transform.rotation = rotation;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveInput * speed ;
    }

    private Rigidbody _rb;
    Vector3 _moveInput;
    Transform _transform;
}
