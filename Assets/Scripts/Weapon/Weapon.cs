using UnityEngine;

namespace TwinStickShooter {
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Shooter[] canons;

        public void Trigger(AttackerData attacker)
        {
            foreach(Shooter canon in canons)
            {
                canon.Fire(attacker);
            }
        }
    }
}
