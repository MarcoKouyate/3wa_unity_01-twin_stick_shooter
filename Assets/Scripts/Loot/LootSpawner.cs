using UnityEngine;

namespace TwinStickShooter {
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private LootStruct[] _loots;

        public void Spawn()
        {
            foreach(LootStruct loot in _loots)
            {
                float roll = Random.Range(0f, 1f);
                if (roll > loot.spawnrate) continue;
                Debug.Log($"Roll: {roll} ({loot.prefab.name},{loot.spawnrate})");
                Instantiate(loot.prefab, transform.position, Quaternion.identity);
                break;
            }
        }
    }
}
