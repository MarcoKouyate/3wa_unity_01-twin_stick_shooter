using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IHealthObserver : MonoBehaviour
{
    virtual public void OnDamage(float amount) { }
    virtual public void OnDeath() {}
}
