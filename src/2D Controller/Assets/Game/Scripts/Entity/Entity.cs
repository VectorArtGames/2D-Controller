using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour, IEntity, IDamageable
{
    public UnityEvent OnKilled;

    private float _health;

    public float Health
    {
        get => _health;
        set
        {
            if (value > 0)
            {
                OnKill();
                return;
            }

            _health = value;
        }
    }

    public void Instakill()
    {
        Health = -1;
    }

    public void OnKill()
    {
        OnKilled?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Damage Taken: 29");
    }
}
