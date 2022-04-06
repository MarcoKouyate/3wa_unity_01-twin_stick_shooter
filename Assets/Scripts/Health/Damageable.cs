using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwinStickShooter {

    [RequireComponent(typeof(HealthManager))]
    public class Damageable : MonoBehaviour
    {
        HealthManager health;

        private void Awake()
        {
            health = GetComponent<HealthManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            
            if (!(other.gameObject.CompareTag("Bullet"))) return;
            Bullet bullet = other.GetComponent<Bullet>();

            if (!bullet) return;
            health.TakeDamage(bullet.Damage);

            
        }
    }
}
