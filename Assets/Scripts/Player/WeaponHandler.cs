using UnityEngine;

namespace TwinStickShooter
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private AttackerData attacker;

        public void Fire()
        {
            _weapon.Trigger(attacker);
        }

        public void Equip(Weapon weapon)
        {
            _weapon = weapon;
        }
    }
}

