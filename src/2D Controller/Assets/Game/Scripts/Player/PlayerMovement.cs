using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using static PlayerCollision.CollisionDirection;

public class PlayerMovement : MonoBehaviour
{
    private PlayerCollision playerCollision;
    private Rigidbody2D rb;

    public float Speed;

    private void Awake()
    {
        TryGetComponent(out playerCollision);
        TryGetComponent(out rb);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Jump") && playerCollision.AnyColliding())
        {
            float dir = 0;
            if (playerCollision.IsColliding(Right))
                dir = -1;
            else if (playerCollision.IsColliding(Left))
                dir = 1;

            rb.velocity = new Vector2(20 * dir, playerCollision.IsColliding(Bottom) ? 20 : 15);
        }

        var x = Input.GetAxis("Horizontal");
        if (x != 0)
        {
            var dir = new Vector2(x * Speed, rb.velocity.y);
            rb.velocity = Vector2.Lerp(rb.velocity, dir, Time.deltaTime * Speed);
        }
    }
}
