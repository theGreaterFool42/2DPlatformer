using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("You hit it");
        }
    }
}
