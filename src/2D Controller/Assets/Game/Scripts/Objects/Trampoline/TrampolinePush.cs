using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TrampolinePush : MonoBehaviour
{
    public float PushForce;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!(other.gameObject.GetComponentInParent<PlayerEntity>() is PlayerEntity player)) return;
        if (!player.TryGetComponent(out Rigidbody2D rb)) return;
        rb.velocity = new Vector2(rb.velocity.x, PushForce);
    }
}
