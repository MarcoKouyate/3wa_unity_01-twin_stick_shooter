using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        bool notouch = other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy");

        if (!notouch)
        {
            Destroy(gameObject);
        }
    }
}
