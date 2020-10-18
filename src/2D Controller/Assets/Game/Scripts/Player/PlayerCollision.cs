using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public LayerMask collisionMask;

    public float checkRadius = 0.25f;

    public bool CanMove;

    private void Awake()
    {
        TryGetComponent(out rb);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public bool IsColliding(CollisionDirection dir) =>
        Physics2D.OverlapCircleNonAlloc(rb.position + GetDirection(dir),
            checkRadius, new Collider2D[1], collisionMask) > 0;

    public bool AnyColliding()
    {
        return IsColliding(CollisionDirection.Bottom) ||
            IsColliding(CollisionDirection.Right) ||
            IsColliding(CollisionDirection.Left);
    }

    public Vector2 GetDirection(CollisionDirection dir)
    {
        if (!(spriteRenderer is SpriteRenderer r && r.bounds.extents is Vector3 e)) return Vector2.zero;

        switch (dir)
        {
            case CollisionDirection.Bottom: // In Use
                return new Vector2(0, -e.y);
            case CollisionDirection.Top:
                return new Vector2(0, e.y);
            case CollisionDirection.Right:
                return new Vector2(e.x, 0);
            case CollisionDirection.Left:
                return new Vector2(-e.x, 0);
        }

        return Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        if (rb == null || spriteRenderer == null)
        {
            return;
        }

        for (var i = 0; i < typeof(CollisionDirection).GetEnumNames().Length; i++)
        {
            Gizmos.color = Color.red;
            var dir = (CollisionDirection) i;
            var pos = rb.position + GetDirection(dir);
            Gizmos.DrawWireSphere(pos, checkRadius);
        }
    }

    public enum CollisionDirection
    {
        Right = 0,
        Left = 1,
        Top = 2,
        Bottom = 3
    }
}
