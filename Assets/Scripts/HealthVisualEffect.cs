﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthVisualEffect : IHealthObserver 
{
    [SerializeField]
    private GameObject _deathEffect;

    [SerializeField]
    private AudioData _damageSFX;

    [SerializeField]
    private float _flashDuration;

    private HealthManager _health;
    private Material _material;
    private Color _originalColor;
    private AudioManager _audio;
    private bool _isDamaged;
    private float _impactTime;
    private float _ratio;

    private void Awake()
    {
        _health = GetComponent<HealthManager>();
        _material = GetComponent<MeshRenderer>().material;
        _originalColor = _material.color;
        _audio = AudioManager.getFrom(gameObject);
        _isDamaged = false;
    }

    private void Start()
    {
        _health.Subcribe(this);
    }


    public void Update()
    {
        if(_isDamaged)
        {
            DamageEffect();
        } else
        {
            HealthColor();
        }
    }

    public void DamageEffect()
    {
        float endTime = _impactTime + _flashDuration;

        if (Time.time < endTime)
        {
            _ratio =  (Time.time - _impactTime) / _flashDuration;
            _material.color = new Color(BrightOverTime(_originalColor.r), BrightOverTime(_originalColor.g), BrightOverTime(_originalColor.b));
        } else
        {
            _isDamaged = false;
        }
    }

    private float BrightOverTime(float color)
    {
        float residual = (1 - color);
        return color + (residual - (residual * _ratio));
    }

    public void HealthColor()
    {
        float brightness = _health.ratio();
        _material.color = new Color(_originalColor.r * brightness, _originalColor.g * brightness, _originalColor.b * brightness);
    }

    public override void OnDamage(float amount)
    {
        _audio.Play(_damageSFX);
        _isDamaged = true;
        _impactTime = Time.time;
    }


    public override void OnDeath()
    {
        GameObject.Instantiate(_deathEffect, transform.position, transform.rotation);
    }
}
