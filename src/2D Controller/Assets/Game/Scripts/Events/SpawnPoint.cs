using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static SpawnPoint Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public SpriteRenderer spriteRenderer;

    private void OnDrawGizmosSelected()
    {
        if (spriteRenderer == null) return;
        var s = spriteRenderer.bounds;
        Gizmos.DrawWireCube(transform.position, s.size);
    }
}
