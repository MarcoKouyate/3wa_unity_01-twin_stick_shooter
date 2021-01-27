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
        _moveInput = Vector3.zero;
    }

    private void Update()
    {
        _moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _moveMagnitude = Mathf.Clamp01(_moveInput.magnitude);
        _moveInput.Normalize();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveInput * speed * _moveMagnitude;
    }

    private Rigidbody _rb;
    Vector3 _moveInput;
    float _moveMagnitude;
}
