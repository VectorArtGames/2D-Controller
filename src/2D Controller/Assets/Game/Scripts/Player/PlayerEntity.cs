using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class PlayerEntity : Entity
{
    [Header("Configuration"), Space(2f)]
    public int Lives;

    [Header("Events"), Space(5f)]
    public UnityEvent onKilled;

    private void Awake() { }

    public void Test()
    {
        TakeDamage(10.0f);
    }

    public override void OnKilled()
    {
        Lives--;
        onKilled?.Invoke();
    }
}
