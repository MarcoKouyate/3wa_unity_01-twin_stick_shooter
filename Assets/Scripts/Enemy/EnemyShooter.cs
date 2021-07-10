using UnityEngine;

namespace TwinStickShooter
{
    public class EnemyShooter : MonoBehaviour
    {
        [SerializeField] private Shooter[] _shooters;
        [SerializeField] private AttackerData attacker;

        private void Update()
        {
            foreach (Shooter shooter in _shooters)
            {
                shooter.Fire(attacker);
            }
        }
    }
}

