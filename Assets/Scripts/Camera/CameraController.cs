using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera playerCam;
    public Transform CamPosBehind;
    public Transform CamPosAbove;
    public Transform CamPosOnSide;
    public Transform Player;
    float speed = 10.0f;
    private float timeSinceStart;
    private float journeyLength;
    private Transform startMarker;
    private Transform endMarker;

    // Use this for initialization
    void Start()
    {
        playerCam = GetComponent<Camera>();
        startMarker = CamPosOnSide;
        endMarker = CamPosBehind;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Go Behind
            timeSinceStart = 0;
            startMarker = endMarker;
            endMarker = CamPosBehind;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Go Above
            timeSinceStart = 0;
            startMarker = endMarker;
            endMarker = CamPosAbove;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Go Side
            timeSinceStart = 0;
            startMarker = endMarker;
            endMarker = CamPosOnSide;
        }
        ChangeCameraPosition(startMarker, endMarker);
        playerCam.transform.LookAt(Player);
    }



    void ChangeCameraPosition(Transform startMarker, Transform endMarker)
    {
        timeSinceStart += Time.deltaTime;
        //Debug.Log(timeSinceStart);
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        float distCovered = (timeSinceStart) * speed;
        float fracJourney = distCovered / journeyLength;
        playerCam.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    }
}
