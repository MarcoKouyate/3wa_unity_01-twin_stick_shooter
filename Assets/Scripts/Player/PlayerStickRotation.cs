using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerStickRotation : MonoBehaviour
{
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rotationInput = new Vector3(Input.GetAxisRaw("OrientationHorizontal"), 0, Input.GetAxisRaw("OrientationVertical"));
    }

    private void FixedUpdate()
    {
        if (!Mathf.Approximately(_rotationInput.sqrMagnitude, 0))
        {
            Quaternion lookRotation = Quaternion.LookRotation(_rotationInput);
            _rb.MoveRotation(lookRotation);
        }
    }

    private Rigidbody _rb;
    Vector3 _rotationInput;
}
