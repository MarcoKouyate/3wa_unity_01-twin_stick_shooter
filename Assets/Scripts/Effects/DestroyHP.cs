using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHP : MonoBehaviour
{
    [SerializeField] HealthManager playerHP;
    [SerializeField] int hp;

    private void Update()
    {
        float damage = playerHP.maxHP - playerHP.currentHP;
        if(damage >= hp)
        {
            Destroy(gameObject);
        }
    }
}
