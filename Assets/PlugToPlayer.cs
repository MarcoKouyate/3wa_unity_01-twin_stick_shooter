using UnityEngine;

namespace TwinStickShooter {
    public class PlugToPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerController _player;
        public bool paused;
        public bool stick;

        private void Update()
        {
            if (paused) return;

            _player.Move(InputController.Instance.MovementInput);
            _player.Rotate(GetRotation());

            if(InputController.Instance.OnAction) _player.Action();
        }

        public Quaternion GetRotation()
        {
            return stick? GetRotationFromStick() : GetRotationFromMouse();
        }

        public Quaternion GetRotationFromMouse()
        {
            Vector3 hitPoint = transform.position;
            hitPoint.y = _player.transform.position.y;

            Vector3 directionToHit = hitPoint - _player.transform.position;

            if (Mathf.Approximately(directionToHit.sqrMagnitude, 0))
            {
                return _player.transform.rotation;
            }

            Quaternion lookRotation = Quaternion.LookRotation(directionToHit);

            return lookRotation;
        }

        public Quaternion GetRotationFromStick()
        {
            Vector3 _rotationInput = new Vector3(Input.GetAxisRaw("OrientationHorizontal"), 0, Input.GetAxisRaw("OrientationVertical"));

            return (!Mathf.Approximately(_rotationInput.sqrMagnitude, 0)) ? Quaternion.LookRotation(_rotationInput) : _player.transform.rotation;
        }

    }
}
