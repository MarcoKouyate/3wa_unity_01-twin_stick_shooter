using UnityEngine;

namespace TwinStickShooter {
    public class ExplodeOnLoot : MonoBehaviour
    {
        [SerializeField] private WeaponLoot _weaponLoot;
        [SerializeField] private Explosion _explosion;

        private void Awake()
        {
            _weaponLoot.OnLoot += OnLoot;
        }

        private void OnLoot(object sender, System.EventArgs e)
        {
            _explosion.Trigger();
        }
    }
}
