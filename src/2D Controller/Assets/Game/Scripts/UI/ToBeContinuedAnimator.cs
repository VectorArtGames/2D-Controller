using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ToBeContinuedAnimator : MonoBehaviour
{
    public GameObject TobeContinuedObj;
    private Animator _animation;

    private void Awake()
    {
        if (TobeContinuedObj == null) return;

        TobeContinuedObj.TryGetComponent(out _animation);
    }

    public void PlayAnimation()
    {
        _animation.SetBool("ShouldTrigger", true);
    }
}
