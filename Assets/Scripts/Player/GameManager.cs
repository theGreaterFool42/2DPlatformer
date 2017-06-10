using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Player;

    public enum GameState
    {
        JumpnRun,
        BulletHellFromAbove,
        BulletHellFromSide
    }

    public GameState currentState;

    public Vector3 getPlayerPos()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        return Player.position;
    }
}