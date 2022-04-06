using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class BulletCollision : MonoBehaviour
{
    #region Show In Inspector
    [SerializeField] private GameObject _impactPrefab;
    #endregion


    #region Unity Awake
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    #endregion


    #region Collisions
    private void OnTriggerEnter(Collider other)
    {
        SpawnImpact();
    }


    private void SpawnImpact()
    {
        if (!_impactPrefab) return;
        GameObject projectile = Instantiate(_impactPrefab, transform.position, transform.rotation);
        TwinStickShooter.ParticleMaterialSetter particleMaterialSetter = projectile.GetComponent<TwinStickShooter.ParticleMaterialSetter>();

        if (!particleMaterialSetter) return;
        particleMaterialSetter.SetMaterial(_meshRenderer.material);
    }
    #endregion


    #region Private Variables
    private MeshRenderer _meshRenderer;
    #endregion
}
