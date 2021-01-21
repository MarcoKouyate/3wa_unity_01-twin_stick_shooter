using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField]
    private Shooter[] _shooters;


    private void Update()
    {
        foreach(Shooter shooter in _shooters)
        {
            shooter.Fire();
        }
    }
}
