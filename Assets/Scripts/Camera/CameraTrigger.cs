using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    CameraController CC;
    private GameManager _gameManager;
    public string endMarker;
    public string newState;
    // Use this for initialization
    void Start()
    {
        // CC = FindObjectOfType<CameraController>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log(endMarker);
    //    CC.timeSinceStart = 0;
    //    CC.startMarker = CC.endMarker;
    //    switch (endMarker)
    //    {
    //        case "Side":
    //            CC.endMarker = CC.CamPosOnSide;
    //            break;
    //        case "Behind":
    //            CC.endMarker = CC.CamPosBehind;
    //            break;
    //        case "Above":
    //            CC.endMarker = CC.CamPosAbove;
    //            break;
    //        default:
    //            CC.endMarker = CC.CamPosOnSide;
    //            break;
    //    }
    //    CC.ChangeCameraPosition(CC.startMarker, CC.endMarker);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerTriggerThing")
        {
            Debug.Log("TriggerThingie");
            switch (newState)
            {
                case "JumpnRun":
                    _gameManager.currentState = GameManager.GameState.JumpnRun;
                    break;
                case "BulletHellFromAbove":
                    _gameManager.currentState = GameManager.GameState.BulletHellFromAbove;
                    break;
                case "BulletHellFromSide":
                    _gameManager.currentState = GameManager.GameState.BulletHellFromSide;
                    break;
                default:
                    break;
            } 
        }
    }
}
