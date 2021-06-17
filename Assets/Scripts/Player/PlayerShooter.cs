using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    GameObject _weapon;

    Shooter _shooter;

    private void Start()
    {
        _shooter = _weapon.GetComponent<Shooter>();
    }

    public void Fire()
    {
        _shooter.Fire();
    }
}
