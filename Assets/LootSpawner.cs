using UnityEngine;

namespace TwinStickShooter {
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _lootPrefab;
        public void Spawn()
        {
            Instantiate(_lootPrefab, transform.position, Quaternion.identity);
        }
    }
}
