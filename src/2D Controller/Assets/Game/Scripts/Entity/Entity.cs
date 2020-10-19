using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour, IEntity, IDamageable
{
    public float Health { get; set; }

    public void Instakill()
    {
        Health = -1;
    }

    public void OnKill()
    {

    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Damage Taken: 29");
    }
}
