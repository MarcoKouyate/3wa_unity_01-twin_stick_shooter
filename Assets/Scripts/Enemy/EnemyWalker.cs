using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyWalker : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private float _moveSpeed = 1f;

    private void Awake()
    {
        _enemyTransform = transform;
        _rigidbody = GetComponent<Rigidbody>();

        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (_playerTransform == null)
        {
            Debug.LogWarning("Enemy Walker component can't find any gameObject with Player tag");
        }
    }

    private void FixedUpdate()
    {
        TurnTowardsPlayer();
        MoveForward();
    }

    private void MoveForward()
    {
        _rigidbody.velocity = _enemyTransform.forward * _moveSpeed;
    }

    private void TurnTowardsPlayer()
    {
        if (_playerTransform == null)
        {
            return;
        }

        float step = _rotationSpeed * Time.deltaTime * 100;
        Vector3 directionToPlayer = (_playerTransform.position - _enemyTransform.position).normalized;
        Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer, Vector3.up);
        Quaternion rotation = Quaternion.RotateTowards(_enemyTransform.rotation, rotationToPlayer, step);
        _rigidbody.MoveRotation(rotation);
    }


    private Transform _playerTransform;
    private Transform _enemyTransform;
    private Rigidbody _rigidbody;
}
