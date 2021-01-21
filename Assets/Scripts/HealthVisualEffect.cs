using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthVisualEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject _deathEffect;

    private HealthManager health;
    private Material material;
    private Color originalColor;

    private float brightness;
    private AudioManager _audio;

    private void Awake()
    {
        health = GetComponent<HealthManager>();
        material = GetComponent<MeshRenderer>().material;
        originalColor = material.color;
        _audio = GetComponent<AudioManager>();
    }

    private void Update()
    {
        brightness = health.ratio();
        material.color = new Color(originalColor.r * brightness, originalColor.g * brightness, originalColor.b * brightness);

        if(health.isDead())
        {
            deathEffect();
        }
    }

    private void deathEffect()
    {
        GameObject.Instantiate(_deathEffect, transform.position, transform.rotation);
    }
}
