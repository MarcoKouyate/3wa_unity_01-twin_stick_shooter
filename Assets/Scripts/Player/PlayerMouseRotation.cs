using UnityEngine;


    public class PlayerMouseRotation : MonoBehaviour
    {
        private void Awake()
        {
            _transform = transform;
            _mainCamera = Camera.main;

            _plane = new Plane(Vector3.up, Vector3.zero);
        }


        private void Update()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (_plane.Raycast(ray, out float enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                hitPoint.y = _transform.position.y;

                Vector3 directionToHit = hitPoint - _transform.position;

                if (Mathf.Approximately(directionToHit.sqrMagnitude, 0))
                {
                    return;
                }

                Quaternion lookRotation = Quaternion.LookRotation(directionToHit);

                _transform.rotation = lookRotation;
            }
        }

        private Transform _transform;
        private Camera _mainCamera;
        private Plane _plane;
    }
