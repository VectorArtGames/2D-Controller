using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public LayerMask GroundMask;
    public static SpawnPoint Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public SpriteRenderer spriteRenderer;

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (spriteRenderer == null) return;
        Gizmos.color = Color.green;

        var s = spriteRenderer.bounds;

        var rayLeft = Physics2D.Raycast(new Vector2(transform.position.x - (s.size.x / 2), transform.position.y - 0.1f), Vector2.down, Mathf.Infinity, GroundMask);
        var rayRight = Physics2D.Raycast(new Vector2(transform.position.x + (s.size.x / 2), transform.position.y - 0.1f), Vector2.down, Mathf.Infinity, GroundMask);

        var leftDist = Vector2.Distance(transform.position, rayLeft.point);
        var rightDist = Vector2.Distance(transform.position, rayRight.point);

        var choose = leftDist > rightDist ? rayRight : rayLeft;

        Gizmos.DrawWireCube(choose.transform != null ? new Vector2(transform.position.x, choose.point.y + (s.size.y / 2)) : (Vector2) transform.position, s.size);
    }

#endif
}