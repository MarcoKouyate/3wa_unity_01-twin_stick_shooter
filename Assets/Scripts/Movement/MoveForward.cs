using UnityEngine;

namespace TwinStickShooter {
    [RequireComponent(typeof(Rigidbody))]
    public class MoveForward : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = transform;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rigidbody.velocity = _transform.forward * _speed * Time.fixedDeltaTime;
            Vector3 newPosition = _transform.position + _rigidbody.velocity;
            _rigidbody.MovePosition(newPosition);
        }

        public void ChangeSpeed(float value)
        {
            _speed = value;
        }

        private Rigidbody _rigidbody;
        private Transform _transform;
    }
}
