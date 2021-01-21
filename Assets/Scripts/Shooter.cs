using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnTransform;
    [SerializeField] private float bulletSpeed = 1f;
    [SerializeField] private float interval = 0f;
    [SerializeField] private float bulletLifetime = 1f;
    [SerializeField] private AudioData sfx;

    private float _nextShotTime;
    private AudioManager _audio;

    private void Awake()
    {
        _nextShotTime = Time.time;
        _audio = GetComponent<AudioManager>();
    }

    public void Fire()
    {
        if (Time.time >= _nextShotTime)
        {
             _nextShotTime = Time.time + interval;
             sendProjectile();
        }
    }

    private void sendProjectile()
    {
        GameObject bullet = GameObject.Instantiate(_bulletPrefab);
        bullet.transform.position = _bulletSpawnTransform.position;
        bullet.transform.rotation = _bulletSpawnTransform.rotation;
        bullet.GetComponent<Bullet>().speed = bulletSpeed;
        bullet.GetComponent<Bullet>().lifetime = bulletLifetime;

        if (sfx)
        {
            _audio.Play(sfx);
        } else
        {
            Debug.LogWarning("No sound effect has been assigned to this Game Object");
        }

    }
}
