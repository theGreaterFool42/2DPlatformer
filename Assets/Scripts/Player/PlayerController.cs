using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float jumpHeight;
    private bool running;

    Rigidbody rb;



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Velocity: " + rb.velocity);
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        if(Input.GetButton("SpeedUp"))
        {
            running = true;
            rb.velocity = new Vector3(move * runSpeed, rb.velocity.y, 0);
        }
        else
        {
            running = false;
            rb.velocity = new Vector3(move * walkSpeed, rb.velocity.y, 0); 
        }
    }
}
