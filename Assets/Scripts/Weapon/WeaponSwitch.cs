using UnityEngine;

namespace TwinStickShooter {
    public class WeaponSwitch : MonoBehaviour
    {
        [SerializeField] private WeaponHandler weaponHandler;
        [SerializeField] private Weapon[] weapons;

        public void Switch(WeaponType type)
        {
            Weapon weapon = GetWeaponOfType(type);
            
            if (!weapon) return;

            DisableAllWeapons();
            Equip(weapon);
        }

        private void DisableAllWeapons()
        {
            foreach (Weapon weapon in weapons)
            {
                weapon.gameObject.SetActive(false);
            }
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
            weapon.gameObject.SetActive(true);
            weaponHandler.Equip(weapon);
            Debug.Log(weapon);
        }
    }
}
