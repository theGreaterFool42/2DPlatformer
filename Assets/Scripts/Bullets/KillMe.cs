using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMe : MonoBehaviour
{
    public float TimeToLive = 5f;

    // Use this for initialization
    void Start()
    {
        Destroy(this, TimeToLive);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
