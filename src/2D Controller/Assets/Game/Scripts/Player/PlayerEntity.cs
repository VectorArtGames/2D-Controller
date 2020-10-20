using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    public int Lives;

    public void Test()
    {
        TakeDamage(10.0f);
    }
}