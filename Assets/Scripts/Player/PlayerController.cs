using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float jumpHeight;
    public float flyingSpeed;
    private bool running;
    private GameManager _gameManager;
    private float horizontal;
    private float vertical;

    Rigidbody rb;



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Velocity: " + rb.velocity);
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        switch (_gameManager.currentState)
        {
            case GameManager.GameState.JumpnRun:
                walkSpeed = 10;
                runSpeed = 20;
                jumpHeight = 5;
                if (Input.GetButton("SpeedUp"))
                {
                    running = true;
                    rb.velocity = new Vector3(moveHorizontal * runSpeed, rb.velocity.y, 0);
                }
                else
                {
                    running = false;
                    rb.velocity = new Vector3(moveHorizontal * walkSpeed, rb.velocity.y, 0);
                }
                break;
            case GameManager.GameState.BulletHellFromAbove:
                walkSpeed = 20;
                runSpeed = 30;
                jumpHeight = 5;
                rb.useGravity = false;
                if (Input.GetButton("SpeedUp"))
                {
                    running = true;
                    rb.velocity = new Vector3(flyingSpeed, moveVertical * runSpeed, -moveHorizontal * runSpeed);
                }
                else
                {
                    running = false;
                    rb.velocity = new Vector3(flyingSpeed, moveVertical * walkSpeed, -moveHorizontal * walkSpeed);
                }
                break;
            case GameManager.GameState.BulletHellFromSide:
                break;
            default:
                break;
        }
    }
}
