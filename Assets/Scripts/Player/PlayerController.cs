using UnityEngine;

namespace TwinStickShooter {
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private WeaponHandler _playerShooter;

        public void Move(Vector2 direction)
        {
            _playerMovement.Move(direction);
        }

        public void Rotate(Quaternion rotation)
        {
            _playerMovement.Rotate(rotation);
        }

        public void Action()
        {
            _playerShooter.Fire();
        }


    }
}
