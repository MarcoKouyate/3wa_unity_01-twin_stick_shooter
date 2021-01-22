using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private float _maxHP = 0;

    [SerializeField]
    private float _currentHP;

    [SerializeField]
    private float _armorMultiplier = 1f;

    private AudioManager _audio;
    private List<IHealthObserver> observers;

    private void Awake()
    {
        _currentHP = _maxHP;
        observers = new List<IHealthObserver>();
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
        foreach (IHealthObserver observer in observers)
        {
            observer.OnDeath();
        }

        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        _currentHP -= amount * _armorMultiplier;


        foreach(IHealthObserver observer in observers)
        {
            observer.OnDamage(amount);
        }
    }

    public void heal(float amount)
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

    public float ratio()
    {
        if(_maxHP != 0)
        {
            return _currentHP / _maxHP;
        }

        return 0;
    }

    public void Subcribe(IHealthObserver observer)
    {
        if(!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void Unsubcribe(IHealthObserver observer)
    {
        while (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }
}
