using UnityEngine;

public class NormalBulletScript : BulletInterface {

    private GameManager manager;
    private Vector3 shotDirection;
    public float speed = 5;

    void OnEnable()
    {
        manager = FindObjectOfType<GameManager>();
        Invoke("Destroy", 7f);
        shotDirection = manager.getPlayerPos() - transform.position;
    }

    void Update()
    {
        transform.position += shotDirection.normalized * Time.deltaTime * speed;
    }
}