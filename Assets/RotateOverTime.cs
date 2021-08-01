using UnityEngine;

namespace Game {
    public class RotateOverTime : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Awake()
        {
            
        }

        private void Update()
        {
            Vector3 rotation = new Vector3(0, speed * Time.deltaTime, 0);
            transform.Rotate(rotation);
        }
    }
}
