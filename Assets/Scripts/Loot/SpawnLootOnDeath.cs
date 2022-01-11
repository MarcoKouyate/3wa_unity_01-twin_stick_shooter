using UnityEngine;

namespace TwinStickShooter {
    [RequireComponent(typeof(LootSpawner))]
    public class SpawnLootOnDeath : MonoBehaviour
    {
        [SerializeField] private HealthManager _health;

        private void Awake()
        {
            _lootSpawner = GetComponent<LootSpawner>();
            _health.OnDeath += OnDeath;
        }

        private void OnDeath(object sender, System.EventArgs e)
        {
            _lootSpawner.Spawn();
        }

        private LootSpawner _lootSpawner;
    }
}
