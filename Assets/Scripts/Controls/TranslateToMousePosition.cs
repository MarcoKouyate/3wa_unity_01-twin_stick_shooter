using UnityEngine;

namespace TwinStickShooter {
    public class TranslateToMousePosition : MonoBehaviour
    {
        private void Awake()
        {
            _camera = Camera.main;
            _transform = transform;
            _plane = new Plane(Vector3.up, Vector3.zero);
        }

        private void Update()
        {
            Ray ray = _camera.ScreenPointToRay(InputController.Instance.TouchPosition);

            if (_plane.Raycast(ray, out float enter))
            {
                Debug.Log("Update from TranslateToMousePosition");
                _transform.position = ray.GetPoint(enter);
            }
            
        }

        private Camera _camera;
        private Plane _plane;
        private Transform _transform;
    }
}
