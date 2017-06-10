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
    public float timeSinceStart;
    public float journeyLength;
    public Transform startMarker;
    public Transform endMarker;
    public GameObject KolibriJump;
    public GameObject KolibriFly;
    public GameManager _gameManager;
    private GameManager.GameState lastState;


    // Use this for initialization
    void Start()
    {
        playerCam = GetComponent<Camera>();
        startMarker = CamPosAbove;
        endMarker = CamPosOnSide;
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        lastState = _gameManager.currentState;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //Go Behind
                _gameManager.currentState = GameManager.GameState.BulletHellFromSide;
                //timeSinceStart = 0;
                //startMarker = endMarker;
                //endMarker = CamPosBehind;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //Go Above
                _gameManager.currentState = GameManager.GameState.BulletHellFromAbove;
                //timeSinceStart = 0;
                //startMarker = endMarker;
                //endMarker = CamPosAbove;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                //Go Side
                _gameManager.currentState = GameManager.GameState.JumpnRun;
                //timeSinceStart = 0;
                //startMarker = endMarker;
                //endMarker = CamPosOnSide;
            } 
        }
        //This is the new and better one
        //Change to this one when the tranformation to the new system is finished
        if ((timeSinceStart > 3f) && (lastState !=_gameManager.currentState))
        {
            switch (_gameManager.currentState)
            {
                case GameManager.GameState.JumpnRun:
                    timeSinceStart = 0;
                    startMarker = endMarker;
                    endMarker = CamPosOnSide;
                    //Replace this with Animation
                    KolibriJump.SetActive(true);
                    KolibriFly.SetActive(false);
                    break;
                case GameManager.GameState.BulletHellFromAbove:
                    timeSinceStart = 0;
                    startMarker = endMarker;
                    endMarker = CamPosAbove;
                    //Replace this with Animation
                    KolibriFly.SetActive(true);
                    KolibriJump.SetActive(false);
                    break;
                case GameManager.GameState.BulletHellFromSide:
                    //Here are still the old CameraFromBehind values. CHANGE THIS!
                    timeSinceStart = 0;
                    startMarker = endMarker;
                    endMarker = CamPosBehind;
                    //Replace this with Animation
                    KolibriJump.SetActive(true);
                    KolibriFly.SetActive(false);
                    break;
                default:
                    break;
            }
            lastState = _gameManager.currentState;
        }


        ChangeCameraPosition(startMarker, endMarker);
        playerCam.transform.LookAt(Player);
        

        switch (endMarker.ToString())
        {
            case "CamPosBehind (UnityEngine.Transform)":
                break;
            case "CamPosAbove (UnityEngine.Transform)":
                //Replace this with Animation
                KolibriFly.SetActive(true);
                KolibriJump.SetActive(false);
                break;
            case "CamPosOnSide (UnityEngine.Transform)":
                //Replace this with Animation
                KolibriJump.SetActive(true);
                KolibriFly.SetActive(false);
                break;
            default:
                break;
        }
        //print(endMarker.ToString());
    }



    public void ChangeCameraPosition(Transform startMarker, Transform endMarker)
    {
        timeSinceStart += Time.deltaTime;
        //Debug.Log(timeSinceStart);
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        float distCovered = (timeSinceStart) * speed;
        float fracJourney = distCovered / journeyLength;
        playerCam.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    }
}
