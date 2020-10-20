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

            gameObject.SetActive(value);
        }
    }

    public void Instakill()
    {
        Health = -1;
    }

    public void OnKill()
    {
        IsDead = true;
        OnKilled?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Damage Taken: 29");
    }
}