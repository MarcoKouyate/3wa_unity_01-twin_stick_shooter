using UnityEngine;

namespace TwinStickShooter {
    public class WeaponLoot : MonoBehaviour
    {
        [SerializeField] private WeaponType weaponType;

        private void OnTriggerEnter(Collider other)
        {
            if (!(other.CompareTag("Player"))) return;

            WeaponSwitch weaponSwitch = other.GetComponent<WeaponSwitch>();

            if (!weaponSwitch) return;

            weaponSwitch.Switch(weaponType);
        }
    }
}
