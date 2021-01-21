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
    private float armorMultiplier = 1f;


    private void Awake()
    {
        _currentHP = _maxHP;

    }

    private void Update()
    {
        Survive();
    }

    public void Survive()
    {
        if(isDead())
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        _currentHP -= amount * armorMultiplier;
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
}
