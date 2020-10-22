using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class FinishTrigger : MonoBehaviour
{
    public UnityEvent OnFinishAnimation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.gameObject.GetComponentInParent<PlayerEntity>() is PlayerEntity player)) return;
        OnFinishAnimation?.Invoke();
        player.TryGetComponent(out Rigidbody2D rb);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!(other.gameObject.GetComponentInParent<PlayerEntity>() is PlayerEntity player)) return;
        OnFinishAnimation?.Invoke();
        player.TryGetComponent(out Rigidbody2D rb);
        player.gameObject.SetActive(false);
    }
}
