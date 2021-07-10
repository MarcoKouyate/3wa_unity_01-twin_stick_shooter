using UnityEngine;

namespace TwinStickShooter
{
    public class EnemyCombatIA : MonoBehaviour
    {
        [SerializeField] private WeaponHandler weaponHandler;

        private void Update()
        {
            weaponHandler.Fire();
        }
    }
}

