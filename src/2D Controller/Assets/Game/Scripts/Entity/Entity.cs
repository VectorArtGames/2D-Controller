﻿using UnityEngine;

public class Entity : MonoBehaviour, IEntity, IDamageable
{
    private float _health;

    public float Health
    {
        get => _health;
        set
        {
            if (_health - value > 0)
            {
                OnKill();
                return;
            }

            _health = value;
            Debug.Log($"Damage taken {value}\nHP Remaining: {_health}");
        }
    }

    private bool _isDead;
    public bool IsDead
    {
        get => _isDead;
        set
        {
            _isDead = value;

        }
    }

    public void Instakill()
    {
        Health = -1;
    }

    public void OnKill()
    {
        IsDead = true;
        OnKilled();
    }

    public virtual void OnKilled() { }

    public void TakeDamage(float damage)
    {
        Debug.Log("Damage Taken: 29");
    }
}