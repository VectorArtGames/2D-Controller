using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public interface IDamageable
{
    float Health { get; set; }

    void TakeDamage(float damage);

    void Instakill();

    void OnKill();
}
