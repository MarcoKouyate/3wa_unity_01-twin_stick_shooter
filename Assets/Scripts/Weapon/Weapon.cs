using UnityEngine;

namespace TwinStickShooter {
    public enum WeaponType { Custom, Basic, Double, Sword }

    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Shooter[] canons;
        [SerializeField] private Sword[] swords;
        [SerializeField] private WeaponType weaponType;

        public WeaponType Type { get => weaponType; }

        public void Trigger(AttackerData attacker)
        {
            foreach(Shooter canon in canons)
            {
                canon.Fire(attacker);
            }

            foreach (Sword sword in swords)
            {
                sword.Fire(attacker);
            }
        }
    }
}
