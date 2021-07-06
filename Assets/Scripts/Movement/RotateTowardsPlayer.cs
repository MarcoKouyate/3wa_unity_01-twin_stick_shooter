using UnityEngine;

namespace TwinStickShooter {
    [RequireComponent(typeof(RotateTowardsTarget))]
    public class RotateTowardsPlayer : MonoBehaviour
    {
        private void Awake()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if(!player)
            {
                Debug.LogWarning("Couldn't find gameobject with Player tag in the scene");
                return;
            }

            RotateTowardsTarget rotationComponent = GetComponent<RotateTowardsTarget>();
            rotationComponent.SetTarget(player.transform);
        }
    }
}
