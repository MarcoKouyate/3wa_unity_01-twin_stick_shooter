using UnityEngine;

namespace TwinStickShooter
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private AttackerData attacker;

        public void Fire()
        {
            _weapon.Trigger(attacker);
        }
    }
}

