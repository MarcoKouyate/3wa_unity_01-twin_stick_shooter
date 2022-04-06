using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] IntVariable _enemyCount;

    private void OnDestroy()
    {
        _enemyCount.value--;
    }
}
