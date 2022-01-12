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
            _expansion += (InputController.Instance.OnAction) ? _expansionspeed : -_decreasespeed;
            _expansion = Mathf.Clamp01(_expansion);
            _sword.transform.localScale = Vector3.Lerp(Vector3.zero, _targetScale, _expansion);
        }

        private float _expansion = 0f;
        private Vector3 _targetScale;
    }
}
