using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    private Transform _playerTransform;
    private Transform _enemyTransform;
    private Rigidbody _rigidbody;

    [SerializeField]
    private float rotationSpeed = 1f;

    [SerializeField]
    private float moveSpeed = 1f;

    private void Awake()
    {
        _playerTransform = GameObject.Find("Player").transform;
        _enemyTransform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Quaternion rotation = TurnTowardsPlayer();
        _rigidbody.MoveRotation(rotation);
        _rigidbody.velocity = _enemyTransform.forward * moveSpeed;
    }

    private Quaternion TurnTowardsPlayer()
    {
        Quaternion rotation = _enemyTransform.rotation;

        if (_playerTransform != null)
        {
            float step = rotationSpeed * Time.deltaTime * 100;
            Vector3 relativePos = _playerTransform.position - _enemyTransform.position;
            Quaternion targetRotation = Quaternion.LookRotation(relativePos, Vector3.up);
            rotation = Quaternion.RotateTowards(_enemyTransform.rotation, targetRotation, step);
        }

        return rotation;
    }
}
