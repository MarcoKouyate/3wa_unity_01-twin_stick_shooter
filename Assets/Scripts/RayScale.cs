using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwinStickShooter {
    public class RayScale : MonoBehaviour
    {
        [SerializeField] float _maxRange;
        [SerializeField] bool _break = false;

        private void Update()
        {
            Scale();
        }

        private void Scale()
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            float scale = (Physics.Raycast(ray, out hit)) ? hit.distance : _maxRange;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Clamp(scale, 0, _maxRange));
            if (_break) Debug.Break();
        }
    }
}
