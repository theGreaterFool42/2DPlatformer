using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Player;

    public Vector3 getPlayerPos()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        return Player.position;
    }
}