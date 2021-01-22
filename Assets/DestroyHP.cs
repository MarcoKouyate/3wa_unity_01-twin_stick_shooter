using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHP : MonoBehaviour
{
    [SerializeField] IntVariable playerHP;
    [SerializeField] int hp;

    private void Update()
    {
        if(playerHP.value <= hp)
        {
            Destroy(gameObject);
        }
    }
}
