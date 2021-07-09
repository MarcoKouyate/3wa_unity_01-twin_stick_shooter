using UnityEngine;

namespace TwinStickShooter {
    [RequireComponent(typeof(Rigidbody))]
    public class RotateTowardsTarget : MonoBehaviour
    {
        #region Show In Inspector
        [SerializeField] private float _rotationSpeed = 1f;
        [SerializeField] private Transform _target;

        [Header("Constraint Axis")]
        [SerializeField] private bool constraintX;
        [SerializeField] private bool constraintY;
        [SerializeField] private bool constraintZ;
        #endregion


        #region Public Methods
        public void SetTarget(Transform target)
        {
            _target = target;
        }
        #endregion

        
        #region Awake
        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }
        #endregion


        #region Fixed Update
        private void FixedUpdate()
        {
            Rotate();
        }

        private void Rotate()
        {
            if (!_target)
            {
                return;
            }

            float step = _rotationSpeed * Time.deltaTime * 100;
            Vector3 directionToPlayer = (_target.position - _transform.position).normalized;
            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer, Vector3.up);
            Quaternion rotation = Quaternion.RotateTowards(_transform.rotation, rotationToPlayer, step);
            _rigidbody.MoveRotation(rotation);
            _transform.rotation = rotation;
            Constraint(constraintX, constraintY, constraintZ);
        }

        #endregion

        private void Constraint(bool X, bool Y, bool Z)
        {
            _transform.rotation = Quaternion.Euler(
                GetAxis(_transform.rotation.eulerAngles.x, X),
                GetAxis(_transform.rotation.eulerAngles.y, Y),
                GetAxis(_transform.rotation.eulerAngles.z, Z)
            );
        }

        private float GetAxis(float angle, bool hasConstraint)
        {
            return hasConstraint ? 0 : angle;
        }

        #region Private Variables
        private Transform _transform;
        private Rigidbody _rigidbody;
        #endregion
    }
}
