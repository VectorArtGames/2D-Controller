using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float Speed;
    public Transform Target;
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Target.position.x, Target.position.y, transform.position.z), Time.deltaTime * Speed);
    }
}
