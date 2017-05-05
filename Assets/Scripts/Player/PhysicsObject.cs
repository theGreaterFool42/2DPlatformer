﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    public const float initialGravityModifier = 10f;
    protected float gravityModifier = initialGravityModifier;
    public float minGroundNormalY = 0.65f;


    protected Vector2 targetVelocity;
    protected bool isGrounded;
    protected Vector2 groundNormal;
    protected const float minMoveDistance = 0.001f;
    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitbuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected RaycastHit2D[] wjHitbuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> wjHitBufferList = new List<RaycastHit2D>(16);
    protected const float shellRadius = 0.01f;
    //protected float distance;

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
    }

    protected virtual void ComputeVelocity()
    {

    }

    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;

        isGrounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false, deltaPosition);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true, deltaPosition);
    }

    void Movement(Vector2 move, bool yMovement, Vector2 deltaPostion)
    {
        float distance = move.magnitude;

        //Check if something hits the physicsObject
        //For performance reasons we do it only if the object is moving
        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitbuffer, distance + shellRadius);
            hitBufferList.Clear();
            //If something hit the physicsObject we store it in hitBufferList
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitbuffer[i]);
            }
            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                //Check if the thing we collide with is ground
                if (currentNormal.y > minGroundNormalY)
                {
                    isGrounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }
                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                //Only update the new distance, if we won't be within the shellRadius after the update
                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }

            int wjCount = rb2d.Cast(deltaPostion, contactFilter, wjHitbuffer, distance + shellRadius);
            wjHitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                wjHitBufferList.Add(wjHitbuffer[i]);
            }
            for (int i = 0; i < hitBufferList.Count; i++)
            {
                isGrounded = true;
            }

        }
        rb2d.position = rb2d.position + move.normalized * distance;
    }
}
