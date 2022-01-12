using UnityEngine;

namespace TwinStickShooter {
    public class SwordExpansion : MonoBehaviour
    {
        [SerializeField]
        [Range(0f,1f)] private float _expansionspeed;

        [SerializeField]
        [Range(0f, 1f)] private float _decreasespeed;

        [SerializeField]
        [Range(0f, 1f)] private float _disablerate;

        [SerializeField]
        private GameObject _sword;

        private void Awake()
        {
            _targetScale = _sword.transform.localScale;
        }

        private void Update()
        {
            _sword.SetActive(_disablerate <= _expansion);
            _expansion = Mathf.Clamp01(_expansion);
            _sword.transform.localScale = Vector3.Lerp(Vector3.zero, _targetScale, _expansion);
        }

        public void Active(bool isActive)
        {
            _expansion += (isActive) ? _expansionspeed : -_decreasespeed;
        }

        private float _expansion = 0f;
        private Vector3 _targetScale;
    }
}
