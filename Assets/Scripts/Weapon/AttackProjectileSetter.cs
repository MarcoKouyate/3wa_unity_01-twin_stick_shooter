using UnityEngine;

namespace TwinStickShooter {
    [RequireComponent(typeof(MeshRenderer))]
    public class AttackProjectileSetter : MonoBehaviour
    {

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            
        }

        public void SetAttacker(AttackerData attackerData)
        {
            _meshRenderer.material = attackerData.material;
            gameObject.layer = LayerMask.NameToLayer(attackerData.layerName);
        }

        private MeshRenderer _meshRenderer;
    }
}
