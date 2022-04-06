using UnityEngine;

namespace TwinStickShooter {
    public class WeaponSwitch : MonoBehaviour
    {
        [SerializeField] private WeaponHandler weaponHandler;
        [SerializeField] private Weapon[] weapons;

        public void Equip(WeaponType type)
        {
            Weapon weapon = GetWeaponOfType(type);
            
            if (!weapon) return;

            Equip(weapon);
        }

        private Weapon GetWeaponOfType(WeaponType type)
        {
            foreach (Weapon weapon in weapons)
            {
                if (weapon.Type == type) return weapon;
            }

            return null;
        }

        public void Equip(Weapon weapon)
        {
            DisableAllWeapons();
            weapon.gameObject.SetActive(true);
            weaponHandler.Equip(weapon);
        }

        private void DisableAllWeapons()
        {
            foreach (Weapon weapon in weapons)
            {
                weapon.gameObject.SetActive(false);
            }
        }
    }
}
