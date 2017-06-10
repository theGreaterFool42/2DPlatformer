using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollisionEffect : MonoBehaviour
{
    public ParticleSystem FancyLight;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FancyLight.gameObject.SetActive(true);
        }
        else
        {
            FancyLight.gameObject.SetActive(false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        FancyLight.gameObject.SetActive(false);
    }
}
