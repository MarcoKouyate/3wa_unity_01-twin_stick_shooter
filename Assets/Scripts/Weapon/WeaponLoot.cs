using UnityEngine;

namespace TwinStickShooter {
    public class WeaponLoot : MonoBehaviour
    {
        [SerializeField] private WeaponType weaponType;

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

            weaponSwitch.Switch(weaponType);
            OnLoot?.Invoke(this, System.EventArgs.Empty);
        }
    }
}
