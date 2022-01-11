using UnityEngine;

namespace TwinStickShooter {

    [System.Serializable]
    public struct LootStruct 
    {
        public GameObject prefab;
        
        [Range(0f,1f)]
        public float spawnrate;
    }
}
