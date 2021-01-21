using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProtection : MonoBehaviour
{
    [SerializeField]
    GameObject _shield;

    [SerializeField]
    IntVariable _enemyCount;

    private void Update()
    {
        if(_enemyCount.value <= 1)
        {
            Destroy(_shield);
        }
    }
}
