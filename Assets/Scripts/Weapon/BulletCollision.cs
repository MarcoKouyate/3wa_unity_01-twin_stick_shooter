using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject _impactPrefab;
    [SerializeField] private int _bounces;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        SpawnImpact();
        if(_bounces <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Destroy");
            return;
        }



        _bounces--;

        RaycastHit hit;

        if (Physics.Raycast(transform.position - transform.forward * 5f, transform.forward, out hit, 10f))
        {
            Vector3 reflectV = Vector3.Reflect(transform.forward, hit.normal);
            transform.LookAt(transform.position + reflectV);
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
