using System.Collections.Generic;
using UnityEngine;

namespace TwinStickShooter {
    public struct TrailTransform
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    public class SwordTrail : MonoBehaviour
    {
        [SerializeField] private Transform[] _trails;

        private Queue<TrailTransform> _trailTransforms;

        private void Awake()
        {
            _trailTransforms = new Queue<TrailTransform>();
            frames = 0;
        }

        public void Update()
        {
            Trail();
        }

        private void Trail()
        {
            TrailTransform current;
            current.position = transform.position;
            current.rotation = transform.rotation;
            _trailTransforms.Enqueue(current);

            int index = 0;

            while (_trailTransforms.Count > _trails.Length)
            {
                _trailTransforms.Dequeue();
                Debug.Log("Remove Queue");
            }

            foreach (TrailTransform trailTransform in _trailTransforms)
            {
                Transform trail = _trails[index];
                trail.rotation = trailTransform.rotation;
                trail.position = trailTransform.position;
                index++;
            }
        }

        private int frames;
    }
}
