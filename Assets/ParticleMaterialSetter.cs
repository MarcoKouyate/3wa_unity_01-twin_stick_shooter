using UnityEngine;

namespace TwinStickShooter {
    [RequireComponent(typeof(ParticleSystemRenderer))]
    public class ParticleMaterialSetter : MonoBehaviour
    {
        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystemRenderer>();
        }

        public void SetMaterial(Material material)
        {
            _particleSystem.material = material;
        }

        private ParticleSystemRenderer _particleSystem;
    }
}
