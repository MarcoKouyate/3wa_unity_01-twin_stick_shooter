using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class BulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject _impactPrefab;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool notouch = other.gameObject.CompareTag("Player") && gameObject.CompareTag("Ally Bullet")  || 
                       other.gameObject.CompareTag("Enemy")  && gameObject.CompareTag("Enemy Bullet") ||
                       other.gameObject.CompareTag("Ally Bullet") && gameObject.CompareTag("Ally Bullet") ||
                       other.gameObject.CompareTag("Enemy Bullet") && gameObject.CompareTag("Enemy Bullet");

        if (!notouch)
        {
            SpawnImpact();
            Destroy(gameObject);
        }
    }

    private void SpawnImpact()
    {
        GameObject projectile = Instantiate(_impactPrefab, transform.position, transform.rotation);
        TwinStickShooter.ParticleMaterialSetter particleMaterialSetter = projectile.GetComponent<TwinStickShooter.ParticleMaterialSetter>();

        if (!particleMaterialSetter) return;
        particleMaterialSetter.SetMaterial(_meshRenderer.material);
    }

    private MeshRenderer _meshRenderer; 
}
