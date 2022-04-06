using UnityEngine;

namespace TwinStickShooter
{
    public class Rebound : MonoBehaviour
    {
        [SerializeField] private int _bounces;

        private void OnTriggerEnter(Collider other)
        {
            if (_bounces <= 0)
            {
                Destroy(gameObject);
                return;
            }

            _bounces--;
            Redirect();
        }

        private void Redirect()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position - transform.forward * 5f, transform.forward, out hit, 10f))
            {
                Vector3 reflectV = Vector3.Reflect(transform.forward, hit.normal);
                transform.LookAt(transform.position + reflectV);
            }
        }

        public void SetBounce(int bounces)
        {
            _bounces = bounces;
        }
    }
}
