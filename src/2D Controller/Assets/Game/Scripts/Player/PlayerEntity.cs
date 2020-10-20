using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class PlayerEntity : Entity
{
    public UnityEvent onKilled;
    public int Lives;

    private void Awake() { }

    public void Test()
    {
        TakeDamage(10.0f);
    }

    public override void OnKilled()
    {
        Lives++;
    }
}
