using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject _impactPrefab;

    private void OnTriggerEnter(Collider other)
    {
        bool notouch = other.gameObject.CompareTag("Player") && gameObject.CompareTag("Ally Bullet")  || 
                       other.gameObject.CompareTag("Enemy")  && gameObject.CompareTag("Enemy Bullet") ||
                       other.gameObject.CompareTag("Ally Bullet") && gameObject.CompareTag("Ally Bullet") ||
                       other.gameObject.CompareTag("Enemy Bullet") && gameObject.CompareTag("Enemy Bullet");

        if (!notouch)
        {
            GameObject.Instantiate(_impactPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
