using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;


    private Rigidbody _rb;
    Vector3 _moveInput;
    Vector3 _rotationInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _rotationInput = new Vector3(Input.GetAxisRaw("MoveHorizontal"), 0,  Input.GetAxisRaw("MoveVertical"));
        _moveInput.Normalize();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveInput * speed;
        if (!Mathf.Approximately(_rotationInput.sqrMagnitude, 0 ))
        {
            Quaternion lookRotation = Quaternion.LookRotation(_rotationInput);
            _rb.MoveRotation(lookRotation);
        }
    }
}
