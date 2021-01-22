using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] IntVariable _enemyCount;

    HealthManager health;

    private void Awake()
    {
        health = GetComponent<HealthManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ally Bullet"))
        {
            Destroy(other.gameObject);
            health.TakeDamage(1);
        }
    }

    private void OnDestroy()
    {
        _enemyCount.value--;
    }
}
