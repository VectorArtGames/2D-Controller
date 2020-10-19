using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    public float Damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!(other.gameObject.TryGetComponent(out PlayerEntity player))) return;

        player.TakeDamage(100);
    }

}
