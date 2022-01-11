using UnityEngine;

namespace TwinStickShooter {
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private GameObject particle;

        public void Trigger()
        {
            if (particle)
            {
                Instantiate(particle, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }
    }
}
