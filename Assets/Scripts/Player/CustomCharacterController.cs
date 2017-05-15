using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterController : PhysicsObject
{
    public float minSpeed = 25f;
    public float maxSpeed = 35f;
    public float timeToMaxSpeed = 1f;
    public float jumpHeight = 35f;
    public float extraGravity = 3f;
    private float speed;
    private float accelerationRatePerSec;

    // Use this for initialization
    void Start()
    {
        speed = minSpeed;
        accelerationRatePerSec = maxSpeed / timeToMaxSpeed;
    }

    // Update is called once per frame
    protected override void ComputeVelocity()
    {
        Vector2 moveDirection = Vector2.zero;

        moveDirection.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpHeight;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
                velocity.y = velocity.y * 0.5f;
        }
        if (Input.GetButton("SpeedUp"))
        {
            speed += accelerationRatePerSec * Time.deltaTime;
            speed = Mathf.Min(speed, maxSpeed);
        }
        else if (!Input.GetButton("SpeedUp"))
        {
            speed -= accelerationRatePerSec * Time.deltaTime;
            speed = Mathf.Max(speed, minSpeed);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            gravityModifier = initialGravityModifier * extraGravity;
        }
        else if (Input.GetAxis("Vertical") > -0.1)
        {
            gravityModifier = initialGravityModifier;
        }

        targetVelocity = moveDirection * speed;
        //Debug.Log("");
    }
}
