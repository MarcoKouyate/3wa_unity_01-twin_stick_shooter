using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private HealthManager health;

    private void Awake()
    {
        health = GetComponent<HealthManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Shield"))
        {
            health.TakeDamage(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Explosion"))
        {
            health.TakeDamage(1);
        }
    }
}
