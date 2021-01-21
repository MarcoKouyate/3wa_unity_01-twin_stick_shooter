using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    IntVariable _enemyCount;

    private void Awake()
    {
        _enemyCount.value = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
