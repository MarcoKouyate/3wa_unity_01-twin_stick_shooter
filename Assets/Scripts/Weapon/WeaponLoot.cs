using UnityEngine;

namespace TwinStickShooter {
    public class WeaponLoot : MonoBehaviour
    {
        [SerializeField] private WeaponType weaponType;
        [SerializeField] private Weapon _weapon;

        public event System.EventHandler OnLoot;

        private void OnTriggerEnter(Collider other)
        {
            if (!(other.CompareTag("Player"))) return;
            Loot(other.gameObject);
        }

        private void Loot(GameObject other)
        {
            WeaponSwitch weaponSwitch = other.GetComponent<WeaponSwitch>();

            if (!weaponSwitch) return;

            EquipWeapon(weaponSwitch);

            OnLoot?.Invoke(this, System.EventArgs.Empty);
        }

        private void EquipWeapon(WeaponSwitch weaponSwitch)
        {
            if (weaponType == WeaponType.Custom)
            {
                if (!_weapon) return;
                Weapon weapon = Instantiate(_weapon, weaponSwitch.transform);
                weaponSwitch.Equip(weapon);
            }
            else
            {
                weaponSwitch.Equip(weaponType);
            }
        }
    }
}
