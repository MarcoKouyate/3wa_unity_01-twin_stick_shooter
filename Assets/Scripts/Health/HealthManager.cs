using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float _maxHP = 0;
    [SerializeField] private float _currentHP;
    [SerializeField] private float _armorMultiplier = 1f;
    public float _invicibilityDuration = 0.5f;

    private AudioManager _audio;
    private List<IHealthObserver> _observers;
    private float _impactTime;

    private void Awake()
    {
        _currentHP = _maxHP;
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

        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        if(!IsInvicible())
        {
            _currentHP -= amount * _armorMultiplier;
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
        _currentHP += amount;
        if (_currentHP > _maxHP)
        {
            _currentHP = _maxHP;
        }
    }

    public bool isDead()
    {
        return _currentHP <= 0;
    }

    public float Ratio()
    {
        if(_maxHP != 0)
        {
            return _currentHP / _maxHP;
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
