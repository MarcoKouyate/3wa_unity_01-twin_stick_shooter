using UnityEngine;

namespace TwinStickShooter {
    public enum WeaponType { Basic, Double }

    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Shooter[] canons;
        [SerializeField] private WeaponType weaponType;

        public WeaponType Type { get => weaponType; }

        public void Trigger(AttackerData attacker)
        {
            foreach(Shooter canon in canons)
            {
                canon.Fire(attacker);
            }
        }
    }
}
