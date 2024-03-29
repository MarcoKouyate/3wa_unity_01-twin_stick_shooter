﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float _armorMultiplier = 1f;
    [SerializeField] private float _hp = 1f;
    
    public float maxHP { get; private set; }
    public float currentHP { get; set; }

    public float _invicibilityDuration = 0.5f;

    private List<IHealthObserver> _observers;
    private float _impactTime;


    public event System.EventHandler OnDeath;

    private void Awake()
    {
        maxHP = _hp;
        currentHP = maxHP;
        _observers = new List<IHealthObserver>();
        _impactTime = 0f;
    }

    private void LateUpdate()
    {
        Survive();
    }

    public void Survive()
    {
        if(isDead())
        {
            Die();
        }
    }

    public void Die()
    {
        foreach (IHealthObserver observer in _observers)
        {
            observer.OnDeath();
        }

        OnDeath?.Invoke(this, System.EventArgs.Empty);

        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        if(!IsInvicible())
        {
            currentHP -= amount * _armorMultiplier;
            _impactTime = Time.time;

            foreach (IHealthObserver observer in _observers)
            {
                observer.OnDamage(amount);
            }
        }
    }

    public bool IsInvicible()
    {
        return (Time.time < _impactTime + _invicibilityDuration);
    }

    public void Heal(float amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public bool isDead()
    {
        return currentHP <= 0;
    }

    public float Ratio()
    {
        if(maxHP != 0)
        {
            return currentHP / maxHP;
        }

        return 0;
    }

    public void Subcribe(IHealthObserver observer)
    {
        if(!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void Unsubcribe(IHealthObserver observer)
    {
        while (_observers.Contains(observer))
        {
            _observers.Remove(observer);
        }
    }
}
