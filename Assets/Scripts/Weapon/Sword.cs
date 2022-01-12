using UnityEngine;

namespace TwinStickShooter {
    public class Sword : MonoBehaviour, Weaponable
    {
        [SerializeField] private SwordExpansion _expansion;


        public void Update()
        {
            _expansion.Active(isActive);
            isActive = false;
        }

        public void Fire(AttackerData attacker)
        {
            isActive = true;
        }

        private bool isActive;
    }
}
